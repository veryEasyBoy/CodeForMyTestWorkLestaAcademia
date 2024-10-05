using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

internal class Taimer : MonoBehaviour
{
    private int sec = 0;
    private int min = 0;
    private protected TMP_Text TimerText;
    private int delta = 1;
    private bool IsBool = false;
    private bool IsBool2 = true;
    private void OnTriggerEnter(Collider taim)
    {
        if (taim.gameObject.CompareTag("ForTriiger") && IsBool2)
        {
            IsBool = true;
            IsBool2 = false;
            StartTime();
        }
    }
    private protected IEnumerator TimerCoroutine()
    {
        if (TimerText != null)
        {
            while (true)
            {
                if (sec == 59)
                {
                    min++;
                    sec = -1;
                }
                
                sec += delta;
                TimerText.text = min.ToString("D2") +" минут" + " : " + sec.ToString("D2") + " секунд";
                yield return new WaitForSeconds(1);
                IsBool2 = true;
            }
        }
    }
    private void StartTime()
    {
        if (IsBool == true)
        {
            TimerText = GameObject.Find("Taimer").GetComponent<TMP_Text>();
            StartCoroutine(TimerCoroutine());
        }
    }

}
