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
    public bool jumping; // a bool for jumping
    public bool inputSwitch; // to know if we're controller or keyboard, controller = true and keyboard = false

    public int coins;
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
        

        // ---- Rotation Stuff ---- //
        if (inputSwitch == true) // if using controller
        {
            float rightStick = Input.GetAxis("RightStick X"); // now get the right stick left and right input
            yRotation = rightStick * horizontalSpeed * Time.deltaTime; // hold our new Y axis rotation
            Vector3 playerRotation = transform.rotation.eulerAngles; // this variable will allow us to apply the rotation to the player
            playerRotation.y += yRotation; // set the y rotation
            transform.rotation = Quaternion.Euler(playerRotation); // applies our new rotation
        }
        if(inputSwitch == false) // if using mouse and keyboard
        {
            float mouseX = Input.GetAxis("Mouse X"); // get the mouse X axis
            yRotation = mouseX * horizontalSpeed * Time.deltaTime; // hold our new Y axis rotation
            Vector3 playerRotation = transform.rotation.eulerAngles; // this variable will allow us to apply the rotation to the player
            playerRotation.y += yRotation; // set the y rotation
            transform.rotation = Quaternion.Euler(playerRotation); // applies our new rotation
        }

        // ---- Jumping ---- //
        if (jumping == false && Input.GetAxis("Jump") > 0) // only run the jump stuff if we havent jumped yet
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse); // add force up
            jumping = true;
        }
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        jumping = false; // if we collide with anything then we're not jumping. This will be changed in the future
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Coin>()) // when we collide with a coin
        {
            coins++; // increase coin amount by 1
            Destroy(other.gameObject); // destroy the coin
        }
    }
}
