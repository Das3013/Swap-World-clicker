using System.Collections;
using UnityEngine;

public class AutoClicker : Clicker
{
    [SerializeField] public float delay;

    private void Start()
    {
        UpgradeStore.OnDateChange.AddListener(SetDataClicker);
        SetDataClicker();
        AddScore();
    }

    IEnumerator AddScoreCorutine()
    {
        yield return new WaitForSeconds(delay);
        ScoreManager.AddScore(score);
        AddScore();
    }

    public override void AddScore()
    {
        StartCoroutine(AddScoreCorutine());
    }
}
