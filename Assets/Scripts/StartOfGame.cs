using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartOfGame : MonoBehaviour
{
    private DialogueManager dMan;


    private string[] opening = { "You wake up to the twilight sky as the sun dips below the horizon. ",
        "You seem to be on a road trip with your family, but you have no recollection of when you left, where you’re going, and for how long. ",
        "You feel a little disoriented and confused, but decide to just focus on the present for the time being.",
        "You: Oh look, we’re almost here!", "Your car pulls into a long driveway and you step outside to see a large abandoned looking house.",
        
        //ADD MORE

    };
    private bool compText = false;
    
    


    // Start is called before the first frame update
    void Start()
    {
        dMan = FindAnyObjectByType<DialogueManager>();
    }

    // Update is called once per frame
    void Update()
    {

        if (!compText)
        {
            compText = dMan.ShowBox(opening);

        }

        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

        RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);

        if (Input.GetMouseButtonDown(0))
        {
            if (hit.collider != null)
            {
                if (hit.collider.gameObject.tag == "BackHome")
                {
                    SceneManager.LoadScene("House", LoadSceneMode.Single);
                }
            }
        }
    }
        
    
}
