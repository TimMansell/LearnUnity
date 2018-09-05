using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Char : MonoBehaviour {
    public float Speed = 5f;

	// Use this for initialization
	void Start () {
		
	}

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += Vector3.forward * Time.deltaTime * Speed;
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
    }

    // Update is called once per frame
    void Update () {
		
	}
}
