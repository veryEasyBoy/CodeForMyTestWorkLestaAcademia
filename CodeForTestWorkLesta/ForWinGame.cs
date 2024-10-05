using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

internal class ForWinGame : Taimer
{
    [SerializeField] private float delay = 1f;
    [SerializeField] private protected TMP_Text objectTime;
    private bool Bool = false;
    private IEnumerator GameWinScene()
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    private void Start()
    {
        Time.timeScale = 0;
        objectTime.GetComponent<TMP_Text>().enabled = true;
        StartCoroutine(GameWinScene());
        Cursor.lockState = CursorLockMode.None;
    }
}
