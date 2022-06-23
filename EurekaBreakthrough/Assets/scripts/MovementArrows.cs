using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovementArrows : MonoBehaviour
{
    public bool MoveEnabled;
    public GridManager GM;

    public GameObject Arrows;
    public GameObject Left;
    public GameObject Right;
    public GameObject Up;
    public GameObject Down;
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
        else
        {
            if (PCC.gameObject.transform.position.x != Mathf.Round(PCC.gameObject.transform.position.x / 3.2f) * 3.2f || PCC.gameObject.transform.position.y != Mathf.Round(PCC.gameObject.transform.position.y / 3.2f) * 3.2f)
            {
                if (PCC.gameObject.transform.position.x != 9.6)
                {
                    MoveEnabled = true;
                }
                else
                {
                    MoveEnabled = false;
                }
            }
            else
            {
                MoveEnabled = true;
            }
        }

        if (MoveEnabled)
        {
            Arrows.SetActive(true);
        }
        else
        {
            Arrows.SetActive(false);
        }

        {
            if (!PCC.up.active)
            {
                Up.SetActive(false);
            }
            else
            {
                Up.SetActive(true);
            }

            if (!PCC.down.active)
            {
                Down.SetActive(false);
            }
            else
            {
                Down.SetActive(true);
            }

            if (!PCC.left.active)
            {
                Left.SetActive(false);
            }
            else
            {
                Left.SetActive(true);
            }

            if (!PCC.right.active)
            {
                Right.SetActive(false);
            }
            else
            {
                Right.SetActive(true);
            }
        }


    }

    public void MoveUp()
    {
        if (PCC.up.active)
        {
            TargetPoint = new Vector2 (PCC.gameObject.transform.position.x, PCC.gameObject.transform.position.y + GM.TileY);
            PCC.currentInitiative -= 1;
        }
    }
    public void MoveDown()
    {
        if (PCC.down.active)
        {
            TargetPoint = new Vector2(PCC.gameObject.transform.position.x, PCC.gameObject.transform.position.y - GM.TileY);
            PCC.currentInitiative -= 1;
        }
    }
    public void MoveLeft()
    {
        if (PCC.left.active)
        {
            TargetPoint = new Vector2(PCC.gameObject.transform.position.x - GM.TileX, PCC.gameObject.transform.position.y);
            PCC.currentInitiative -= 1;
        }
    }
    public void MoveRight()
    {
        if (PCC.right.active)
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
