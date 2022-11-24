using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class GameObjectDecorator : MonoBehaviour
{
    public GameObject Obj;
    public UnityEvent OnAwakeEvent;
    public void Toggle()
    {
        Obj.SetActive(!Obj.activeSelf);
    }

    void Awake()
    {
        if (OnAwakeEvent != null)
        {
            OnAwakeEvent.Invoke();
        }
    }
}