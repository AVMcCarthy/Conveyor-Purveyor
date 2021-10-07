using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Adhere : MonoBehaviour
{
    void OnTriggerEnter (Collider other)
    {
        Debug.Log("Sauce triggered.");
        GameObject that = other.gameObject;
        if (that.CompareTag("Ingredient") && that.transform.parent == null)
        {
            Debug.Log("Ingredient detected");
            other.transform.rotation = Quaternion.identity;
            other.transform.parent = this.transform;
            Debug.Log("Ingredient Parented");
            // Destroy(that.GetComponent<XRGrabInteractable>());
            // Debug.Log("Ingredient grab disabled");
            that.GetComponent<Rigidbody>().useGravity = false;
            that.GetComponent<Rigidbody>().isKinematic = true;
            Debug.Log("Ingredient gravity disabled.");
            other.enabled = false;
            Debug.Log("Ingredient collider disabled");
        }
    }
}
