using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    [SerializeField]
    float destroyDelay = 0.1f;

    [SerializeField]
    Color32 hasPackageColor = new Color32(0, 190, 0, 254);

    [SerializeField]
    Color32 noPackageColor = new Color32(255, 255, 255, 254);

    bool hasPackage = false;

    SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void OnCollisionEnter2D(Collision2D other) { }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Package")
        {
            if (!hasPackage)
            {
                Debug.Log("Package picked up!");
                hasPackage = true;
                spriteRenderer.color = hasPackageColor;
                Destroy(other.gameObject, destroyDelay);
            }
            else
            {
                Debug.Log("You already have a package!");
            }
        }
        else if (other.tag == "Customer")
        {
            if (hasPackage)
            {
                Debug.Log("Package is delivered!");
                hasPackage = false;
                spriteRenderer.color = noPackageColor;
            }
            else
            {
                Debug.Log("You do not have a package to deliver!");
            }
        }
    }
}
