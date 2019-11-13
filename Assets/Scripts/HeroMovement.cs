using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroMovement : MonoBehaviour
{

    public float speed;
    bool isJumpReady;

    [SerializeField]
    float jumpHigh;

    Collision ground;

    Vector3 direction;
    float maxJumpValue;

    // Start is called before the first frame update
    void Start()
    {
        maxJumpValue = float.MinValue;
    }

    // Update is called once per frame
    void Update()
    {
       
        isJumpReady = ReadyToJump(ground);
        //isJumpReady = false;

        if (Input.anyKey)
        {
            Move();
        }
    }


    private void Move()
    {
        direction = Vector3.zero;
        Vector3 jumpDirection = Vector3.zero;



        if (Input.GetKey("w"))
            direction += Vector3.forward;
        if (Input.GetKey("a"))
            direction += Vector3.left;
        if (Input.GetKey("s"))
            direction += Vector3.back;
        if (Input.GetKey("d"))
            direction += Vector3.right;
        if (Input.GetKey("space") && isJumpReady)
        {
            jumpDirection = Vector3.up;
        }


        transform.localPosition += direction * speed * Time.deltaTime;
        transform.localPosition += jumpDirection * jumpHigh * Time.deltaTime;

    }


    private bool ReadyToJump(Collision ground)
    {

        //if zamienip=ony na OnCollisionStay
       /* if (ground.gameObject.tag == "ground")
        {
            maxJumpValue = float.MinValue;
            return true;
        }*/
           // OnCollisionStay(ground);

            if (maxJumpValue < transform.position.y)
                maxJumpValue = transform.position.y;
            else
                return false;


        return true;
    }


    private void OnCollisionStay(Collision collision)
    {
        if(collision.gameObject)
        {
            maxJumpValue = float.MinValue;
            isJumpReady = true;
        }
        
    }

}
