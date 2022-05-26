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
        if (FuturePlayer != null)
        {
            if (PresentPlayer.currentInitiative < FuturePlayer.currentInitiative)
            {
                EnemyInitiative = 10 - PresentPlayer.currentInitiative;
            }
            else
            {
                EnemyInitiative = 10 - FuturePlayer.currentInitiative;
            }
        }
        else
        {
            EnemyInitiative = 10 - PresentPlayer.currentInitiative;
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
                    if (Enemy1 != null)
                    {
                        Enemy1.GetComponent<EnemyController>().DecideAction();
                        EnemyCount = 2;
                        EnemyInitiative--;
                    }
                    else
                    {
                        EnemyCount++;
                    }
                }
                else if (EnemyCount == 2)
                {
                    if (Enemy2 != null)
                    {
                        Enemy2.GetComponent<EnemyController>().DecideAction();
                        EnemyCount = 3;
                        EnemyInitiative--;
                    }
                    else
                    {
                        EnemyCount++;
                    }
                }
                else if (EnemyCount == 3)
                {
                    if (Enemy3 != null)
                    {
                        Enemy3.GetComponent<EnemyController>().DecideAction();
                        EnemyCount = 1;
                        EnemyInitiative--;
                    }
                    else
                    {
                        EnemyCount++;
                    }
                }
            }
            else
            {
                turnIsPlayers = true;
                PresentPlayer.NewTurn();
                if (FuturePlayer != null)
                {
                    FuturePlayer.NewTurn();
                }
            }
        }
    }
}
