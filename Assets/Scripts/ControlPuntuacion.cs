using UnityEngine;
using TMPro;

public class ControlPuntuacion : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI puntosTexto;  // Se asigna desde el Inspector
    [SerializeField] private TextMeshProUGUI puntosRecord; // Se asigna desde el Inspector
    public int puntuacion = 0;  // Puntuación del jugador

    void Start()
    {
        // Verificar si los objetos están asignados en el Inspector
        if (puntosTexto == null || puntosRecord == null)
        {
            Debug.LogError("TextMeshProUGUI no está asignado en el Inspector.");
            return;
        }

        puntosTexto.text = puntuacion.ToString();
        puntosRecord.text = PlayerPrefs.GetInt("BestScore", 0).ToString();
    }

    public void ActualizarRecordPuntuacion()
    {
        int bestScore = PlayerPrefs.GetInt("BestScore", 0);

        if (puntuacion > bestScore)
        {
            PlayerPrefs.SetInt("BestScore", puntuacion);  // Corregido el typo
            PlayerPrefs.Save();  // Guardar cambios
            puntosRecord.text = puntuacion.ToString();
        }
    }

    public void ActualizarPuntuacion()
    {
        puntuacion++;
        puntosTexto.text = puntuacion.ToString();
        ActualizarRecordPuntuacion();  // Se debe actualizar el récord, no llamarse a sí mismo
    }
}
