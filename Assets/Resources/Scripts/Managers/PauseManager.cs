using UnityEngine;
using UnityEngine.InputSystem;

public class PauseManager : MonoBehaviour
{
    public GameObject PauseMenu;
    public GameObject ControlsSubmenu;

    public Conductor Conductor;
    public PlayerInput PlayerInput;

    private bool IsPaused;

    public static PauseManager Instance { get; private set; }

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(Instance);
        }
    }

    public void OnVisitHome()
    {
        GameManager.Instance.ChangeScene("Home");
    }

    public void OnControlsOpen()
    {
        PauseMenu.SetActive(false);
        ControlsSubmenu.SetActive(true);
    }

    public void OnControlsClose()
    {
        PauseMenu.SetActive(true);
        ControlsSubmenu.SetActive(false);
    }

    public void OnSkipLevel()
    {
        GameManager.Instance.SkipLevel();
    }

    public void OnQuit()
    {
        GameManager.Instance.ChangeScene("MainMenu");
    }

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
        
        if (Conductor != null)
        {
            Conductor.Pause();
        }

        PlayerInput.SwitchCurrentActionMap("UI");
        IsPaused = true;
        PauseMenu.SetActive(true);
    }
    private void Unpause()
    {
        Time.timeScale = 1f;

        if (Conductor != null)
        {
            Conductor.Resume();
        }

        PlayerInput.SwitchCurrentActionMap("Player controls");
        IsPaused = false;
        PauseMenu.SetActive(false);
        ControlsSubmenu.SetActive(false);
    }
}
