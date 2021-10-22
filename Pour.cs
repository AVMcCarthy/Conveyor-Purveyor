using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pour : MonoBehaviour
{
    ParticleSystem splatter;
    public Material sauce;

    // Start is called before the first frame update
    void Start()
    {
        splatter = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Angle(Vector3.down, transform.forward) < 90f)
        {
            Debug.Log("Pouring now");
            splatter.Play();
            var main = splatter.main;
            main.cullingMode = ParticleSystemCullingMode.Automatic;
        }
        else
        {
            Debug.Log("Not pouring");
            splatter.Stop();
        }
    }
}
