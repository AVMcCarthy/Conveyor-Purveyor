using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PizzaEval : MonoBehaviour
{
    public Text banner;
    public Text tally;

    public int rushSize = 30; // The number of pizzas in a single "rush"; by default, 30.

    public int pizzaCount;
    public int rightPizzas;
    public int missing;
    public int wrong;
    public GameObject eventHandle;  //The Event Handler for the Pizzaria

    void Start ()
    {
        pizzaCount = 0;
    }

    // OnTriggerEnter is called whenever a rigidbody collider interacts with the oven
    private void OnTriggerEnter (Collider other)
    {
        GameObject that = other.gameObject;
        Debug.Log("Something hit the oven.");
        if (that.CompareTag("Pizza"))   //The oven only bothers to interact with pizzas.
        {
            Debug.Log("It was a pizza!");

            int expect = eventHandle.GetComponent<CreateOrder>().extras;
            int maybeMissing = expect + 2; // 2 For the cheese and sauce
            Transform sauce = that.transform.Find("Sauce");
            if (sauce != null)  //Pizzas only have children through the sauce
            {
                --maybeMissing;
                bool foundCheese = false;
                int i = 0;
                string[] seek = eventHandle.GetComponent<CreateOrder>().items;
                int[] found = {0, 0, 0};

                while (i < sauce.childCount)
                {
                    string kid = sauce.GetChild(i++).name;  //Only use of i, so increment too
                    Debug.Log("Checking next child: " + kid);
                    if (kid.Equals("Cheese Layer(Clone)"))         //Cheese, like sauce, is always required
                    {
                        Debug.Log("Found cheese");
                        if (!foundCheese)
                        {
                            --maybeMissing;
                            foundCheese = true;
                        }
                    }
                    else
                    {
                        Debug.Log("This is not cheese");
                        bool hit = false;
                        for (int j = 0; j < expect; ++j)
                        {
                            if (kid.Equals(seek[j] + "(Clone)") || kid.Equals(seek[j] + " Layer(Clone)"))
                            {   //The desired ingredient, either individual or layered
                                Debug.Log("Found extra ingredient " + seek[j]);
                                hit = true;
                                if (found[j] < 1)
                                {
                                    found[j] = 1;
                                    --maybeMissing;
                                }
                            }
                        }

                        if (!hit)   //No hit means ingredient was not expected
                        {
                            ++wrong;
                            Debug.Log("This is the wrong ingredient");
                        }
                    }
                }
            }

            missing += maybeMissing;
            if (maybeMissing == 0)
                ++rightPizzas;

            pizzaCount += 1;    //Incrementing pizzaCount also deletes the pizza which reached the oven
            if (pizzaCount < rushSize)  //Make more pizzas as long as the rush continues
                eventHandle.GetComponent<MakeDough>().create();
            else
            {
                banner.text = "Dinner rush complete!";
                string score = "Pizzas: " + rightPizzas + " out of " + pizzaCount + "!\n";
                score = string.Concat(score, "Missed: " + missing + " ingredients.\n");
                score = string.Concat(score, "Wrong: " + wrong + " ingredients!");
                tally.text = score;
            }
        }
    }

    public void OnRestart ()
    {
        pizzaCount = 0;
    }
}
