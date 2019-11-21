using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IzzyAnimation : MonoBehaviour
{
    [SerializeField]
    public bool jump, lost;

    [SerializeField]
    bool isDialog, isAnimationEven, wannaTalk, inSight;

    [SerializeField]
    float range, fieldOfViewAngle;

    private Animator anim;
    private bool breakCoroutine;
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        anim = GetComponent<Animator>();
        jump = lost = false;
        isDialog = inSight = isAnimationEven = false;
        wannaTalk = true;
        breakCoroutine = false;
        StartCoroutine(IzzyBehaviour());
    }

    // Update is called once per frame
    void Update()
    { 
        anim.SetBool("Jump", jump);
        inSight = IsInSight();
    }

    private void Jump()
    {
        jump = true;
        lost =  false;
    }

    private void Damage()
    {
        lost = true;
        jump = false;
    }


    private IEnumerator IzzyBehaviour()
    {
        while(!breakCoroutine)
        {
            if (isDialog)
            {
                yield break;
            }
            while(inSight && wannaTalk)
            {
                anim.Play("human_hello_friendly", -1, 1);
                print("Hello my friend");
                yield return new WaitForSeconds(10);
            }

            while (!inSight || !wannaTalk)
            {
                Wait();
                isAnimationEven = !isAnimationEven;
                yield return new WaitForSeconds(10);
            }

            yield return null;
        }

    }

    private void Wait()
    {
        if (isAnimationEven)
            anim.Play("WAIT02", -1, 1);
        else
            anim.Play("WAIT01", -1, 1);
    }

    private bool IsInSight()
    {

        Vector3 direction = player.transform.position - transform.position;
        float angle = Vector3.Angle(direction, transform.forward);



        if(angle < fieldOfViewAngle)
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position + transform.up, direction.normalized, out hit, range) && hit.collider.gameObject.tag == "Player")
            {
                //Debug.Log("Did Hit");
                inSight = true;
            }
            else
                inSight = false;
        }


        return inSight;
    }
}
