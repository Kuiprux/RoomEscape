using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookShelf : MonoBehaviour
{
    [HideInInspector]
    public bool move = false;

    void Update()
    {
        if (move)
        {
            if (transform.position.x > 780)
            {
                transform.position = transform.position + Vector3.left * 0.07f;
            }
        }
    }
}
