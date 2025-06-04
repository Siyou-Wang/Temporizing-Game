using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    SpriteRenderer rabbit;
    public Sprite rabbitFront;
    public Sprite rabbitLeft;
    public Sprite rabbitRight;
    public Sprite rabbitBack;
    private static int steps;


    // Start is called before the first frame update
    void Start()
    {
        rabbit = gameObject.GetComponent<SpriteRenderer>();
        steps = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + 2, 1);
            rabbit.sprite = rabbitBack;
            steps++;

        }
        if (Input.GetKeyDown(KeyCode.S)) {
            transform.position = new Vector3(transform.position.x, transform.position.y - 2, 1);
            rabbit.sprite = rabbitFront;
            steps++;
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            transform.position = new Vector3(transform.position.x - 2, transform.position.y, 1);
            rabbit.sprite = rabbitLeft;
            steps++;
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            transform.position = new Vector3(transform.position.x + 2, transform.position.y, 1);
            rabbit.sprite = rabbitRight;
            steps++;
        }


    }

    public static int returnSteps()
    {
        return steps;
    }

    public static void setSteps()
    {
        steps = 0;
    }

    public static void addSteps()
    {
        steps += 2;
    }
}
