using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovementArrows : MonoBehaviour
{
    public bool MoveEnabled;
    public GridManager GM;

    public Button Up;
    public Button Down;
    public Button Left;
    public Button Right;

    public GameObject up;
    public GameObject down;
    public GameObject left;
    public GameObject right;
    public float tileSpeed;
    public Vector2 TargetPoint;
    public PlayerController_Combat PCC;


    // Update is called once per frame
    void Update()
    {
        if (MoveEnabled)
        {
            Up.enabled = true;
            Down.enabled = true;
            Left.enabled = true;
            Right.enabled = true;
        }
        else
        {
            Up.enabled = false;
            Down.enabled = false;
            Left.enabled = false;
            Right.enabled = false;
        }
        transform.position = Vector2.MoveTowards(transform.position, TargetPoint, Time.deltaTime * tileSpeed);

        if (PCC.currentInitiative == 0)
        {
            MoveEnabled = false;
        }
    }

    public void MoveUp()
    {
        TargetPoint = new Vector2 (transform.position.x, transform.position.y + GM.TileY);
        PCC.currentInitiative -= 1;
    }
    public void MoveDown()
    {
        TargetPoint = new Vector2(transform.position.x, transform.position.y - GM.TileY);
        PCC.currentInitiative -= 1;
    }
    public void MoveLeft()
    {
        TargetPoint = new Vector2(transform.position.x - GM.TileX, transform.position.y);
        PCC.currentInitiative -= 1;
    }
    public void MoveRight()
    {
        TargetPoint = new Vector2(transform.position.x + GM.TileX, transform.position.y);
        PCC.currentInitiative -= 1;
    }
}
