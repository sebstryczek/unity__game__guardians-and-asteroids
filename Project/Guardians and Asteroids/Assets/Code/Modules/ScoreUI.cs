using UnityEngine;
using UnityEngine.UI;

public class ScoreUI : MonoBehaviour
{
    private Text uiText;

    private void Awake()
    {
        this.uiText = this.GetComponent<Text>();
    }

    private void Update()
    {
        StateScore stateScore = State.Instance.Get<StateScore>();
        if (stateScore)
        {
            int score = State.Instance.Get<StateScore>().Score;
            this.uiText.text = score.ToString();
        }
    }
}
