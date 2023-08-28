

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script requires you to have setup your animator with 3 parameters, "InputMagnitude", "InputX", "InputZ"
//With a blend tree to control the inputmagnitude and allow blending between animations.
[RequireComponent(typeof(CharacterController))]
public class Movimiento : MonoBehaviour {


    
    public float speed = 1.0f;
    public float RotationSpeed = 1.0f;
    public float JumpForce = 1.0f;
    public float InputX;
	public float InputZ;
    public float allowPlayerRotation = 0.1f;
	public Animator anim;
	public CharacterController controller;
	public bool isGrounded;

    [Header("Animation Smoothing")]
    [Range(0, 1f)]
    public float HorizontalAnimSmoothTime = 0.2f;
    [Range(0, 1f)]
    public float VerticalAnimTime = 0.2f;
    [Range(0,1f)]
    public float StartAnimTime = 0.3f;
    [Range(0, 1f)]
    public float StopAnimTime = 0.15f;

    private Rigidbody Physics;
	// Use this for initialization
	void Start () {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Physics = GetComponent<Rigidbody>();

		anim = this.GetComponent<Animator> ();
		controller = this.GetComponent<CharacterController> ();
	}
	
	// Update is called once per frame
	void Update()
    {   //Moviemiento
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        transform.Translate(new Vector3(horizontal, 0.0f, vertical) * Time.deltaTime * speed);

        //Rotacion
        float rotationY = Input.GetAxis("Mouse X");
        transform.Rotate(new Vector3(0, rotationY * Time.deltaTime * RotationSpeed, 0));

        //Salto

    if(Input.GetKeyDown(KeyCode.Space)){ 

        Physics.AddForce(new Vector3(0, JumpForce, 0), ForceMode.Impulse); 
    }
       
    }

    /*public void LookAt(Vector3 pos)
    {
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(pos), desiredRotationSpeed);
    }*/

    /*public void RotateToCamera(Transform t)
    {

        var camera = Camera.main;
        var forward = cam.transform.forward;
        var right = cam.transform.right;

        desiredMoveDirection = forward;

        t.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(desiredMoveDirection), desiredRotationSpeed);
    }*/

	void InputMagnitude() {
		//Calculate Input Vectors
		InputX = Input.GetAxis ("Horizontal");
		InputZ = Input.GetAxis ("Vertical");

		//anim.SetFloat ("InputZ", InputZ, VerticalAnimTime, Time.deltaTime * 2f);
		//anim.SetFloat ("InputX", InputX, HorizontalAnimSmoothTime, Time.deltaTime * 2f);

		//Calculate the Input Magnitude
		speed = new Vector2(InputX, InputZ).sqrMagnitude;

        //Physically move player

		if (speed > allowPlayerRotation) {
			anim.SetFloat ("Blend", speed, StartAnimTime, Time.deltaTime);
		} else if (speed < allowPlayerRotation) {
			anim.SetFloat ("Blend", speed, StopAnimTime, Time.deltaTime);
		}
	}
}
