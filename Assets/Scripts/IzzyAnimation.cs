using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IzzyAnimation : MonoBehaviour
{
    [SerializeField]
    public bool jump, lost, wait1, wait2, hello;

    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        jump = lost = wait1 = wait2 = hello = false;
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetBool("Jump", jump);
        anim.SetBool("Lose", lost);
        anim.SetBool("Wait1", wait1);
        anim.SetBool("Wait2", wait2);
        anim.SetBool("Hello", hello);
    }

    private void Jump()
    {
        jump = true;
        lost = wait1 = wait2 = hello = false;
    }

    private void Damage()
    {
        lost = true;
        jump = wait1 = wait2 = hello = false;
    }

    private void Wait()
    {
        jump = lost = hello = false;
    }

    private void Hello()
    {
        hello = true;
        jump = lost = wait1 = wait2 = false;
    }
}
