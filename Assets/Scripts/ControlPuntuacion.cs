using UnityEngine;
using TMPro;

public class ControlPuntuacion : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI puntosTexto;  
    [SerializeField] private TextMeshProUGUI puntosRecord;
    public int puntuacion = 0;  

    void Start()
    {
        puntosTexto.text = puntuacion.ToString();
        puntosRecord.text = PlayerPrefs.GetInt("BestScore", 0).ToString();
    }

    public void ActualizarRecordPuntuacion()
    {
        int bestScore = PlayerPrefs.GetInt("BestScore", 0);

        if (puntuacion > bestScore)
        {
            PlayerPrefs.SetInt("BestScore", puntuacion);  
            PlayerPrefs.Save(); 
            puntosRecord.text = puntuacion.ToString();
        }
    }

    public void ActualizarPuntuacion()
    {
        puntuacion++;
        puntosTexto.text = puntuacion.ToString();
        ActualizarRecordPuntuacion();  
    }
}
