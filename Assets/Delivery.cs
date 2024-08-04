using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    [SerializeField]
    float destroyDelay = 0.1f;

    bool hasPackage = false;

    void OnCollisionEnter2D(Collision2D other) { }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Package")
        {
            if (!hasPackage)
            {
                Debug.Log("Package picked up!");
                hasPackage = true;
                Destroy(other.gameObject);
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
            }
            else
            {
                Debug.Log("You do not have a package to deliver!");
            }
        }
    }
}
