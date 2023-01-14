using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float moveSpeed = 10f;
    public float rotationSpeed = 10f;
    public float touchSensitivity = 100f;

    private float rotation;
    private Rigidbody rb;

    void Start ()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update ()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            rotation = touch.position.x / touchSensitivity;
        }
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
