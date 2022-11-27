using UnityEngine;

public class ContinueButton : MonoBehaviour
{
    public SaveManager Saver;

    void Start()
    {
        if (!Saver.HasSaveData())
        {
            gameObject.SetActive(false);
        }
    }
}
