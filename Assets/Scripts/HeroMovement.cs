using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroMovement : MonoBehaviour
{

    public float speed;

    Vector3 direction;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKey)
        {
            Move();
        }
    }


    private void Move()
    {
        direction = Vector3.zero;

        if (Input.GetKey("w"))
            direction = Vector3.forward;
        if (Input.GetKey("a"))
            direction = Vector3.left;
        if (Input.GetKey("s"))
            direction = Vector3.back;
        if (Input.GetKey("d"))
            direction = Vector3.right;
        if (Input.GetKey("space"))
            direction = Vector3.up;

        transform.localPosition += direction * speed * Time.deltaTime;
    }

}
