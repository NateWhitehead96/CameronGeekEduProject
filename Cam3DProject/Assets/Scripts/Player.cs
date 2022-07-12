using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody rb;
    public float jumpForce;
    public Vector3 moveDirection; // what direction the player moves in
    public float horizontalSpeed; // how fast we rotate left and right
    public float yRotation; // holds our y axis rotation

    float horizontal; // movement variable
    float vertical; // movement variable
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // ---- Move input stuff ---- //
        horizontal = Input.GetAxis("Horizontal"); // any input that may effect horizontal movement, a/d, left/right arrow, etc
        vertical = Input.GetAxis("Vertical"); // any input that is for vertical movement, W/S, up and down arrow, etc
        moveDirection = (transform.forward * vertical) + (transform.right * horizontal); // new forward movement direction
        Vector3 force = moveDirection * (moveSpeed * Time.deltaTime); // our force for movement
        transform.position += force; // apply all of that stuff above to our position
        //if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
        //{
        //    horizontal = 0;
        //}

        // ---- Rotation Stuff ---- //
        float rightStick = Input.GetAxis("RightStick X"); // now get the right stick left and right input
        yRotation = rightStick * horizontalSpeed * Time.deltaTime; // hold our new Y axis rotation
        Vector3 playerRotation = transform.rotation.eulerAngles; // this variable will allow us to apply the rotation to the player
        playerRotation.y += yRotation; // set the y rotation
        transform.rotation = Quaternion.Euler(playerRotation); // applies our new rotation

        // ---- Jumping ---- //
        float jump = Input.GetAxis("Jump");
        rb.AddForce(Vector3.up * jumpForce * jump, ForceMode.Impulse); // add force up
        //if (Input.GetAxis("Jump") > 0) // our jump button has been pressed
        //{
        //    rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse); // add force up
        //}
    }
}
