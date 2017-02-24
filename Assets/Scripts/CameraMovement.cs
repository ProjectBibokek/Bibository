using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {
    public GameObject playerModel;
    private Vector3 offset;
    bool isFollowing = false;
    int screenWidth = 0;
    int screenHeight = 0;
    int edgeBoundary = 10;
    private Vector3 currentPosition;
    
    void Start () {
        offset = transform.position - playerModel.transform.position;
        screenWidth = Screen.width;
        screenHeight = Screen.height;

    }
	
	// Update is called once per frame
	void Update () {

	}

    private void LateUpdate()
    {
        currentPosition = transform.position;
        if (Input.mousePosition.x > screenWidth - edgeBoundary)
        {
            Debug.Log("moving screen");
            currentPosition.x += 5 * Time.deltaTime;
            transform.position = currentPosition;
            isFollowing = false;
        }

        if (Input.mousePosition.x < 0 + edgeBoundary)
        {
            Debug.Log("moving screen");
            currentPosition.x -= 5 * Time.deltaTime;
            transform.position = currentPosition;
            isFollowing = false;
        }
        
        if (Input.mousePosition.y > screenHeight - edgeBoundary)
        {
            Debug.Log("moving screen UP");
            currentPosition.z += 5 * Time.deltaTime;
            transform.position = currentPosition;
            isFollowing = false;
        }
            
        if (Input.mousePosition.y < 0 + edgeBoundary)
        {
            Debug.Log("moving screen");
            currentPosition.z -= 5 * Time.deltaTime;
            transform.position = currentPosition;
            isFollowing = false;
        }
        float scrollWheel = Input.GetAxis("Mouse ScrollWheel");
        if (scrollWheel > 0.0f)
        {
            Debug.Log("zoom out");
            currentPosition.y -= 20 * Time.deltaTime;
            transform.position = currentPosition;
            isFollowing = false;
        }
        if (scrollWheel < 0.0f)
        {
            currentPosition.y += 20 * Time.deltaTime;
            transform.position = currentPosition;
            isFollowing = false;
        }
        



        if (Input.GetKeyUp(KeyCode.F1))
        {
            focusOnPlayerModel();
            isFollowing = true;
        }
        
        if(isFollowing == true)
        {
            focusOnPlayerModel();
        }

    }

    public void focusOnPlayerModel() //Перемещает камеру на позицию модели персонажа
    {
        transform.position = playerModel.transform.position + offset;
    }
}
