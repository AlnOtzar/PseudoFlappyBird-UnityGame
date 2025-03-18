using UnityEngine;

public class Movimiento : MonoBehaviour
{
    [SerializeField] private float upForce = 151550f;
    [SerializeField] private AudioSource musicaFondo;
    [SerializeField] private AudioSource efectoMuerte;

    private bool estaMuerto;
    private Rigidbody2D playerRB;
    private Animator playerAnimator;

    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
    }

    void Update()
    {
        if (MenuPausa.enPausa) return;  

        if (Input.GetMouseButtonDown(0) && !estaMuerto)
        {
            Flap();
        }
    }

    private void Flap()
    {
        playerRB.linearVelocity = Vector2.zero;  // Cambié 'linearVelocity' a 'velocity', ya que 'linearVelocity' no existe en Rigidbody2D
        playerRB.AddForce(Vector2.up * upForce);
        playerAnimator.SetTrigger("Flap");
    }
        
    private void OnCollisionEnter2D()
    {
        estaMuerto = true;
        playerAnimator.SetTrigger("Die");

        if (musicaFondo != null)
        {
            musicaFondo.Stop();
        }

        if (efectoMuerte != null)
        {
            efectoMuerte.Play();
        }

        Debug.Log("GameOver llamado");
        GameManager.Instance.GameOver();
    }
}
