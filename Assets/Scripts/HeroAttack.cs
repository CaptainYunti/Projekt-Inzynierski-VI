using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroAttack : MonoBehaviour
{

    Animator anim;
    bool eat;
    GameObject beak;
    
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        eat = false;
        beak = GameObject.Find("Toon Chicken/Beak");
        beak.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            eat = true;
            beak.SetActive(true);
        }
        else
        {
            eat = false;
            beak.SetActive(false);
        }
    }

    private void LateUpdate()
    {
        anim.SetBool("Eat", eat);
    }
}
