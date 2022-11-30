using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int score = 0, level = 1, lives = 3;
    public Ball ball { get; private set; }
    public Paddle paddle { get; private set; }
    public Brick[] bricks { get; private set; }
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        SceneManager.sceneLoaded += OnLevelLoaded;
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
    private void OnLevelLoaded(Scene scene, LoadSceneMode mode)
    {
        this.ball = FindObjectOfType<Ball>();
        this.paddle= FindObjectOfType<Paddle>();
    }
    public void Hit(Brick brick)
    {
        this.score += brick.points;
        if (Cleared())
        {
            loadLevel(this.level + 1);
        }
    }
    private void ResetLevel()
    {
        this.paddle.ResetPaddle();
        this.ball.ResetBall();
    }
    private void GameOver()
    {
        //SceneManager.LoadScene("GameOver");
        NewGame();
    }
    public void HitBottom()
    {
        this.lives--;
        if (this.lives > 0)
            ResetLevel();
        else
            GameOver();
    }
    private bool Cleared()
    {
        for(int i=0; i<this.bricks.Length; i++)
        {
            if (this.bricks[i].gameObject.activeInHierarchy && !this.bricks[i].unbreakable) 
                return false;
        }
        return true;
    }
}
