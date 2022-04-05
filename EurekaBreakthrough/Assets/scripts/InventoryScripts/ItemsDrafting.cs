using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class ItemsDrafting : MonoBehaviour
{
    public bool canAttack;
    public int ammo;

    public class Weapon
    {
        public string name { get; set; }
        public bool ranged { get; set; }
        public float accuracy { get; set; }
        public float dmg { get; set; }
        public string dmgType { get; set; }
        public float critChance { get; set; }

        public Weapon(string _name, bool _ranged, float _accuracy, float _dmg, string _dmgType, float _critChance)
        {
            _name = name;
            _ranged = ranged;
            _accuracy = accuracy;
            _dmg = dmg;
            _dmgType = dmgType;
            _critChance = critChance;
        }
    }


    public List<Weapon> weapons = new List<Weapon>();

    void Awake()
    {
        // adding weapon stats, probably could do this a lot easier by importing from text file, not something ive done before
        weapons.Add(new Weapon("War Club", false, 80f, 50f, "bashing", 15f));
        weapons.Add(new Weapon("Sword", false, 85f, 32f, "slashing", 20f));
        weapons.Add(new Weapon("Poison Spear", false, 85f, 25f, "piercing", 10f));
        weapons.Add(new Weapon("Steam Cannon", true, 80f, 60f, "piercing", 5f));
        weapons.Add(new Weapon("Boom Stick", true, 70f, 50f, "piercing", 15f));
        weapons.Add(new Weapon("Hunting Boomerang", true, 90f, 40f, "bashing", 20f));
        weapons.Add(new Weapon("Rifle", true, 75f, 45f, "piercing", 15f));
    }

    void Update()
    {
        // switch for active weapons, then pass stats into dmg stats 
    }

    // need to understand what will determine the weapon the enemy has and replace weapons[i]
    void Attack(Weapon weapon)
    {
        if (!weapon.ranged)// && CloseRange.InRange) to be uncommented when script ported over
        {
            canAttack = true;
        }
        else if (weapon.ranged)// && CloseRange.InRange)
        {
            canAttack = false;
            // swap weapon
        }
        else if (!weapon.ranged)// && MediumRange.InRange) 
        {
            canAttack = false;
        }
        else if (weapon.ranged)// && MediumRange.InRange)
        {
            canAttack = true;
        }

        if (!canAttack)
        {
            // swap weapon
        }

        // generate random number to determine if it hits
        System.Random rnd = new System.Random();
        if (rnd.Next(0, 100) <= weapon.accuracy)
        {
            // check for crit 
            if (rnd.Next(0, 100) <= weapon.critChance)
            {
            //    PlayerController_Combat.maxHealth -= weapon.dmg;
            }
            float dmgtotake = rnd.Next(0, 100) <= weapon.critChance ? weapon.dmg * 2 : weapon.dmg;


        }
        else
        {
            // misses, play miss animation
        }
    }
}
