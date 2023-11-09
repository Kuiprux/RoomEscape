using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class NewsProblem : Room
{
    public string[] news = new string[5];
    public Sprite[] getNews = new Sprite[5];
    public int index = 1;
    
    public void put()
    {
        if (inventoryManager.GetActiveItem().Contains("news"))
        {
            news[index] = inventoryManager.GetActiveItem();
            inventoryManager.UseActiveItem();

            transform.GetComponent<Image>().sprite = getNews[index];
            index++;

            if (index > 4)
            {
                CancelInvoke();
                Invoke("check", 1);
            }
        }
    }

    public void check()
    {
        if (news[1] == "news3" && news[2] == "news2" && news[3] == "news4" && news[4] == "news1")
        {
            Debug.Log("Correct!");

            CancelInvoke();
            Invoke("getCard", 1);
        }

        else
        {
            Debug.Log("Do it again!");

            for (int i = 1; i < news.Length; i++)
            {
                AcquireItem(news[i]);
                news[i] = "";
            }

            transform.GetComponent<Image>().sprite = getNews[0];
            index = 1;
        }
    }

    public void getCard()
    {
        transform.Find("obj_card").gameObject.SetActive(true);
    }
}
