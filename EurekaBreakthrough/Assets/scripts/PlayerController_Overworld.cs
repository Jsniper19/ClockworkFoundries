using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController_Overworld : MonoBehaviour
{
    public float TileX = 1;
    public float TileY = 1;


    public float tileSpeed;

    public CollisionCheck up;
    public CollisionCheck down;
    public CollisionCheck left;
    public CollisionCheck right;

    public GameObject Up;
    public GameObject Down;
    public GameObject Left;
    public GameObject Right;
    public bool MoveEnabled;
    public GameObject Arrows;



    public Vector2 TargetPoint;
    public bool PLAY = true;

    private void Start()
    {
        TargetPoint = transform.position;
    }

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, TargetPoint, Time.deltaTime * tileSpeed);
        {
            if (!up.active)
            {
                Up.SetActive(false);
            }
            else
            {
                Up.SetActive(true);
            }

            if (!down.active)
            {
                Down.SetActive(false);
            }
            else
            {
                Down.SetActive(true);
            }

            if (!left.active)
            {
                Left.SetActive(false);
            }
            else
            {
                Left.SetActive(true);
            }

            if (!right.active)
            {
                Right.SetActive(false);
            }
            else
            {
                Right.SetActive(true);
            }
        }

        //if (transform.position.x != Mathf.Round(transform.position.x / 3.2f) * 3.2f || transform.position.y != Mathf.Round(transform.position.y / 3.2f) * 3.2f)
        if (transform.position.x == TargetPoint.x && transform.position.y == TargetPoint.y)
        {
            MoveEnabled = true;
        }
        else
        {
            MoveEnabled = false;
            
        }

        if (MoveEnabled)
        {
            Arrows.SetActive(true);
        }
        else
        {
            Arrows.SetActive(false);
        }
    }

    public void MoveUp()
    {
        if (up.active)
        {
            TargetPoint = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y + TileY);
        }
    }
    public void MoveDown()
    {
        if (down.active)
        {
            TargetPoint = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y - TileY);
        }
    }
    public void MoveLeft()
    {
        if (left.active)
        {
            TargetPoint = new Vector2(gameObject.transform.position.x - TileX, gameObject.transform.position.y);
        }
    }
    public void MoveRight()
    {
        if (right.active)
        {
            TargetPoint = new Vector2(gameObject.transform.position.x + TileX, gameObject.transform.position.y);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Barrier"))
        {
            Debug.Log("hi");
            TargetPoint = transform.position;
            TargetPoint.x = TargetPoint.x / TileX;
            TargetPoint.x = Mathf.Round(TargetPoint.x) * TileX;
            TargetPoint.y = TargetPoint.y / TileY;
            TargetPoint.y = Mathf.Round(TargetPoint.y) * TileY;
        }
    }
}
