using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaveNavigate : MonoBehaviour
{
    private DialougeManager dMan;
    private string[] message = new string[1];
    private bool textShow = false;
    private static bool keyComplete = false;



    // Start is called before the first frame update
    void Start()
    {
        dMan = FindAnyObjectByType<DialougeManager>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

        RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);

        if (Input.GetMouseButtonDown(0))
        {
            if (hit.collider != null)
            {

                if (hit.collider.gameObject.tag == "IntoCave")
                {
                    Camera.main.transform.position = new Vector3(40, 0, -10);
                }
                if (hit.collider.gameObject.tag == "Forest")
                {
                    //DIALOUGE
                }
                if (hit.collider.gameObject.tag == "Key")
                {
                    keyComplete = true;
                    Debug.Log("Collected!");
                    
                }
                if (hit.collider.gameObject.tag == "Cave")
                {
                    Camera.main.transform.position = new Vector3(20, 0, -10);
                }
                if (hit.collider.gameObject.tag == "Safe")
                {
                    Camera.main.transform.position = new Vector3(40, 15, -10);
                }
                if (hit.collider.gameObject.tag == "BackLeft")
                {
                    Camera.main.transform.position = new Vector3(Camera.main.transform.position.x - 20, Camera.main.transform.position.y, -10);
                }
                if (hit.collider.gameObject.tag == "BackRight")
                {
                    Camera.main.transform.position = new Vector3(Camera.main.transform.position.x + 20, Camera.main.transform.position.y, -10);
                }
                if (hit.collider.gameObject.tag == "BackFarLeft")
                {
                    Camera.main.transform.position = new Vector3(Camera.main.transform.position.x - 40, Camera.main.transform.position.y, -10);
                }
                if (hit.collider.gameObject.tag == "BackDown")
                {
                    Camera.main.transform.position = new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y - 20, -10);
                }
            }
        }
    }

    public static bool returnKey() {
        return keyComplete;
    }
}
