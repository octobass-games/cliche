using UnityEngine;
using UnityEngine.Events;

public class DialogueEventInvoker : MonoBehaviour
{
    public DialogueRenderer DialogueRenderer;

    public Dialogue[] Dialogues;
    public UnityEvent[] endEvents;
    public Animator Animator;

    public void InvokeDialogue(int index)
    {
        Debug.Log("InvokeDialogue with index: " + index);
        DialogueRenderer.Run(Dialogues[index], endEvents[index], Animator);
    }
}