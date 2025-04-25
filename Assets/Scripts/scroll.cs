using UnityEngine;

public class scroll : MonoBehaviour
{
    [SerializeField] private float speed = 900.5f;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.linearVelocity = Vector2.left * speed; 
    }

    void Update()
    {
        if(GameManager.Instance.isGamerOver){
            rb.linearVelocity = Vector2.zero;
        }
    }
}
