using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;  

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject gameOverText;

    public bool isGamerOver;

    private static GameManager instance;
    public static GameManager Instance { get { return instance; } }


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

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
