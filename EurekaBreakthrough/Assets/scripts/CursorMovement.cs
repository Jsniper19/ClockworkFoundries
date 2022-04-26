using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorMovement : MonoBehaviour
{
    public Camera Cam;
    void Update()
    {
        transform.position = new Vector3 (Cam.ScreenToWorldPoint(Input.mousePosition).x, Cam.ScreenToWorldPoint(Input.mousePosition).y, 0);

        if (Cam.isActiveAndEnabled == false || Cam == null)
        {
            Cam = FindObjectOfType<Camera>();
        }
    }
}
