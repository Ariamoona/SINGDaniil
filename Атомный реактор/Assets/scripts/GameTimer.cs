using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameTimer : MonoBehaviour
{
    [SerializeField] private Text timerText;

    private float currentTime;
    private bool isRunning;

    public void StartTimer()
    {
        currentTime = 0f;
        isRunning = true;
        StartCoroutine(UpdateTimer());
    }

    public void StopTimer()
    {
        isRunning = false;
    }

    private IEnumerator UpdateTimer()
    {
        while (isRunning)
        {
            currentTime += Time.deltaTime;
            timerText.text = $"Time: {currentTime:F1}s";
            yield return null;
        }
    }
}