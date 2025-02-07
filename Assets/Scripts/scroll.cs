using UnityEngine;

public class scroll : MonoBehaviour
{
    [SerializeField] private float speed = 2.5f;
    private Rigidbody2D rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.linearVelocity = Vector2.left * speed; 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
