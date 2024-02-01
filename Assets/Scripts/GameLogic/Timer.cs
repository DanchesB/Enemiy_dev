using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI TXP;
    public float countdownTime = 0f;
    public float timerFontSize = 40f;
    public float endFontSize = 70f;
    public Vector3 timerFontPosition = new Vector3(450, 230, 0);
    public Vector3 endFontPosition = new Vector3(0, 0, 0);

    public int minutes;
    public int seconds;

    private void Start()
    {
        ChangeFontSize(timerFontSize);
        ChangeFontPosition(timerFontPosition);
        StartCountdown();
    }

    void ChangeFontSize(float newSize)
    {
        TXP.fontSize = newSize;
    }

    void ChangeFontPosition(Vector3 newPosition)
    {
        TXP.rectTransform.localPosition = newPosition;
    }

    void StartCountdown()
    {
        StartCoroutine(CountdownCoroutine());
    }

    System.Collections.IEnumerator CountdownCoroutine()
    {
        float currentTime = countdownTime;

        while (currentTime <= 1500)
        {
            minutes = Mathf.FloorToInt(currentTime / 60);
            seconds = Mathf.FloorToInt(currentTime % 60);

            TXP.text = string.Format("{0:00}:{1:00}", minutes, seconds);
            currentTime++;
            yield return new WaitForSeconds(1f);
        }

        ChangeFontSize(endFontSize);
        ChangeFontPosition(endFontPosition);
        TXP.text = "Immortal Boss!!!!";
    }
}