using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    public GameObject Container;
    public GameObject PauseMenu;
    public GameObject ControlsSubmenu;

    public Conductor Conductor;
    public PlayerInput PlayerInput;

    private bool IsPaused;
    private readonly List<string> UnpausableScenes = new() { "MainMenu", "Introduction" };

    public void OnRestart()
    {
        Time.timeScale = 1f;
        GameManager.Instance.RestartLevel();
    }

    public void OnVisitHome()
    {
        Time.timeScale = 1f;
        GameManager.Instance.ChangeScene("Home");
    }

    public void OnControlsOpen()
    {
        Container.SetActive(true);
        PauseMenu.SetActive(false);
        ControlsSubmenu.SetActive(true);
    }

    public void OnControlsClose()
    {
        Container.SetActive(true);
        PauseMenu.SetActive(true);
        ControlsSubmenu.SetActive(false);
    }

    public void OnSkipLevel()
    {
        Time.timeScale = 1f;
        GameManager.Instance.SkipLevel();
    }

    public void OnQuit()
    {
        Time.timeScale = 1f;
        GameManager.Instance.ChangeScene("MainMenu");
    }

    public void TogglePause(InputAction.CallbackContext context)
    {
        if (IsPausableScene())
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
    }

    public void TogglePause()
    {
        if (IsPausableScene())
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

    public bool ShowOptionalButtons() => SceneManager.GetActiveScene().name != "Home";

    private void Pause()
    {
        Time.timeScale = 0f;
        
        if (Conductor != null)
        {
            Conductor.Pause();
        }

        PlayerInput.SwitchCurrentActionMap("UI");
        IsPaused = true;
        Container.SetActive(true);
        PauseMenu.SetActive(true);
        ControlsSubmenu.SetActive(false);
    }
    private void Unpause()
    {
        Time.timeScale = 1f;

        if (Conductor != null)
        {
            Conductor.Resume();
        }

        bool isHomeScene = !ShowOptionalButtons();
        if (isHomeScene)
        {
            PlayerInput.SwitchCurrentActionMap("Home");
        }
        else
        {
            PlayerInput.SwitchCurrentActionMap("Player controls");
        }

        IsPaused = false;
        Container.SetActive(false);
        PauseMenu.SetActive(false);
        ControlsSubmenu.SetActive(false);
    }

    public bool IsPausableScene() => !UnpausableScenes.Contains(SceneManager.GetActiveScene().name);
}
