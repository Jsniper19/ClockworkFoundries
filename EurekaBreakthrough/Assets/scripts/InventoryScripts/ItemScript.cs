using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemScript : MonoBehaviour
{
    public int itemtype, attackstat, defensestat;
    public string itemname;

    private void Awake()
    {
        itemname = this.gameObject.name;
    }
}
