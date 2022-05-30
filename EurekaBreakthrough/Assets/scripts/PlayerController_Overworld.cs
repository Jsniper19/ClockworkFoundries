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

    public Vector2 TargetPoint;
    public bool PLAY = true;

    /*void Update()
    {
        if (PLAY)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                TargetPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                TargetPoint.x = TargetPoint.x / 3.2f;
                TargetPoint.x = Mathf.Round(TargetPoint.x) * 3.2f;
                TargetPoint.y = TargetPoint.y / 3.2f;
                TargetPoint.y = Mathf.Round(TargetPoint.y) * 3.2f;
            }

            transform.position = Vector2.MoveTowards(transform.position, TargetPoint, Time.deltaTime * tileSpeed);
        }
    }*/

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, TargetPoint, Time.deltaTime * tileSpeed);
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
        //if (collision.gameObject.CompareTag("Barrier"))
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
