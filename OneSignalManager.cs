using UnityEngine;
using OneSignalSDK;

public class OneSignalManager : MonoBehaviour
{
    private string appId = "635c5f12-bb1c-4e8a-92a5-65636c604328";

    void Start()
    {
        // Ініціалізація SDK OneSignal з вашим projectId
        OneSignal.Default.Initialize(appId);

        
    }

   
}
