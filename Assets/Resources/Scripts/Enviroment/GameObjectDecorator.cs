using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class GameObjectDecorator : MonoBehaviour
{
    public GameObject Obj;
    public UnityEvent OnAwakeEvent;

    void Awake()
    {
        if (OnAwakeEvent != null)
        {
            OnAwakeEvent.Invoke();
        }
    }

    public void Destroy()
    {
        Destroy(Obj);
    }

    public void Toggle()
    {
        Obj.SetActive(!Obj.activeSelf);
    }
}