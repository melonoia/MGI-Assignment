using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour {

	public float moveSpeed = 10f;
	public float rotationSpeed;

	private float rotation;
	
	private Rigidbody rb;

	void Start ()
	{
		rb = GetComponent<Rigidbody>();
	}

	void Update ()
	{
		rotation = Input.GetAxisRaw("Horizontal");
	}

	void FixedUpdate ()
	{
		rb.MovePosition(rb.position + transform.forward * moveSpeed * Time.fixedDeltaTime);
	/*	
		Vector3 yRotation = Vector3.up * rotation * rotationSpeed * Time.fixedDeltaTime;
		
		Quaternion deltaRotation = Quaternion.Euler(yRotation);
		
	 	Quaternion targetRotation = rb.rotation * deltaRotation;
	 	
	 	rb.MoveRotation(Quaternion.Slerp(rb.rotation, targetRotation, 10f * Time.deltaTime));
	*/	 	
	}

}
