using UnityEngine;

public class Dart : MonoBehaviour
{
    //reference to dart RigidBody component
    //"new" is used for new version of unity
    private new Rigidbody2D rigidbody;
    //reference to dart collider 
    //we need reference to collider bc we need to turn collider on & off so it doesn't collide with blaster
    private new Collider2D collider;
    //reference to the parent object which is the blaster...
    private Transform parent;
    //by making this var public it'll show up in editor to freely chage the set value
    public float speed = 50f;

    //called automatically by unity when the object is first initialized where the script is
    private void Awake()
    {
        //creating access to these components in order to use
        rigidbody = GetComponent<Rigidbody2D>();
        //disabling physics simulation
        rigidbody.bodyType = RigidbodyType2D.Kinematic;
        collider= GetComponent<Collider2D>();
        //
        collider.enabled = false;
        //we need this bc the dart needs to be detached from parent object to shoot the targer and then reattach again
        //thats why Transform parent needed to be referenced, to see the parent of the parent of the dart
        parent = transform.parent;
    }
    //handling input
    // this is called automatically by unity every single frame the script is enabled
    private void Update()
    {
        //another input that's included by default in the input manager
        //will only be fired when not active/not been fired --- kinematic = has not been fired
        if (rigidbody.isKinematic && Input.GetButton("Fire1"))
        {
            //deparenting dart from blaster so it can kinda move freely
            transform.SetParent(null);
            //reenabling rigidbody simulation
            rigidbody.bodyType = RigidbodyType2D.Dynamic;
            //reenabling collider that way collision can happen between dart and other objects
            collider.enabled = true;
        }
    }

    //handling movement
    private void FixedUpdate()
    {  
        //!=not
        //will move when active/ been fired --- not kinematic = has been fired... if it's kinematic, this wont run
        if (!rigidbody.isKinematic)
        {
        //calculating position
        //getting current position from rigidbody
        Vector2 position = rigidbody.position;
        //updating current position
        //deltatime makes sure the amount we're movind spreads out over time
        position += Vector2.up * speed * Time.fixedDeltaTime;
        //move posision on the rigid body
        rigidbody.MovePosition(position);
        }
       
    }

    //reatatching dart to blaster whenever it collides with something
    //called automatically by unity... others that arent called automaticaly need to be carefuly typed bc of case sensitivity
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //reset parent to initial parent which was saved when the object was initialized
        transform.SetParent(parent);
        //reset position wherever blaster is... local position = local space relative to the parent/blaster which was set in the inspector
        //repositioning dart in the mouth of the blaster
        transform.localPosition = new Vector3(0f, 0.9f, 0);
        //set rigid body to be kinematic again that way it isn't moving
        rigidbody.bodyType = RigidbodyType2D.Kinematic;
        //turning off collider so it doesn't collide with things even when unactive
        collider.enabled = false;

    }
}
