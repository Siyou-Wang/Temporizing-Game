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
    void Update()
    {
        if (dragging) {
            transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition) + offset;
            float curX = transform.position.x;
            float curY = transform.position.y;
            transform.position = new Vector3(curX, curY, 1);
        }

    }

    private void OnMouseDown()
    {
        offset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
        dragging = true;
    }

    private void OnMouseUp()
    {
        dragging = false;
    }
}
