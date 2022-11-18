using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponAim : MonoBehaviour
{

    private Transform aimTransform;
    private SpriteRenderer playerSprite;

    // Start is called before the first frame update
    void Start()
    {
        aimTransform = transform.Find("Aim");
        playerSprite = GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // Set aim rotation
        Vector2 aimDirection = (mousePos - new Vector2(transform.position.x, transform.position.y)).normalized;
        float angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;
        aimTransform.eulerAngles = new Vector3(0, 0, angle);

        // Mirror the weapon at the rotation breakpoint
        Vector2 aimLocalScale = Vector2.one;
        if (angle > 90 || angle < -90) {
            aimLocalScale.y = -1f;
        } else {
            aimLocalScale.y = +1f;
        }
        aimTransform.localScale = aimLocalScale;

        // Put the weapon behind the character when facing forward
        if (angle > 0 && angle < 180) {
            SetLayerAllChildren(aimTransform, playerSprite.sortingOrder - 1);
        } else {
            SetLayerAllChildren(aimTransform, playerSprite.sortingOrder + 1);
        }

        static void SetLayerAllChildren(Transform root, int layer)
        {
            var children = root.GetComponentsInChildren<SpriteRenderer>(includeInactive: true);
            foreach (var child in children)
            {
                child.sortingOrder = layer;
            }
        }
    }
}
