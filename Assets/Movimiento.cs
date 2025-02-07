using UnityEngine;

public class Movimiento : MonoBehaviour
{
    [SerializeField] private float upForce = 350f;

    private bool estaMuerto;
    private Rigidbody2D playerRB;
    private Animator playerAnimator;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>(); // Inicialización del Animator

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !estaMuerto)
        {
            Flap();
        }
    }

    private void Flap()
    {
        playerRB.linearVelocity = Vector2.zero;
        playerRB.AddForce(Vector2.up * upForce);
        playerAnimator.SetTrigger("Flap");
    }
        
    private void OnCollisionEnter2D()
    {
        estaMuerto = true;
        playerAnimator.SetTrigger("Die");
    }
}
