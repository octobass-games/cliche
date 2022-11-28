using UnityEngine;

public class ContinueButton : MonoBehaviour
{
    void Start()
    {
        if (!GameManager.Instance.HasSaveData())
        {
            gameObject.SetActive(false);
        }
    }
}
