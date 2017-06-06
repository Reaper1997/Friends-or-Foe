using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class lookSides : MonoBehaviour {

    public float movementSpeed = 5.0f;
    public float mouseSensitivity = 2.0f;
    public float jumpSpeed = 10.0f;
    public bool isGrounded;
    CharacterController characterController;

    // Use this for initialization
    void Start () {
        characterController = GetComponent<CharacterController>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void FixedUpdate()
    {
        isGrounded = characterController.isGrounded;

        //Rotation
        float rotY = Input.GetAxis("Mouse X") * mouseSensitivity;
        transform.Rotate(0, rotY, 0);
    }
}
