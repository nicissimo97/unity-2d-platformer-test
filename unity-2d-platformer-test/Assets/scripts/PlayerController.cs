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
	public Vector3 respawnPosition;
	public LevelManagerController levelManager;

	void Start () {
		rigidBody = GetComponent<Rigidbody2D>();
		animator = GetComponent<Animator>();
		respawnPosition = transform.position;
		levelManager = FindObjectOfType<LevelManagerController> ();
	}

	void Update () {

		isGrounded = Physics2D.OverlapCircle (groundCheck.position, groundCheckRadius, whatsGround);

		if (Input.GetAxisRaw ("Horizontal") > 0f) {
			rigidBody.velocity = new Vector3 (movingSpeed, rigidBody.velocity.y, 0f);
			transform.localScale = new Vector3 (1f, 1f, 1f);
		} else if (Input.GetAxisRaw ("Horizontal") < 0f) {
			rigidBody.velocity = new Vector3 (-movingSpeed, rigidBody.velocity.y, 0f);
			transform.localScale = new Vector3 (-1f, 1f, 1f);
		} else {
			rigidBody.velocity = new Vector3 (0f, rigidBody.velocity.y, 0f);
		}

		if (Input.GetButtonDown ("Jump") && isGrounded) {
			rigidBody.velocity = new Vector3 (rigidBody.velocity.x, jumpingSpeed, 0f);
		}

		animator.SetFloat("Speed", Mathf.Abs (rigidBody.velocity.x));
		animator.SetBool ("Grounded", isGrounded);
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.tag == "killplane") {
			//gameObject.SetActive (false);
			levelManager.Respawn ();
			//transform.position = respawnPosition;
		}
		if (other.tag == "checkpoint") {
			respawnPosition = other.transform.position;
		}
	}

	void OnCollisionEnter2D(Collision2D other){
		if (other.gameObject.tag == "movingPlatform") {
			transform.parent = other.transform;
		}
	}

	void OnCollisionExit2D(Collision2D other){
		if (other.gameObject.tag == "movingPlatform") {
			transform.parent = null;
		}
	}
}
