using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainRoom2 : Room
{
    // Start is called before the first frame update
    new void Start()
    {
        base.Start();
        transform.Find("Memo").gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Room2_Picture.instance.find >= 3)
        {
            transform.Find("Memo").gameObject.SetActive(true);
        }
    }
}
