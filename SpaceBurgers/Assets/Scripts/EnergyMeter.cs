using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergyMeter : MonoBehaviour
{
    Image EnergyBar0;
    float maxEnergy = 10000f;
    public static float Energy;

     void Start()
    {
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
    }
}