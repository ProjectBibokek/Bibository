using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {
    public GameObject playerModel;
    private Vector3 offset;
    void Start () {
        offset = transform.position - playerModel.transform.position;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void LateUpdate()
    {
        transform.position = playerModel.transform.position + offset;
    }

    public void focusOnPlayerModel() //Перемещает камеру на позицию модели персонажа
    {
        
    }
}
