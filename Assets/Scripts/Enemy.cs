using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    /**
     * Called when the enemy gets hit by a projectile
     */
    public void shoot()
    {
        // Play animation
        anim.SetBool("isDead", true);

    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
