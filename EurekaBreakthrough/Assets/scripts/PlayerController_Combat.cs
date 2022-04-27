using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController_Combat : MonoBehaviour
{
    public float maxHealth;
    public float currentHealth; // need health to be static to be accessed to by enemy attack script
    public int maxInitiative;
    public int currentInitiative;
    public bool isPresent;
    public float timeMeter;
    public bool isSelected;
    public ColliderActivation CA;

    public string equippedWeapon;
    public Weapon _weapon;

    public ColliderActivation closeRange;
    public ColliderActivation longRange;

    public float dmgToTake;
    public Text textPrefab;

    public class Weapon
    {
        // weapon vars, can add the gameobject itself later ?? Maybe add ammo type here to make counting ammo of diff types easier
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
        new Weapon("WarClub", false, 80f, 20f, "bashing", 15f),
        new Weapon("Sword", false, 85f, 16f, "slashing", 20f),
        new Weapon("SteamCannon", true, 80f, 25f, "piercing", 5f),
        new Weapon("BoomStick", true, 70f, 18f, "piercing", 15f),
        new Weapon("Rifle", true, 75f, 20f, "piercing", 15f)
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

            if (_weapon.ranged == true && longRange.Target)
            {
                TakeDamage(_weapon);
            }
            else if (_weapon.ranged == false && closeRange.Target)
            {
                TakeDamage(_weapon);
            }
            else if (_weapon.ranged == true && closeRange.Target)
            {
                TakeDamage(_weapon);
            }
        }
    }

    void TakeDamage(Weapon weapon)
    {
        System.Random rnd = new System.Random();
        if (rnd.Next(0, 100) <= _weapon.accuracy)
        {
            dmgToTake = rnd.Next(0, 100) <= _weapon.critChance ? _weapon.dmg * 2 : _weapon.dmg;
            Debug.Log("hit");
        }
        
        Text dmgText = Instantiate(textPrefab, CA.TargetEnemy.GetComponentInChildren<Canvas>().transform);
        dmgText.text = dmgToTake.ToString();
        Destroy(dmgText, 1.5f);

        CA.TargetEnemy.GetComponent<EnemyController>().currentHealth -= dmgToTake;
        Debug.Log("attacking");
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
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (CA.TargetEnemy != null)
            {
                Attack();
                Debug.Log("attack");
                currentInitiative -= 1;
            }
        }        
    }
}