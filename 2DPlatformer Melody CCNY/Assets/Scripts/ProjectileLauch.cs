
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileLaunch : MonoBehaviour
{
    //IN CLASS COLLEGE NOW MW

    //THIS SCRIPT LIVES ON THE PLAYER, NOT THE LAUNCH POINT

    //GLOBAL VARIABLES
    public GameObject projectilePrefab; //declare and set the projectilePrefab GameObject in the Inspector
    public Transform launchPoint; //the position from which a projectile will launch

    public float shootTime = 0.5f; //cooldown time amount b/w projectile firing, set in inspector
                                   //currently set to 0.5
    public float shootCount; //the cooldown timer itself, set in inspector

    // Start is called before the first frame update
    void Start()
    {
        shootCount = shootTime; //set the shootCounter timer equal to shootTime when the scene starts
    }

    // Update is called once per frame
    void Update()
    {
        //if the Left Mouse Button is pressed AND the shootCounter is reset to 0 or less than 0
        //if(Input.GetButtonDown("Fire1") && shootCounter <= 0)
        if (Input.GetMouseButtonDown(0) && shootCount <= 0)
        {
            Instantiate(projectilePrefab, launchPoint.position, Quaternion.identity);
            //Instantiate needs 3 things! (1,2,3)
            //1. what are you instantiating?
            //2. Where are you instantiating it?
            //3. What is the rotation you're instantiating it with? USE Quaternion.identity

            shootCount = shootTime; //restart the cooldown time to disable ability to shoot
        }

        shootCount -= Time.deltaTime; //reduce cooldown time
    }
}
