using UnityEngine;
using UnityEngine.InputSystem;

public class Paddle : MonoBehaviour
{
    public Rigidbody rb;
    
    public float paddleSpeed;
  
    private Vector3 paddleDirection;
    
    public InputActionReference move;
  
    void FixedUpdate()
    {
        rb.linearVelocity = new Vector3(paddleDirection.x * paddleSpeed, paddleDirection.y * paddleSpeed);
    }
    
    void Update()
    {
        paddleDirection = move.action.ReadValue<Vector3>();
    }
}