using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
public class PlateEditor : MonoBehaviour
{

    // Use this for initialization
	public InputField input;
    public GameObject menuREF;
    public MenuRefrence menu;
    
    public List<int> stack;
    public int BurgerSize;
    public GameObject burgerTemplate;
    public string burgerName;
	void Start()
    {
        menu = menuREF.GetComponent<MenuRefrence>();
        input.text = "name";
       
    }

    // Update is called once per frame
    void Update()
    {
		
    }
    public void resetBurger()
    {
        BurgerSize = 0;
        stack.Clear();
        foreach (Transform i in transform)
        {
            Destroy(i.gameObject);
        }

    }
	
    public void sendBurger()
    {
        
        Hampurilanen burgeri = ScriptableObject.CreateInstance<Hampurilanen>();
        burgeri.Ingredients = stack;
        burgerName = input.text;
        burgeri.name = burgerName;
        AssetDatabase.CreateAsset(burgeri, "assets/Scripts/Burgers/" + burgerName + ".asset");

        resetBurger();
        
		
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

}
