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
        return "";
    }

    public bool UseActiveItem() {
        return false;
    }

    public void OnActiveItemChanged(string itemId) {
        activeItem = itemId;
        //Debug.Log("Active item changed to " + itemId);
    }
}