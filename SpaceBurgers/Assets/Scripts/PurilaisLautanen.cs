using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PurilaisLautanen : MonoBehaviour
{
    public GameObject orderText;
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

    //kim
    public GameObject orderImageHolder;
    //kim

    public void Start()
    {
        orderText = GameObject.FindGameObjectWithTag("Teksti");
        menu = menuREF.GetComponent<MenuRefrence>();
        //BurgerOrder = transform.GetChild(0).GetChild(0).GetComponent<Text>();
        burgeri = menu.BurgerMenu[burgerID];
        BurgerSize = 0;
        BurgerTimer = -1;
        //BurgerOrder.text = burgeri.name;
        orderPassed = false;
        orderText.GetComponent<TextScript>().ShowOrder(burgeri.name);

        //kim
        orderImageHolder = GameObject.FindGameObjectWithTag("Temp");
        ShowOrderImage();
        //kim
    }

    //kim copy from burgerShowCase scripts
    public void ShowOrderImage()
    {
        int burgerLayers = 0;
        float layerHeight = 0.15f;
        float skaala = 1;
        
        if (burgeri.Ingredients.Count > 6)
        {
            layerHeight = 0.15f * (8f / (burgeri.Ingredients.Count + 1));
            skaala = 8f / (burgeri.Ingredients.Count + 1);
        }

        foreach (int i in burgeri.Ingredients)
        {
            GameObject x = Instantiate(burgerTemplate, orderImageHolder.transform.position + new Vector3(0, burgerLayers * layerHeight, 0), Quaternion.identity);
            x.GetComponent<SpriteRenderer>().sprite = menu.IngredientID[i].Kuva;
            burgerLayers++;
            x.GetComponent<SpriteRenderer>().sortingOrder = Mathf.RoundToInt(burgerLayers) + 1;
            x.transform.parent = orderImageHolder.transform;
            x.transform.localScale = new Vector3(1, skaala, 1);
        }

        GameObject kansiSampyla = Instantiate(burgerTemplate, orderImageHolder.transform.position + new Vector3(0, burgerLayers * layerHeight, 0), Quaternion.identity);
        kansiSampyla.GetComponent<SpriteRenderer>().sprite = menu.IngredientID[5].Kuva;
        burgerLayers++;
        kansiSampyla.GetComponent<SpriteRenderer>().sortingOrder = Mathf.RoundToInt(burgerLayers) + 1;
        kansiSampyla.transform.parent = orderImageHolder.transform;
        kansiSampyla.transform.localScale = new Vector3(1, skaala, 1);
    }
    //kim


    public void resetBurger()
    {
        BurgerSize = 0;
        stack.Clear();
        foreach (Transform i in transform)
        {
            Destroy(i.gameObject);
        }
        if (orderPassed)
        {
            orderText.GetComponent<TextScript>().EndOrder();
            Destroy(gameObject);
        }
    }
    public void addLayer(int aines)
    {
        if (stack.Count == 0 && aines == 0)
        {
            stack.Add(aines);
            ShowBurger(aines);
        }
        else if (stack.Count > 0 && aines != 5)
        {
            stack.Add(aines);
            ShowBurger(aines);
        }
        else if (stack.Count > 0)
        {
            ShowBurger(aines);
            sendBurger();
        }

    }
    public void sendBurger()
    {
        if (stack.SequenceEqual(burgeri.Ingredients))
        {
            Debug.Log("Correct burger");


            orderPassed = true;
            burgeri = menu.BurgerMenu[burgerID];
            BurgerTimer = 100;
        }
        else
        {
            Debug.Log("Wrong burger");
            BurgerTimer = 100;
        }

    }
    private void ShowBurger(int aines)
    {
        if (aines >= 0)
        {
            GameObject x = Instantiate(burgerTemplate, gameObject.transform.position + new Vector3(0, BurgerSize * 0.1f, 0), Quaternion.identity);
            x.GetComponent<SpriteRenderer>().sprite = menu.IngredientID[aines].Kuva;
            BurgerSize++;
            x.GetComponent<SpriteRenderer>().sortingOrder = Mathf.RoundToInt(BurgerSize) + 1;
            x.transform.parent = gameObject.transform;
        }

    }
    private void FixedUpdate()
    {
        if (BurgerTimer > 0)
        {
            BurgerTimer -= 1;
        }
        if (BurgerTimer == 0)
        {
            resetBurger();
            BurgerTimer = -1;
        }
    }
}
