using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Controller : MonoBehaviour
{

    public float speed;
    public float jumpForce;

    private Rigidbody rb;

    public bool useRelitiveInput = false;

    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        Jump();

    }
    void FixedUpdate()
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
            rb.AddForce(desiredMoveDirection * speed);
        }
        else
        {
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");

            Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

            rb.AddForce(movement * speed);
        }


    }
    void Jump()
    {
        if (Input.GetButtonDown("Jump"))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }
}
