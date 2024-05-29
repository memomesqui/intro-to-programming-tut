
using UnityEngine;

public class Blaster : MonoBehaviour
{
   //creates access to rigid body component from the blaster
   private new Rigidbody2D rigidbody;
   //var for storing the direction in which the blaster is moving
   private Vector2 direction;
   // public var so we can customaze it in the editor
   public float speed = 20f;

   //to  assign value
   private void Awake()
    {
        //getting refered to the component rigid body
        rigidbody = GetComponent<Rigidbody2D>();
    }

    // this is called automatically by unity every single frame the script is enabled
    private void Update()
    {
        //direction based on user input--creates access to input manager on unity which had the horizontal and vertical input buttons
        direction.x = Input.GetAxis("Horizontal");
        direction.y = Input.GetAxis("Vertical");

    }

    //runs at a fixed time interval, doesn't nessesarily matter what the frame rate is, important for doing physics if we want it to be consistent
    private void FixedUpdate()
    {
        //calculating new position myself
        Vector2 position = rigidbody.position;
        //makes sure vector always has a unit length of 1... important cause creates consistency---deltatime makes sure the amount we're movind spreads out over time
        //for normal update you use deltatime but for fixed update we use fixeddeltatime
        position += direction.normalized * speed * Time.fixedDeltaTime;
        //move to this position---this will also handle collisions and such
        rigidbody.MovePosition(position);
    }


   
}
