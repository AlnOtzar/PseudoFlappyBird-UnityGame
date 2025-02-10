using UnityEngine;

public class Scroll1 : MonoBehaviour
{
    [SerializeField] private float speed = 2.5f;  // Velocidad de desplazamiento
    [SerializeField] private float resetX = -10f; // Límite izquierdo donde se reinicia
    [SerializeField] private float spacing = 2.5f; // Espaciado constante entre tubos
    [SerializeField] private float minY = -2f;    // Altura mínima aleatoria
    [SerializeField] private float maxY = 2f;     // Altura máxima aleatoria

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.linearVelocity = Vector2.left * speed;  // Sincroniza la velocidad de desplazamiento
    }

    void Update()
    {
        if (transform.position.x < resetX)  // Si el tubo sale de la pantalla
        {
            ResetPosition();
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

        // Debug opcional para verificar posiciones
        Debug.Log($"Reposicionando tubo a X: {maxX + spacing}, Y: {randomY}");
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
