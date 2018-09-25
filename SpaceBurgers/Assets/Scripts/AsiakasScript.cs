using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsiakasScript : MonoBehaviour
{

    // Use this for initialization

    public int asiakasMax;
    public GameObject Lautanen;
    public int levelMax;
    public int burgerLevel;
    public int burgerTimer;
    void Start()
    {
        asiakasMax = 1;
        levelMax = 2;
        burgerLevel = 0;
		burgerTimer = -1;
	}

    // Update is called once per frame
    void FixedUpdate()
    {
        if (GameObject.FindGameObjectsWithTag("Lautanen").Length < asiakasMax&&burgerTimer == -1)
        {
            burgerTimer = Random.Range(180, 300);

        }
        if (burgerTimer >= 0)
        {
            burgerTimer--;
        }
		if(burgerTimer == 0){
			OrderBurger();
		}
	}

    void OrderBurger()
    {
        GameObject inst = Instantiate(Lautanen, transform.position, Quaternion.identity);
        if (burgerLevel <= levelMax)
        {
            inst.GetComponent<PurilaisLautanen>().burgerID = burgerLevel;
            burgerLevel++;
        }
        else
        {
            inst.GetComponent<PurilaisLautanen>().burgerID = Random.Range(0, levelMax);
        }
    }


}
