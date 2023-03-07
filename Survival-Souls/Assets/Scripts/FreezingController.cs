using System.Collections;
using UnityEngine;

public class FreezingController : MonoBehaviour
{
    public float transitionTime = 0.5f;
    public bool isActive { get { return active; } }

    private Color freezingColor = new Color(0f, 0.6f, 1f, 1.0f);
    private SpriteRenderer spriteRenderer;
    private int iceColliderCount = 0;
    private Coroutine transitionCoroutine;
    private bool isFreezing = false;
    private bool active = false;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("IceCollider"))
        {
            iceColliderCount++;
            if (!isFreezing)
            {
                if (transitionCoroutine != null)
                {
                    StopCoroutine(transitionCoroutine);
                }
                transitionCoroutine = StartCoroutine(TransitionColor(freezingColor));
            }
            isFreezing = true;
            active = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("IceCollider"))
        {
            iceColliderCount--;
            if (iceColliderCount <= 0)
            {
                isFreezing = false;
                if (transitionCoroutine != null)
                {
                    StopCoroutine(transitionCoroutine);
                }
                transitionCoroutine = StartCoroutine(TransitionColor(Color.white));
                StartCoroutine(WaitBeforeDeactivating());
            }
        }
    }

    private IEnumerator WaitBeforeDeactivating()
    {
        yield return new WaitForSeconds(1f);
        if (!isFreezing)
        {
            active = false;
            if (transitionCoroutine != null)
            {
                StopCoroutine(transitionCoroutine);
            }
            transitionCoroutine = StartCoroutine(TransitionColor(Color.white));
        }
    }

    private IEnumerator TransitionColor(Color targetColor)
    {
        Color startColor = spriteRenderer.color;
        float elapsedTime = 0f;
        while (elapsedTime < transitionTime)
        {
            elapsedTime += Time.deltaTime;
            spriteRenderer.color = Color.Lerp(startColor, targetColor, elapsedTime / transitionTime);
            yield return null;
        }
        spriteRenderer.color = targetColor;
        if (targetColor == Color.white)
        {
            active = false;
        }
    }
}