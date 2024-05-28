using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//var to work with the different functions for loading scenes
using UnityEngine.SceneManagement;
//creates access to ui
using UnityEngine.UI;
//creates access to text mesh pro
using TMPro;
using System;

public class PlayerController : MonoBehaviour
{
    // public variable for speed using floats
    public float speed = 5f;
    //var for jumping in floats
    public float jumpSpeed = 6f;
    //private variable for direction using floats
    private float direction = 0f;
    //private variable for rigid body 2d/player
    private Rigidbody2D player;
    // Start is called before the first frame update

    //var for empty obj to be attached to the feet of the player to chech if she's touching the groung
    public Transform groundCheck;
    //check if feet are overlapping the ground
    public float groundCheckRadius;
    //var for specifying ground layer
    public LayerMask groundLayer;
    //bool var true or false for touching the ground
    private bool isTouchingGround;

    //var for animator 
    private Animator playerAnimation;
    //var for recording position where the player starts in game and if it dies, it'll respawn to that recorded position
    private Vector3 respawnPoint;
    //var for linking script to fall detector thats in the scene to be tracked, fall detector moves wherever player moves
    public GameObject fallDetector;
    //var for Text onject... 
    public TMP_Text scoreText;

    //getting access to healthbar script
    public HealthBar healthBar;

    void Start()
    {
        //to get access to the Rigidbod2D private var
        player = GetComponent<Rigidbody2D>();
        //for animator
        playerAnimation = GetComponent<Animator>();
        //stores position of player before the first frame
        respawnPoint = transform.position;
        //initialize text to display current score
        scoreText.text = "Score: " + KeepingScore.totalScore;
    }

    // Update is called once per frame
    void Update()
    {
        //var for refering to the isTouchingGround position of... ground check obj.pos, groundcheck radius, ground layer in unity 
        isTouchingGround = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        //which direction player moves based on keys and how fast; zero if no key pressed, -# = left moving, +# = right moving
        direction = Input.GetAxis("Horizontal");
        //to see what value is being store in the direction variable
        //Debug.Log(direction);
        //condition for checking if said number will be positive or negative
        if(direction > 0f) 
        {
            //direction positive val
            player.velocity = new Vector2(direction * speed, player.velocity.y);
            //helps player move left when left is pressed
            transform.localScale = new Vector2(0.3049605f, 0.3049605f);
        }
        else if (direction < 0f) 
        {
            //direction negative val
            player.velocity = new Vector2(direction * speed, player.velocity.y);
            //helps player move left when left is pressed
            transform.localScale = new Vector2(-0.3049605f, 0.3049605f);

        }
        //in neither condition had been met= player is still, this line will run
        else 
        {
            player.velocity = new Vector2(0, player.velocity.y);
        }

        //new conditional to check if jump button specified in the input method has been pressed
        //checking two conditions, if both are truw the line will run
        if (Input.GetButtonDown("Jump") && isTouchingGround)
        {
            player.velocity = new Vector2(player.velocity.x, jumpSpeed);
        }

        //to change speed parameter in animator, getting player velocity on x axis so it doesn't become idle when moving to the left, math.f turns - into +
        playerAnimation.SetFloat("Speed", Mathf.Abs(player.velocity.x));
        playerAnimation.SetBool("OnGround", isTouchingGround);

        //x=players position... y=detector position so it catches the player sort of
        fallDetector.transform.position = new Vector2 (transform.position.x, fallDetector.transform.position.y);

    }
         //will be called whenever collision is detected
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if(collision.tag == "FallDetector")
            {
                transform.position = respawnPoint;
            }
            //detection of checkpoint collisions
            else if (collision.tag == "Checkpoint") 
            {
                respawnPoint = transform.position;
            }
            //checkers for portal collisions to move between levels

            else if(collision.tag == "NextLevel")
            {
                //finds out what scene i'm currently in... then adds one to load next scene because it works in indexes starting at 0
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                //when player is in new level the respawn point is updated to where they are currently
                respawnPoint = transform.position;
            }

            else if(collision.tag == "PreviousLevel")
            {
                //does the opposite of the one above
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
                //when player is in new level the respawn point is updated to where they are currently
                respawnPoint = transform.position;
            }
            //makes collision crystals n boxes dissapear after player collects them and keeps record of it even when movind to next level
            else if(collision.tag == "Crystal")
           {
            //    score += 1;
              KeepingScore.totalScore +=1;
              scoreText.text = "Score: " + KeepingScore.totalScore;
              collision.gameObject.SetActive(false);
           }

           else if(collision.tag == "Boxes")
           {
            //    score += 1;
              KeepingScore.totalScore +=5;
              scoreText.text = "Score: " + KeepingScore.totalScore;
              collision.gameObject.SetActive(false);
           }
        }
        //will be called whenever collision is detected when the player stays on the spikes
        private void OnTriggerStay2D (Collider2D collision)
        {
            if(collision.tag == "Spikes")
            {
                healthBar.Damage(0.002f);
            }
        }
}
