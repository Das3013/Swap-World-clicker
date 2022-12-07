using UnityEngine;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour
{
    private Text textScore;

    private void Start()
    {
        textScore= GetComponent<Text>();
        ScoreManager.OnScroreChange.AddListener(SetScoreText);
        textScore.text =$"{ScoreManager.scrore}";
    }

    private void  SetScoreText()
    {
        textScore.text = $"{ScoreManager.scrore}";
    }
}





