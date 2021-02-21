using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Controller : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    // This is used to counteract the increase in mass after collecting objects
    [HideInInspector] public float forceMultiplyer = 1f;

    private Rigidbody rb;

    // Should the player move relitive to the camera's rotation
    public bool useRelitiveInput = false;

    // How many 'ground' objects is the player touching?
    int groundContacts = 0;

    public float airDrag = 0.3f;
    public float groundDrag = 2f;


    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    private void Start()
    {
        rb = GetComponent<Rigidbody>();

        forceMultiplyer = 1.0f;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.transform.CompareTag("Collectible"))
        {
            groundContacts++;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (!collision.transform.CompareTag("Collectible"))
        {
            groundContacts--;
        }
    }


    private void Update()
    {
        // While the player is on the ground, they can move
        if (groundContacts > 0)
		{
            Move();
            Jump();

            rb.drag = groundDrag;
        }
        // While in the air, the player cant move and have reduced drag
		else
		{
            rb.drag = airDrag;
		}
    }


	void Move()
	{
        if (useRelitiveInput)
        {
            float horizontalAxis = Input.GetAxis("Horizontal");
            float verticalAxis = Input.GetAxis("Vertical");

            Camera cam = Camera.main;
            if (cam == null)
            {
                Debug.LogError("No main camera. Add a main camera by setting the MainCamera tag");
                return;
            }

            var forward = cam.transform.forward;
            var right = cam.transform.right;

            //use 2d components
            forward.y = 0f;
            right.y = 0f;
            forward.Normalize();
            right.Normalize();

            //rotate and apply force
            var desiredMoveDirection = forward * verticalAxis + right * horizontalAxis;
            desiredMoveDirection.Normalize();

            //a flat multiplier is used to compensate for the addition of delta time, so speed stays at a similar scale
            rb.AddForce(desiredMoveDirection * speed * forceMultiplyer * Time.deltaTime * 60);
        }
        else
        {
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");

            Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

            rb.AddForce(movement * speed * forceMultiplyer * Time.deltaTime * 60);
        }
    }

	void Jump()
    {
        if (Input.GetButtonDown("Jump"))
        {
            rb.AddForce(Vector3.up * jumpForce * forceMultiplyer, ForceMode.Impulse);
        }
    }
}