using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "StateScore", menuName = "ScriptableObject/StateScore", order = 0)]
public class StateScore : StateFragment
{
    [SerializeField] private int score;
    public int Score { get { return this.score; } }

    public void Reset()
    {
        this.score = 0;
    }

    public void Increment()
    {
        this.score++;
    }

    public void ApplyUI(Text field)
    {
        field.text = this.score.ToString();
    }
}
