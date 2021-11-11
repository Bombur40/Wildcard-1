using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class SceneLoader
{
    // default load duration
    public const float LoadDuration = 2f;
    // is a scene currently loading?
    public static bool loading { get; private set; }

    // Reloads the current active scene
    public static void Reload(float duration = LoadDuration)
    {
        Load(SceneManager.GetActiveScene().name, duration);
    }

    // start reloading scene after seconds has passed
    public static void ReloadAfterSeconds(float seconds)
    {
        // disable other load calls from being called
        loading = true;
        App.Instance.StartCoroutine(ReloadTimer(seconds));
    }

    private static IEnumerator ReloadTimer(float seconds)
    {
        // wait seconds, reload scene
        yield return new WaitForSeconds(seconds);
        loading = false;
        Reload();
    }

    // load scene by string name
    public static void Load(string scene, float duration = LoadDuration)
    {
        // If already loading a scene
        if (loading)
            return;

        // pass coroutine to a monobehaviour class
        App.Instance.StartCoroutine(LoadTimer(scene, duration));

        // reset all objects of type resettable
        // foreach (IResettable obj in FindObjectsOfType<MonoBehaviour>().OfType<IResettable>())
        //     obj.Reset();
    }

    // coroutine to load scene and fade out
    private static IEnumerator LoadTimer(string scene, float duration)
    {
        loading = true;

        // fade out, half of duration
        ScreenFader.FadeOut(duration / 2f);

        // wait for half of duration time
        yield return new WaitForSeconds(duration / 2f);

        // load scene
        SceneManager.LoadScene(scene);

        // fade in, half of duration
        ScreenFader.FadeIn(duration / 2f);

        loading = false;
    }
}
