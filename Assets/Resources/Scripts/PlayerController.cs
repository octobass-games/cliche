using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public void OnUp(InputAction.CallbackContext ctx)
    {
        if (ctx.started) { 
            Debug.Log("Up pressed");
        }
    }

    public void OnRight(InputAction.CallbackContext ctx)
    {
        if (ctx.started)
        {
            Debug.Log("Right pressed");
        }
    }

    public void OnDown(InputAction.CallbackContext ctx)
    {
        if (ctx.started)
        {
            Debug.Log("Down pressed");
        }
    }

    public void OnLeft(InputAction.CallbackContext ctx)
    {
        if (ctx.started)
        {
            Debug.Log("Left pressed");
        }
    }
}
