using UnityEngine;
using UnityEngine.InputSystem;

public class MouseManager : MonoBehaviour
{
    public void OnClick(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            var currentMousePosition = Mouse.current.position.ReadValue();
            var ray = Camera.main.ScreenPointToRay(currentMousePosition);

            var hit = Physics2D.GetRayIntersection(ray);
            var collider = hit.collider;

            if (collider != null)
            {
                var clickable = collider.gameObject.GetComponent<Clickable>();

                if (clickable != null)
                {
                    clickable.OnClick.Invoke();
                }
            }
        }
    }
}
