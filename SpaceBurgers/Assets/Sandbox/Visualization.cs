using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Visualization : MonoBehaviour {

    public GameObject holder;
    public GameObject ingredient;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void InstantiateIngredient()
    {
        Instantiate(ingredient, holder.transform.position, transform.rotation);
    }
}
