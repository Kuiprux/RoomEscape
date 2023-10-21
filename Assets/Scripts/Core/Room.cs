using System;
using System.Collections;
using System.Collections.Generic;
using AYellowpaper.SerializedCollections;
using UnityEngine;

public class Room : MonoBehaviour
{
    [HideInInspector]
    public GameManager gameManager;
    [HideInInspector]
    public InventoryManager inventoryManager;

    [SerializedDictionary("Direction", "Room ID")]
    public SerializedDictionary<Direction, string> AdjecentRooms;

    public void Start() {
        foreach(Transform child in transform) {
            RoomPart roomPart = child.GetComponent<RoomPart>();
            if(roomPart != null) {
                roomPart.room = this;
            }
        }
    }

    public void MoveRoom() {
        if(gameManager == null) {
            //Debug.Log("Moving to " + gameObject.name);
        } else {
            gameManager.MoveRoom(gameObject.name);
        }
    }

    public void AcquireItem(string itemId) {
        if(inventoryManager == null) {
            //Debug.Log(itemId + " acquired");
        } else {
            inventoryManager.AcquireItem(itemId);
        }
    }

}
