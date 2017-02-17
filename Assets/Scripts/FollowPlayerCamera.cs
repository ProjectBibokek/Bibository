using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayerCamera : MonoBehaviour {

    public GameObject playerModel;
    public Vector3 movement;
	// Use this for initialization
	void Start () {
        movement = transform.position - playerModel.transform.position;
	}
	
	// Update is called once per frame
	void LateUpdate () {
        transform.position = playerModel.transform.position + movement;
	}
}
