using UnityEngine;

public class salto : MonoBehaviour
{
    [SerializeField] private float upForce = 350f;

    private bool isDead;
    private Rigidbody2D playerRb;
    private Animator playerAnimator;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>(); // Obtén el componente Animator  
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !isDead)
        {
            Flap();
        }
    }

    private void Flap()
    {
        playerRb.linearVelocity = Vector2.zero;
        playerRb.AddForce(Vector2.up * upForce);
        playerAnimator.SetTrigger("Flap");
    }

    private void OnCollisionEnter2D()
    {
        isDead = true;
        playerAnimator.SetTrigger("Die");
    }
}
