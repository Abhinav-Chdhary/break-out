using UnityEngine;

public class LooseZone : MonoBehaviour
{
    public AudioSource GameOverSound { get; private set; }
    private void Start()
    {
        GameOverSound= GetComponent<AudioSource>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Ball")
        {
            GameOverSound.Play();
            FindObjectOfType<GameManager>().HitBottom();
        }
    }
}
