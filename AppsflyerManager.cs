using UnityEngine;
using AppsFlyerSDK;

public class AppsflyerManager : MonoBehaviour
{
    void Start()
    {
        // Ініціалізація SDK AppsFlyer з вашим devkey
        string devKey = "ytPuQc6oHMvGHLh83FVpdd";
        AppsFlyer.initSDK(devKey, Application.identifier);

        // Інші налаштування, які ви можете додати
        AppsFlyer.startSDK(); // Запуск SDK AppsFlyer
    }
}
