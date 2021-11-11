using System.Collections;
using UnityEngine;

public class TimeManager
{
    private static Coroutine pauseCoroutine;

    // stops time for duration
    public static void Pause(float duration)
    {
        if (pauseCoroutine != null)
            App.Instance.StopCoroutine(pauseCoroutine);

        pauseCoroutine = App.Instance.StartCoroutine(PauseCoroutine(duration));
    }

    private static IEnumerator PauseCoroutine(float duration)
    {
        Time.timeScale = 0;
        yield return new WaitForSecondsRealtime(duration);
        Time.timeScale = 1;
    }
}
