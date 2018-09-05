using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Char : MonoBehaviour {
    public float Speed = 5f;
    public float SprintSpeed = 10f;
    public float Jump = 5f;

    public bool gc = false;
    public bool GroundTouch = false;

    public float CharSpeed;

    // Use this for initialization
    void Start () {
        gc = true;
        CharSpeed = SprintSpeed;

    }

    private void FixedUpdate()
    {
        // Moving.
        if (Input.GetKey(KeyCode.W))
        {
            // Sprinting.
            if (Input.GetKey(KeyCode.LeftShift))
            {
                CharSpeed = SprintSpeed;
            }
            else
            {
                CharSpeed = Speed;
            }

            transform.position += Vector3.forward * Time.deltaTime * CharSpeed;
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.position += Vector3.left * Time.deltaTime * Speed;
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.position += Vector3.back * Time.deltaTime * Speed;
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.position += Vector3.right * Time.deltaTime * Speed;
        }

        // Jumping.
        if (Input.GetKey(KeyCode.Space))
        {
            transform.position += Vector3.up * Time.deltaTime * Jump;
        }

        // Prevent character from jumping if not touching the ground.
        Vector3 gc = transform.TransformDirection(Vector3.down);
        if(Physics.Raycast (transform.position, gc, .5f))
        {
            GroundTouch = true;
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}

