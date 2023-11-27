using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lock : MonoBehaviour
{

    GameObject obj_light;
    GameObject door;
    // Start is called before the first frame update
    void Start()
    {
        obj_light = transform.Find("obj_light").gameObject;
        door = transform.Find("Door").gameObject;
    }
    // Update is called once per frame
    void Update()
    {
        if(obj_light.activeSelf == true)
        {
            door.gameObject.SetActive(true);
        }
    }
}
