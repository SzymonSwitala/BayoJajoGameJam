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
    [SerializeField] private GameObject playerModel;
    [SerializeField] private GameObject deadModel;

    [SerializeField] AudioClip deadSound,jumpSound;
    [SerializeField] private int deadSoundVolume=100,jumpSoundVolume=100;
    bool isFloating;
    public float fallMultipler = 3;
    public float lowJumpMultipler = 2;
   
    private int jumpCount=0;
    private float floatTimer=0;
    bool isDead = false;

    public bool canMove = true;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
       
    }

    void Update()
    {
        if (!canMove) return;
        //movement
        float moveInput = Input.GetAxis("Horizontal");
        Vector3 velocity = rb.linearVelocity;
        velocity.x = moveInput * moveSpeed;
        rb.linearVelocity = new Vector3(velocity.x,rb.linearVelocity.y,0);

      

        if (moveInput > 0.1f)
        {

            Quaternion targetRotation = Quaternion.Euler(0, 0, 0);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, 720f * Time.deltaTime);
        }
        else if (moveInput < -0.1f)
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
            //     rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            rb.linearVelocity = new Vector3(rb.linearVelocity.x, jumpForce, 0);
            AudioManager.Instance.PlayOneShot(jumpSound, jumpSoundVolume);
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

        if (rb.linearVelocity.y < 0)
        {
            rb.linearVelocity += Vector3.up * Physics.gravity.y * (fallMultipler - 1) * Time.deltaTime;
        }
        else if (rb.linearVelocity.y > 0 && !Input.GetKey(KeyCode.W))
        {
            rb.linearVelocity += Vector3.up * Physics.gravity.y * (lowJumpMultipler - 1) * Time.deltaTime;
        }

    }

    public void Dead()
    {
        if (isDead) return;
        Debug.Log("Jajecznica");
        isDead = true;
        AudioManager.Instance.PlayOneShot(deadSound,deadSoundVolume);
        canMove = false;
        playerModel.SetActive(false);
        deadModel.SetActive(true);
   
    }
}
