using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderActivation : MonoBehaviour
{
    public bool InRange;
    public bool CanMove;

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
    }
}