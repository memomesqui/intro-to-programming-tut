using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody2D projectileRb;
    public float speed = 5;
    public float projectileLife = 2;
    public float projectileCount;
    void Start()
    {
        projectileCount = projectileLife;
    }

    // Update is called once per frame
    void Update()
    {
        projectileCount -= Time.deltaTime;
        if (projectileCount <=)
       // projectileRb.velocity = new Vector3(speed, projectileRb.velocity.y, )
    }
    private void FixedUpdate()
    {
        projectileRb.velocity = new Vector3(speed, projectileRb.velocity.y, 0);
           
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Lava")
        {
            Destroy(collision.gameObject);
        }
        Destroy(gameObject);
    }
}
