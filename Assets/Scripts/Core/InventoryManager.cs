using UnityEngine;

public class InventoryManager : MonoBehaviour {

    public Registry registry;

    public MainInventoryBar mainInventoryBar;
    
    public string[] mainItems = new string[6];
    public string[][] subItems = new string[6][];

    public string activeItem = "";

    public GameObject subItemPanel;

    void Start() {
        for(int i = 0; i < 6; i++) {
            subItems[i] = new string[6];
        }
    }

    public void AcquireItem(string itemId) {
        //Debug.Log("Acquired " + itemId);
        //Debug.Log(registry.IsMainItem(itemId));

        if(registry.IsMainItem(itemId)) {
            int index = -1;
            for(int i = 0; i < mainItems.Length; i++) {
                if(mainItems[i] == itemId || mainItems[i] == "") {
                    index = i;
                    break;
                }
            }
            if(index == -1) {
                Debug.Log("Inventory full");
                return;
            }
            mainItems[index] = itemId;

            //print mainItems
        } else if(registry.IsSubItem(itemId)) {
            int mainIndex = -1;
            string mainItemId = registry.GetMainItemId(itemId);
            for(int i = 0; i < mainItems.Length; i++) {
                if(mainItems[i] == mainItemId || mainItems[i] == "") {
                    mainIndex = i;
                    break;
                }
            }
            if(mainIndex == -1) {
                Debug.Log("Inventory full");
                return;
            }
            mainItems[mainIndex] = mainItemId;
            int subIndex = -1;
            for(int j = 0; j < subItems[mainIndex].Length; j++) {
                if(subItems[mainIndex][j] == itemId || subItems[mainIndex][j] == "" || subItems[mainIndex][j] == null) {
                    subIndex = j;
                    break;
                }
            }
            if(subIndex == -1) {
                Debug.Log("Inventory full");
                return;
            }
            subItems[mainIndex][subIndex] = itemId;
        }
        mainInventoryBar.UpdateTextures(mainItems); 
    }

    public string GetActiveItem() {
        return activeItem;
    }

    public bool UseActiveItem() {
        string mainItemId = "";
        string subItemId = "";
        if(registry.IsMainItem(activeItem)) {
            mainItemId = activeItem;
        } else if(registry.IsSubItem(activeItem)) {
            mainItemId = registry.GetMainItemId(activeItem);
            subItemId = activeItem;
        }

        int mainIndex = -1;
        for(int i = 0; i < mainItems.Length; i++) {
            if(mainItems[i] == mainItemId) {
                mainIndex = i;
                break;
            }
        }

        if(mainIndex == -1) {
            Debug.Log("Item not found");
            return false;
        }

        if(subItemId != "") {
           int subIndex = -1;
            for(int j = 0; j < subItems[mainIndex].Length; j++) {
                if(subItems[mainIndex][j] == subItemId) {
                    subIndex = j;
                    break;
                }
            }
            if(subIndex == -1) {
                Debug.Log("Item not found");
                return false;
            }

            for(int i = subIndex; i < subItems[mainIndex].Length - 1; i++) {
                subItems[mainIndex][i] = subItems[mainIndex][i + 1];
            }
            subItems[mainIndex][subItems[mainIndex].Length - 1] = "";
        }

        if(subItemId == "" || subItems[mainIndex][0] == "" || subItemId == null || subItems[mainIndex][0] == null) {
            for(int i = mainIndex; i < mainItems.Length - 1; i++) {
                mainItems[i] = mainItems[i + 1];
                subItems[i] = subItems[i + 1];
            }
            mainItems[mainItems.Length - 1] = "";
            subItems[subItems.Length - 1] = new string[6];
        }

        mainInventoryBar.UpdateTextures(mainItems);
        OnActiveItemChanged("");
        mainInventoryBar.UnselectSlot();

        return true;
    }

    public void OnActiveItemChanged(string itemId) {
        activeItem = itemId;
        //Debug.Log("Active item changed to " + itemId);
    }
}