using UnityEngine;
using AppsFlyerSDK;

public class AppsflyerManager : MonoBehaviour
{
    void Start()
    {
        // ����������� SDK AppsFlyer � ����� devkey
        string devKey = "ytPuQc6oHMvGHLh83FVpdd";
        AppsFlyer.initSDK(devKey, Application.identifier);

        // ���� ������������, �� �� ������ ������
        AppsFlyer.startSDK(); // ������ SDK AppsFlyer
    }
}
