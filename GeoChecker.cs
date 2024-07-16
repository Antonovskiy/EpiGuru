using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using System.Collections;

public class GeoChecker : MonoBehaviour
{
    private string geoCheckUrl = "https://ipapi.co/json/";

    void Awake()
    {
        StartCoroutine(CheckGeoLocation());
    }

    IEnumerator CheckGeoLocation()
    {
        UnityWebRequest request = UnityWebRequest.Get(geoCheckUrl);
        yield return request.SendWebRequest();

        if (request.result != UnityWebRequest.Result.Success)
        {
            Debug.LogError("Error fetching geo location: " + request.error);
            // Додаткові дії у випадку помилки, наприклад, показати повідомлення користувачу
        }
        else
        {
            GeoResponse response = JsonUtility.FromJson<GeoResponse>(request.downloadHandler.text);
            if (response.country_code == "UA")
            {
                ShowGameScreen();
            }
            else
            {
                ShowWikiPage();
            }
        }
    }

    void ShowGameScreen()
    {
        // Перевірка, чи головна сцена вже завантажена
        if (SceneManager.GetActiveScene().name != "Menu")
        {
            // Завантаження головного екрану гри
            SceneManager.LoadScene("Menu");
        }
    }

    void ShowWikiPage()
    {
        // Показати Вікіпедію на весь екран
        Application.OpenURL("https://uk.wikipedia.org/");
    }

    [System.Serializable]
    public class GeoResponse
    {
        public string ip;
        public string country_code;
        public string country_name;
        // Додаткові поля, які ви можете використовувати з відповіді API
    }
}
