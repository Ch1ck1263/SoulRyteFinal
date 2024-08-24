using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleAttribute : MonoBehaviour
{
    private void Start()
    {

    }

    // This function gets called everytime this object collides with another
    private void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(gameObject);
    }
}


