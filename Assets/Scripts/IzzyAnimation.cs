using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IzzyAnimation : MonoBehaviour
{
    [SerializeField]
    public bool jump, lost, hello;

    [SerializeField]
    bool isDialog, isInRange, isAnimationEven, wannaTalk;

    private Animator anim;
    private bool breakCoroutine;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        jump = lost = hello = false;
        isDialog = isInRange = isAnimationEven = wannaTalk = false;
        breakCoroutine = false;
        StartCoroutine(IzzyBehaviour());
    }

    // Update is called once per frame
    void Update()
    { 
        anim.SetBool("Jump", jump);
        anim.SetBool("Lose", lost);
        anim.SetBool("Hello", hello);
    }

    private void Jump()
    {
        jump = true;
        lost = hello = false;
    }

    private void Damage()
    {
        lost = true;
        jump = hello = false;
    }


    private void Hello()
    {
        hello = true;
        jump = lost =  false;
    }

    private IEnumerator IzzyBehaviour()
    {

        if (isDialog)
        {
            yield break;
        }
        if(isInRange && wannaTalk)
        {

        }

        Wait();
        isAnimationEven = !isAnimationEven;

        yield return new WaitForSeconds(30);
        StartCoroutine(IzzyBehaviour());
        yield return null;
    }

    private void Wait()
    {
        if (isAnimationEven)
            anim.Play("WAIT02", -1, 1);
        else
            anim.Play("WAIT01", -1, 1);
    }
}
