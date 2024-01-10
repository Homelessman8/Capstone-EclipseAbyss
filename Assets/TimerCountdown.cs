using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class TimerCountdown : MonoBehaviour
{


    
    public TextMeshProUGUI timerCountdown; // Reference to the TextMeshProUGUI component for displaying time.
    

    public int Duration;
    public GameManager gameManager;
    private int remainingDuration;

    private bool Pause;

    private void Start()
    {
        Being(Duration);
    }

    private void Being(int Second)
    {
        remainingDuration = Second;
        StartCoroutine(UpdateTimer());
    }

    private IEnumerator UpdateTimer()
    {
        while (remainingDuration >= 0)
        {
            //    if (!Pause)
            //    {
            timerCountdown.text = $"{remainingDuration / 60:00}:{remainingDuration % 60:00}";
                //uiFill.fillAmount = Mathf.InverseLerp(0, Duration, remainingDuration);
                remainingDuration--;
                yield return new WaitForSeconds(1f);
            //}
            //yield return null;
        }
        OnEnd();
    }

    private void OnEnd()
    {
        //End Time , if want Do something
        Debug.Log("game over, escape in time next time");
        gameManager.GameOver();
    }
}
