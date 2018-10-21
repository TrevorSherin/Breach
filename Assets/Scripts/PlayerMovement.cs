using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float speed = 10;
    private Rigidbody rig;

	void Start ()
    {
        rig = GetComponent<Rigidbody>();
	}
	
	void Update ()
    {
        float hAxis = Input.GetAxis("Horizontal");
        float vAxis = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(hAxis, 0, vAxis) * speed * Time.deltaTime;
        print (rig);
        rig.MovePosition(transform.position + movement);
    }
}
