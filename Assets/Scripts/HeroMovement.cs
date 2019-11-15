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
    float yaw, pitch;

    Camera backCamera, frontCamera, birdViewCamera,
        izzyTalkCamera, izzySideCamera;
    Camera[] cameras;

    // Start is called before the first frame update
    void Start()
    {
        maxJumpValue = float.MinValue;
        cameraRotation = new Vector3(0, 0, 0);
        yaw = pitch = 0;
        SetCameras();

    }

    // Update is called once per frame
    void Update()
    {
       
        isJumpReady = ReadyToJump(ground);
        //isJumpReady = false;

        if(Input.GetKey("k"))
        {

        }
        else

        if (Input.anyKey)
        {
            Move();
        }

    }

    private void LateUpdate()
    {
        Camera.main.transform.localEulerAngles = cameraRotation * mouseSens;
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

        if (Input.GetMouseButton(1))
        {
            yaw = Input.GetAxisRaw("Mouse X") * mouseSens;
            pitch = -Input.GetAxisRaw("Mouse Y") * mouseSens;
            cameraRotation += new Vector3(pitch, yaw, 0);
        }
        else
        {
            //yaw = pitch = 0;
            cameraRotation = new Vector3(0, 0, 0);
        }

        if(Input.GetKeyDown("1"))
        {
            foreach(Camera c in cameras)
            {
                if (c == backCamera)
                    c.enabled = true;
                else
                    c.enabled = false;
            }
        }
        if (Input.GetKeyDown("2"))
        {
            foreach (Camera c in cameras)
            {
                if (c == frontCamera)
                    c.enabled = true;
                else
                    c.enabled = false;
            }
        }
        if (Input.GetKeyDown("3"))
        {
            foreach (Camera c in cameras)
            {
                if (c == birdViewCamera)
                    c.enabled = true;
                else
                    c.enabled = false;
            }
        }


        //rotation = new Vector3(0, Input.GetAxis("Mouse X"), 0);

        transform.localPosition += direction * speed * Time.deltaTime;
        transform.localPosition += jumpDirection * jumpHigh * Time.deltaTime;

        //transform.Rotate(rotation * mouseSens * Time.deltaTime);


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

    private void SetCameras()
    {

        cameras = Camera.allCameras;

        backCamera = Camera.main;

        foreach(Camera c in cameras)
        {
            if (c.name == "Camera Bird View")
                birdViewCamera = c;
            if (c.name == "Camera Izzy Side")
                izzySideCamera = c;
            if (c.name == "Camera Izzy")
                izzyTalkCamera = c;
            if (c.name == "Camera Chicken Front")
                frontCamera = c;
        }

    }





}
