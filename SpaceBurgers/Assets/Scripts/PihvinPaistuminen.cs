﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PihvinPaistuminen : MonoBehaviour {

	public float paistoaika = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		paistoaika += Time.deltaTime;
		if(paistoaika > 6){
		GetComponent<SpriteRenderer>().color = new Color (0.5f, 0.5f, 0.5f, 1f);
	}
	}
}
