using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIArrows : MonoBehaviour
{
    public Dictionary<Direction, string> arrowMap = new Dictionary<Direction, string>();

    public GameObject upArrow;
    public GameObject downArrow;
    public GameObject leftArrow;
    public GameObject rightArrow;

    public GameManager gameManager;

    public void ResetArrows() {
        SetArrowActive(Direction.Up, false);
        SetArrowActive(Direction.Down, false);
        SetArrowActive(Direction.Left, false);
        SetArrowActive(Direction.Right, false);
    }

    public void SetArrow(Direction direction, string roomId) {
        arrowMap[direction] = roomId;
        SetArrowActive(direction, roomId != null);
    }

    void SetArrowActive(Direction direction, bool isActive) {
        switch(direction) {
            case Direction.Up:
                upArrow.SetActive(isActive);
                break;
            case Direction.Down:
                downArrow.SetActive(isActive);
                break;
            case Direction.Left:
                leftArrow.SetActive(isActive);
                break;
            case Direction.Right:
                rightArrow.SetActive(isActive);
                break;
        }
    }

    public void OnArrowClick(string dirStr) {
        Direction direction = (Direction) System.Enum.Parse(typeof(Direction), dirStr);
        if(arrowMap.ContainsKey(direction) && arrowMap[direction] != null)
            gameManager.ChangeRoom(arrowMap[direction]);
    }
}
