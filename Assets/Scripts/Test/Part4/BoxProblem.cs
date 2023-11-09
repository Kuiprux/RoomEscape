using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BoxProblem : Room
{
    public MainRoom4 room4;

    [HideInInspector]
    public string piece1 = "";
    [HideInInspector]
    public string piece2 = "";

    public Sprite getNone;
    public Sprite getTop;
    public Sprite getBottom;
    public Sprite getAll;

    public void put(int number)
    {
        switch(number)
        {
            case 1:
                if (inventoryManager.GetActiveItem().Contains("top"))
                {
                    piece1 = inventoryManager.GetActiveItem();
                    inventoryManager.UseActiveItem();

                    transform.Find("obj_panel_1").gameObject.SetActive(false);

                    if (piece2.Length == 0)
                    {
                        transform.GetComponent<Image>().sprite = getTop;
                    }
                    else
                    {
                        transform.GetComponent<Image>().sprite = getAll;

                        CancelInvoke();
                        Invoke("check", 1);
                    }
                }
                break;
            case 2:
                if (inventoryManager.GetActiveItem().Contains("bottom"))
                {
                    piece2 = inventoryManager.GetActiveItem();
                    inventoryManager.UseActiveItem();

                    transform.Find("obj_panel_2").gameObject.SetActive(false);

                    if (piece1.Length == 0)
                    {
                        transform.GetComponent<Image>().sprite = getBottom;
                    }
                    else
                    {
                        transform.GetComponent<Image>().sprite = getAll;

                        CancelInvoke();
                        Invoke("check", 1);
                    }
                }
                break;
            default:
                Debug.Log("Error!");
                break;
        }
    }

    public void check()
    {
        if (piece1 == "top2" && piece2 == "bottom4")
        {
            Debug.Log("Correct!");

            gameManager.ChangeRoom("main_room4");
            room4.clear();
        }
        else
        {
            Debug.Log("Do it again!");
            
            AcquireItem(piece1);
            AcquireItem(piece2);

            piece1 = "";
            piece2 = "";

            transform.Find("obj_panel_1").gameObject.SetActive(true);
            transform.Find("obj_panel_2").gameObject.SetActive(true);

            transform.GetComponent<Image>().sprite = getNone;
        }
    }
}
