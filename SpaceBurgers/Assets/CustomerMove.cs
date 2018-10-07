using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerMove : MonoBehaviour {
	Vector3 RealPos;
	[SerializeField]
	public float magnitude;
	[SerializeField]
	public float freq;
	[SerializeField]
	public float speed;
	public bool ordered;
	public GameObject startOrderPoint;
	public GameObject orderPoint;
	public GameObject LeavePoint;
	// Use this for initialization
	public GameObject asiakasRef;
	public Transform target;
	void Start () {
		RealPos = transform.position;
		speed = 0.2f;
		asiakasRef = GameObject.FindGameObjectWithTag("AsiakasCTRL");
		target = startOrderPoint.transform;
		ordered = false;
		freq = 1f;
		magnitude = 0.1f;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		
		if(target == orderPoint.transform&&Vector2.Distance(RealPos,target.position)<0.1f&&!ordered){
			asiakasRef.GetComponent<AsiakasScript>().OrderBurger();
			ordered = true;
		}
		if(target == LeavePoint.transform&&Vector2.Distance(RealPos,target.position)<0.1f&&ordered){
			asiakasRef.GetComponent<AsiakasScript>().burgerTimer = Random.Range(180, 300);
			ordered = false;
		}
		RealPos = Vector2.MoveTowards(RealPos,target.position,speed);
		transform.position = RealPos +transform.up*Mathf.Sin(Time.time*freq)*magnitude;

	}
	public void StartOrder(){
		RealPos = startOrderPoint.transform.position;
		target = orderPoint.transform;
	}
	public void Leave(){
		target = LeavePoint.transform;
	}
}
