using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergyMeter : MonoBehaviour
{
    Image EnergyBar0;
    float maxEnergy = 10000f;
    public static float Energy;

    //kim
    PauseControl gameControl;
    public GameObject gameControlGameObject;
    //kim

     void Start()
    {
        //kim
        gameControl = gameControlGameObject.GetComponent<PauseControl>();
        //kim

        EnergyBar0 = GetComponent<Image>();
        Energy = maxEnergy;
    }
    void FixedUpdate()
    {
        if (Energy > 0)
        {
            Energy-=10;
        }
        
        EnergyBar0.fillAmount = Energy / maxEnergy;

        if(Energy == 0)
        {
            gameControl.GameOver();
        }
    }

   
}