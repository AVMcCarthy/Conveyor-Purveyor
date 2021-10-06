using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit : MonoBehaviour
{
    public static bool leave;

    // Update is called once per frame
    void Update()
    {
        if (leave)
        {
            Debug.Log("Program terminating.");
            Application.Quit();
        }
    }

    public static void terminate ()
    {
        leave = true;
    }
}
