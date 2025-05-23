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
                if (hit.collider.gameObject.tag == "Attic")
                {

                }
                if (hit.collider.gameObject.tag == "Bed")
                {

                }
                if (hit.collider.gameObject.tag == "Drawer1")
                {

                }
                if (hit.collider.gameObject.tag == "Drawer2")
                {

                }
                if (hit.collider.gameObject.tag == "Door1")
                {
                    Camera.main.transform.position = new Vector3(20, 20, -10);
                }
                if (hit.collider.gameObject.tag == "Door2")
                {

                }
                if (hit.collider.gameObject.tag == "Door3")
                {

                }
                if (hit.collider.gameObject.tag == "Stairs")
                {

                }
            }
        }
    }
}
