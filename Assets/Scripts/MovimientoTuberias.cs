using UnityEngine;

public class Scroll1 : MonoBehaviour
{
    public float speed = 80f;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Inicializa el Rigidbody2D
    }

    void Update()
    {
        if (!GameManager.Instance.isGamerOver) // Solo se mueven si el juego NO ha terminado
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
        }
    }

}
