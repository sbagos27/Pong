using UnityEngine;
using UnityEngine.InputSystem;

public class Paddle : MonoBehaviour
{
    
    //leave in for explain in vid how not working
    public Rigidbody rb;
    
    public float paddleSpeed;
  
    private Vector3 paddleDirection;
    
    public InputActionReference move;
    
    public AudioClip paddleHit;
  
    private void OnEnable()
    {
        move.action.Enable();
    }
    //THIS IS NEEDED TO HAVE BOTH MOVE
    private void OnDisable()
    {
        move.action.Disable();
    }

    void OnCollisionEnter(Collision collision)
    {
        AudioSource audioSrc = GetComponent<AudioSource>();
        audioSrc.clip = paddleHit;
        audioSrc.Play();
    }
    
    void FixedUpdate()
    {
        rb.linearVelocity = new Vector3(paddleDirection.x * paddleSpeed, paddleDirection.y * paddleSpeed);
    }
    
    void Update()
    {
        paddleDirection = move.action.ReadValue<Vector3>();
        
    }
}