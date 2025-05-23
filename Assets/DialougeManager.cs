using UnityEngine.UI;
using UnityEngine;

public class DialougeManager : MonoBehaviour
{
    public GameObject background;
    public Text dText;
    private string[] strings;
    private int count = 1;

    public GameObject blackout;
    public Text dText1;
    private string[] strings1;
    private int count1 = 1;

    bool dialougeActive = false;
    bool blackoutActive = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
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

        if (blackoutActive && Input.GetKeyDown(KeyCode.Space))
        {
            if (count1 == strings1.Length)
            {
                blackout.SetActive(false);
                blackoutActive = false;
                count1 = 0;
            }
            dText1.text = strings1[count1];
            count1++;
        }
    }

    public bool ShowBox(string[] dialouge) {
        dialougeActive = true;
        background.SetActive(true);
        dText.text = dialouge[0];
        strings = dialouge;
        return true;
    }

    public bool blackOutScreen(string[] dialouge)
    {
        blackoutActive = true;
        blackout.SetActive(true);
        dText1.text = dialouge[0];
        strings1 = dialouge;
        return true;
    }
}
