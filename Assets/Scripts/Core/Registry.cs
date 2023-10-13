using System;
using System.Collections.Generic;
using UnityEngine;
using AYellowpaper.SerializedCollections;

public class Registry : MonoBehaviour {
    
    [SerializedDictionary("ID", "Room")]
    public SerializedDictionary<string, Room> roomMap = new SerializedDictionary<string, Room>();
    [SerializedDictionary("ID", "MainItem")]
    public SerializedDictionary<string, MainItemData> mainItemMap = new SerializedDictionary<string, MainItemData>();
    [SerializedDictionary("ID", "SubItem")]
    public SerializedDictionary<string, SubItemData> subItemMap = new SerializedDictionary<string, SubItemData>();

    [HideInInspector]
    public GameManager gameManager;
    [HideInInspector]
    public InventoryManager inventoryManager;

    void Start() {
        foreach(var mainItem in mainItemMap) {
            foreach(var subItemId in mainItem.Value.subItemIds) {
                subItemMap[subItemId].mainItemId = mainItem.Key;
            }
        }
    }

    public bool IsMainItem(string itemId) {
        return itemId != null && mainItemMap.ContainsKey(itemId);
    }

    public bool IsSubItem(string itemId) {
        return itemId != null && subItemMap.ContainsKey(itemId);
    }

    public string GetMainItemId(string itemId) {
        if(IsSubItem(itemId)) {
            return subItemMap[itemId].mainItemId;
        }
        return null;
    }

    public bool hasSubItems(string itemId) {
        if(IsMainItem(itemId)) {
            return mainItemMap[itemId].subItemIds.Length > 0;
        }
        return false;
    }

    public Sprite GetItemTexture(string itemId) {
        if(IsMainItem(itemId)) {
            return mainItemMap[itemId].texture;
        } else if(IsSubItem(itemId)) {
            return subItemMap[itemId].texture;
        }
        return null;
    }

    public Sprite GetItemInspectionImage(string itemid)
    {
        if(IsMainItem(itemid)) {
            return mainItemMap[itemid].inspectionImage;
        } else if(IsSubItem(itemid)) {
            return subItemMap[itemid].inspectionImage;
        }
        return null;
    }

    public string[] GetSubItems(string itemId) {
        if(IsMainItem(itemId)) {
            return mainItemMap[itemId].subItemIds;
        }
        return null;
    }
}

[Serializable]
public class MainItemData {
    public Sprite texture;
    public Sprite inspectionImage;
    public string[] subItemIds;
}

[Serializable]
public class SubItemData {
    public Sprite texture;
    public Sprite inspectionImage;
    [HideInInspector]
    public string mainItemId;
}