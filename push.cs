using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class push : MonoBehaviour
{
    static bool pressed;
    Transform pos;
    Vector3 inDest = new Vector3(0, 0, -0.4f);
    Vector3 outDest = new Vector3(0, 0, -0.5f);
    float pressSpeed = 0.1f;

    void Start()
    {
        pos = this.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (pressed && pos.localPosition.z < inDest.z)
        {
            pos.Translate(Vector3.forward * pressSpeed * Time.deltaTime);
        }
        else if (pos.localPosition.z > outDest.z)
        {
            pressed = false;
            pos.Translate(Vector3.back * pressSpeed * Time.deltaTime);
        }
    }

    public static void press()
    {
        pressed = true;
    }
}
