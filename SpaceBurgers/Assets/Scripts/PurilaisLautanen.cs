using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurilaisLautanen : MonoBehaviour
{
    public MenuRefrence menu;
    public Hampurilanen burgeri;
    public List<int> stack;
    public int burgerID;
    public void Start()
    {
        menu = gameObject.GetComponent<MenuRefrence>();    
        burgerID = 0;
        burgeri = menu.BurgerMenu[burgerID];
    }
    public void resetBurger()
    {

        stack.Clear();

    }
    public void addLayer(int aines)
    {
        if(stack.Count == 0&& aines ==0){
            stack.Add(aines);
        }
        else if(stack.Count >0){
            stack.Add(aines);
        }

    }
    public void sendBurger(){
        if(stack.SequenceEqual(burgeri.Ingredients)){
            Debug.Log("Correct burger");
            resetBurger();
            if(burgerID <1){
                burgerID++;
            }else{
                burgerID = 0;
            }
            
            burgeri = menu.BurgerMenu[burgerID];
        }
        else{
            Debug.Log("Wrong burger");
            resetBurger();
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
			 foreach(int i in stack )
            {
                Debug.Log(i);
            }
        }

    }
}
