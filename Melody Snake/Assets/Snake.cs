using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour
{
   private Vector2 _direction = Vector2.right;
   private List<Transform> _segments = new List<Transform>();
   public Transform segmentPrefab;
   public int initialSize = 4;


   private void Start()
    {
       ResetState();

    }
   

   private void Update()
   {

    //assigning directions to keys

    if (Input.GetKeyDown(KeyCode.W))
    {
        _direction = Vector2.up;
    } 
    
    else if (Input.GetKeyDown(KeyCode.S))
    {
        _direction = Vector2.down;
    }

    else if (Input.GetKeyDown(KeyCode.A))
    {
        _direction = Vector2.left;
    }

    else if (Input.GetKeyDown(KeyCode.S))
    {
        _direction = Vector2.down;
    }

    else if (Input.GetKeyDown(KeyCode.D))
    {
        _direction = Vector2.right;
    }
   }

   private void FixedUpdate()
   {
    //makes sure that all appearing segments move following the head so thats why it's iterated in reverse order, head stays in place and
    //last piece moves behind it and then the piece bofore that one.
    for (int i = _segments.Count - 1; i > 0; i--)
    {
        _segments[i].position = _segments[i - 1].position;
    }

    //rounding numbers to make sure the snake is aligned to a grid

    this.transform.position = new Vector3(
        Mathf.Round(this.transform.position.x) + _direction.x,
        Mathf.Round(this.transform.position.y) + _direction.y,
        //z direction is not needed so that's why 0.0f
        0.0f

    );
   }

   private  void Grow()
    {
        //creates new segments of snake appearing to grow
       Transform segment = Instantiate(this.segmentPrefab);
       segment.position = _segments[_segments.Count - 1].position;

       _segments.Add(segment);

    }

    //clearing out list of segments and starting all over again
    private  void ResetState()
    {
       for (int i = 1; i < _segments.Count; i++)
       {
        Destroy(_segments[i].gameObject);
       }

       _segments.Clear();
       _segments.Add(this.transform);

    for (int i = 1; i < this.initialSize; i++)
       {
        _segments.Add(Instantiate(this.segmentPrefab));
       }

       this.transform.position = Vector3.zero;

    }

     private void OnTriggerEnter2D(Collider2D other)
    {
        //food isn't an obstacle so it will grow here instead of reseting 
        if (other.tag == "Food")
        {
        Grow();
        } 
        //making self and walls an obstacle so when self hits those you loose game
        else if (other.tag == "Obstacle"){
            ResetState();
        }

    }
   
}
