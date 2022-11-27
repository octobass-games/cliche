using UnityEngine;

public class ContinueButton : MonoBehaviour
{
    void Start()
    {
        if (!SaveManager.Instance.HasSaveData())
        {
            gameObject.SetActive(false);
        }
    }
}
