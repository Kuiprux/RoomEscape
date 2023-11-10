using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Segment : MonoBehaviour
{
    public Segment linkedSegment;
    public int[] linkedSegmentIndex = new int[7];
    public bool[] initialSegState = new bool[7];

    public List<GameObject> return_button_react = new List<GameObject>();

    void Start() {
        for(int i = 0; i < 7; i++) {
            return_button_react[i].GetComponent<Image>().color = gameObject.GetComponent<Image>().color;
            if(!initialSegState[i])
                ToggleButton(i);
        }
    }

    public void ToggleButton(int index) {
        Image image = return_button_react[index].GetComponent<Image>();
        image.color = new Color(image.color.r, image.color.g, image.color.b, 1 - image.color.a);
    }

    public void OnButtonClick(int index) {
        Debug.Log("Button " + index + " clicked");
        ToggleButton(index);
        if(linkedSegment != null)
            linkedSegment.ToggleButton(linkedSegmentIndex[index]);
    }
}
