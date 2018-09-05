using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam : MonoBehaviour {

    public GameObject Player;

    private Vector3 offset;

	// Use this for initialization
	void Start () {
        offset = transform.position - Player.transform.position;
	}

    private void LateUpdate()
    {
        transform.position = Player.transform.position + offset;
    }
}
