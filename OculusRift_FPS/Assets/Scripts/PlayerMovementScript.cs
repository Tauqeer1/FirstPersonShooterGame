using UnityEngine;
using System.Collections;

public class PlayerMovementScript : MonoBehaviour {

    CharacterController controller;
    Camera characterCamera;
    Vector3 move = Vector3.zero;
    public float moveSpeed = 3f;
    public float turnSpeed = 3f;
    void Awake()
    {
        controller = GetComponent<CharacterController>();
        characterCamera = GetComponentInChildren<Camera>();
    }
    void Update()
    {

        //Rotation of Character
        CharacterRotation();

        ///Movement of Character
        CharacterMovement();
    }
    /// <summary>
    /// Character Rotation Function
    /// </summary>
    void CharacterRotation()
    {
        characterCamera.transform.Rotate(new Vector3(Input.GetAxis("Mouse Y") * turnSpeed, 0, 0));
        transform.Rotate(new Vector3(0f, Input.GetAxis("Mouse X") * turnSpeed * Time.deltaTime, 0f));
    }
    /// <summary>
    /// Character Movement Function
    /// </summary>
    void CharacterMovement()
    {
        //This move the character w.r.t local space
        move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        //normalize the move vector
        move.Normalize();

        //TransformDirection converts from local space to world space
        move = transform.TransformDirection(move);

        //controller will move the character with the give moveSpeed
        controller.SimpleMove(move * moveSpeed);
    }


    

    
}
