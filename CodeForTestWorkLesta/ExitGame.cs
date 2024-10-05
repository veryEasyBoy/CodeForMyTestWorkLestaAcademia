using System.Collections;
using System.Collections.Generic;
using UnityEngine;

internal class ExitGame : MonoBehaviour
{
    private void Exit()
    {
         Application.Quit();
    }
    public void btnExitGame() => Exit();
}
