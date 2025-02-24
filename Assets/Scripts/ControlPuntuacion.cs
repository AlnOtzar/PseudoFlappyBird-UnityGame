using UnityEngine;
using TMPro;

public class ControlPuntuacion : MonoBehaviour
{
    private TMP_Text puntosTexto;
    private TMP_Text puntosFinalTexto;  // Nueva variable para la puntuación final
    public int puntuacion = 0;
    public int puntuacionFinal = 0;

    void Start()
    {
        GameObject puntosObject = GameObject.FindGameObjectWithTag("puntos");
        GameObject puntosFinalObject = GameObject.FindGameObjectWithTag("PuntuacionFinalText");  // Buscar el objeto con el tag "puntosFinal"

        if (puntosObject != null)
        {
            puntosTexto = puntosObject.GetComponent<TMP_Text>();
            ActualizarTextoPuntuacion();
        }
        else
        {
            Debug.LogError("No se encontró el objeto con el tag 'puntos'. Verifica que el TextMeshPro tenga el tag correcto.");
        }

        if (puntosFinalObject != null)
        {
            puntosFinalTexto = puntosFinalObject.GetComponent<TMP_Text>();  // Asignar el texto de la puntuación final
            ActualizarTextoPuntuacionFinal();
        }
        else
        {
            Debug.LogError("No se encontró el objeto con el tag 'puntosFinal'. Verifica que el TextMeshPro tenga el tag correcto.");
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("puntuacion")) 
        {
            puntuacion++;
            puntuacionFinal = puntuacion;  // Actualizar la puntuación final
            ActualizarTextoPuntuacion();
            ActualizarTextoPuntuacionFinal();  // Actualizar la puntuación final
            Debug.Log($"Punto sumado en: {col.gameObject.name}. Total: {puntuacion}");
        }
    }

    private void ActualizarTextoPuntuacion()
    {
        if (puntosTexto != null)
        {
            puntosTexto.text = puntuacion.ToString();
        }
    }

    private void ActualizarTextoPuntuacionFinal()
    {
        if (puntosFinalTexto != null)
        {
            puntosFinalTexto.text = puntuacionFinal.ToString();  // Mostrar la puntuación final
        }
    }
}
