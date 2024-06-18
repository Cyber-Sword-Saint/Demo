using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotController : MonoBehaviour
{

    public static PotController instance;
    private List<string> ingredients = new List<string>();
    public GameObject spoon;

    private void Awake()
	{
		instance = this;
	}

    void OnMouseDown()
    {
        Cook();
    }

    void Start()
    {
        ingredients = new List<string>();
    }

    public void Cook()
    {
        if (ingredients.Count > 0)
        {
            Debug.Log("Cooking with ingredients: " + string.Join(", ", ingredients));
            ingredients.Clear();
            spoon.SetActive(true);
        }
        else
        {
            Debug.Log("No ingredients to cook.");
        }
    }

    public void AddIngre(string ingreName)
    {
        ingredients.Add(ingreName);
    }
}
