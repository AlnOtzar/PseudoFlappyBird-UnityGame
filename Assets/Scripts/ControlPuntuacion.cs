using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ControlPuntuacion : MonoBehaviour
{
    private TMP_Text puntosTexto;
    private int puntuacion = 0;

    void Start()
    {
        // Buscar el TextMeshPro con el tag "puntos"
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
        if (col.CompareTag("player")) // Si el objeto que entra tiene el tag "player"
        {
            puntuacion++; // Aumentar la puntuación
            ActualizarTextoPuntuacion();
            Debug.Log($"El objeto {col.gameObject.name} pasó por el BoxCollider2D. Nueva puntuación: {puntuacion}");
        }
    }

    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.CompareTag("player")) // Asegurar que detecta al player si sigue dentro
        {
            Debug.Log($"El objeto {col.gameObject.name} sigue dentro del BoxCollider2D.");
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("player")) // Cuando el objeto sale del BoxCollider2D
        {
            Debug.Log($"El objeto {col.gameObject.name} salió del BoxCollider2D.");
        }
    }

    private void ActualizarTextoPuntuacion()
    {
        if (puntosTexto != null)
        {
            puntosTexto.text = puntuacion.ToString(); // Actualizar el texto con la puntuación actualizada
        }
    }
}
