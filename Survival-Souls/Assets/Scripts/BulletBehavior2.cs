using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Rendering.Universal;

public class BulletBehavior2 : MonoBehaviour
{
    private float timer;
    private SpriteRenderer spriteRenderer;
    private BoxCollider2D boxCollider;
    public float damage;
    private Collider2D enemyCollided;
    private Coroutine deactivateArrowCoroutine;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        boxCollider = GetComponent<BoxCollider2D>();
    }
    private void Start()
    {
        damage = 2;
        damage = damage * (1 + (JSONSaving.SharedInstance.playerData.damage * 0.25f));
        //deathParticle = GameObject.Find("pufParticles").GetComponent<ParticleSystem>();
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (!gameObject.activeInHierarchy) return;

        if (collider.CompareTag("Drop") || collider.CompareTag("EnemySpike") || collider.CompareTag("EnemyRock"))
        {
            return;
        }

        if (collider.tag.Contains("Enemy"))
        {
            var enemy = collider.GetComponent<Enemy>();
            enemy.HP -= (damage);
            enemyCollided = collider;

            if (enemy.HP <= 0)
            {
                var drop = collider.GetComponent<DropOnDestroy>();
                drop.Drop();


                if (collider.CompareTag("GolemiceEnemy"))
                {
                    collider.GetComponent<SpriteRenderer>().enabled = false;
                    collider.GetComponent<BoxCollider2D>().enabled = false;
                    collider.GetComponent<NavMeshAgent>().enabled = false;
                    Instantiate(Resources.Load<GameObject>("pufParticles"), collider.transform.position, Quaternion.identity);

                    // Desactivamos la generaci�n de particulas de hielo
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


            }

            CameraShake.instance.StartShake(.2f, .1f);

            if (deactivateArrowCoroutine != null)
            {
                StopCoroutine(deactivateArrowCoroutine);
            }

            if (gameObject.activeInHierarchy)
            {
                deactivateArrowCoroutine = StartCoroutine(DeactivateArrow(0.5f));
            }
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
        deactivateArrowCoroutine = null;
    }

    private void Update()
    {
        if (!gameObject.activeInHierarchy) return;

        timer += Time.deltaTime;

        if (timer > 3f && deactivateArrowCoroutine == null)
        {
            deactivateArrowCoroutine = StartCoroutine(DeactivateArrow(0.5f));
            timer = 0f;
        }
    }
}