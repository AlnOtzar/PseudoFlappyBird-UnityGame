using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;  // Necesario para usar TextMesh Pro

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject gameOverText;
    [SerializeField] private TMP_Text puntuacionFinalText; // Para el componente TMP_Text de TextMesh Pro

    public bool isGamerOver;

    private static GameManager instance;
    public static GameManager Instance { get { return instance; } }

    // Referencia al script ControlPuntuacion

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        if (Input.GetMouseButton(0) && isGamerOver)
        {
            RestartGame();
        }
    }

    public void GameOver()
    {
        isGamerOver = true;
        gameOverText.SetActive(true);
    }


    private void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
