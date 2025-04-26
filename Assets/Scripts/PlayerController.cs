using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float jumpForce = 5f;
    [SerializeField] private int maxJumps = 2;
    [SerializeField] public float maxFloatTime = 2f;
    public float floatGravityMultiplier = 0.3f;
    [SerializeField] private bool isGrounded;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundCheckRadius = 0.2f;
    [SerializeField] private LayerMask groundLayer;
    
    private Rigidbody rb;
    [SerializeField] private Animator animator;
    [SerializeField] private Transform playerModel;
    bool isFloating;

    private int jumpCount=0;
    private float floatTimer=0;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {

        //movement
        float moveInput = Input.GetAxis("Horizontal");
        Vector3 velocity = rb.linearVelocity;
        velocity.x = moveInput * moveSpeed;
        rb.linearVelocity = velocity;

        
        if (moveInput>0.1f)
        {
            
            Quaternion targetRotation = Quaternion.Euler(0, 0, 0);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, 720f * Time.deltaTime);
        }
        else if(moveInput<-0.1f)
        {
           
            Quaternion targetRotation = Quaternion.Euler(0, 180, 0);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, 720f * Time.deltaTime);
        }


        animator.SetBool("isGrounded", isGrounded);
        animator.SetFloat("Speed", Mathf.Abs(rb.linearVelocity.x));
        animator.SetBool("isFloating", isFloating);


        isGrounded = Physics.CheckSphere(groundCheck.position, groundCheckRadius, groundLayer);

        if (isGrounded)
        {
            jumpCount = 0;
            floatTimer = maxFloatTime;
        }

        if (Input.GetKeyDown(KeyCode.W) && jumpCount < maxJumps-1)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
           jumpCount++;
           
        }
       
        if (!isGrounded && Input.GetKey(KeyCode.Space) && floatTimer > 0f)
        {
            isFloating = true;
              Vector3 floatVelocity = rb.linearVelocity;
            floatVelocity.y *= floatGravityMultiplier;
            rb.linearVelocity = floatVelocity;
            floatTimer -= Time.deltaTime;
        }
        else
        {
            isFloating = false;
        }
    }
}
