using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearFloor : MonoBehaviour
{
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ingredient") && other.transform.parent == null)
        {
            Debug.Log("Ingredient hit the floor.");
            Destroy(other.gameObject);
        }
    }
}
