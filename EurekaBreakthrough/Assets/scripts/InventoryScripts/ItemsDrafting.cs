using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class ItemsDrafting : MonoBehaviour
{
    public bool canAttack;
    [Header("Enter Weapon names with capital letters and spaces, IE War Club")]
    public string equippedRanged;
    public string equippedMelee;
    int melee, ranged;
    public float poisonDamageMod;

    #region Weapons
    // data structure for weapons
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

    // storing weapon stats 
    public List<Weapon> weapons = new List<Weapon>(){
        new Weapon("War Club", false, 80f, 50f, "bashing", 15f),
        new Weapon("Sword", false, 85f, 32f, "slashing", 20f),
        new Weapon("Poison Spear", false, 85f, 25f, "piercing", 10f),
        new Weapon("Steam Cannon", true, 80f, 60f, "piercing", 5f),
        new Weapon("Boom Stick", true, 70f, 50f, "piercing", 15f),
        new Weapon("Hunting Boomerang", true, 90f, 40f, "bashing", 20f),
        new Weapon("Rifle", true, 75f, 45f, "piercing", 15f)
    };
    #endregion

    void Start()
    {
        // find equipped weapon
        for (int i = 0; i < weapons.Count; i++)
        {
            if (weapons[i].name == equippedRanged)
            {
                ranged = i;
            }
            else if (weapons[i].name == equippedMelee)
            {
                melee = i;
            }
        }

        print(weapons[2]);

        Attack(weapons[melee]);
    }

    void Update()
    {
      /*  if (CloseRange.InRange)
        {
            if (Ammo > 0)
            {
                Move(false);
            }
            else
            {
                Attack(weapon[melee]);
            }
        }
        else
        {
            if (Ammo > 0)
            {
                if (MediumRange.InRange)
                {
                    Attack(weapon[ranged]);
                }
                else
                {
                    Move(true);
                }
            }
        }*/
    }


    void Attack(Weapon weapon)
    {
        // generate random number to determine if it hits
        System.Random rnd = new System.Random();
        if (rnd.Next(0, 100) <= weapon.accuracy)
        {
            float dmgToTake = rnd.Next(0, 100) <= weapon.critChance ? weapon.dmg * 2 : weapon.dmg; // need to change this to include defense stats too
            // PlayerController_Combat.maxHealth -= dmgtotake; need maxhealth to be a static var in playercontroller
            print(dmgToTake);

            // checking to deal poison damage
            if (weapons[melee].name == "Poison Spear")
            {
                /* count turns, will add this when we have turn order finished
                if (turnCount >= 3)
                {
                    PlayerController_Combat.maxHealth -= weapons[melee].dmg * poisonDamageMod;
                }
                 */
            }
        }
        else
        {
            // misses, play miss animation
        }
    }
}