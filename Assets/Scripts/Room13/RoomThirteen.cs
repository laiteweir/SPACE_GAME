using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoomThirteen : MonoBehaviour
{
    [SerializeField] private TextAsset textFile;
    private string[] dialog;
    [SerializeField] private Image image;
    [SerializeField] private float fadeOutTime = 5f;
    [SerializeField] private float fadeInTime = 5f;
    public bool isBossDefeated = false;

    private void Start()
    {
        dialog = textFile.text.Split('\n');
    }

    public void OnBossDefeated()
    {
        Manager.Instance.DialogBox.StartTalk(dialog, StartFadeOutAndIn);
    }

    private IEnumerator Fade(Color startColor, Color endColor, float fadeTime)
    {
        float fadeStartTime = Time.time;
        while (Time.time - fadeStartTime < fadeTime)
        {
            float t = (Time.time - fadeStartTime) / fadeTime;
            image.color = Color.Lerp(startColor, endColor, t);
            yield return null;
        }
        image.color = endColor;
    }
    private IEnumerator FadeOutAndIn()
    {
        yield return StartCoroutine(Fade(Color.clear, Color.black, fadeOutTime));
        yield return StartCoroutine(Fade(Color.black, Color.white, fadeInTime));
        Manager.Instance.Ending();
    }

    private void StartFadeOutAndIn()
    {
        Manager.Instance.UIManager.OpenUI(image.gameObject);
        StartCoroutine(FadeOutAndIn());
    }
}
