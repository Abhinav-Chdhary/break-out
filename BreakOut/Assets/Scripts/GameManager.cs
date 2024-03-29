using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int score = 0, level = 1, lives = 3;
    public Ball ball { get; private set; }
    public Paddle paddle { get; private set; }
    public Brick[] bricks { get; private set; }
    //UI elements
    public Text scoreText;
    public Text liveNumber;
    public Button playButton;
    public Button pauseButton;
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        SceneManager.sceneLoaded += OnLevelLoaded;
        scoreText.text = score.ToString();
    }
    private void Start()
    {
        Button play = playButton.GetComponent<Button>();
        play.onClick.AddListener(startPlaying);
        Button pause = pauseButton.GetComponent<Button>();
        pause.onClick.AddListener(stopPlaying);
        NewGame();
    }
    private void NewGame()
    {
        score = 0;
        lives = 3;
        Time.timeScale = 0; //game paused by default
        scoreText.text = score.ToString();
        liveNumber.text = lives.ToString();

        loadLevel(1);
    }
    private void startPlaying()
    {
        Time.timeScale = 1;
    }
    private void stopPlaying()
    {
        Time.timeScale = 0;
    }
    private void loadLevel(int level)
    {
        this.level = level;

        SceneManager.LoadScene("Level"+level);
    }
    private void OnLevelLoaded(Scene scene, LoadSceneMode mode)
    {
        ball = FindObjectOfType<Ball>();
        paddle= FindObjectOfType<Paddle>();
        bricks = FindObjectsOfType<Brick>();
    }
    public void Hit(Brick brick)
    {
        score += brick.points;
        if (Cleared())
        {
            loadLevel(level + 1);
        }
        //update score
        scoreText.text = score.ToString();
    }
    private void ResetLevel()
    {
        paddle.ResetPaddle();
        ball.ResetBall();
    }
    private void GameOver()
    {
        NewGame();
    }
    public void HitBottom()
    {
        lives--;
        liveNumber.text = lives.ToString();
        if (lives > 0)
            ResetLevel();
        else
            GameOver();
    }
    private bool Cleared()
    {
        for(int i=0; i<bricks.Length; i++)
        {
            if (bricks[i].gameObject.activeInHierarchy && !bricks[i].unbreakable) 
                return false;
        }
        return true;
    }
}