using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Rendering.Universal;

public class BulletBehavior : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private BoxCollider2D boxCollider;
    public float damage;
    private float time;
    private Collider2D enemyCollided;

    private bool charged = false;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    private void Start()
    {
        damage = damage * (1 + (JSONSaving.SharedInstance.playerData.damage * 0.25f));
        if (CompareTag("chargedArrow"))
        {
            charged = true;
            damage *= 5;
            Debug.Log(damage);
            StartCoroutine(DeactivateChargedArrow(10f));
        } else {
            StartCoroutine(DeactivateArrowCooldown(3f));
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (!gameObject.activeInHierarchy) return;

        if (collider.tag.Contains("Drop") || collider.tag.Contains("iceCollider"))
        {
            return;
        }

        if (collider.tag.Contains("SceneCollider") || collider.CompareTag("EnemySpike") || collider.CompareTag("EnemyRock") || collider.CompareTag("EnemyRockHuge"))
        {
            if (!charged)
            {
                StartCoroutine(DeactivateArrow(0.5f));
            }
            return;
        }

        if (collider.tag.Contains("Enemy"))
        {
            GameObject.Find("CollisionSound").GetComponent<AudioSource>().Play();

            var enemy = collider.GetComponent<Enemy>();
            enemy.HP -= (damage);
            enemyCollided = collider;

            if (enemy.HP <= 0)
            {
                var drop = collider.GetComponent<DropOnDestroy>();
                drop.Drop();
                enemy.HP = enemy.initialHP;
                time = Clock.SharedInstance.time;

                if (collider.CompareTag("GolemiceEnemy"))
                {
                    collider.GetComponent<SpriteRenderer>().enabled = false;
                    collider.GetComponent<BoxCollider2D>().enabled = false;
                    Instantiate(Resources.Load<GameObject>("pufParticles"), collider.transform.position, Quaternion.identity);

                    // Desactivamos la generación de particulas de hielo
                    ParticleSystem iceParticles = enemyCollided.GetComponent<ParticleSystem>();
                    ParticleSystem.EmissionModule emissionModule = iceParticles.emission;
                    emissionModule.enabled = false;
                    IceGolem iceGolemScript = enemyCollided.gameObject.GetComponent<IceGolem>();
                    StartCoroutine(iceGolemScript.DeactivateAllIceColliders());
                }
                else
                {
                    Instantiate(Resources.Load<GameObject>("pufParticles"), collider.transform.position, Quaternion.identity);
                    collider.gameObject.SetActive(false);

                }

                if (collider.CompareTag("SlimeEnemy"))
                {
                    if (time < 180)
                    {
                        Spawner.SharedInstance.creditGain(3);
                    }
                    else
                    {
                        Spawner.SharedInstance.creditGain(5);
                    }
                }
                else
                {
                    if (time < 180)
                    {
                        Spawner.SharedInstance.creditGain(8);
                    }
                    else
                    {
                        Spawner.SharedInstance.creditGain(10);
                    }
                }
            }

            CameraShake.instance.StartShake(.2f, .1f);
            if (!charged)
            {
                StartCoroutine(DeactivateArrow(0.5f));
            }
        }
    }

    private IEnumerator DeactivateChargedArrow(float delay)
    {
        yield return new WaitForSeconds(delay);
        if (gameObject.activeInHierarchy)
        {
            gameObject.SetActive(false);
        }
    }

    private IEnumerator DeactivateArrow(float delay)
    {
        spriteRenderer.enabled = false;
        boxCollider.enabled = false;
        yield return new WaitForSeconds(delay);

        if (gameObject.activeInHierarchy)
        {
            gameObject.SetActive(false);
        }

        spriteRenderer.enabled = true;
        boxCollider.enabled = true;
    }

    private IEnumerator DeactivateArrowCooldown(float delay)
    {
        yield return new WaitForSeconds(delay);
        StartCoroutine(DeactivateArrow(0.5f));
    }
}
