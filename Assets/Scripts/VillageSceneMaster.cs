using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class VillageSceneMaster : MonoBehaviour
{
    GameObject player;
    GameObject izzy;
    [SerializeField]
    GameObject cows;
    Canvas canvasPlayer;
    Canvas canvasDialogue;
    Text izzyText;
    Text playerText1, playerText2, playerText3;
    Camera playerCamera, izzyCamera, mainCamera;
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
        DeactiveCows();
        print("Start");
        StartCoroutine(FirstDialogue());
    }

    private void DeactiveCows()
    {
        try { cows.SetActive(false); }
        catch ( UnassignedReferenceException e){ }

    }



    private void ActiveCows()
    {
        cows.SetActive(true);
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
        DialogueNode izzy1 = new DialogueNode(text, count, false, 0);
        dialogueIzzy.Add(izzy1);

        text = new string[32];
        count = 0;

        text[count++] = "Fajne masz cycki! Wpierdolę je!";
        text[count++] = "Rzeczywiście ładnie tutaj, jak tak patrzę... To no rzeczywiście lepiej niż jakbym nie patrzył.";
        text[count++] = "Hehehehehehe xD";
        DialogueNode player1 = new DialogueNode(text, count, true, izzy1.id);
        dialogueIzzy.Add(player1);

        text = new string[32];
        count = 0;

        text[count++] = "Co?";
        text[count++] = "Jak śmiesz, Ty jebiąca kogucią spermą ofiaro losu. Sperdalaj! Oby te krowy Cię zajebały, przeżuły i wysrały na nasiona.";
        text[count++] = "Nasiona które zjedzą Twoje małe bombelki xD";
        DialogueNode izzy2 = new DialogueNode(text, count, false, player1.id);
        dialogueIzzy.Add(izzy2);

        text = new string[32];
        count = 0;

        text[count++] = "A to dobrze.";
        text[count++] = "Jak skończysz gapić mi się na cycki, to może zauważysz wściekłe irackie krowy idące Ci wpierdolić.";
        text[count++] = "Powodzenia Kwoko";
        DialogueNode izzy3 = new DialogueNode(text, count, false, player1.id);
        dialogueIzzy.Add(izzy3);

        text = new string[32];
        count = 0;

        text[count++] = "Hehe xD";
        text[count++] = "Krowa xD";
        DialogueNode izzy4 = new DialogueNode(text, count, false, player1.id);
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


        Camera[] cameras = Camera.allCameras;
        DialogueNode node;
        bool canGoNext = false;
        player.GetComponent<HeroMovement>().ReadyToDialogue();
        yield return null;
        player.GetComponent<HeroMovement>().enabled = false;
        yield return null;
        player.GetComponent<HeroAttack>().enabled = false;
        yield return null;
        player.GetComponent<HeroUI>().enabled = false;
        yield return null;
        //izzy.GetComponent<IzzyAnimation>().StopCoroutine(izzy.GetComponent<IzzyAnimation>().IzzyBehaviour());
        //yield return null;
        izzy.GetComponent<IzzyAnimation>().enabled = false;
        yield return null;


        izzyCamera.enabled = true;
        foreach (Camera cam in cameras)
        {
            if (cam == izzyCamera);
            else
                cam.enabled = false;
        }


        izzyCamera.enabled = true;
        canvasDialogue.enabled = true;
        canvasPlayer.enabled = false;


        izzyText.text = " ";
        playerText1.text = " ";
        playerText2.text = " ";
        playerText3.text = " ";
        yield return null;

        node = dialogueIzzy[0];

        for(int i = 0; i < 3; i++)
        {
            yield return null;
            izzyText.text = node.GetText();
            izzyText.color = Color.white;
            yield return null;
            while (!canGoNext)
            {
                if (Input.GetKeyDown("space") || Input.GetMouseButtonDown(0))
                    canGoNext = true;
                yield return null;
            }
            canGoNext = false;
        }

        node = dialogueIzzy[1];
        izzyCamera.enabled = false;
        playerCamera.enabled = true;

        playerText1.text = node.GetText();
        playerText2.text = node.GetText();
        playerText3.text = node.GetText();

        while(!canGoNext)
        {
            if(Input.GetMouseButtonDown(0))
            {
                if (playerText1.GetComponent<TextDialogueInteraction>().pointerOver)
                {
                    node = dialogueIzzy[2];
                    canGoNext = true;
                }
                if (playerText2.GetComponent<TextDialogueInteraction>().pointerOver)
                {
                    node = dialogueIzzy[3];
                    canGoNext = true;
                }
                if (playerText3.GetComponent<TextDialogueInteraction>().pointerOver)
                {
                    node = dialogueIzzy[4];
                    canGoNext = true;
                }
            }
            yield return null;
        }

        canGoNext = false;
        izzyCamera.enabled = true;
        playerCamera.enabled = false;

        playerText1.text = " ";
        playerText2.text = " ";
        playerText3.text = " ";

        for (int i = 0; i < 3; i++)
        {
            izzyText.text = node.GetText();
            while (!canGoNext)
            {
                if (Input.GetKeyDown("space") || Input.GetMouseButtonDown(0))
                    canGoNext = true;
                yield return null;
            }
            canGoNext = false;
        }

        mainCamera.enabled = true;
        izzyCamera.enabled = false;
        player.GetComponent<HeroMovement>().enabled = true;
        player.GetComponent<HeroUI>().enabled = true;
        izzy.GetComponent<IzzyAnimation>().enabled = true;
        player.GetComponent<HeroAttack>().enabled = true;
        yield return null;
        izzyWannaTalk = false;
        izzy.GetComponent<IzzyAnimation>().wannaTalk = false;
        canvasPlayer.enabled = true;
        canvasDialogue.enabled = false;

        ActiveCows();
        //izzy.GetComponent<IzzyAnimation>().StartCoroutine(izzy.GetComponent<IzzyAnimation>().IzzyBehaviour());

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
            if (c == Camera.main)
                mainCamera = Camera.main;
        }
    }

}
