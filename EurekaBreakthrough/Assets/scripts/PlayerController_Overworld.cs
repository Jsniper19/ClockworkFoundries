using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController_Overworld : MonoBehaviour
{
    public int TileSizeX = 1;
    public int TileSizeY = 1;

    public int minTileX;
    public int minTileY;
    public int maxTileX;
    public int maxTileY;
    public float tileSpeed;

    public Vector2 TargetPoint;
    public bool PLAY = true;

    // Update is called once per frame
    void Update()
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
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //if (collision.gameObject.CompareTag("Barrier"))
        {
            Debug.Log("hi");
            TargetPoint = transform.position;
            TargetPoint.x = TargetPoint.x / 3.2f;
            TargetPoint.x = Mathf.Round(TargetPoint.x) * 3.2f;
            TargetPoint.y = TargetPoint.y / 3.2f;
            TargetPoint.y = Mathf.Round(TargetPoint.y) * 3.2f;
        }
    }
}
