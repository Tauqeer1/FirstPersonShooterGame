using UnityEngine;
using System.Collections;

public class PlayerMovementScript : MonoBehaviour {

    CharacterController controller;
    Camera characterCamera;
    Vector3 move = Vector3.zero;
    public float moveSpeed = 3f;
    public float turnSpeed = 3f;
    float cameraRotationX = 0f;
    float minAngleRotation = -45f;
    float maxAngleRotation = 45f;
    Vector3 gravity = Vector3.zero;
    bool jump;
    public float jumpSpeed = 5f;
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
        //Rotate the camera in y-axis
        transform.Rotate(new Vector3(0f, Input.GetAxis("Mouse X") * turnSpeed * Time.deltaTime, 0f));
        //Get the camera x rotation in variable cameraRotationX
        cameraRotationX -= Input.GetAxis("Mouse Y");
        //Camera always look in positive z-axis with character
        characterCamera.transform.forward = transform.forward;
        //Limit the x Rotation to 45 degree up and down
        cameraRotationX = Mathf.Clamp(cameraRotationX, minAngleRotation, maxAngleRotation);
        //Camera rotation in x-axis
        characterCamera.transform.Rotate(new Vector3(cameraRotationX, 0, 0));
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

        //controller will move the character in meter/second and the velocity along y-axis is ignored but gravity is applied by default
        //controller.SimpleMove(move * moveSpeed);
        move *= moveSpeed;
        if (!controller.isGrounded)
        {
            gravity += Physics.gravity * Time.deltaTime;
        }
        else
        {
            gravity = Vector3.zero;
            if (jump)
            {
                gravity.y = jumpSpeed;
                jump = false;
            }
        }
        move += gravity;
        //controller will move the character by motion and the gravity is not apply by default
        controller.Move(move * Time.deltaTime);

        if (Input.GetKey(KeyCode.Space) && controller.isGrounded)
        {
            jump = true;
        }
    }


    

    
}
