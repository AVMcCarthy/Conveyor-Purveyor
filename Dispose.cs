using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dispose : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Finish"))
        {
            Destroy(other.GetComponent<UnityEngine.AI.NavMeshAgent>());
            Destroy(other.GetComponent<Conveyor>());
            Destroy(other.GetComponent<Burn>());
            Destroy(other.GetComponentInChildren<Adhere>());
            other.transform.parent = transform;
            other.transform.localPosition = new Vector3(0,other.transform.localPosition.y,0);
        }
    }
}
