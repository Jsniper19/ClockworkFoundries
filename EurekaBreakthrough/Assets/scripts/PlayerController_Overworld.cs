using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController_Overworld : MonoBehaviour
{
    public int TileX = 1;
    public int TileY = 1;


    public float tileSpeed;

    public CollisionCheck up;
    public CollisionCheck down;
    public CollisionCheck left;
    public CollisionCheck right;

    public Vector2 TargetPoint;
    public bool PLAY = true;

    private void Start()
    {
        TargetPoint = transform.position;
    }

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
