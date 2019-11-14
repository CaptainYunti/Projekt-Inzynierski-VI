using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroMovement : MonoBehaviour
{

    public float speed;
    bool isJumpReady;

    [SerializeField]
    float jumpHigh;
    [SerializeField]
    float mouseSens;
    [SerializeField]
    float rotationSpeed;

    Collision ground;

    Vector3 direction;
    Vector3 rotation;
    Vector3 cameraRotation;
    Vector3 cameraMovement;
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
            direction += transform.forward;
        if (Input.GetKey("a"))
            //direction -= transform.right;
            transform.Rotate(0, -rotationSpeed * Time.deltaTime, 0);
        if (Input.GetKey("s"))
            direction -= transform.forward;
        if (Input.GetKey("d"))
            //direction += transform.right;
            transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);
        if (Input.GetKey("space") && isJumpReady)
        {
            jumpDirection = Vector3.up;
        }

        if(Input.GetMouseButton(1))
        {
            cameraRotation = new Vector3(Input.GetAxis("Mouse Y"), Input.GetAxis("Mouse X"), 0);
        }

        rotation = new Vector3(0, Input.GetAxis("Mouse X"), 0);

        transform.localPosition += direction * speed * Time.deltaTime;
        transform.localPosition += jumpDirection * jumpHigh * Time.deltaTime;

        //transform.Rotate(rotation * mouseSens * Time.deltaTime);

        //Camera.current.transform.Rotate(cameraRotation * -mouseSens * Time.deltaTime);
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
