using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainRoom3 : Room
{
    public void MoveNews()
    {
        gameManager.ChangeRoom("room3_news");
    }
}
