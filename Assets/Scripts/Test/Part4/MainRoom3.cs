using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainRoom3 : Room
{
    new void Start()
    {
        base.Start();
    }

    public void MoveNews()
    {
        gameManager.ChangeRoom("room3_news");
    }
}
