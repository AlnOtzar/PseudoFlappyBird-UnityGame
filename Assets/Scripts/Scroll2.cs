using UnityEngine;

public class Scroll1 : MonoBehaviour
{
    [SerializeField] private float speed = 75.5f;  // Velocidad de desplazamiento
    [SerializeField] private float resetX = -200f; // Límite izquierdo donde se reinicia
    [SerializeField] private float spacing = 100.5f; // Espaciado constante entre tubos
    [SerializeField] private float minY = 500f;    // Altura mínima aleatoria
    [SerializeField] private float maxY = 700f;     // Altura máxima aleatoria

    private Rigidbody2D rb;

   void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.linearVelocity = Vector2.left * speed;

        // Ajustar la posición inicial solo si está fuera del rango
        if (transform.position.y < minY || transform.position.y > maxY)
        {
            float newY = Random.Range(minY, maxY);
            transform.position = new Vector3(transform.position.x, newY, transform.position.z);
        }
    }


    void Update()
    {
        if (transform.position.x < resetX * .8)  // Si el tubo sale de la pantalla
        {
            ResetPosition();
            
        }
        if(GameManager.Instance.isGamerOver){
            rb.linearVelocity = Vector2.zero;
        }
    }

    private void ResetPosition()
    {
        // Encuentra el tubo más a la derecha
        float maxX = FindFarthestTube();

        // Genera altura aleatoria dentro del rango permitido
        float randomY = Random.Range(minY, maxY);

        // Reposiciona el tubo al final del último tubo más un espacio constante
        transform.position = new Vector3(maxX + spacing, randomY, transform.position.z);
    }

    private float FindFarthestTube()
    {
        GameObject[] tubes = GameObject.FindGameObjectsWithTag("tubos");
        float maxX = float.MinValue;

        foreach (GameObject tube in tubes)
        {
            if (tube.transform.position.x > maxX)
            {
                maxX = tube.transform.position.x;
            }
        }

        return maxX;
    }
}
