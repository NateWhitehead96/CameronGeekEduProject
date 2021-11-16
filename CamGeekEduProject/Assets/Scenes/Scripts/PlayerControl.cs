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
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerInput();
        //Checks();
        
    }

    public void PlayerInput()
    {
        if (!isGrounded)
        {
            input = Input.GetAxisRaw("Horizontal") * moveSpeed;
        }else if (isGrounded)
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
    //void Checks()
    //{
        
    //    isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
    //}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground")) // when we hit ground we check the grounded bool
        {
            isGrounded = true;
        }

        if (collision.gameObject.CompareTag("Fly"))
        {
            Score += 1; // score++;
            Destroy(collision.gameObject);
        }
    }
}
