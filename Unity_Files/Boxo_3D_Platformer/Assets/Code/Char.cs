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

    public GameObject DeathZone1;
    public GameObject DeathZone2;
    public GameObject DeathZone3;
    public GameObject DeathZone4;

    public GameObject RespawnPoint1;
    public GameObject RespawnPoint2;
    public GameObject RespawnPoint3;
    public GameObject RespawnPoint4;

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

            CheckLose();
        }

        // Spikes collision.
        if (other.gameObject.CompareTag("EnviroHazard03"))
        {
            transform.position = RespawnPoint4.transform.position;

            CountPickups -= 1;

            SetCountText();

            CheckLose();
        }

        // Respawn points.
        if (other.gameObject == DeathZone1)
        {
            transform.position = RespawnPoint1.transform.position;

            CountPickups -= 1;

            SetCountText();

            CheckLose();
        }

        if (other.gameObject == DeathZone2)
        {
            transform.position = RespawnPoint2.transform.position;

            CountPickups -= 1;

            SetCountText();

            CheckLose();
        }

        if (other.gameObject == DeathZone3)
        {
            transform.position = RespawnPoint3.transform.position;

            CountPickups -= 1;

            SetCountText();

            CheckLose();
        }

        if (other.gameObject == DeathZone4)
        {
            transform.position = RespawnPoint4.transform.position;

            CountPickups -= 1;

            SetCountText();

            CheckLose();
        }

        // Finish detection.
        if (other.gameObject.CompareTag("Finish"))
        {
            WinText.text = "CONGRATS YOU WON!!!";
        }
    }

    void SetCountText()
    {
        CountText.text = "Count: " + CountPickups.ToString();
    }

    void CheckLose()
    {
        if (CountPickups <= -1)
        {
            Destroy(gameObject);

            WinText.text = "You lose :(";
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}

