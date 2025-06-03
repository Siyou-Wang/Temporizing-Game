using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class riddlePaperGame : MonoBehaviour
{
    private Transform upperLeft;
    private Transform upperRight;
    private Transform lowerLeft;
    private Transform lowerRight;

    private Transform upperLeftPos;
    private Transform upperRightPos;
    private Transform lowerLeftPos;
    private Transform lowerRightPos;

    private string[] puzzleComplete = { "TEXT"};
    private bool text = false;

    private bool paperUpperLeft = false;
    private bool paperUpperRight = false;
    private bool paperLowerLeft = false;
    private bool paperLowerRight = false;

    private DialougeManager dMan;

    // Start is called before the first frame update
    void Start()
    {
        upperLeft = GameObject.Find("riddlePaperUpperLeft").transform;
        upperRight = GameObject.Find("riddlePaperUpperRight").transform;
        lowerLeft = GameObject.Find("riddlePaperBottomLeft").transform;
        lowerRight = GameObject.Find("riddlePaperBottomRight").transform;

        upperLeftPos = GameObject.Find("UpperLeftCheck").transform;
        upperRightPos = GameObject.Find("UpperRightCheck").transform;
        lowerLeftPos = GameObject.Find("BottomLeftCheck").transform;
        lowerRightPos = GameObject.Find("BottomRightCheck").transform;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 distance1 = upperLeft.position - upperLeftPos.position;
        float magnitude = distance1.magnitude;
        if (magnitude < .25) {
            paperUpperLeft = true;
            upperLeft.position = upperLeftPos.position;
        }

        Vector3 distance2 = upperRight.position - upperRightPos.position;
        magnitude = distance2.magnitude;
        if (magnitude < .25)
        {
            paperUpperRight = true;
            upperRight.position = upperRightPos.position;
        }

        Vector3 distance3 = lowerLeft.position - lowerLeftPos.position;
        magnitude = distance3.magnitude;
        if (magnitude < .25)
        {
            paperLowerLeft = true;
            lowerLeft.position = lowerLeftPos.position;
        }

        Vector3 distance4 = lowerRight.position - lowerRightPos.position;
        magnitude = distance4.magnitude;
        if (magnitude < .25)
        {
            paperLowerRight = true;
            lowerRight.position = lowerRightPos.position;
        }

        if (paperLowerLeft && paperLowerRight && paperUpperLeft && paperUpperRight) {
            if (!text) {
                //text = dMan.ShowBox(puzzleComplete);
                //text = false;
            
            }
        }
    }
}
