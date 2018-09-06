using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Visualization : MonoBehaviour {

    public GameObject holder;
    public GameObject ingredient;

    public AinesOsa ingredientData;

    private GameObject burger;

    private void Start()
    {
        burger = GameObject.Find("Burger");
    }


    public void InstantiateIngredient()
    {
        GameObject obj = Instantiate(ingredient, holder.transform.position, transform.rotation);
        obj.transform.parent = burger.transform;
        obj.GetComponent<SpriteRenderer>().sprite = ingredientData.Kuva;
        obj.gameObject.name = ingredientData.name;
    }
}
