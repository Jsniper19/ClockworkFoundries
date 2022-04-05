using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float maxHealth;
    public float currentHealth;
    public GameObject PlayerCharacter;
    public GridManager GM;


    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Attack()
    {

    }

    void Move()
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
