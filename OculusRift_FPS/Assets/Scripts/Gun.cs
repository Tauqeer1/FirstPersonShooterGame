using UnityEngine;
using System.Collections;

public class Gun : MonoBehaviour {

    public GameObject cameraObject;
    public float targetXRotation;
    public float targetYRotation;
    public float targetXRotationVelocity;   
    public float targetYRotationVelocity;

    public float rotateSpeed = 0.3f;    //Rotation speed of the gun
    public float holdHeight = -0.5f;    //Height of the gun to hold
    public float holdSide = 0.5f;       //side of the gun to hold

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        transform.position = cameraObject.transform.position + (Quaternion.Euler(0, targetYRotation, 0) * new Vector3(holdSide, holdHeight, 0));

        targetXRotation = Mathf.SmoothDamp(targetXRotation, cameraObject.GetComponent<MouseLook>().xRotation,ref targetXRotationVelocity, rotateSpeed);
        targetYRotation = Mathf.SmoothDamp(targetYRotation, cameraObject.GetComponent<MouseLook>().yRotation, ref targetYRotationVelocity, rotateSpeed);

        transform.rotation = Quaternion.Euler(new Vector3(targetXRotation, targetYRotation, 0));
	}
}
