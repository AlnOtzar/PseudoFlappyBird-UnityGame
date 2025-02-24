using Unity.VisualScripting;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject gameOverText;

    public bool isGamerOver;
    private static GameManager instance;
    public static GameManager Instance { get {return instance;} }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        if(instance == null){
            instance = this;
        }
        else{
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0) && isGamerOver){
            RestartGame();
        }
        
    }

    public void GameOver()
    {
        isGamerOver = true;
        gameOverText.SetActive(true);
    }

    private void RestartGame(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
