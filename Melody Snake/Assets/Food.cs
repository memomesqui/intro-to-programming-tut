
using UnityEngine;

public class Food : MonoBehaviour
{
    public BoxCollider2D gridArea;

    private void Start()
    {
        RandomizePosition();
    }

    private void RandomizePosition()
    {
        //creates random positions for the snake to catch and adding mathf.round to make sure it aligns with the grid
        Bounds bounds = this.gridArea.bounds;

        float x = Random.Range (bounds.min.x, bounds.max.x);
        float y = Random.Range (bounds.min.y, bounds.max.y);

        this.transform.position = new Vector3(Mathf.Round(x), Mathf.Round(y), 0.0f);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //to make sure to check what other game objects collide with the food
        if (other.tag == "Player")
        {
        RandomizePosition();
        }
    }
}
