using UnityEngine;
using System;

public class InitializeApp : MonoBehaviour
{
    public static Action OnInitializeApp;
    public static Action OnInitalizeAppFailed;

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    private static void Initialize()
    {
        // If app already exists in scene
        if (FindObjectOfType<App>())
        {
            OnInitalizeAppFailed?.Invoke();
            return;
        }

        // Create app from resources folder
        GameObject app = Resources.Load("App") as GameObject;
        GameObject go = Instantiate(app);
        go.name = App.AppName;

        OnInitializeApp?.Invoke();
    }
}
