using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class DialogueRenderer : MonoBehaviour
{
    private List<DialougeLine> Lines;
    private int Index = 0;
    private UnityEvent EventOnEnd;
    public TMPro.TextMeshProUGUI Speaker;
    public TMPro.TextMeshProUGUI TextArea;
    public Button button;
    public GameObject panel;
    public Animator Animator;

    public void Run(Dialogue dialogue, UnityEvent eventOnEnd, Animator animator)
    {
        Debug.Log("Dialogue.Run:" + dialogue.name);
        Lines = getLines(dialogue);
        Index = 0;
        EventOnEnd = eventOnEnd;
        TextArea.text = Lines[Index].Line;
        Speaker.text = Lines[Index].Speaker;
        button.onClick.RemoveAllListeners();
        button.onClick.AddListener(nextDialogue);
        Animator = animator;
        runAnimation();
        panel.SetActive(true);
    }

    private void Render()
    {
        TextArea.text = Lines[Index].Line;
        Speaker.text = Lines[Index].Speaker;
        runAnimation();
    }

    private void nextDialogue()
    {
        if (Index == Lines.Count - 1)
        {
            Debug.Log("Dialogue Complete, next Event: "+ EventOnEnd);
            panel.SetActive(false);

            if (EventOnEnd != null)
            {
                EventOnEnd.Invoke();
            }
        }
        else
        {
            Index += 1;
            Render();
        }
    }

    private void runAnimation()
    {
        var trigger = Lines[Index].Trigger;
        if (Animator != null && trigger!= null)
        {
            Animator.SetTrigger(trigger);
        }
    }

    private List<DialougeLine> getLines(Dialogue dialogue)
    {
        var lines = dialogue.Text.Split("\n");
        return lines.ToList().Select((line) =>
        {
            var splitLine = line.Split(":");
            var trigger = splitLine.Length == 3 ? splitLine[2] : null;
            return new DialougeLine(splitLine[0], splitLine[1], trigger);
        }).ToList();
    }
}