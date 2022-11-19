using System.Collections;
using UnityEngine;

[CreateAssetMenu]
public class Dialogue : ScriptableObject
{
    [TextArea(10, 50)]
    public string Text;
}