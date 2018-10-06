using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextScript : MonoBehaviour
{
   
    // Use this for initialization
    public Text teksti;
    public GameObject anchor;

    void Start()
    {
       
        teksti = gameObject.GetComponent<Text>();
        teksti.enabled = false;

    }
    
    
    void Update()
    {
        if(anchor != null){
            transform.position = Camera.main.WorldToScreenPoint(anchor.transform.position);
        }
        
    }
    public void ShowOrder(string burgerName)
    {
        teksti.enabled = true;

        teksti.text = burgerName;

       
    }
    public void EndOrder()
    {
        teksti.enabled = false;

      
    }

}
