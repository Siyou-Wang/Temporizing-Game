using UnityEngine.UI;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    public GameObject background;
    public Text dText;
    private string[] strings;
    private int count = 1;


    bool dialougeActive = false;


    private void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Checkes if activly in dialogue and if user is pressing space to move on
        if(dialougeActive && Input.GetKeyDown(KeyCode.Space))
        {
            if (count == strings.Length) {
                background.SetActive(false);
                dialougeActive = false;
                count = 0;
            }
            dText.text = strings[count];
            count++;
        }

      
    }

    //Shows the next piece of dialouge
    public bool ShowBox(string[] dialouge) {
        dialougeActive = true;
        background.SetActive(true);
        dText.text = dialouge[0];
        strings = dialouge;
        return true;
    }

   
}
