using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Customer : MonoBehaviour {


    public List<Hampurilanen> hampurilanens;
    int orderItemIndex;
    public GameObject imageHolder;


    //public GameObject orderBoard;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnMouseDown()
    {
        orderItemIndex = UnityEngine.Random.Range(0, 2);
        Debug.Log(hampurilanens[orderItemIndex].name);
        //Instantiate(hampurilanens[orderItemIndex], orderBoard.transform.position, transform.rotation);
        imageHolder.GetComponent<SpriteRenderer>().sprite = hampurilanens[orderItemIndex].Image;
    }
}
