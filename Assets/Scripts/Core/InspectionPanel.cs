using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InspectionPanel : MonoBehaviour
{
    public Image inspectionImage;

    public void ShowPanel(Sprite sprite) {
        inspectionImage.sprite = sprite;
        gameObject.SetActive(true);
    }
}
