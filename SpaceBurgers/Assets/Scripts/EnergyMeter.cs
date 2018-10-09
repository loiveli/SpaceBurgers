using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergyMeter : MonoBehaviour
{
    Image EnergyBar0;
    float maxEnergy = 2000f;
    public static float Energy;
    public int energySteps;
    //kim
    public float TotalEnergy;
    PauseControl gameControl;
    public GameObject gameControlGameObject;
    //kim

    void Start()
    {
        //kim
        gameControl = gameControlGameObject.GetComponent<PauseControl>();
        //kim
        energySteps = 6;
        EnergyBar0 = GetComponent<Image>();
        Energy = maxEnergy +2000f;
        TotalEnergy = 1f;
    }
    void FixedUpdate()
    {
        if (Energy > 0)
        {
            Energy -= 10;
        }

        EnergyBar0.fillAmount = TotalEnergy;

        if (Energy == 0)
        {
            Energy = maxEnergy;
            TotalEnergy -=1f/energySteps; 
        }
        if(TotalEnergy<(1f/energySteps)/2){
            gameControl.GameOver();
        }
    }


}