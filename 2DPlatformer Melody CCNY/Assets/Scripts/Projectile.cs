
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    //IN CLASS COLLEGE NOW MW

    //GLOBAL VARIABLES
    public Rigidbody2D projectileRb; //declare and set the Rigidbody for the Projectile in the inspector
    public float speed = 4; //declare how fast the projectile will go (alter in inspector)

    //projectile countdown timer stuff
    public float projectileLife = 2; //how long the projectile will last, 2 seconds
    public float projectileCount; //counts down time until the projectile destorys itself. (
                                  //currenlty set to 0

    // Start is called before the first frame update
    void Start()
    {
        projectileCount = projectileLife; //set projectileCount equal to projectile Life
    }

    // Update is called once per frame
    void Update()
    {
        projectileCount -= Time.deltaTime; //reduces the projectileCount w/ each second

        if (projectileCount < 0) //if the projectileCount runs out...
        {
            Destroy(gameObject); //destroy the gameObject this script is on (the projectile) 
        }
    }

    private void FixedUpdate()
    //FixedUpdate() is called every fixed framerate frame. It runs exactly 50 times per second all the time.
    //it's better practice to use FixedUpdate when applying force, torque, physics-related stuff b/c it's executed in sync with the physics engine, , not the framerate
    //IN SHORT: Moving w/ Rigidbody stuff -> FixedUpdate()
    //VS: Moving w/ transform -> Update()

    {
        projectileRb.velocity = new Vector3(speed, projectileRb.velocity.y, 0); //shoot to the right according to your Vector3
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //NOTE: The RigidBody on the projectile must be DYNAMIC for this collision to register. at least one object in any given collision has to be Dynamic

        //if projectile collides w/ an enemy
        if (collision.gameObject.tag == "Lava")
        {
            //Debug.Log("projectile hit lava rock");
            Destroy(collision.gameObject);  //destroy the object this projectile collided with
        }

        Destroy(gameObject); //Destroy the projectile
    }
}
