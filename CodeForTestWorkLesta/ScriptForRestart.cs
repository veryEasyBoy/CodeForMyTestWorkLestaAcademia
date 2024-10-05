using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

internal class ScriptForRestart : MonoBehaviour
{
    private KeyCode keyRestart = KeyCode.R;
    private void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void btnRestart() => RestartGame();
    private void Update()
    {
        if (Input.GetKeyDown(keyRestart))
        {
            RestartGame();
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
