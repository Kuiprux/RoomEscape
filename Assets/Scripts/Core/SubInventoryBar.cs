using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubInventoryBar : InventoryBar
{
    public MainInventoryBar mainInventoryBar;

    bool isSubBarHovered = false;
    bool isMainSlotHovered = false;
    
    public override void OnSlotClicked(int index, bool isSelected) {
        if(isSelected)
            gameManager.ShowInspectionPanel(itemids[index]);
        else {
            mainInventoryBar.SelectSlot(-1);
            SelectSlot(index);
            inventoryManager.OnActiveItemChanged(itemids[index]);
        }
    }

    public override void OnSlotHovered(int index, bool isHovered) {}



    public void SetShow(bool shouldShow) {
        gameObject.GetComponent<Animator>().SetBool("shouldShow", shouldShow);
    }

    public void SetPanelHovered(bool isHovered) {
        isSubBarHovered = isHovered;
        if(isSubBarHovered || isMainSlotHovered)
            UpdateShow();
        else
            Invoke("UpdateShow", 0.5f);
    }

    public void SetTriggererHovered(bool isHovered) {
        isMainSlotHovered = isHovered;
        if(isSubBarHovered || isMainSlotHovered)
            UpdateShow();
        else
            Invoke("UpdateShow", 0.5f);
    }

    public void UpdateShow() {
        if(isSubBarHovered || isMainSlotHovered)
            SetShow(true);
        else
            SetShow(false);
    }
}
