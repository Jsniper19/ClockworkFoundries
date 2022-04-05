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

    public float DamageLong;
    public string TypeLong;
    public float AccuracyLong;
    public float CritLong;

    public float DamageClose;
    public string TypeClose;
    public float AccuracyClose;
    public float CritClose;


    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (CloseRange.InRange)
        {
            if (Ammo > 0)
            {
                Move(false);
            }
            else
            {
                Attack();
            }
        }
        else
        {
            if (Ammo > 0)
            {
                if (MediumRange.InRange)
                {
                    Attack();
                }
                else
                {
                    Move(true);
                }
            }
        }
    }


    //Hamish complete this to get the enemy to attack
    void Attack()
    {
        if (Ammo < 0)
        {

        }
        else
        {

        }
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
