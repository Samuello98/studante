using UnityEngine;
using System.Collections;

public class ClickDetection : Interactable
{

    private bool isClicked = false;

    public override void Interact(GameObject caller)
    {
        Debug.Log(caller.name + "CLICKED" + gameObject.name);
        isClicked = true;

    }

     void Update()
    {
        Debug.Log(isClicked);  
    }
}
