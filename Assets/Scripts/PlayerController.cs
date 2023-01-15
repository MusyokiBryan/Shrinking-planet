using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float moveSpeed = 10f;
	public float rotationSpeed = 10f;

	private float rotation;
	private Rigidbody rb;

	public Joystick joystick;

	void Start ()
	{
		rb = GetComponent<Rigidbody>();
	}

	void Update ()
	{
		rotation = joystick.Horizontal;
	}

	void FixedUpdate ()
	{
		rb.MovePosition(rb.position + transform.forward * moveSpeed * Time.fixedDeltaTime);
		Vector3 yRotation = Vector3.up * rotation * rotationSpeed * Time.fixedDeltaTime;
		Quaternion deltaRotation = Quaternion.Euler(yRotation);
		Quaternion targetRotation = rb.rotation * deltaRotation;
		rb.MoveRotation(Quaternion.Slerp(rb.rotation, targetRotation, 50f * Time.deltaTime));
		
	}

}
