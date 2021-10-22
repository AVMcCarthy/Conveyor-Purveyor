using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateOrder : MonoBehaviour
{
    public Text orderItems;
    public Text called;

    public int extras;

    public string[] items = {"", "", ""};

    private string[] ingredients = {"Anchovies", "Pineapple", "Green Peppers", "Bacon", "Olives", "Onions", "Basil", "Garlic", "Tomatoes", "Chicken", "Pepperoni", "Mushrooms", "Sausage"};

    private string toSingular (string plural)
    {
        string val = plural;
        switch (plural)
        {
            case "Anchovies":
                val = "Anchovy";
                break;
            case "Green Peppers":
                val = "Green Pepper";
                break;
            case "Olives":
                val = "Olive";
                break;
            case "Onions":
                val = "Onion";
                break;
            case "Tomatoes":
                val = "Tomato";
                break;
            case "Mushrooms":
                val = "Mushroom";
                break;
        }
        return val;
    }

    public void OrderUp ()
    {
        string sauce = "Sauce\n";
        string cheese = "Cheese\n";

        int selected = 0;
        extras = Random.Range(0, 7) % 4;
        int start = 0;
        while (selected < extras)
        {
            start = Random.Range(start, ingredients.Length - extras + selected + 1);
            items[selected++] = ingredients[start++];
        }

        string toppings = string.Concat(sauce, cheese);
        switch (extras)
        {
            case 3:
                toppings = string.Concat(toppings, items[2], "\n");
                items[2] = toSingular(items[2]);
                goto case 2;
            case 2:
                toppings = string.Concat(toppings, items[1], "\n");
                items[1] = toSingular(items[1]);
                goto case 1;
            case 1:
                toppings = string.Concat(toppings, items[0]);
                items[0] = toSingular(items[0]);
                break;
        }
        orderItems.text = toppings;

        string pizza = " Pizza";
        switch (extras)
        {
            case 1:
                pizza = string.Concat(items[0], pizza);
                break;
            case 2:
                pizza = string.Concat(items[1], " and ", items[0], pizza);
                break;
            case 3:
                pizza = string.Concat(", and ", items[0], pizza);
                pizza = string.Concat(items[2], ", ", items[1], pizza);
                break;
            default:
                pizza = string.Concat("Cheese ", pizza);
                break;
        }
        called.text = pizza;
    }
}
