using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIInventory : MonoBehaviour
{
    public void SetShow(bool show) {
        gameObject.GetComponent<Animator>().SetBool("shouldShow", show);
    }
}
