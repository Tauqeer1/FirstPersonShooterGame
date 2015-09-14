using UnityEngine;
using System.Collections;

public class AnimationScript : MonoBehaviour {

    Animator walkAnimator;

    void Awake()
    {
        walkAnimator = GetComponent<Animator>();
    }
	// Use this for initialization
	void Start () {
	
	}
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S)
            || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            walkAnimator.SetBool("Walk", true);
        }
        else
        {
            walkAnimator.SetBool("Walk", false);
        }
       
	}
}
