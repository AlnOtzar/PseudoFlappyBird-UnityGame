
using UnityEngine;
using UnityEngine.SceneManagement;

public class Salir : MonoBehaviour
{
    
    public void Empezar(string EmpezarNivel)
    {
        SceneManager.LoadScene(EmpezarNivel);
    }
    // Método para salir del juego
    public void SalirJuego()
    {
        Application.Quit();
    }
}
