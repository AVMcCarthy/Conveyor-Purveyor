using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeDough : MonoBehaviour
{
    public Object raw;
    public Transform source;
    public GameObject oven;
    public Transform trashBelt;

    // void Start ()
    // {
    //     create();
    // }

    public void create ()
    {
        GameObject dough;
        dough = (GameObject) Instantiate(raw, source.position, Quaternion.identity);
        dough.GetComponent<Conveyor>().oven = oven;
        dough.GetComponent<Conveyor>().trashMid = trashBelt;
        dough.GetComponent<Transform>().SetParent(null);
        this.gameObject.SendMessage("OrderUp");
    }
}
