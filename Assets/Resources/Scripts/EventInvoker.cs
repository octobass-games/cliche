using UnityEngine;
using UnityEngine.Events;

public class EventInvoker : MonoBehaviour
{
    public UnityEvent Event;
    public UnityEvent Event2;
    public UnityEvent Event3;
    public UnityEvent Event4;
    public UnityEvent Event5;

    public void InvokeCustomEvent() => Event.Invoke();
    public void InvokeCustomEvent2() => Event2.Invoke();
    public void InvokeCustomEvent3() => Event3.Invoke();
    public void InvokeCustomEvent4() => Event4.Invoke();
    public void InvokeCustomEvent5() => Event5.Invoke();
}