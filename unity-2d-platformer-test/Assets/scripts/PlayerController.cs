using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float movingSpeed;
	public Rigidbody2D rigidBody;
	public Animator animator;
	public float jumpingSpeed;
	public Transform groundCheck;
	public float groundCheckRadius;
	public LayerMask whatsGround;
	public bool isGrounded;

	void Start () {
		rigidBody = GetComponent<Rigidbody2D>();
		animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {

		isGrounded = Physics2D.OverlapCircle (groundCheck.position, groundCheckRadius, whatsGround);

		if (Input.GetAxisRaw ("Horizontal") > 0f) {
			rigidBody.velocity = new Vector3 (movingSpeed, rigidBody.velocity.y, 0f);
		}
		if (Input.GetAxisRaw ("Horizontal") < 0f) {
			rigidBody.velocity = new Vector3 (-movingSpeed, rigidBody.velocity.y, 0f);
		}

		if (Input.GetButtonDown ("Jump") && isGrounded) {
			rigidBody.velocity = new Vector3 (rigidBody.velocity.x, jumpingSpeed, 0f);
		}

		animator.SetFloat("Speed", Mathf.Abs (rigidBody.velocity.x));
		animator.SetBool ("Grounded", isGrounded);
	}
}
