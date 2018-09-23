using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsiakasScript : MonoBehaviour {

	// Use this for initialization
	
	public int asiakasMax;
	public GameObject Lautanen;
	public int levelMax;
	void Start () {
		asiakasMax = 1;
		levelMax = 2;
	}
	
	// Update is called once per frame
	void Update () {
		if(GameObject.FindGameObjectsWithTag("Lautanen").Length < asiakasMax){
			GameObject inst = Instantiate( Lautanen, transform.position,Quaternion.identity);
			inst.GetComponent<PurilaisLautanen>().burgerID = Random.Range (0,levelMax);
		}
	}
}
