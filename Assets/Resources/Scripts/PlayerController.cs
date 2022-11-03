using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public Judge PlayerJudge;

    public void OnUp(InputAction.CallbackContext context)
    {
        if (context.started) { 
            Debug.Log("Up pressed");
            PlayerJudge.PassJudgement();
        }
    }

    public void OnRight(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            Debug.Log("Right pressed");
            PlayerJudge.PassJudgement();
        }
    }

    public void OnDown(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            Debug.Log("Down pressed");
            PlayerJudge.PassJudgement();
        }
    }

    public void OnLeft(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            Debug.Log("Left pressed");
            PlayerJudge.PassJudgement();
        }
    }
}
