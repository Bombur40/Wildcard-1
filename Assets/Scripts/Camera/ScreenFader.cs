using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

// fades canvas over camera
public class ScreenFader : MonoBehaviour
{
    // default duration of fading
    public const float FADE_DURATION = 1f;

    private static RawImage image;
    private static Color blackColor = Color.black;
    private static Color transparentColor = Color.clear;

    private void Awake() => image = GetComponent<RawImage>();

    // When loading first scene of game, fade in
    // [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
    // private static void Init() => FadeIn();

    public static void FadeOut(float duration = FADE_DURATION)
    {
        image.DOColor(blackColor, duration);
    }

    public static void FadeIn(float duration = FADE_DURATION)
    {
        image.DOColor(transparentColor, duration);
    }
}