using System.Collections;
using UnityEngine;

public class GameObjectDecorator : MonoBehaviour
{
    public GameObject Obj;
    public void Toggle()
    {
        Obj.SetActive(!Obj.activeSelf);
    }
}