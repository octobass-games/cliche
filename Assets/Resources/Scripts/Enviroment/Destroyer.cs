using System.Collections;
using UnityEngine;


public class Destroyer : MonoBehaviour
{
    public void DestroySelf()
    {
        Destroy(gameObject);
    }
}