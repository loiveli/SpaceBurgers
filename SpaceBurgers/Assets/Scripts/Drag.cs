﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drag : MonoBehaviour {

    public float moveSpeed;

    [HideInInspector]
    public float offset = 0.05f;
    private bool following;
    void Start ()
    {
		following = false;
		offset += 10;
	}

    void Update ()
    {
		if (Input.GetMouseButtonDown(0) && 
           ((Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position).magnitude <= offset))
		{
			if (following)
			{
				following = false;
			}
			else
			{
				following = true;
			}
		}

        if (following)
		{
			transform.position = Vector2.Lerp(transform.position, 
                                 Camera.main.ScreenToWorldPoint(Input.mousePosition), moveSpeed);
		}
	}
}
