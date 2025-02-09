using UnityEngine;

public class Scroll1 : MonoBehaviour
{
    [SerializeField] private float speed = 2.5f;  // Velocidad de desplazamiento
    [SerializeField] private float resetX = -10f; // Límite izquierdo donde se reinicia
    [SerializeField] private float spacing = 3.5f; // Espaciado entre tubos
    [SerializeField] private float minY = -2f;    // Altura mínima aleatoria
    [SerializeField] private float maxY = 2f;     // Altura máxima aleatoria

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.left * speed; // Mueve los tubos hacia la izquierda
    }

    void Update()
    {
        if (transform.position.x < resetX) // Si el tubo sale de la pantalla
        {
            ResetPosition();
        }
    }

    private void ResetPosition()
    {
        // Encuentra el tubo más a la derecha
        float maxX = FindFarthestTube();

        // Genera altura aleatoria
        float randomY = Random.Range(minY, maxY);

        // Reposiciona el tubo al final del último tubo más un espacio
        transform.position = new Vector3(maxX + spacing, randomY, transform.position.z);
    }

   private float FindFarthestTube()
{
    GameObject[] tubes = GameObject.FindGameObjectsWithTag("grupotubos");
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
