using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room2_Picture : Room
{
    
    Rigidbody2D rigid_memo;
    public static Room2_Picture instance;
    public int find;
    
    // Start is called before the first frame update
    new void Start()
    {
        base.Start();
        rigid_memo = GameObject.Find("Memo").GetComponent<Rigidbody2D>();
        Room2_Picture.instance = this;
    }

    // Update is called once per frame
   void Update()
    {
        if(find >= 3)
        {
            rigid_memo.gravityScale = 50;
        }
    }

    public void FindError()
    {
        find +=1;
    }
}
