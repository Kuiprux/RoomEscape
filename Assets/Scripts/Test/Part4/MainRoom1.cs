using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainRoom1 : Room
{

    new void Start()
    {
        base.Start();
    }

    public void useCard()
    {
        if (inventoryManager.GetActiveItem() == "card")
        {
            inventoryManager.UseActiveItem();
            transform.Find("obj_light").gameObject.SetActive(true);
        }
    }
}
