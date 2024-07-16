using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5.0f;
    public Joystick joystick; // Посилання на джойстик
    public GameObject buttonClose;
    public TMP_Text scoreText;
    public TMP_Text scoreTextGame;
    private int score = 0;

    private bool gameOver = false;

    private void Start()
    {
        buttonClose.SetActive(false);
    }
    void Update()
    {
        if (gameOver)
        {
            return;
        }
        scoreTextGame.text = "Score: " + score.ToString();
        // Отримання вводу від джойстика
        float horizontal = joystick.Horizontal;
        float vertical = joystick.Vertical;

        // Розрахунок руху
        Vector3 movement = new Vector3(horizontal, 0.0f, vertical) * speed * Time.deltaTime;

        // Здійснення руху
        transform.Translate(movement);
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Перевірка, чи зіткнувся гравець з перешкодою
        if (collision.gameObject.tag == "Obstacle")
        {
            gameOver = true;
            scoreText.text = "You score: " + score.ToString();
            buttonClose.SetActive(true);
            // Для перезапуску сцени або виконання іншої дії можна використовувати наступний рядок:
            // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Перевірка, чи зіткнувся гравець з монетою
        if (other.gameObject.tag == "Coin")
        {
            // Збільшуємо рахунок
            score += 1;
            
            // Знищуємо монету
            Destroy(other.gameObject);
        }
    }
}
