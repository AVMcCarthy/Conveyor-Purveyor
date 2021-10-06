using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Decay : MonoBehaviour
{
    public float maxSeconds = 60.0F;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject, maxSeconds);
    }
}
