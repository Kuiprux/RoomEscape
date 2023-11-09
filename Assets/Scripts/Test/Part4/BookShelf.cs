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
            Debug.Log(transform.position.x);
            if (transform.position.x > 1350)
            {
                transform.position = transform.position + Vector3.left * 0.3f;
            }
        }
    }
}
