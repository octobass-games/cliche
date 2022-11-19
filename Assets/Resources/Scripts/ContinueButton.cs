using UnityEngine;

public class ContinueButton : MonoBehaviour
{
    public Saver Saver;

    void Start()
    {
        if (!Saver.HasSaveData())
        {
            gameObject.SetActive(false);
        }
    }
}
