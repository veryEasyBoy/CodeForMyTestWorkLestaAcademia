using System.Collections;
using System.Collections.Generic;
using UnityEngine;

internal class PausedScript : MonoBehaviour
{
    [SerializeField] private GameObject imPaused;
    [SerializeField] private KeyCode[] pauseKeys = {KeyCode.Escape,KeyCode.P};
    private void Pause()
    {
        if (Time.timeScale > 0)
        {
            Time.timeScale = 0;
            imPaused.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            Time.timeScale = 1;
            imPaused.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
    public void btnContinue() => Pause(); //Для кнопки в меню
    private void Start()
    {
        if (imPaused.activeInHierarchy)
        {
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.None;
        }
    }

    private void Update()
    {
        foreach (KeyCode key in pauseKeys) //Для считывания паузы с клавиш
        {
            if (Input.GetKeyDown(key))
            {
                Pause();
                break;
            }
        }
    }

}
