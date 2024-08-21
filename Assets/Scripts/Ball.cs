using UnityEngine;

public class Ball : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb;
    private AudioSource audio;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        audio = GetComponent<AudioSource>();
        LaunchBall();
    }

    private void LaunchBall()
    {
        bool isRight = Random.value >= 0.5;
        float xVelocity = -1f;

        if (isRight)
        {
            xVelocity = 1f;
        }

        float yVelocirty = Random.Range(-1, 1);

        rb.linearVelocity = new Vector2(xVelocity * speed, yVelocirty * speed);
    }

    public void ReplaceBall()
    {
        gameObject.transform.position = new Vector3(0f, 0f, 0f);
        LaunchBall();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        audio.Play();
        if (collision.gameObject.name == "AIscoreBorder")
        {
            GameManager.Instance.UpdateScore(true);
        }
        if (collision.gameObject.name == "PlayerBorder")
        {
            GameManager.Instance.UpdateScore(false);

        }
    }

}
