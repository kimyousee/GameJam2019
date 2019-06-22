using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject projectile;
    public float cooldown;
    private float timer;

    bool canShoot = true;

    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // When the LMB is pressed
        if (Input.GetKeyDown(KeyCode.Mouse0) && canShoot == true)
        {
            // trigger the shoot animation
            anim.SetTrigger("shoot");

            // Spawn a bullet
            GameObject bullet = (GameObject)Instantiate(projectile, transform.position, transform.rotation);

            //trigger cooldown
            canShoot = false;
            Debug.Log("Can Shoot = FALSE");
            timer = cooldown;
        }

        timer = timer - Time.deltaTime;

        if (timer <= 0)
        {
            canShoot = true;
            Debug.Log("Can Shoot = TRUE");
        }

    }

}
