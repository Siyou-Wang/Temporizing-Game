using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Room1Navigate : MonoBehaviour
{
    private string[] room1Dialogue0 = {"You: Well this is cozy...", "You: It looks like nobody’s lived here in years."};
    private string[] room1Dialogue01 = {"You: Hmmm...it's locked. Maybe I should come back later."};
    private string[] room1Dialogue1 = {"You: I think this could be my room. Blue is my favorite color! I’ll settle in for the night."};
    private string[] room1Dialogue2 = {"You: This room is perfect for my little sister."};
    private string[] room1Dialogue3 = {"You: This room is perfect for my parents. They’re probably busy, so I should let them go to bed."};
    private string[] room1Dialogue4 = {"You wake up the next morning to find that your sister is missing.", "You: *Yawn* Good morning…wait where's my sister? Is she still asleep?", 
        "Mom: Are you okay sweetie? What are you talking about?", "You: What do you mean? My sister??", "Dad: Who?", "You: My little sister!", 
        "Mom: Sweetie you don’t have a little sister. You’ve always been an only child.", "Your heart drops. What’s going on? How could your parents forget about your sister?"};
    private string[] room1Dialogue5 = {"You: What’s this? It seems to have writing on it.", "You lay out all the pieces of paper to take a closer look."} ;

    private string[] room1Dialogue8 = {"You: Dad! Where's mom?", "Dad: Are you okay honey? What are you talking about?", "You: Not this again. First my sister and now my mother!! Where are they?",
        "Dad: You’re worrying me. It’s always been just the two of us."};

    private string[] room1Dialogue9 = {"You: Oh look! A lock. What is that sound from behind the door?", "Door: ...Panting and heavy breathing…",
        "You: What is in there? Could it be my mom and sister? I wish I could go inside and find out. Maybe I should bring something, just in case its dangerous.", "You: I wonder if this is what the key opens. Only one way to find out!",
        "You: Oh my gosh! It’s opening!", "The door opens to reveal a grotesque eyeless beast, its stomach split with pulsating eyes lining its innards.", 
        "Black goo slowly oozes down its open ribs, collecting in shallow puddles on the floor. It seems as if it is in great pain, thrashing its head about.", 
        "With a start, you realize its skull is worn to the bone.", "You: AAAAAAAAAAAAAAAAAAAA", "The monster makes a faint choking noise, swinging its head towards you.",
        "You: YOU ATE MY FAMILY!", "The monster makes a wet squelching noise as it moves towards you, angling its great body towards the sound of your voice.",
        "You: I better run or I’m next.", "Door: Click.", "You: NO! The door is locked! This is the end!!", "You: If I’m here, I might as well avenge my family. I have this chair and I’m not afraid to use it.",
        "The monster growls in challenge."};
    private string[] di = { "It's certainly...something"};
    

        private bool dialogue0 = false;
        private bool dialogue01 = false;
        private bool dialogue1 = false;
        private bool dialogue2 = false;
        private bool dialogue3 = false;
        private bool dialogue4 = false;
        private bool dialogue5 = false;
        private bool dialogue8 = false;
        private bool dialogue9 = false;

        private bool dialogue = false;


    private DialogueManager dMan;
    private string[] message = new string[1];
    private bool textShow = false;
    private int day = 0;

    private Vector3 targetPos = new Vector3(0, 20, -10);
    private bool d1Done = false;
    private bool d2Done = false;
    private GameObject dad;
    private GameObject mom;
    private GameObject sister;


    // Start is called before the first frame update
    void Start()
    {
        dMan = FindAnyObjectByType<DialogueManager>();
        if (!dialogue)
        {
            dialogue = dMan.ShowBox(di);

        }

        dad = GameObject.Find("Dad");
        mom = GameObject.Find("Mom");
        sister = GameObject.Find("Sister");
    }

    // Update is called once per frame
    void Update()
    {
        if(day >= 1) {
            sister.SetActive(false);

        }
        if(day >= 2)
        {
            mom.SetActive(false);

        }
        if(day >= 3)
        {
            dad.SetActive(false);
        }
        if (CaveNavigate.returnKey())
        {
            day = 4;
        }

        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

        RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);

        if (Input.GetMouseButtonDown(0)) {
            if (hit.collider != null) {
                if (hit.collider.gameObject.tag == "House") {
                    Camera.main.transform.position = new Vector3(0, 20, -10);
                    if (!dialogue0)
                    {
                        dialogue0 = dMan.ShowBox(room1Dialogue0);

                    }
                }
                if (hit.collider.gameObject.tag == "Attic" && (day >= 3 || CaveNavigate.returnKey()))
                {
                    Camera.main.transform.position = new Vector3(-40, 20, -10);
                    
                    if (!dialogue9)
                    {
                        dialogue9 = dMan.ShowBox(room1Dialogue9);

                    }
                }
                else
                {
                    if (!dialogue01)
                    {
                        dialogue01 = dMan.ShowBox(room1Dialogue01);

                    }
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
                    if (!dialogue1)
                    {
                        dialogue1 = dMan.ShowBox(room1Dialogue1);

                    }
                }
                if (hit.collider.gameObject.tag == "Door2" && day >= 1)
                {
                    Camera.main.transform.position = new Vector3(0, 40, -10);
                }
                if (day==1 && Camera.main.transform.position == targetPos)
                {
                    if (!dialogue4)
                    {
                        dialogue4 = dMan.ShowBox(room1Dialogue4);

                    }
                }
                else if (hit.collider.gameObject.tag == "Door2")
                {
                   if (!dialogue2)
                    {
                        dialogue2 = dMan.ShowBox(room1Dialogue2);

                    }
                }
                if (hit.collider.gameObject.tag == "Door3" && day >= 2)
                {
                    Camera.main.transform.position = new Vector3(40, 20, -10);
                }
                if (day==2 && Camera.main.transform.position == targetPos)
                {
                    if (!dialogue8)
                    {
                        dialogue8 = dMan.ShowBox(room1Dialogue8);

                    }
                }
                else if (hit.collider.gameObject.tag == "Door3") {
                    if (!dialogue3)
                    {
                        dialogue3 = dMan.ShowBox(room1Dialogue3);

                    }
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
                    if (!dialogue5)
                    {
                        dialogue5 = dMan.ShowBox(room1Dialogue5);

                    }
                }
                if (hit.collider.gameObject.tag == "LeaveHouse")
                {
                   SceneManager.LoadScene("Forest", LoadSceneMode.Single);
                }
            }
        }
    }
}
