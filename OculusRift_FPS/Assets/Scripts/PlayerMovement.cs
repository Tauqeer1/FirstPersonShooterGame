using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

    public float walkAcceleration = 5.0f;
    public GameObject cameraObject;

    void Awake()
    {
        
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        //Rotate player in y axis w.r.t camera
        transform.rotation = Quaternion.Euler(new Vector3(0, cameraObject.GetComponent<MouseLook>().currentYRotation, 0));

        //Add relative to move the character in local space w.r.t character forward direction
        GetComponent<Rigidbody>().AddRelativeForce(new Vector3(Input.GetAxis("Horizontal") * walkAcceleration, 0, Input.GetAxis("Vertical") * walkAcceleration));
	}
}
