using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public InventoryManager inventoryManager;
    public InspectionPanel inspectionPanel;
    public Registry registry;
    public UIArrows arrows;

    public string curRoomId;

    void Start()
    {
        registry.gameManager = this;
        registry.inventoryManager = inventoryManager;

        foreach(var room in registry.roomMap) {
            room.Value.gameManager = this;
            room.Value.inventoryManager = inventoryManager;
        }

        HideAllRooms();

        ChangeRoom(curRoomId);
    }

    void HideAllRooms() {
        foreach(var room in registry.roomMap) {
            room.Value.gameObject.SetActive(false);
        }
    }

    public void ChangeRoom(string roomId) {
        if(curRoomId != null && curRoomId != "") {
            registry.roomMap[curRoomId].gameObject.SetActive(false);
        }
        if(roomId != null && roomId != "") {
            curRoomId = roomId;
            registry.roomMap[roomId].gameObject.SetActive(true);

            UpdateArrows();
        }
    }

    void UpdateArrows() {
        arrows.ResetArrows();

        if(curRoomId == "")
            return;
        foreach(var arrow in registry.roomMap[curRoomId].GetComponent<Room>().AdjecentRooms) {
            arrows.SetArrow(arrow.Key, arrow.Value);
        }
    }

    public void MoveRoom(string dirStr) { 
        Direction direction = (Direction) Enum.Parse(typeof(Direction), dirStr);
        string roomId = registry.roomMap[registry.roomMap[curRoomId].name].GetComponent<Room>().AdjecentRooms[direction];
        if(roomId != null)
            ChangeRoom(roomId);
    }

    public void ShowInspectionPanel(string itemid)
    {
        Sprite inspectionImage = registry.GetItemInspectionImage(itemid);
        if(inspectionImage != null) {
            inspectionPanel.ShowPanel(inspectionImage);
        }
    }
}
