using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovementArrows : MonoBehaviour
{
    public bool MoveEnabled;
    public GridManager GM;

    public GameObject up;
    public GameObject down;
    public GameObject left;
    public GameObject right;
    public GameObject Arrows;
    public float tileSpeed;
    public Vector2 TargetPoint;
    public PlayerController_Combat PCC;

    private void Start()
    {
        TargetPoint = transform.position;
    }
    // Update is called once per frame
    void Update()
    {
        
        if (MoveEnabled && PCC.isSelected)
        {
            up.SetActive(true);
            down.SetActive(true);
            left.SetActive(true);
            down.SetActive(true);
            Arrows.SetActive(true);
        }
        else
        {
            up.SetActive(false);
            down.SetActive(false);
            left.SetActive(false);
            down.SetActive(false);
            Arrows.SetActive(false);
        }
        transform.position = Vector2.MoveTowards(transform.position, TargetPoint, Time.deltaTime * tileSpeed);

        if (PCC.currentInitiative <= 0)
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
