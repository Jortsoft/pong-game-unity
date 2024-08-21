using UnityEngine;

public class DeskController : MonoBehaviour
{
    [SerializeField] private bool isAI;
    [SerializeField] private Transform ball;

    private float speed = 5;

    private void Update()
    {
        if (isAI)
        {
            MoveAIdesk();
        } else
        {
            MoveDesk();
        }
    }

    private void MoveDesk()
    {
        // Get the mouse position in world coordinates
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // Update the object's position, maintaining the fixed X position
        if (Time.timeScale == 0) return;
        transform.position = new Vector3(gameObject.transform.position.x, mousePosition.y, transform.position.z);
    }
    private void MoveAIdesk()
    {
        if (ball.position.y > transform.position.y)
        {
            transform.Translate(Vector2.up * speed * Time.deltaTime);
        }
        else if (ball.position.y < transform.position.y)
        {
            transform.Translate(Vector2.down * speed * Time.deltaTime);
        }

        // Clamp the paddle's position within the screen bounds
        transform.position = new Vector2(transform.position.x, Mathf.Clamp(transform.position.y, -4f, 4f));
    }
}
