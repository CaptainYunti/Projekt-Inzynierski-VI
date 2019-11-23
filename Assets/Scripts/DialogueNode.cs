using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueNode
{
    string[] dialogues;
    int dialoguesCount, dialogNumber;
    bool isPlayerDialogue;
    public DialogueNode parent;
    public List<DialogueNode> childs = new List<DialogueNode>();


    public DialogueNode(string[] dialogues, int dialoguesCount, bool isPlayerDialogue, DialogueNode parent)
    {
        this.dialogues = new string[dialoguesCount];
        this.dialoguesCount = dialoguesCount;
        this.isPlayerDialogue = isPlayerDialogue;
        this.parent = parent;
        this.childs = null;
        parent.childs.Add(this);
    }
    public DialogueNode(string[] dialogues, int dialoguesCount, bool isPlayerDialogue)
    {
        this.dialogues = new string[dialoguesCount];
        this.dialoguesCount = dialoguesCount;
        this.isPlayerDialogue = isPlayerDialogue;
        this.childs = null;
        parent = null;
    }

    public DialogueNode GetParent() => this.parent;

    public DialogueNode GetChild(int number)
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
    }

    public string GetText()
    {
        if (dialogNumber >= dialoguesCount)
            return "";

        return dialogues[dialogNumber];
    }

    public void ResetTextCount() => dialogNumber = 0;



}
