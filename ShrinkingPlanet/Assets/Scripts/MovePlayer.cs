using UnityEngine;
using UnityEngine.EventSystems;

public class MovePlayer : MonoBehaviour, IPointerDownHandler, IPointerUpHandler {

	public float moveSpeed = 20f;
	public float rotationSpeed;
	
	private float rotation;
	
	public GameObject player;
	private Rigidbody rb;
	
	bool isPressed = false;
	
	void Start ()
	{
		rb = player.GetComponent<Rigidbody>();
	}
	
	void Update()
	{
		//rotation = Input.GetAxisRaw("Horizontal");
	}
	
	void FixedUpdate ()
	{
		if(isPressed)
		{	
			Vector3 yRotation = Vector3.up * rotationSpeed * Time.fixedDeltaTime;			
			Quaternion deltaRotation = Quaternion.Euler(yRotation);			
		 	Quaternion targetRotation = rb.rotation * deltaRotation;		 	
		 	rb.MoveRotation(Quaternion.Slerp(rb.rotation, targetRotation, 10f * Time.deltaTime));
		}	
			return;
	}
	
	public void OnPointerDown(PointerEventData eventData)
	{
		isPressed = true;
	}
	
	public void OnPointerUp(PointerEventData eventData)
	{
		isPressed = false;
	}
	
}
