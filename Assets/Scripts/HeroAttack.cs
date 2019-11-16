using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroAttack : MonoBehaviour
{

    Animator anim;
    bool eat;
    GameObject beak;
    SphereCollider beakCollider;
    
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        eat = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            eat = true;
        }
        else
        {
            eat = false;
        }
    }

    private void LateUpdate()
    {
        anim.SetBool("Eat", eat);
    }
}
