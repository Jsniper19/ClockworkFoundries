using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderActivation : MonoBehaviour
{
    public bool InRange;
    public bool CanMove;
    public bool Target;
    public GameObject TargetEnemy;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            InRange = true;
        }
        if (collision.CompareTag("Barrier"))
        {
            CanMove = false;
        }
        if (collision.CompareTag("Enemy"))
        {
            Target = true;
            TargetEnemy = collision.gameObject;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            InRange = true;
        }
        if (collision.CompareTag("Barrier"))
        {
            CanMove = false;
        }
        if (collision.CompareTag("Enemy"))
        {
            Target = true;
            TargetEnemy = collision.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            InRange = false;
        }
        if (collision.CompareTag("Barrier"))
        {
            CanMove = true;
        }
        if (collision.CompareTag("Enemy"))
        {
            Target = false;
            TargetEnemy = null;
        }
    }
}