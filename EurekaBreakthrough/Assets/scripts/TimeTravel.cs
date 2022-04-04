using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeTravel : MonoBehaviour
{
    public int PlayerStartX;
    public int PlayerStartY;
    public int Enemy1StartX;
    public int Enemy1StartY;
    public int Enemy2StartX;
    public int Enemy2StartY;
    public int Enemy3StartX;
    public int Enemy3StartY;

    public GameObject PlayerCombat;
    public GameObject Enemy1;
    public GameObject Enemy2;
    public GameObject Enemy3;

    void Travel()
    {
        var PlayerPresent = Instantiate(PlayerCombat, new Vector2(PlayerStartX, PlayerStartY), Quaternion.identity);
        var EnemyOne = Instantiate(Enemy1, new Vector2(Enemy1StartX, Enemy1StartY), Quaternion.identity);
        var EnemyTwo = Instantiate(Enemy2, new Vector2(Enemy2StartX, Enemy2StartY), Quaternion.identity);
        var EnemyThree = Instantiate(Enemy3, new Vector2(Enemy3StartX, Enemy3StartY), Quaternion.identity);
    }
}
