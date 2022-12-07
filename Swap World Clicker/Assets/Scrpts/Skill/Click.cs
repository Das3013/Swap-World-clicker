using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Click : Clicker
{
    private void Start()
    {
        UpgradeStore.OnDateChange.AddListener(SetDataClicker);
        SetDataClicker();
    }

    public override void AddScore()
    {
        ScoreManager.AddScore(score);
    }
}
