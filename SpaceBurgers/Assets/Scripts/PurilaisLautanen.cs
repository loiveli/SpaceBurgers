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
    public GameObject burgerTemplate;
    private float BurgerSize;
    public void Start()
    {
        menu = gameObject.GetComponent<MenuRefrence>();    
        burgerID = 0;
        burgeri = menu.BurgerMenu[burgerID];
        BurgerSize = 0;
    }
    public void resetBurger()
    {
        BurgerSize = 0;
        stack.Clear();
        foreach(GameObject i in GameObject.FindGameObjectsWithTag("Aines")){
            Destroy(i);
        }
    }
    public void addLayer(int aines)
    {
        if(stack.Count == 0&& aines ==0){
            stack.Add(aines);
            ShowBurger(aines);
        }
        else if(stack.Count >0){
            stack.Add(aines);
            ShowBurger(aines);
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
    private void ShowBurger(int aines){
        GameObject x = Instantiate(burgerTemplate, gameObject.transform.position + new Vector3(0,BurgerSize,0),Quaternion.identity );
        x.GetComponent<SpriteRenderer>().sprite = menu.IngredientID[aines].Kuva;
        BurgerSize += 0.05f;
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
