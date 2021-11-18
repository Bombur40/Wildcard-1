using System.Collections.Generic;
using UnityEngine;

public class App : Singleton<App>
{
    public static string AppName = "App";

    [SerializeField] private List<ScriptableObject> loadables;

    private void Awake() => DontDestroyOnLoad(gameObject);
}
