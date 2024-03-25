using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Draggable : MonoBehaviour
{   //MW class
    //declare global variables
    private bool isDragging = false;
    private Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isDragging)
        {
            transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
    }
    //newprivateboolean
    private void OnMouseDown()
    {
        offset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //Debug.Log("isDraggin = " + isDragging);
        isDragging = false;
    }

    private void OnMouseUp()
    {
        Debug.Log("isDraggin = " + isDragging);
        isDragging=true;
    }
}
