using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{

    SpriteRenderer monsterSprite;
    public Sprite monsterIdle;
    public Sprite monsterAttack;

    private Transform player;
    private Transform monster;

    // Start is called before the first frame update
    void Start()
    {
        monsterSprite = gameObject.GetComponent<SpriteRenderer>();
        player = GameObject.Find("Player").transform;
        monster = GameObject.Find("Monster").transform;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 distance1 = player.position - monster.position;
        float magnitude = distance1.magnitude;
        if (magnitude < 0.5)
        {
            monsterSprite.sprite = monsterAttack;

        }
        monsterSprite.sprite = monsterIdle;

        if(PlayerMovement.returnSteps() > 3)
        {
            monster.position = player.position;

        }

    }

    

}    
