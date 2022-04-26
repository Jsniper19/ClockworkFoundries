using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController_Combat : MonoBehaviour
{
    public float maxHealth;
    public static float currentHealth; // need health to be static to be accessed to by enemy attack script
    public int maxInitiative;
    public int currentInitiative;
    public bool isPresent;
    public float timeMeter;
    public bool isSelected;
    public ColliderActivation CA;

    public string equippedWeapon;
    public Weapon _weapon;

    public class Weapon
    {
        // weapon vars, can add the gameobject itself later ?? Maybe add ammou type here to make counting ammo of diff types easier
        public string name { get; set; }
        public bool ranged { get; set; }
        public float accuracy { get; set; }
        public float dmg { get; set; }
        public string dmgType { get; set; }
        public float critChance { get; set; }

        public Weapon(string _name, bool _ranged, float _accuracy, float _dmg, string _dmgType, float _critChance)
        {
            name = _name;
            ranged = _ranged;
            accuracy = _accuracy;
            dmg = _dmg;
            dmgType = _dmgType;
            critChance = _critChance;
        }

        public override string ToString() => $"({name}, {ranged}, {accuracy}, {dmg}, {dmgType}, {critChance})";
    }

    public List<Weapon> weapons = new List<Weapon>(){
        new Weapon("WarClub", false, 80f, 50f, "bashing", 15f),
        new Weapon("Sword", false, 85f, 32f, "slashing", 20f),
        new Weapon("SteamCannon", true, 80f, 60f, "piercing", 5f),
        new Weapon("BoomStick", true, 70f, 50f, "piercing", 15f),
        new Weapon("Rifle", true, 75f, 45f, "piercing", 15f)
    };

    void Start()
    {
        currentHealth = maxHealth;
        currentInitiative = maxInitiative;
    }

    public void Attack()
    {
        if (currentInitiative > 1)
        {
            for (int i = 0; i < weapons.Count; i++)
            {
                if (weapons[i].name == equippedWeapon)
                {
                    _weapon = weapons[i];
                }
            }

            System.Random rnd = new System.Random();
            if (rnd.Next(0, 100) <= _weapon.accuracy)
            {
                float dmgToTake = rnd.Next(0, 100) <= _weapon.critChance ? _weapon.dmg * 2 : _weapon.dmg;
            }
        }
    }

    void TestFunction()
    {
        int initiativeCost = 1;
        currentInitiative -= initiativeCost;

        Debug.Log("Selection Successful");
    }

    public void NewTurn()
    {
        currentInitiative = maxInitiative;
        timeMeter += 1;
    }

    private void Update()
    {
        
    }
}
