using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 15;
    public LayerMask collisionMask;
    public LayerMask blockMask;
    public LayerMask enemyMask;
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //move the projectile forward
        transform.Translate(Vector3.up * Time.deltaTime * speed);

        // set up raycasting
        Ray ray = new Ray(transform.position, transform.up);
        RaycastHit hit;

        //look for a collision with a reflective surface
        if (Physics.Raycast(ray, out hit, Time.deltaTime * speed + .1f, collisionMask))
        {
            //calculate the reflected angle    
            Vector3 reflectDir = Vector3.Reflect(ray.direction, hit.normal);
            float rotation = 0 - Mathf.Atan2(reflectDir.x, reflectDir.y) * Mathf.Rad2Deg;
            //apply the reflected angle   
            // Debug.Log("reflectDir.y = " + reflectDir.y + " reflectDir.x = " + reflectDir.x + " Rotation = " + rotation);
            transform.eulerAngles = new Vector3(0, 0, rotation);

        } // if it collides with anon reflective surface, destroy the projectile
        else if (Physics.Raycast(ray, out hit, Time.deltaTime * speed + .1f, blockMask))
        {
            Destroy(gameObject);

        } // Collided with enemy
        else if (Physics.Raycast(ray, out hit, Time.deltaTime * speed * .1f, enemyMask))
        {
            // Play the bullet collision animation
            Destroy(gameObject);
            //hit.collider.gameObject.GetComponent<>
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
