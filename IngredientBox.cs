using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientBox : MonoBehaviour
{
    public GameObject contents;
    Transform pivot;

    void Start()
    {
        pivot = this.transform.parent;
    }

    public void spawn()
    {
        GameObject topping = (GameObject) Instantiate(contents, pivot.position + Vector3.back * 0.1f, Quaternion.identity);
    }

    // void OnTriggerEnter(Collider other)
    // {
    //     if (other.CompareTag("Pizza"))
    //         spawn();
    // }
}
