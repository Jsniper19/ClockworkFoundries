using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool turnIsPlayers;
    public int EnemyInitiative;
    public int EnemyCount;

    public PlayerController_Combat PresentPlayer;
    public PlayerController_Combat FuturePlayer;

    public GameObject Enemy1;
    public GameObject Enemy2;
    public GameObject Enemy3;

    public void EndTurn()
    {
        if (PresentPlayer.currentInitiative < FuturePlayer.currentInitiative)
        {
            EnemyInitiative = 10 - PresentPlayer.currentInitiative;
        }
        else
        {
            EnemyInitiative = 10 - FuturePlayer.currentInitiative;
        }
        turnIsPlayers = false;
    }

    private void Update()
    {
        if (!turnIsPlayers)
        {
            if (EnemyInitiative > 0)
            {
                if (EnemyCount == 1)
                {
                    Enemy1.GetComponent<EnemyController>().DecideAction();
                    EnemyCount = 2;
                    EnemyInitiative--;
                }
                else if (EnemyCount == 2)
                {
                    Enemy2.GetComponent<EnemyController>().DecideAction();
                    EnemyCount = 3;
                    EnemyInitiative--;
                }
                else if (EnemyCount == 3)
                {
                    Enemy3.GetComponent<EnemyController>().DecideAction();
                    EnemyCount = 1;
                    EnemyInitiative--;
                }
            }
            else
            {
                turnIsPlayers = true;
                PresentPlayer.NewTurn();
                FuturePlayer.NewTurn();
            }
        }
    }
}
