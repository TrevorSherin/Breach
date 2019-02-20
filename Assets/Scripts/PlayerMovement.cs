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
            //Debug.DrawLine(cameraRay.origin, pointToLook, Color.blue);
            transform.LookAt(pointToLook);
        }
        
        /*float hAxis = Input.GetAxis("Horizontal");
        float vAxis = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(hAxis, 0, vAxis) * moveSpeed * Time.deltaTime;
        print (rig);
        rig.MovePosition(transform.position + movement);*/
    }

    void FixedUpdate()
    {
        rig.velocity = moveVelocity;
    }
}
