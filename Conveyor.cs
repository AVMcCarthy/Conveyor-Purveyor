using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conveyor : MonoBehaviour
{
    public GameObject oven;
    public Transform trashMid;
    public int startCount;
    public int startRight;
    private UnityEngine.AI.NavMeshAgent agent;
    private bool isTrash;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        agent.destination = oven.transform.position;
        startCount = oven.GetComponent<PizzaEval>().pizzaCount;
        startRight = oven.GetComponent<PizzaEval>().rightPizzas;
        agent.speed *= startCount + 1;
        isTrash = false;
        Debug.Log("Pizza destination: " + agent.destination);
    }

    void Update()
    {
        if (!isTrash && oven.GetComponent<PizzaEval>().pizzaCount != startCount)
        {
            if (oven.GetComponent<PizzaEval>().rightPizzas != startRight)
            {
                Debug.Log("Deleting Pizza");
                Destroy(this.gameObject);
            }
            else
            {
                Debug.Log("Trashing Pizza");
                gameObject.BroadcastMessage("burn");
                gameObject.tag = "Finish";
                isTrash = true;
                agent.destination = trashMid.position + Vector3.forward;
                agent.autoTraverseOffMeshLink = true;
                agent.speed = 1;
                Debug.Log("Pizza should now move to trash belt");
                Debug.Log("Pizza destination: " + agent.destination);
            }
        }
    }

    void OnCollisionEnter (Collision other)
    {
        if(other.transform == trashMid)
        {
            agent.destination = trashMid.position + Vector3.back;
            Debug.Log("Pizza destination: " + agent.destination);
        }
    }
}
