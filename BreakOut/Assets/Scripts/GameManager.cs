using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int score = 0, level = 1, lives = 3;
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);

    }
    private void Start()
    {
        NewGame();
    }
    private void NewGame()
    {
        this.score = 0;
        this.lives = 3;

        loadLevel(1);
    }
    private void loadLevel(int level)
    {
        this.level = level;

        SceneManager.LoadScene("Level"+level);
    }
}
