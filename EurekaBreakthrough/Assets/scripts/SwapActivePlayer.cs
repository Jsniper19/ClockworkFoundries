using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwapActivePlayer : MonoBehaviour
{
    public Camera CameraPresent;
    public Camera CameraFuture;
    public PlayerController_Combat PCCPresent;
    public PlayerController_Combat PCCFuture;
    public MovementArrows MA;
    public UIManagement UIM;

    public bool present;

    public void SwapPlayer()
    {
        if (!present)
        {
            CameraPresent.enabled = true;
            CameraFuture.enabled = false;
            PCCPresent.isSelected = true;
            PCCFuture.isSelected = false;
            MA.PCC = MA.Present;
            UIM.Set = UIM.Present;
            present = true;
        }
        else
        {
            CameraFuture.enabled = true;
            CameraPresent.enabled = false;
            PCCPresent.isSelected = false;
            PCCFuture.isSelected = true;
            MA.PCC = MA.Future;
            UIM.Set = UIM.Future;
            present = false;
        }
    }
}
