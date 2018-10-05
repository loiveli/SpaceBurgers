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
    GameObject orderImageHolder;
    GameObject orderImageChild;
    public GameObject customerImageHolder;
    public GameObject customerOriginPosition;
    public GameObject customerTargetPosition;

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
        orderImageChild = GameObject.FindGameObjectWithTag("TempChild");
        customerImageHolder = GameObject.FindGameObjectWithTag("Customer");
        customerOriginPosition = GameObject.FindGameObjectWithTag("Origin");
        customerTargetPosition = GameObject.FindGameObjectWithTag("Target");
        ShowOrderImage();
        //kim
    }

    //kim copy from burgerShowCase scripts
    public void ShowOrderImage()
    {
        orderImageHolder.GetComponentInChildren<SpriteRenderer>().sprite = Resources.Load<Sprite>("speechBubble");
        customerImageHolder.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Customer1");
        customerImageHolder.transform.position = customerOriginPosition.transform.position;

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
            GameObject x = Instantiate(burgerTemplate, orderImageChild.transform.position + new Vector3(0, burgerLayers * layerHeight, 0), Quaternion.identity);
            x.GetComponent<SpriteRenderer>().sprite = menu.IngredientID[i].Kuva;
            burgerLayers++;
            x.GetComponent<SpriteRenderer>().sortingOrder = Mathf.RoundToInt(burgerLayers) + 1;
            x.transform.parent = orderImageChild.transform;
            x.transform.localScale = new Vector3(1, skaala, 1);
        }

        GameObject kansiSampyla = Instantiate(burgerTemplate, orderImageChild.transform.position + new Vector3(0, burgerLayers * layerHeight, 0), Quaternion.identity);
        kansiSampyla.GetComponent<SpriteRenderer>().sprite = menu.IngredientID[5].Kuva;
        burgerLayers++;
        kansiSampyla.GetComponent<SpriteRenderer>().sortingOrder = Mathf.RoundToInt(burgerLayers) + 1;
        kansiSampyla.transform.parent = orderImageChild.transform;
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
            
            //kim
            orderImageHolder.GetComponentInChildren<SpriteRenderer>().sprite = Resources.Load<Sprite>("transparent");
            customerImageHolder.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("transparent");
            foreach (Transform obj in orderImageChild.transform)
            {
                Destroy(obj.gameObject);
            }
            //kim

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
