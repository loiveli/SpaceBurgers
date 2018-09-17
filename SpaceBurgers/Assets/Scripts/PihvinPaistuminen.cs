using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PihvinPaistuminen : MonoBehaviour {

	public float paistoaika = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		paistoaika += Time.deltaTime;
		
		//pihvin paisto hyväksi
		if(paistoaika > 5 && paistoaika < 10){
			GetComponent<SpriteRenderer>().color = new Color (0.5f, 0.5f, 0.5f, 1f);
		}
		//pihvin karrelle palaminen
		if(paistoaika > 10){
			GetComponent<SpriteRenderer>().color = new Color (0f, 0f, 0f, 1f);
		}
		if(paistoaika > 15){
			Destroy(gameObject);
		}
	}
}
