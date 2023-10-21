using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainInventoryBar : InventoryBar
{
    public SubInventoryBar subInventoryBar;
    public override void OnSlotHovered(int index, bool isHovered) {
        subInventoryBar.UpdateTextures(inventoryManager.subItems[index]);

        if(registry.hasSubItems(itemids[index]))
            subInventoryBar.SetTriggererHovered(isHovered);
        else
            subInventoryBar.SetTriggererHovered(false);
    }

    public override void OnSlotClicked(int index, bool isSelected) {
        if(isSelected)
            gameManager.ShowInspectionPanel(itemids[index]);
        else if(!registry.hasSubItems(itemids[index])) {
            subInventoryBar.SelectSlot(-1);
            SelectSlot(index);
            inventoryManager.OnActiveItemChanged(itemids[index]);
        }
    }

    public void UnselectSlot() {
        SelectSlot(-1);
        subInventoryBar.SelectSlot(-1);
    }
}
