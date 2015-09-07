using UnityEngine;
using System.Collections;

public class PlayerMovementMecannim : MonoBehaviour {


    public GameObject cameraObject;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.rotation = Quaternion.Euler(new Vector3(0, cameraObject.GetComponent<MouseLook>().currentYRotation, 0));
	}
}
