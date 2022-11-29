using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ButtonCursor : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private MouseManager MouseManager;
    private bool IsInButton;

    void Awake()
    {
        if (MouseManager == null)
        {
            MouseManager = FindObjectOfType<MouseManager>();
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        MouseManager.SetClickableCursor();
        IsInButton = true;
    }

    void OnDisable()
    {
        if (IsInButton)
        {
            MouseManager.SetNeutralCursor();
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        MouseManager.SetNeutralCursor();
        IsInButton = false;
    }

}