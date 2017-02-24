using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement : MonoBehaviour {

    public Ray movementRay;
    NavMeshAgent navMeshAgent;

	// Use this for initialization
	void Start () {
        navMeshAgent = GetComponent<NavMeshAgent>();
	}
	
	// Update is called once per frame
	void Update () {
        RaycastHit mousePointer;
        movementRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Input.GetMouseButtonUp(1))
        {
            if (Physics.Raycast(movementRay, out mousePointer, 100.0f))
            {
                navMeshAgent.SetDestination(mousePointer.point);
            }
        }

	}
}
