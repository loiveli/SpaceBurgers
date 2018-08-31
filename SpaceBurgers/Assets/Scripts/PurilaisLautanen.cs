using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurilaisLautanen : MonoBehaviour
{

    public List<int> stack;
    public void resetBurger()
    {

        stack.Clear();

    }
    public void addLayer(int aines)
    {

        stack.Add(aines);

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
