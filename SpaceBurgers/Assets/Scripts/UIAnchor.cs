using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIAnchor : MonoBehaviour {

	// Use this for initialization
	public GameObject anchor;
	void Update()
    {
        if(anchor != null){
            transform.position = Camera.main.WorldToScreenPoint(anchor.transform.position);
        }
        
    }
}
