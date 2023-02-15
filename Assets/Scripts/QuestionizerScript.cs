using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Question", menuName = "Scriptable Objects/Questionaire", order = 1)]
public class QuestionizerScript : ScriptableObject
{
    public string problem;
    public List<int> balls = new();
    public List<int> answer= new();
    public int min;
    public int max;
}
