using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CaveNavigate : MonoBehaviour
{
    
    private string[] caveDialogue1 = {"You: Maybe I should look inside.", "You: Wow. It’s so dark here. Let’s go explore."};
    private string[] caveDialogue3 = {"You: What’s this, a safe? What could be inside? It looks like I need a pin."};
    private string[] caveDialogue4 = {"You: Whoa! It opened!", "You: That key looks important…I should keep it. I wonder what it opens…"};
    private string[] caveDialogue5 = {"You: Oh look! That's the way I came. The house is back that way."};
    private string[] caveD = { "This is really isolated..." };

    private bool text1 = false;
    private bool text3 = false;
    private bool text4 = false;
    private bool text5 = false;
    private bool text0 = false;

    private DialogueManager dMan;
    private static bool keyComplete = false;



    // Start is called before the first frame update
    void Start()
    {
        dMan = FindAnyObjectByType<DialogueManager>();
        if (!text0)
        {
            text0 = dMan.ShowBox(caveD);
        }
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
                    if (!text1)
                    {
                        text1 = dMan.ShowBox(caveDialogue1);
                    }
                }
                if (hit.collider.gameObject.tag == "Forest")
                {
                    if (!text5)
                    {
                        text5 = dMan.ShowBox(caveDialogue5);

                    }
                }
                if (hit.collider.gameObject.tag == "Key")
                {
                    keyComplete = true;
                    Debug.Log("Collected!");
                    if (!text4)
                    {
                        text4 = dMan.ShowBox(caveDialogue4);
                    }
                    
                }
                if (hit.collider.gameObject.tag == "BackHome")
                {
                    SceneManager.LoadScene("House", LoadSceneMode.Single);
                }

                if (hit.collider.gameObject.tag == "Cave")
                {
                    Camera.main.transform.position = new Vector3(20, 0, -10);
                }
                if (hit.collider.gameObject.tag == "Safe")
                {
                    Camera.main.transform.position = new Vector3(40, 20, -10);
                    if (!text3)
                    {
                        text3 = dMan.ShowBox(caveDialogue3);
                    }
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
