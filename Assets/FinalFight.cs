using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalFight : MonoBehaviour
{

    private Transform player;
    private Transform monster;

    

    private int playerH;
    private int monsterH;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").transform;
        monster = GameObject.Find("Monster").transform;
        playerH = 50;
        monsterH = 25;
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
            //DIALOUGE
            Debug.Log("Lost");

        }
        if(monsterH <= 0)
        {
            //DIALOUGE
            Debug.Log("Win");
        }
    }
}
