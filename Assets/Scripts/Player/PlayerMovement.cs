using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 5f;
    [SerializeField]
    private float jumpForce = 10f;
    [SerializeField]
    private float rotationSpeed = 0.5f; // For mouse rotation
    
    //State
    private Rigidbody rb;
    private bool isGrounded = true;
    private float yaw; // For mouse rotation
    
    //Reference
    private PlayerInput input;
    
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        input = GetComponent<PlayerInput>();
        rb.freezeRotation = true;
    }
        
    private void Update()
    {
      HandleRotation();
      
      if (input.JumpPressed && isGrounded)
      {
         Jump();
      }
    }
    
    private void FixedUpdate()
        {
           HandleMovement(); 
           Debug.Log($"PlayerMovement using MoveInput: {input.MoveInput}");

        }
        
    private void HandleRotation()
            {
                 yaw += input.MouseX * rotationSpeed;
                 transform.rotation = Quaternion.Euler(0f, yaw, 0f);   
            }
            
    private void HandleMovement()
    {
        Vector2 move = input.MoveInput;
        Vector3 direction = transform.forward * move.y + transform.right * move.x;
        Vector3 velocity = direction.normalized * moveSpeed;

        // Apply velocity while maintaining vertical (Y) velocity
        Vector3 currentVelocity = rb.linearVelocity;
        rb.linearVelocity = new Vector3(velocity.x, currentVelocity.y, velocity.z);
    }

    
    private void Jump()
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
        
     private void OnCollisionEnter(Collision collision)
         {
             if (collision.gameObject.CompareTag("Ground"))
             {
                 isGrounded = true;
             }
         }
}
