using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class ButtonsActive : MonoBehaviour
{
    public int restartSceneIndex;
    public Button pauseButton;

    void Start()
    {
       pauseButton.onClick.AddListener(PauseGame);
    }

    public void LoadingScene()
    {
        // ����������� ����� �� ��������
        SceneManager.LoadScene(restartSceneIndex);
    }

    public void PauseGame()
    {
        if (Time.timeScale == 1)
        {
            Time.timeScale = 0; // �����
            pauseButton.GetComponentInChildren<TMP_Text>().text = "Resume";
        }
        else
        {
            Time.timeScale = 1; // ����������
            pauseButton.GetComponentInChildren<TMP_Text>().text = "Pause";
        }
    }

    public void ExitGame()
    {
        // ����� � ���
        Application.Quit();
    }
}
