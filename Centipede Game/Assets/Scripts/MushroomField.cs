//will handle spawing all the mushrooms as a whole
using UnityEngine;

public class MushroomField : MonoBehaviour
{
    //for the field we need a reference to that colider2D component so we can check what the balance of it is
    private BoxCollider2D area;
    //var for our mushroom prefab that way we can reinstantiate it over and over again
    //making it public so there can be assing a refenrence to the prefab on the editor 
    //any prefab will need the mushroom script attached to it
    public Mushroom prefab;
    //var to indicate how many mushrroms I'd like to spawn
    public int amount = 50;

    //reference to area
    private void Awake()
    {
        area = GetComponent<BoxCollider2D>();
    
    }

    // Start is called before the first frame update
    private void Start()
    {
        Generate();
    }

    //
    private void Generate()
    {
        //bounds of collider
        Bounds bounds = area.bounds;
        //loop the mushroom spawning amount
        for (int i = 0; i< amount; i ++)
        {
            //picking random position within bounds to instantiate prefab
            Vector2 position = Vector2.zero;
            //assigning x and y independently and rounding values with Mathf.Round
            position.x = Mathf.Round(Random.Range(bounds.min.x, bounds.max.x));
            position.y = Mathf.Round(Random.Range(bounds.min.y, bounds.max.y));

            //instantiating/creating a new clone of the mushroom Quaternion=Rotantion but it's not needed here, using transform to parent it to keep it organized
            Instantiate(prefab, position, Quaternion.identity, transform);
        }
    }

}
