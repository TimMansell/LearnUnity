using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Char : MonoBehaviour {
    public float Speed = 5f;
    public float SprintSpeed = 10f;
    public float Jump = 5f;
    public float Hurt = 30f;

    public bool gc = false;
    public bool GroundTouch = false;

    public float CharSpeed;

    public Text CountText;
    public Text WinText;
    private int CountPickups;

    // Use this for initialization
    void Start () {
        gc = true;
        CharSpeed = SprintSpeed;

        CountPickups = 0;

        SetCountText();
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

        // Collision detection.
       
    }

    void OnTriggerEnter(Collider other)
    {

        // Pickup items.
        if (other.gameObject.CompareTag("Pickup"))
        {
            other.gameObject.SetActive(false);
            CountPickups += 1;

            SetCountText();
        }

        // Enemy collision.
        if (other.gameObject.CompareTag("Enemy"))
        {
            transform.position += Vector3.back * Time.deltaTime * Hurt;

            CountPickups -= 1;

            SetCountText();



            if (CountPickups <= -1)
            {
                Destroy(gameObject);

                WinText.text = "You lose :(";
            }
        }
    }

    void SetCountText()
    {
        CountText.text = "Count: " + CountPickups.ToString();

        if (CountPickups >= 12)
        {
            WinText.text = "CONGRATS YOU WON!!!";
        }
    }



    // Update is called once per frame
    void Update () {
		
	}
}

