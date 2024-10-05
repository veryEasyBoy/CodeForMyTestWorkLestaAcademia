using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

internal class PlayGame : MonoBehaviour
{
    [SerializeField] private protected GameObject imStartGame;
    private void Start()
    {
        Time.timeScale = 0;
    }
    private void Update()
    {
        if (Input.GetKey(KeyCode.E))
        {
            StartGame();
        }
    }
    public void btnOnPress() => StartGame();
    private void StartGame()
    {
        imStartGame.SetActive(false);
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.Locked;
    }
}
