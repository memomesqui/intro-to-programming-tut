using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    //var for camera to have acces to the player
    public GameObject player;
    //makes camera move ahead of player
    public float offset;
    //makes camera movement smoother
    public float offsetSmoothing;
    //stores player position
    private Vector3 playerPosition;
    //

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //updating position of the camera
        playerPosition = new Vector3(player.transform.position.x, transform.position.y, transform.position.z);
        
        //if plater is looking right this will update player position as well as for the left
        if(player.transform.localScale.x > 0f)
        {
            playerPosition = new Vector3(playerPosition.x + offset, playerPosition.y, playerPosition.z);
        }
        else 
        {
             playerPosition = new Vector3(playerPosition.x - offset, playerPosition.y, playerPosition.z);
        }

        transform.position = Vector3.Lerp(transform.position, playerPosition, offsetSmoothing * Time.deltaTime);
    }
}
