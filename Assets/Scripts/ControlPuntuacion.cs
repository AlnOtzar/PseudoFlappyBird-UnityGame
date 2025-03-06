using UnityEngine;
using TMPro;

public class ControlPuntuacion : MonoBehaviour
{
    private TMP_Text puntosTexto;
    public int puntuacion = 0;  // Puntuación del jugador

    void Start()
    {
        // Encuentra el objeto con el tag "puntos" y asigna el componente TMP_Text
        GameObject puntosObject = GameObject.FindGameObjectWithTag("puntos");

        if (puntosObject != null)
        {
            puntosTexto = puntosObject.GetComponent<TMP_Text>();
            ActualizarTextoPuntuacion();
        }
        else
        {
            Debug.LogError("No se encontró el objeto con el tag 'puntos'. Verifica que el TextMeshPro tenga el tag correcto.");
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("puntuacion"))
        {
            puntuacion++;  // Incrementar la puntuación
            ActualizarTextoPuntuacion();
        }
    }

    private void ActualizarTextoPuntuacion()
    {
        if (puntosTexto != null)
        {
            puntosTexto.text = puntuacion.ToString();  // Actualizar el texto en pantalla
        }
    }

    // Este método permitirá al GameManager obtener la puntuación actualizada
    public int ObtenerPuntuacion()
    {
        return puntuacion;
    }
}
