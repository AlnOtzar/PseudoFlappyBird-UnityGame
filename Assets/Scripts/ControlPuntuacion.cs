using UnityEngine;
using TMPro;

public class ControlPuntuacion : MonoBehaviour
{
    private TMP_Text puntosTexto;
    public int puntuacion = 0;

    void Start()
    {
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
            puntuacion++;
            ActualizarTextoPuntuacion();
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
}
