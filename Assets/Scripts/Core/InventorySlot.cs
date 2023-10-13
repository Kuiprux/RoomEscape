using System;
using System.Collections;
using System.Collections.Generic;
using Codice.Client.GameUI.Update;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public Sprite bgBasic;
    public Sprite bgSub;
    public Sprite fgBasicNormal;
    public Sprite fgBasicHover;
    public Sprite fgBasicSelected;
    public Sprite fgSubNormal;
    public Sprite fgSubHover;
    public Sprite fgSubSelected;

    bool isHovered = false;
    bool isSelected = false;
    bool hasSubItem = false;
    Sprite itemTexture;

    [HideInInspector]
    public InventoryBar inventoryBar;
    [HideInInspector]
    public int index;

    public Image background;
    public Image item;
    public Image foreground;

    void Start() {
        UpdateUI();
    }

    public void SetItem(bool hasSubItem, Sprite texture) {
        //Debug.Log("SetItem: " + hasSubItem + ", " + texture);
        this.hasSubItem = hasSubItem;
        itemTexture = texture;
        UpdateUI();
    }

    public void RemoveItem() {
        hasSubItem = false;
        itemTexture = null;
        UpdateUI();
    }

    public void SetHovered(bool isHovered) {
        this.isHovered = isHovered;
        //Debug.Log("SetHovered: " + isHovered);
        UpdateUI();

        inventoryBar.OnSlotHovered(index, isHovered);
    }

    public void SetSelected(bool isSelected) {
        this.isSelected = isSelected;
        //Debug.Log("SetSelected: " + isSelected);
        UpdateUI();
    }

    public void OnClick() {
        //Debug.Log("OnClick: " + index);
        if(itemTexture == null)
            return;
        inventoryBar.OnSlotClicked(index, isSelected);
    }

    public void UpdateUI() {
        if(hasSubItem) {
            background.sprite = bgSub;
            item.sprite = itemTexture;
            foreground.sprite = itemTexture == null ? null : isSelected ? fgSubSelected : isHovered ? fgSubHover : fgSubNormal;
        } else {
            //Debug.Log("UpdateUI: " + itemTexture);
            background.sprite = bgBasic;
            item.sprite = itemTexture;
            foreground.sprite = itemTexture == null ? null : isSelected ? fgBasicSelected : isHovered ? fgBasicHover : fgBasicNormal;
        }

        if(itemTexture == null) {
            item.color = new Color(0, 0, 0, 0);
            foreground.color = new Color(0, 0, 0, 0);
        } else {
            item.color = new Color(1, 1, 1, 1);
            foreground.color = new Color(1, 1, 1, 1);
        }
    }

}
