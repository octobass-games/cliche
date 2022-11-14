using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    private bool IsPaused;

    public void TogglePause(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            if (IsPaused)
            {
                Unpause();
            }
            else
            {
                Pause();
            }
        }
    }

    private void Pause()
    {
        Time.timeScale = 0f;
        FindObjectOfType<Conductor>().Pause();
        FindObjectOfType<PlayerInput>().SwitchCurrentActionMap("UI");
        IsPaused = true;
    }

    private void Unpause()
    {
        Time.timeScale = 1f;
        FindObjectOfType<Conductor>().Resume();
        FindObjectOfType<PlayerInput>().SwitchCurrentActionMap("Player controls");
        IsPaused = false;
    }
}
