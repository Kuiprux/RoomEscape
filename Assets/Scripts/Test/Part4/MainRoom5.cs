using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainRoom5 : Room
{
    public void getNews()
    {
        AcquireItem("news1");
        AcquireItem("news2");
        AcquireItem("news3");
        AcquireItem("news4");
        Destroy(transform.Find("news").gameObject);
    }
}
