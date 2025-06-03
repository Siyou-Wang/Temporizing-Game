using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Room1Navigate : MonoBehaviour
{
    private DialougeManager dMan;
    private string[] message = new string[1];
    private bool textShow = false;
    private int day = 0;

    private bool d1Done = false;
    private bool d2Done = false;

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

        if (Input.GetMouseButtonDown(0)) {
            if (hit.collider != null) {
                if (hit.collider.gameObject.tag == "House") {
                    Camera.main.transform.position = new Vector3(0, 20, -10);
                }
                if (hit.collider.gameObject.tag == "Attic" && day >= 3 && CaveNavigate.returnKey())
                {
                    Camera.main.transform.position = new Vector3(-40, 20, -10);
                }
                else if (hit.collider.gameObject.tag == "Attic" && day < 3)
                {

                }
                else if (hit.collider.gameObject.tag == "Attic" && !CaveNavigate.returnKey())
                {

                }
                if (hit.collider.gameObject.tag == "Bed")
                {
                    day++;
                    
                }
                if (hit.collider.gameObject.tag == "Drawer1")
                {
                    d1Done = true;
                    if (d1Done && d2Done) {
                        Camera.main.transform.position = new Vector3(40, 40, -10);
                    }
                }
                if (hit.collider.gameObject.tag == "Drawer2")
                {
                    d2Done = true;
                    if (d1Done && d2Done) {
                        Camera.main.transform.position = new Vector3(40, 40, -10);
                    }
                }
                if (hit.collider.gameObject.tag == "Door1")
                {
                    Camera.main.transform.position = new Vector3(20, 20, -10);
                }
                if (hit.collider.gameObject.tag == "Door2" && day >= 1)
                {
                    Camera.main.transform.position = new Vector3(0, 40, -10);
                }else if (hit.collider.gameObject.tag == "Door2")
                {
                   
                }
                if (hit.collider.gameObject.tag == "Door3" && day >= 2)
                {
                    Camera.main.transform.position = new Vector3(40, 20, -10);
                }else if (hit.collider.gameObject.tag == "Door3") {

                }
                if (hit.collider.gameObject.tag == "Stairs")
                {
                    Camera.main.transform.position = new Vector3(-20, 20, -10);
                }
                if (hit.collider.gameObject.tag == "BackLeft") {
                    Camera.main.transform.position = new Vector3(Camera.main.transform.position.x-20, Camera.main.transform.position.y, -10);
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
                    Camera.main.transform.position = new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y -20, -10);
                }
                if (hit.collider.gameObject.tag == "BulltinBoard") {
                    Camera.main.transform.position = new Vector3(0, 60, -10);
                }
            }
        }
    }
}
