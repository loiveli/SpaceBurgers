﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsiakasScript : MonoBehaviour
{

    // Use this for initialization
    
    public GameObject asiakas;
    public GameObject orderText;
    public int asiakasMax;
    public GameObject Lautanen;
    public int levelMax;
    public int burgerLevel;
    public int burgerTimer;
    public int BurgerCount;
    public int NewBurgerAmount;
    public int ProgressionLevel;
    public int ProgressionMax;
    public int levelRequirement;
    public int UnlockedIngredients;
    void Start()
    {
        UnlockedIngredients = 10;
        asiakasMax = 1;
        levelMax = 2;
        burgerLevel = 0;
        burgerTimer = -1;
        ProgressionLevel = 0;
        ProgressionMax = 0;
        NewBurgerAmount = 3;
        levelRequirement = 5;
        burgerTimer = Random.Range(180, 300);

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (BurgerCount % levelRequirement == 0 && ProgressionLevel < ProgressionMax)
        {
            levelMax += NewBurgerAmount;
            ProgressionLevel++;
        }
        
        
            
        
        if (burgerTimer >= 0)
        {
            burgerTimer--;
        }
        if (burgerTimer == 0)
        {
            asiakas.GetComponent<CustomerMove>().StartOrder();
        }

    }

    public void OrderBurger()
    {
        BurgerCount++;
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
