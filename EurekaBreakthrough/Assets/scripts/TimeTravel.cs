using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeTravel : MonoBehaviour
{
    public float PlayerStartX;
    public float PlayerStartY;
    public float Enemy1StartX;
    public float Enemy1StartY;
    public float Enemy2StartX;
    public float Enemy2StartY;
    public float Enemy3StartX;
    public float Enemy3StartY;

    public GameObject PlayerCombat;
    public GameObject Enemy1;
    public GameObject Enemy2;
    public GameObject Enemy3;
    public GameObject PlayerFuture;
    public GameObject Enemy1Future;
    public GameObject Enemy2Future;
    public GameObject Enemy3Future;

    public void Travel()
    {
        var PlayerPresent = Instantiate(PlayerCombat, new Vector2(PlayerStartX, PlayerStartY), Quaternion.identity);
        var EnemyOne = Instantiate(Enemy1, new Vector2(Enemy1StartX, Enemy1StartY), Quaternion.identity);
        var EnemyTwo = Instantiate(Enemy2, new Vector2(Enemy2StartX, Enemy2StartY), Quaternion.identity);
        var EnemyThree = Instantiate(Enemy3, new Vector2(Enemy3StartX, Enemy3StartY), Quaternion.identity);
        PlayerFuture.GetComponent<PlayerController_Combat>().isPresent = false;
        if (Enemy1Future.activeInHierarchy)
        {
            Enemy1Future.SetActive(false);
        }
        if (Enemy2Future.activeInHierarchy)
        {
            Enemy2Future.SetActive(false);
        }
        if (Enemy3Future.activeInHierarchy)
        {
            Enemy3Future.SetActive(false);
        }
    }
}
