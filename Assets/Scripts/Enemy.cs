using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    /**
     * Called when the enemy gets hit by a projectile
     */
    public void shoot()
    {
        // Play animation
        // Wait until animation is done
        // Update game
        GameController controller = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        controller.killEnemy();

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
