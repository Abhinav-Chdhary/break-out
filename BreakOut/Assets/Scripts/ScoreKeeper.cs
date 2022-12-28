using UnityEngine;
using UnityEngine.UI;

public class ScoreKeeper : MonoBehaviour
{
    public int scoreValue { get; private set; }
    Text textscoreText;

    public void Awake()
    {
        textscoreText= GetComponent<Text>();
        //scoreValue = GetComponent<>();
    }
}
