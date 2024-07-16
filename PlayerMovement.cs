using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5.0f;
    public Joystick joystick; // ��������� �� ��������
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
        // ��������� ����� �� ���������
        float horizontal = joystick.Horizontal;
        float vertical = joystick.Vertical;

        // ���������� ����
        Vector3 movement = new Vector3(horizontal, 0.0f, vertical) * speed * Time.deltaTime;

        // ��������� ����
        transform.Translate(movement);
    }

    private void OnCollisionEnter(Collision collision)
    {
        // ��������, �� �������� ������� � ����������
        if (collision.gameObject.tag == "Obstacle")
        {
            gameOver = true;
            scoreText.text = "You score: " + score.ToString();
            buttonClose.SetActive(true);
            // ��� ����������� ����� ��� ��������� ���� 䳿 ����� ��������������� ��������� �����:
            // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // ��������, �� �������� ������� � �������
        if (other.gameObject.tag == "Coin")
        {
            // �������� �������
            score += 1;
            
            // ������� ������
            Destroy(other.gameObject);
        }
    }
}
