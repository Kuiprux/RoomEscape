using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InventoryBar : MonoBehaviour
{
    public InventoryManager inventoryManager;
    public GameManager gameManager;
    public Registry registry; 
    public GameObject slotPrefab;

    public int slotCount = 6;

    public InventorySlot[] slots;
    protected string[] itemids;
    int selectedIndex = -1;

    public void Start() {
        slots = new InventorySlot[slotCount];
        itemids = new string[slotCount];
        for(int i = 0; i < slotCount; i++) {
            GameObject slot = Instantiate(slotPrefab, transform);
            slots[i] = slot.GetComponent<InventorySlot>();
            slots[i].inventoryBar = this;
            slots[i].index = i;
        }
    }

    public void UpdateTextures(string[] itemids) {
        this.itemids = itemids;
        for(int i = 0; i < slotCount; i++) {
            //Debug.Log(itemids[i]);
            if(itemids[i] == "" || itemids[i] == null) {
                slots[i].SetItem(false, null);
            } else if(registry.IsMainItem(itemids[i])) {
                slots[i].SetItem(registry.hasSubItems(itemids[i]), registry.GetItemTexture(itemids[i]));
            } else if(registry.IsSubItem(itemids[i])) {
                slots[i].SetItem(false, registry.GetItemTexture(itemids[i]));
            }
        }
    }

    public abstract void OnSlotHovered(int index, bool isHovered);

    public abstract void OnSlotClicked(int index, bool isSelected);

    public void SelectSlot(int index) {
        if(selectedIndex != -1) {
            slots[selectedIndex].SetSelected(false);
        }
        selectedIndex = index;
        if(selectedIndex != -1)
            slots[selectedIndex].SetSelected(true);
    }
}
