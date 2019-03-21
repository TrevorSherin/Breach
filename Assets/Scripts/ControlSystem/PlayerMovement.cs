using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float moveSpeed = 10;
    private Rigidbody rig;

    private Vector3 moveInput;
    private Vector3 moveVelocity;
    private Camera mainCamera;

    void Start ()
    {
        rig = GetComponent<Rigidbody>();
        mainCamera = FindObjectOfType<Camera>();
	}
	
	void Update ()
    {
        moveInput = new Vector3(-Input.GetAxisRaw("Vertical"), 0f, Input.GetAxisRaw("Horizontal"));
        moveVelocity = moveInput * moveSpeed;

        Ray cameraRay = mainCamera.ScreenPointToRay(Input.mousePosition);
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
        float rayLength;

        if(groundPlane.Raycast(cameraRay, out rayLength))
        {
            Vector3 pointToLook = cameraRay.GetPoint(rayLength);
            
            transform.LookAt(new Vector3(pointToLook.x,transform.position.y,pointToLook.z));
        }
    }

    public void Reset()
    {
        transform.position = new Vector3(0, 0, 0);
        transform.rotation = new Quaternion(0, 0, 0, 0);
    }

    void FixedUpdate()
    {
        rig.velocity = moveVelocity;
    }
}
