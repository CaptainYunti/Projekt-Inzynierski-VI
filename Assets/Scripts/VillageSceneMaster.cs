using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class VillageSceneMaster : MonoBehaviour
{
    GameObject player;
    GameObject izzy;
    Canvas canvasPlayer;
    Canvas canvasDialogue;
    Text izzyText;
    Text playerText1, playerText2, playerText3;
    Camera playerCamera, izzyCamera;
    List<DialogueNode> dialogueIzzy;
    bool izzyWannaTalk;
    bool isReadyToTalk;
    bool firstDialogueComplete;
    bool ready;


    // Start is called before the first frame update
    void Start()
    {
        dialogueIzzy = new List<DialogueNode>();
        BuildDialogIzzy1();
        player = GameObject.FindWithTag("Player");
        izzy = GameObject.FindWithTag("NPC");
        //izzyWannaTalk = GetIzzyTalk(ref izzy.GetComponent<IzzyAnimation>().wannaTalk);
        izzyWannaTalk = izzy.GetComponent<IzzyAnimation>().wannaTalk;
        canvasDialogue = GameObject.Find("Canvas Dialog").GetComponent<Canvas>();
        canvasPlayer = GameObject.Find("Canvas Player").GetComponent<Canvas>();
        player.GetComponent<HeroUI>().enabled = false;
        canvasPlayer.enabled = false;
        canvasDialogue.enabled = true;
        izzyText = GameObject.Find("NPC Text").GetComponent<Text>();
        playerText1 = GameObject.Find("Player Text 1").GetComponent<Text>();
        playerText2 = GameObject.Find("Player Text 2").GetComponent<Text>();
        playerText3 = GameObject.Find("Player Text 3").GetComponent<Text>();
        firstDialogueComplete = false;
        SetCameras();
        canvasDialogue.enabled = false;
        canvasPlayer.enabled = true;
        player.GetComponent<HeroUI>().enabled = true;
        ready = false;
        print("Start");
        StartCoroutine(FirstDialogue());
    }

    // Update is called once per frame
    void Update()
    {
    }

    private ref bool GetIzzyTalk(ref bool izzyTalk)
    {
        return ref izzyTalk;
    }

    private void BuildDialogIzzy1()
    {
        string[] text = new string[32];
        int count = 0;

        text[count++] = "Cześć kurczak!";
        text[count++] = "Ładną pogodzę dziś mamy.";
        text[count++] = "Co dziś jesz na obiad?";
        DialogueNode izzy1 = new DialogueNode(text, count, false);
        dialogueIzzy.Add(izzy1);

        text = new string[32];
        count = 0;

        text[count++] = "Fajne masz cycki! Wpierdolę je!";
        text[count++] = "Rzeczywiście ładnie tutaj, jak tak patrzę... To no rzeczywiście lepiej niż jakbym nie patrzył.";
        text[count++] = "Hehehehehehe xD";
        DialogueNode player1 = new DialogueNode(text, count, true, izzy1);
        dialogueIzzy.Add(player1);

        text = new string[32];
        count = 0;

        text[count++] = "Co?";
        text[count++] = "Jak śmiesz, Ty jebiąca kogucią spermą ofiaro losu. Sperdalaj! Oby te krowy Cię zajebały, przeżuły i wysrały na nasiona.";
        text[count++] = "Nasiona które zjedzą Twoje małe bombelki xD";
        DialogueNode izzy2 = new DialogueNode(text, count, false, player1);
        dialogueIzzy.Add(izzy2);

        text = new string[32];
        count = 0;

        text[count++] = "A to dobrze.";
        text[count++] = "Jak skończysz gapić mi się na cycki, to może zauważysz wściekłe irackie krowy idące Ci wpierdolić.";
        text[count++] = "Powodzenia Kwoko";
        DialogueNode izzy3 = new DialogueNode(text, count, false, player1);
        dialogueIzzy.Add(izzy3);

        text = new string[32];
        count = 0;

        text[count++] = "Hehe xD";
        text[count++] = "Krowa xD";
        DialogueNode izzy4 = new DialogueNode(text, count, false, player1);
        dialogueIzzy.Add(izzy4);

    }

    private bool TalkDistance()
    {
        if (Vector3.Distance(player.transform.position, izzy.transform.position) >= 5)
            return false;

        return true;
    }

    private IEnumerator FirstDialogue()
    {
        print("Wszłem");
        while (!ready)
        {
            ready = TalkDistance() && izzyWannaTalk;
            yield return null;
        }
        print("Przeszłem xD");
        Camera[] cameras = Camera.allCameras;
        DialogueNode node;
        bool canGoNext = false;
        player.GetComponent<HeroMovement>().enabled = false;
        player.GetComponent<HeroUI>().enabled = false;

        foreach (Camera cam in cameras)
            cam.enabled = false;

        izzyCamera.enabled = true;
        canvasPlayer.enabled = false;
        canvasDialogue.enabled = true;
        playerText1.text = "";
        playerText2.text = "";
        playerText3.text = "";

        node = dialogueIzzy[0];

        for(int i = 0; i < 3; i++)
        {
            izzyText.text = node.GetText();
            while (!canGoNext)
            {
                if (Input.GetKeyDown("space") || Input.GetMouseButtonDown(0))
                    canGoNext = true;
            }
            canGoNext = false;
        }

        node = node.GetChild(0);
        izzyCamera.enabled = false;
        playerCamera.enabled = true;

        playerText1.text = node.GetText();
        playerText2.text = node.GetText();
        playerText3.text = node.GetText();

        while(!canGoNext)
        {
            if(Input.GetMouseButtonDown(0) || Input.GetKeyDown("space"))
            {
                if (EventSystem.current.currentSelectedGameObject == playerText1)
                {
                    node = node.GetChild(0);
                    canGoNext = true;
                }
                if (EventSystem.current.currentSelectedGameObject == playerText2)
                {
                    node = node.GetChild(1);
                    canGoNext = true;
                }
                if (EventSystem.current.currentSelectedGameObject == playerText3)
                {
                    node = node.GetChild(2);
                    canGoNext = true;
                }
            }
        }

        canGoNext = false;
        izzyCamera.enabled = true;
        playerCamera.enabled = false;

        playerText1.text = "";
        playerText2.text = "";
        playerText3.text = "";

        for (int i = 0; i < 3; i++)
        {
            izzyText.text = node.GetText();
            while (!canGoNext)
            {
                if (Input.GetKeyDown("space") || Input.GetMouseButtonDown(0))
                    canGoNext = true;
            }
            canGoNext = false;
        }

        izzyCamera.enabled = false;
        Camera.main.enabled = true;
        player.GetComponent<HeroMovement>().enabled = true;
        player.GetComponent<HeroUI>().enabled = true;
        izzyWannaTalk = false;
        canvasPlayer.enabled = true;
        canvasDialogue.enabled = false;



        yield return null;
    }

    private void SetCameras()
    {

        Camera[] cameras = Camera.allCameras;
        foreach (Camera c in cameras)
        {
            if (c.name == "Camera Chicken Front")
                playerCamera = c;
            if (c.name == "Camera Izzy")
                izzyCamera = c;
        }
    }
}
