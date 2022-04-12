using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float maxHealth;
    public float currentHealth;
    public GameObject PlayerCharacter;
    public GridManager GM;

    public ColliderActivation CloseRange;
    public ColliderActivation MediumRange;

    public int Ammo;

    public float poisonDamageMod;
    [Header("Enter Weapon names with capital letters and NO spaces, IE WarClub")]
    public string equippedRanged;
    public string equippedMelee;
    int melee, ranged;

    #region Weapons
    // weapon class to store/access weapons easily
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
        new Weapon("WarClub", false, 80f, 50f, "bashing", 15f),
        new Weapon("Sword", false, 85f, 32f, "slashing", 20f),
        new Weapon("SteamCannon", true, 80f, 60f, "piercing", 5f),
        new Weapon("BoomStick", true, 70f, 50f, "piercing", 15f),
        new Weapon("Rifle", true, 75f, 45f, "piercing", 15f)
    };
    #endregion

    void Awake()
    {
        currentHealth = maxHealth;

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
    }

    public void DecideAction()
    {
        if (CloseRange.InRange)
        {
            if (Ammo > 0)
            {
                Move(false);
            }
            else
            {
                Attack(weapons[melee]);
            }
        }
        else
        {
            if (Ammo > 0)
            {
                if (MediumRange.InRange)
                {
                    Attack(weapons[ranged]);
                }
                else
                {
                    Move(true);
                }
            }
        }
    }

    void Attack(Weapon weapon)
    {
        // generate random number to determine if it hits
        System.Random rnd = new System.Random();
        if (rnd.Next(0, 100) <= weapon.accuracy)
        {
            float dmgToTake = rnd.Next(0, 100) <= weapon.critChance ? weapon.dmg * 2 : weapon.dmg; // need to change this to include defense stats too
            PlayerController_Combat.currentHealth -= dmgToTake;   
            print("Damage: " + dmgToTake + " GameObject: " + this.gameObject.name);

            if (weapon.ranged == true) Ammo -= 1;
        }
        else
        {
            // misses, play miss animation
        }
        //GM.EnemyInitiative -= 1;
    }

    void Move(bool forward)
    {
        var RelPosX = transform.position.x - PlayerCharacter.transform.position.x;
        var RelPosY = transform.position.y - PlayerCharacter.transform.position.y;

        if (RelPosX > -RelPosY || RelPosX < RelPosY)
        {
            //up
        }
        else if (RelPosX > RelPosY || RelPosX < -RelPosY)
        {
            //down
        }
        else if (RelPosX > -RelPosY || RelPosX > RelPosY)
        {
            //right
        }
        else if (RelPosX < RelPosY || RelPosX < -RelPosY)
        {
            //left
        }
    }
}