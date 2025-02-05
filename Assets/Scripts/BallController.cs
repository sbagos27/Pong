using UnityEngine;
using UnityEngine.Rendering.Universal;

public class BallController : MonoBehaviour
{
    public Rigidbody rb;

    public float speed;
    
    void Start()
    {
        Launch();
    }

    void Update()
    {
        Vector3 up = new Vector3(0f, 1f, 0f);
        Quaternion posRotation = Quaternion.Euler(0f, 45f, 0f);
        Quaternion negRotation = Quaternion.Euler(0f, -45f, 0f);

        Vector3 posVector = posRotation * up;
        Vector3 negVector = negRotation * up;
        
        Debug.DrawRay(transform.position, posVector, Color.red);
        Debug.DrawRay(transform.position, negVector, Color.green);

    }
    
    void OnCollisionEnter(Collision collision)
    {
        if (rb.linearVelocity.magnitude == 0)
        {
            Launch();
        }
        
        Vector3 normal = collision.contacts[0].normal;

        Vector3 reflectedVelocity = Vector3.Reflect(rb.linearVelocity, normal);

        rb.linearVelocity = reflectedVelocity * 1.8f;
    }
    
    public void Launch()
    {
        transform.rotation = Quaternion.identity;

        transform.position = new Vector3(10,0,0);
        
        float x = Random.Range(0, 2) == 0 ? -1 : 1;
        float y = Random.Range(0, 2) == 0 ? -1 : 1;

        Vector3 launchDirection = new Vector3(x, y, 0).normalized;
        rb.linearVelocity = launchDirection * speed;
    }
    
}