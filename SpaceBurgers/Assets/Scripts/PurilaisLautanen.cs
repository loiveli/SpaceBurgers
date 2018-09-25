using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PurilaisLautanen : MonoBehaviour
{
    public GameObject menuREF;
    public MenuRefrence menu;
    public Hampurilanen burgeri;
    public List<int> stack;
    public int burgerID;
    public GameObject burgerTemplate;
    private float BurgerSize;
    public int BurgerTimer;
    public bool orderPassed;
    Text BurgerOrder;
    public void Start()
    {
        menu = menuREF.GetComponent<MenuRefrence>();    
        //BurgerOrder = transform.GetChild(0).GetChild(0).GetComponent<Text>();
        burgeri = menu.BurgerMenu[burgerID];
        BurgerSize = 0;
        BurgerTimer = -1;
        //BurgerOrder.text = burgeri.name;
        orderPassed = false;
    }
    public void resetBurger()
    {
        BurgerSize = 0;
        stack.Clear();
        foreach(GameObject i in GameObject.FindGameObjectsWithTag("Aines")){
            Destroy(i);
        }
        if(orderPassed){
            Destroy(gameObject);
        }
    }
    public void addLayer(int aines)
    {
        if(stack.Count == 0&& aines ==0){
            stack.Add(aines);
            ShowBurger(aines);
        }
        else if(stack.Count >0&&aines != 5){
            stack.Add(aines);
            ShowBurger(aines);
        }else if (stack.Count > 0) {
            ShowBurger(aines);
            sendBurger();
        }
        
    }
    public void sendBurger(){
        if(stack.SequenceEqual(burgeri.Ingredients)){
            Debug.Log("Correct burger");
            
           
            orderPassed = true;
            burgeri = menu.BurgerMenu[burgerID];
            BurgerTimer = 100;
        }
        else{
            Debug.Log("Wrong burger");
            BurgerTimer = 100;
        }
        
    }
    private void ShowBurger(int aines){
        if(aines >= 0){
            GameObject x = Instantiate(burgerTemplate, gameObject.transform.position + new Vector3(0,BurgerSize*0.1f,0),Quaternion.identity );
        x.GetComponent<SpriteRenderer>().sprite = menu.IngredientID[aines].Kuva;
        BurgerSize += 1;
        x.GetComponent<SpriteRenderer>().sortingOrder = Mathf.RoundToInt(BurgerSize)+1;
        }
        
    }
    private void FixedUpdate()
    {
       if(BurgerTimer > 0){
           BurgerTimer -= 1;
       }
        if( BurgerTimer == 0){
            resetBurger();
            BurgerTimer = -1;
        }
    }
}
