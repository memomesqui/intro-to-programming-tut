using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{   //global variables

    public Rigidbody2D playerBody;

    public float playerSpeed = 0.05f;
    public float jumpForce = 300;
    public bool isJumping = false;
    //player health
    public int maxHealth = 20;
    public int currentHealth;
    public HealthBar healthBarScript;

    //flip directionvariables
    public bool flippedLeft; //keeps track of which way youre facing
    public bool facingRight; //keeps track of which way you should be facing

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBarScript.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        Jump();
    }
    private void MovePlayer ()
    {
        Vector3 newPos = transform.position;

        if (Input.GetKey(KeyCode.A))
        {
            // Debug.Log("A pressed");
            newPos.x -= playerSpeed;
            facingRight = false;
            Flip(facingRight);
        }

        else if (Input.GetKey(KeyCode.D))
        {
            //Debug.Log("D pressed");
            newPos.x += playerSpeed;
            facingRight = false;
            Flip(facingRight);

        }
        transform.position = newPos;

    }

     private void Jump()
     {
        if (!isJumping && Input.GetKeyDown(KeyCode.Space))
        {
            playerBody.AddForce(new Vector3(playerBody.velocity.x, jumpForce, 0));
            isJumping = true;
        }
     }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Surface")
        {
            isJumping = false;
            //Debug.Log("Collision 2D");
        }

       

        if (collision.gameObject.tag == "Lava")
        {
            TakeDamage(2);
        }
    }
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBarScript.SetHealth(currentHealth);
    }

    void Flip(bool facingLeft)
    {
       // Debug.Log("Flip() called. facongRight = " + facingRight)

        if (facingLeft && !flippedLeft)
        {
            transform.Rotate(0, -180, 0);
            flippedLeft = true; 
        }
    }
}
