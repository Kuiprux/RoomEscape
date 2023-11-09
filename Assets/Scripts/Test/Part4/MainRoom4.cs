using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class MainRoom4 : Room
{
    public BookShelf bookshelf;

    public void clear()
    {
        bookshelf.move = true;

        transform.Find("obj_box").gameObject.SetActive(false);
        transform.Find("obj_hidden").gameObject.SetActive(true);
    }

    public void MoveBox()
    {
        gameManager.ChangeRoom("room4_box");
    }

    public void MoveHidden()
    {
        gameManager.ChangeRoom("main_room5");
    }
}
