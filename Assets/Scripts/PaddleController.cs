using UnityEngine;
using UnityEngine.InputSystem;

public class PaddleController : MonoBehaviour
{
    public InputActionReference moveAction; 
    public float speed = 5f;

    private void OnEnable()
    {
        moveAction.action.Enable();
    }

    private void OnDisable()
    {
        moveAction.action.Disable();
    }

    private void Update()
    {
        float moveInput = moveAction.action.ReadValue<Vector2>().y; 
        transform.Translate(Vector3.up * moveInput * speed * Time.deltaTime);
    }
}