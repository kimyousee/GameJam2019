using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
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
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            // trigger the shoot animation
            anim.SetTrigger("shoot");

            // Spawn a bullet
        }
    }
}
