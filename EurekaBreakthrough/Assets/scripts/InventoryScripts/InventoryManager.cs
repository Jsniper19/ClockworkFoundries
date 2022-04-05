using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    bool inInventory;
    public GameObject panel;

    public List<Item> itemList = new List<Item>();

    // todo 
    // implement pick up function,

   public struct Item {
        // Using a simple defense/attack style stat system to test, also using an int system for item types where say 0 is a weapon, 1 is a headpiece etc.
        public Item(int type, int attack, int defense, string name, int index, bool equipped)
        {
            itemType = type;
            attackStat = attack;
            defenseStat = defense;
            itemName = name;
            indexPos = index;
            isEquipped = equipped;
        }

        public int itemType { get; set; }
        public int attackStat { get; set; }
        public int defenseStat { get; set; }
        public int indexPos { get; set; }
        public string itemName { get; set; }
        public bool isEquipped { get; set; }  

        // lets vars be accesible to get and set when creating new item
        public override string ToString() => $"({itemType}, {attackStat}, {defenseStat}, {itemName}, {indexPos}, {isEquipped})";
    }


    void Start()
    {

    }
    
    void Update()
    {
        // Handles Inventory GUI toggling
        if (Input.GetKeyDown(KeyCode.I))
        {
            inInventory = toggleInventory();
        }

        if (inInventory == true)
        {
            panel.gameObject.SetActive(true);
        }
        else panel.gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        // check if player has hit item and take its stats, delete other item
        if (col.gameObject.CompareTag("Item"))
        {
            ItemScript a = col.gameObject.GetComponent<ItemScript>();
            if (a != null)
            {
                PickUpItem(a.itemtype, a.attackstat, a.defensestat, a.itemname);
            }
        }
    }

    void PickUpItem(int itemtype, int attackstat, int defensestat, string itemname)
    {
        // index counter,
        int i = 0;
        itemList.Add(new Item(itemtype, attackstat, defensestat, itemname, i, false) { itemName = itemname });
        print(itemList[i]);
        i++;
    }

    void UpdateStats()
    {
        // search through list and retreive all equipped items, then add those stats to characters base stats
    }

    bool toggleInventory()
    {
        if (Time.timeScale == 0f)
        {
            Time.timeScale = 1f;
            return (false);
        }
        else
        {
            Time.timeScale = 0f;
            return (true);
        }
    }
}
