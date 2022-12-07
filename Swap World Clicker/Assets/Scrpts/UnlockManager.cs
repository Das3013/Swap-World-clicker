using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockManager : MonoBehaviour
{
    [SerializeField] private int worldId;
    [SerializeField] private SaveSystem save;
    [SerializeField] private GameObject[] unclockObjects;

    private void Start()
    {
        UpgradeStore.OnDateChange.AddListener(SetUnlock);
        SetUnlock();
    }


    private void SetUnlock()
    {
        StoreData data = save._worldData.storeDates[worldId];
        for (int i = 0; i < data.clickerData.Length; i++)
        {
            unclockObjects[i].SetActive(data.clickerData[i].isUnlock);
        }
    }
}
