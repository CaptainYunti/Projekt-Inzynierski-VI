using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueNode
{
    public int id;
    string[] dialogues;
    int dialoguesCount, dialogNumber;
    bool isPlayerDialogue;
    public int parentID;
    public List<int> childID = new List<int>();


    public DialogueNode(string[] dialogues, int dialoguesCount, bool isPlayerDialogue, int parentID)
    {
        this.dialogues = dialogues;
        this.dialoguesCount = dialoguesCount;
        this.isPlayerDialogue = isPlayerDialogue;
        this.parentID = parentID;
    }


    //public DialogueNode GetParent() => this.parent;

   /* public DialogueNode GetChild(int number)
    {
        try
        {
            return childs[number];
        }
        catch(System.Exception e)
        {
            Debug.LogError("Hehehe, zjebany kod xD");
        }

        DialogueNode node = this;

        while(node.parent != null)
        {
            node = node.parent;
        }

        return node;
    }*/

    public string GetText()
    {
        if (dialogNumber >= dialoguesCount)
            return " ";

        return dialogues[dialogNumber++];
    }

    public void ResetTextCount() => dialogNumber = 0;



}
