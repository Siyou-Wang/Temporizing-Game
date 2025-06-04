using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalFight : MonoBehaviour
{


    private Transform player;
    private Transform monster;
    private DialogueManager dMan;

    private string[] room1Dialogue13 = {"You break the door down with your chair and are greeted by an empty house. Your family is still missing.",
        "Faintly, you hear quick footsteps approaching the house. It seems your trials are not yet over…"};
    private string[] room1Dialogue14 = {"You were the monster’s next meal.", "As you slowly succumb to your wounds, you see eerily familiar eyes lining the monster's throat. You see them twitch to face you, then start to water. Mom…?"
        };
    
    private bool dialogue13 = false;
    private bool dialogue14 = false;

    private int playerH;
    private int monsterH;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").transform;
        monster = GameObject.Find("Monster").transform;
        playerH = 50;
        monsterH = 25;
        dMan = FindAnyObjectByType<DialogueManager>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 distance1 = player.position - monster.position;
        float magnitude = distance1.magnitude;
        if (magnitude < 0.5) {
            playerH -= 10;
            PlayerMovement.setSteps();
          
        }
        if (Input.GetKeyDown(KeyCode.Q)){
            monsterH -= 3;
            PlayerMovement.addSteps();
        }

        if(playerH <= 0)
        {
            if (!dialogue14)
            {
                dialogue14 = dMan.ShowBox(room1Dialogue14);

            }
            //DIALOUGE
            Debug.Log("Lost");
        }
        if(monsterH <= 0)
        {
            if (!dialogue13)
            {
                dialogue13 = dMan.ShowBox(room1Dialogue13);

            }
            //DIALOUGE
            Debug.Log("Win");
        }
    }
}
