using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float maxHealth;
    public float currentHealth;
    public int maxInitiative;
    public int currentInitiative;
    public bool isPresent;
    public float timeMeter;

    public float TileX;
    public float TileY;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        currentInitiative = maxInitiative;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void MoveUp()
    {
        gameObject.transform.position = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y + TileY);
    }

    void MoveDown()
    {
        gameObject.transform.position = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y - TileY);
    }

    void MoveLeft()
    {
        gameObject.transform.position = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y - TileX);
    }

    void MoveRight()
    {
        gameObject.transform.position = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y + TileX);
    }
}
