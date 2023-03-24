using System.Collections;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    private float timer;
    private SpriteRenderer spriteRenderer;
    private BoxCollider2D boxCollider;
    public float damage;

    private Coroutine deactivateArrowCoroutine;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        boxCollider = GetComponent<BoxCollider2D>();
    }
    private void Start()
    {
        damage = 1;
        damage = damage * (1 + (JSONSaving.SharedInstance.playerData.damage * 0.25f));
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
            enemy.HP  -= (damage);

            if (enemy.HP <= 0)
            {
                var drop = collider.GetComponent<DropOnDestroy>();
                drop.Drop();
                collider.gameObject.SetActive(false);
                enemy.HP = enemy.initialHP;

                if (collider.CompareTag("SlimeEnemy"))
                {
                    Spawner.SharedInstance.creditGain(3);
                }
                else
                {
                    Spawner.SharedInstance.creditGain(8);
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
