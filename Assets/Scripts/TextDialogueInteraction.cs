using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TextDialogueInteraction : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    public bool pointerOver;
    // Start is called before the first frame update
    void Start()
    {
        pointerOver = false;
    }

    public void OnPointerEnter(PointerEventData pointer)
    {
        pointerOver = true;
    }

    public void OnPointerExit(PointerEventData pointer)
    {
        pointerOver = false;
    }
}
