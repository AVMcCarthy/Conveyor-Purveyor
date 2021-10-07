using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Burn : MonoBehaviour
{
    public Material charcoal;
    public void burn()
    {
        if (TryGetComponent(out Renderer rend))
            rend.material = charcoal;
        else
        {
            Renderer[] renders = GetComponentsInChildren<Renderer>();
            foreach(Renderer r in renders)
                r.material = charcoal;
        }
        Debug.Log(gameObject.name + " burned");
    }
}
