using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveableObject : MonoBehaviour
{
    private bool dragging = false;
    private Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    //Checks if user is dragging the object
    void Update()
    {
        if (dragging) {
            transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition) + offset;
            float curX = transform.position.x;
            float curY = transform.position.y;
            transform.position = new Vector3(curX, curY, 1);
        }

    }

    //When mouse clicks on a object, offset is set and dragging is true
    private void OnMouseDown()
    {
        offset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
        dragging = true;
    }

    //Cancels dragging when the user stops clicking on object
    private void OnMouseUp()
    {
        dragging = false;
    }
}
