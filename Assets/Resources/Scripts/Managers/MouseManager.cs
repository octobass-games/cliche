using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class MouseManager : MonoBehaviour
{
    public EventSystem EventSystem;
    public Texture2D NeutralCursorTexture;
    public Texture2D ClickableCursorTexture;

    private Texture2D CurrentCursorTexture;

    void Awake()
    {
        SetNeutralCursor();
    }

    void Update()
    {
        if (IsMouseOverUIElement())
        {
            return;
        }

        var clickableBeneathMouse = FindClickableBeneathCursor();

        if (clickableBeneathMouse != null)
        {
            SetClickableCursor();
        }
        else
        {
            SetNeutralCursor();
        }
    }

    public void SetNeutralCursor() => SetCursor(NeutralCursorTexture);

    public void SetClickableCursor() => SetCursor(ClickableCursorTexture);

    public void OnClick(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            Clickable clickable = FindClickableBeneathCursor();

            if (clickable != null)
            {
                clickable.OnClick.Invoke();
            }
        }
    }

    private bool IsMouseOverUIElement() => EventSystem.current.IsPointerOverGameObject();

    private Clickable FindClickableBeneathCursor()
    {
        if (IsMouseOverUIElement())
        {
            return null;
        }

        if (Camera.main != null)
        {
            var currentMousePosition = Mouse.current.position.ReadValue();
            var ray = Camera.main.ScreenPointToRay(currentMousePosition);

            var hit = Physics2D.GetRayIntersection(ray);
            var collider = hit.collider;

            if (collider != null)
            {
                return collider.gameObject.GetComponent<Clickable>();
            }
        }

        return null;
    }

    private void SetCursor(Texture2D cursorTexture)
    {
        if (CurrentCursorTexture != cursorTexture)
        {
            Vector2 cursorOffset = new Vector2(cursorTexture.width / 2, 0);
            Cursor.SetCursor(cursorTexture, cursorOffset, CursorMode.Auto);
        }
    }
}
