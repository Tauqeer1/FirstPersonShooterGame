using UnityEngine;
using System.Collections;

public class GunMovementScript : MonoBehaviour {

    public float moveAmount = 1;
    public float moveSpeed = 2;
    public GameObject gunObject;
    public float moveOnX;
    public float moveOnY;
    public Vector3 defaultPosition;
    public Vector3 newGunPosition;

	// Use this for initialization
	void Start () {
        defaultPosition = transform.localPosition;

	}
	
	// Update is called once per frame
	void Update () {
        moveOnX = Input.GetAxis("Mouse X") * Time.deltaTime * moveAmount;
        moveOnY = Input.GetAxis("Mouse Y") * Time.deltaTime * moveAmount;
        newGunPosition = new Vector3(defaultPosition.x + moveOnX, defaultPosition.y + moveOnY, defaultPosition.z);
        gunObject.transform.localPosition = Vector3.Lerp(gunObject.transform.localPosition, newGunPosition, moveSpeed * Time.deltaTime);
	}
}
