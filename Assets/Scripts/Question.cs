using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Question : ScriptableObject
{
    [TextArea(1,2)]
    public string question;

    [TextArea(1,7)]
    public string answer;
}
