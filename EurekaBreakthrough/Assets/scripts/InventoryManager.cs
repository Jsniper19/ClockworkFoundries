using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    bool inInventory;
    public GameObject panel;

    public List<Item> itemList = new List<Item>();

    // todo 
    // implement pick up function, add toggleable menu

   public struct Item {
        // Using a simple defense/attack style stat system to test, also using an int system for item types where say 0 is a weapon, 1 is a headpiece etc.
        public Item(int type, int attack, int defense, string name)
        {
            itemType = type;
            attackStat = attack;
            defenseStat = defense;
            itemName = name;
        }

        public int itemType { get; set; }
        public int attackStat { get; set; }
        public int defenseStat { get; set; }
        public string itemName { get; set; }

        // lets vars be accesible to get and set when creating new item
        public override string ToString() => $"({itemType}, {attackStat}, {defenseStat}, {itemName})";
    }


    void Start()
    {
        Item sword = new Item(0, 0, 5, "Sword");
        itemList.Add(sword);
        print(itemList[0]);
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // check if player has hit item and take its stats, make a new Item() and 
    }

    void PickUpItem()
    {

    }

    void UpdateStats()
    {

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
