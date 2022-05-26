using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovementArrows : MonoBehaviour
{
    public bool MoveEnabled;
    public GridManager GM;

    public CollisionCheck up;
    public CollisionCheck down;
    public CollisionCheck left;
    public CollisionCheck right;
    public GameObject Arrows;
    public float tileSpeed;
    public Vector2 TargetPoint;
    public PlayerController_Combat Future;
    public PlayerController_Combat Present;
    public PlayerController_Combat PCC;

    private void Start()
    {
        TargetPoint = PCC.gameObject.transform.position;
        PCC = Present;
    }
    // Update is called once per frame
    void Update()
    {
        PCC.gameObject.transform.position = Vector2.MoveTowards(PCC.gameObject.transform.position, TargetPoint, Time.deltaTime * tileSpeed);

        if (PCC.currentInitiative <= 0)
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
        TargetPoint = new Vector2 (PCC.gameObject.transform.position.x, PCC.gameObject.transform.position.y + GM.TileY);
        PCC.currentInitiative -= 1;
        }
    }
    public void MoveDown()
    {
        if (down.active)
        {
            TargetPoint = new Vector2(PCC.gameObject.transform.position.x, PCC.gameObject.transform.position.y - GM.TileY);
            PCC.currentInitiative -= 1;
        }
    }
    public void MoveLeft()
    {
        if (left.active)
        {
            TargetPoint = new Vector2(PCC.gameObject.transform.position.x - GM.TileX, PCC.gameObject.transform.position.y);
            PCC.currentInitiative -= 1;
        }
    }
    public void MoveRight()
    {
        if (right.active)
        {
            TargetPoint = new Vector2(PCC.gameObject.transform.position.x + GM.TileX, PCC.gameObject.transform.position.y);
            PCC.currentInitiative -= 1;
        }
    }

    public void ResetTarget()
    {
        TargetPoint = PCC.gameObject.transform.position;
    }
}
