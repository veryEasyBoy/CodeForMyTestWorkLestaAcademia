using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

internal class GameOver : MonoBehaviour
{
    [SerializeField] private float delay = 1f;

    IEnumerator GameOverScene()
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
       
    }
    private void Start()
    {
        Time.timeScale = 0;
        StartCoroutine("GameOverScene");
        Cursor.lockState = CursorLockMode.None;
    }
}
