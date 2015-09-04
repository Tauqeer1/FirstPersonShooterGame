using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

    public float walkAcceleration = 5.0f;
    public float walkDecelerationTime = 1.05f;
    [HideInInspector]
    public float walkDecelerationVelocityX;
    [HideInInspector]
    public float walkDecelerationVelocityZ;
    public GameObject cameraObject;
    public float maxWalkSpeed = 20;
    public Vector2 horizontalMovement;
    public float jumpVelocity = 800;
    public bool grounded = false;
    public float maxSlope = 60;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        //Get rigidbody velocity x and z and stored in horizontalMovement
        horizontalMovement = new Vector2(GetComponent<Rigidbody>().velocity.x, GetComponent<Rigidbody>().velocity.z);
        
        //Check the horizontalMovment magnitude with maximum Walk Speed
        if (horizontalMovement.magnitude > maxWalkSpeed)
        {
            
            horizontalMovement = horizontalMovement.normalized;
            horizontalMovement *= maxWalkSpeed;
        }
       
        //Set the maximum x and z velocity 
        GetComponent<Rigidbody>().velocity = new Vector3(horizontalMovement.x, 0, horizontalMovement.y);

        //Rotate player in y axis w.r.t camera
        transform.rotation = Quaternion.Euler(new Vector3(0, cameraObject.GetComponent<MouseLook>().currentYRotation, 0));

        //Add relative to move the character in local space w.r.t character forward direction
        GetComponent<Rigidbody>().AddRelativeForce(new Vector3(Input.GetAxis("Horizontal") * walkAcceleration * Time.deltaTime, 0, Input.GetAxis("Vertical") * walkAcceleration * Time.deltaTime));

        //Set the character to smoothly stop when movement keys are not pressing
        if (Input.GetAxis("Horizontal") == 0 && Input.GetAxis("Vertical") == 0 && grounded)
        {
            float xVelocity = GetComponent<Rigidbody>().velocity.x;
            float zVelocity = GetComponent<Rigidbody>().velocity.z;

            //Smooth the deceleration of x-axis
            xVelocity = Mathf.SmoothDamp(xVelocity, 0, ref walkDecelerationVelocityX, walkDecelerationTime);

            //Smooth the deceleration of z-axis
            zVelocity = Mathf.SmoothDamp(zVelocity, 0, ref walkDecelerationVelocityZ, walkDecelerationTime);

            //Set the new velocity vector
            GetComponent<Rigidbody>().velocity = new Vector3(xVelocity, 0, zVelocity);
        }
        
        //Press the space button to jump
        if (Input.GetButtonDown("Jump") && grounded)
        {
            GetComponent<Rigidbody>().AddForce(0, jumpVelocity, 0);
        }

	}
    //Function to check the collision is in stay
    void OnCollisionStay(Collision collisionInfo)
    {
        //Check all the contactPoint in collisionInfo.contacts
        foreach (ContactPoint contact in collisionInfo.contacts)
        {
            //if angle b/w contact.normal and vector3.up is less than maxSlope then grounded should be true
            if (Vector3.Angle(contact.normal, Vector3.up) < maxSlope)
            {
                grounded = true;
            }
        }
    }
    void OnCollisionExit()
    {
        grounded = false;
    }
}
