using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float moveSpeed;
    public float jumpForce;
    private float input;
    public Rigidbody2D playerRigidBody;
    private bool isGrounded;
    public Transform groundCheck;
    public LayerMask groundLayer;
    public float groundCheckRadius;
    public GameObject JumpParticles;

    public static int Score;

    public bool isInWater;

    public Vector3 CheckpointPosition;

    public bool isDead = false;
    public float WaterLevel; // the y value for the water
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!isDead)
        {
            PlayerInput();
        }
        else
            HitByHazard();
        //Checks();
        
    }

    public void PlayerInput()
    {
        if (!isInWater)
        {
            if (!isGrounded) // land controls
            {
                input = Input.GetAxisRaw("Horizontal") * moveSpeed;
            }
            else if (isGrounded)
            {
                input = 0;
            }

            if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
            {
                playerRigidBody.AddForce(new Vector2(0, jumpForce));
                Instantiate(JumpParticles, groundCheck.position, JumpParticles.transform.rotation);
                isGrounded = false; // shows we're jumping
            }
            playerRigidBody.velocity = new Vector2(input, playerRigidBody.velocity.y);
        }

        if (input == 0) // being idle/standing still in the water
        {
            transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, 0); // rotate us back to 0
        }

        if (isInWater) // water controls
        {
            input = Input.GetAxisRaw("Horizontal") * moveSpeed;

            transform.position = new Vector3(transform.position.x + input * Time.deltaTime, transform.position.y);

            if(input > 0) // moving right in the water
            {
                transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, -10); // rotate us 10 degrees
            }
            if(input < 0)// moving left in the water
            {
                transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, 10); // rotate us 10 degrees
            }
            

            if (Input.GetKeyDown(KeyCode.Space))
            {
                playerRigidBody.AddForce(new Vector2(0, jumpForce));
                Instantiate(JumpParticles, groundCheck.position, JumpParticles.transform.rotation);
                isGrounded = false; // shows we're jumping
            }
        }
    }

    public void HitByHazard()
    {
        // disable our collider
        CircleCollider2D collider = GetComponent<CircleCollider2D>(); // get a reference to our collider
        collider.enabled = false; // this will disable the collider
        playerRigidBody.gravityScale = 0; // disable gravity
        Vector3 distanceToCP = transform.position - CheckpointPosition; // finding the vector to the checkpoint
        playerRigidBody.MovePosition(CheckpointPosition);
        //transform.Translate(distanceToCP * 1 * Time.deltaTime); // moving us to the checkpoint
        if (transform.position.x == CheckpointPosition.x) // when we hit the checkpoint enable collider and gravity
        {
            isDead = false;
            collider.enabled = true;
            playerRigidBody.gravityScale = 1;
        }
        
    }
    //void Checks()
    //{
        
    //    isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
    //}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground")) // when we hit ground we check the grounded bool
        {
            isGrounded = true;
            isInWater = false;
        }

        if (collision.gameObject.CompareTag("Water"))
        {
            isInWater = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Water"))
        {
            isInWater = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Fly"))
        {
            Score += 1; // score++;
            collision.gameObject.GetComponent<FlyBehaviour>().Collected = true; // the fly we run into will be set to collected
        }

        if (collision.gameObject.CompareTag("Checkpoint"))
        {
            CheckpointPosition = collision.gameObject.transform.position;
        }
    }

}
