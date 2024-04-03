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
        }

        else if (Input.GetKey(KeyCode.D))
        {
            //Debug.Log("D pressed");
            newPos.x += playerSpeed;
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
        }

        //Debug.Log("Collision 2D");

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
}
