using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeTravel : MonoBehaviour
{
    public Vector3 PlayerStart;
    public Vector3 Enemy1Start;
    public Vector3 Enemy2Start;
    public Vector3 Enemy3Start;

    public GameObject PlayerPrefab;
    public GameObject Enemy1;
    public GameObject Enemy2;
    public GameObject Enemy3;
    public GameObject PlayerPresent;
    public GameObject PlayerFuture;
    public GameObject EnemyPrefab;

    public SwapActivePlayer SAP;
    public GameManager GM;
    public MovementArrows MA;
    public UIManagement UIM;

    public void Travel()
    {
        if (PlayerPresent.transform.position != PlayerStart && PlayerPresent.transform.position != Enemy1Start && PlayerPresent.transform.position != Enemy2Start && PlayerPresent.transform.position != Enemy3Start)
        {
            if (Enemy1 != null)
            {
                Destroy(Enemy1);
            }
            if (Enemy2 != null)
            {
                Destroy(Enemy2);
            }
            if (Enemy3 != null)
            {
                Destroy(Enemy3);
            }
            if (PlayerFuture != null)
            {
                Destroy(PlayerFuture);
            }
            PlayerFuture = PlayerPresent;
            PlayerPresent = Instantiate(PlayerPrefab, PlayerStart, Quaternion.identity);
            Enemy1 = Instantiate(EnemyPrefab, Enemy1Start, Quaternion.identity);
            Enemy2 = Instantiate(EnemyPrefab, Enemy2Start, Quaternion.identity);
            Enemy3 = Instantiate(EnemyPrefab, Enemy3Start, Quaternion.identity);
            PlayerFuture.GetComponent<PlayerController_Combat>().isPresent = false;

            GM.FuturePlayer = GM.PresentPlayer;
            GM.PresentPlayer = PlayerPresent.GetComponent<PlayerController_Combat>();

            SAP.PCCFuture = SAP.PCCPresent;
            SAP.PCCPresent = PlayerPresent.GetComponent<PlayerController_Combat>();
            SAP.CameraFuture = SAP.CameraPresent;
            SAP.CameraPresent = PlayerPresent.GetComponentInChildren(typeof(Camera)).gameObject;
            SAP.CameraPresent.SetActive(false);

            MA.Future = MA.Present;
            MA.Present = PlayerPresent.GetComponent<PlayerController_Combat>();

            UIM.Future = UIM.Present;
            UIM.Present = PlayerPresent.GetComponent<PlayerController_Combat>();

             foreach (var deadEnemy  in GameObject.FindGameObjectsWithTag("DeadEnemy"))
             {
                 Destroy(deadEnemy);
             }

        }
    }
}
