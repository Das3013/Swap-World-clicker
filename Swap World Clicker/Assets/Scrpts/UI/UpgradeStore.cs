using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections.Generic;

public class UpgradeStore : MonoBehaviour
{
    [SerializeField] private SaveSystem saveSystem;
    public WorldStoreCells[] worldStoreCells;
    private int currentWorldId;
    [SerializeField] private GameObject[] worlds;
    [SerializeField] private List<GameObject> selectedIndecators;
    public static UnityEvent OnDateChange = new UnityEvent();

    private void Start()
    {
        CheckCost();
        currentWorldId = PlayerPrefs.GetInt("WorldId",0);
        worlds[currentWorldId].SetActive(true);
        selectedIndecators[currentWorldId].SetActive(true);
        SwapWorld(currentWorldId);
        ScoreManager.OnScroreChange.AddListener(CheckCost);
        LoadDate();
    }

    private void LoadDate()
    {
        WorldData date = saveSystem._worldData;
        for (int i = 0; i < date.storeDates.Length; i++)
        {
            worldStoreCells[i].isUnlock = date.storeDates[i].isUnlock;
            for (int j= 0; j< date.storeDates[i].clickerData.Length; j++)
            {
                worldStoreCells[i].storeCells[j].isUnlock = date.storeDates[i].clickerData[j].isUnlock;
                worldStoreCells[i].storeCells[j].cost.text = $"{date.storeDates[i].clickerData[j].cost}";
                worldStoreCells[i].storeCells[j].description.text = $"„T„r„u„|„y„‰„y„r„p„u„„ „„€„|„…„‰„p„u„}„„u „€„‰„{„y „~„p {date.storeDates[i].clickerData[j].scoreAdd}";
            }
        }
    }

    public void AddLevel(int _clickerId)
    {
        WorldData date = saveSystem._worldData;
        if (date.storeDates[currentWorldId].clickerData[_clickerId].isUnlock == false)
        {
            date.storeDates[currentWorldId].clickerData[_clickerId].isUnlock = true;
        }
        ScoreManager.MinusScore(date.storeDates[currentWorldId].clickerData[_clickerId].cost);
        date.storeDates[currentWorldId].clickerData[_clickerId].scoreAdd *= 2;
        date.storeDates[currentWorldId].clickerData[_clickerId].cost *= 5;
        date.storeDates[currentWorldId].clickerData[_clickerId].currentLevel++;
        worldStoreCells[currentWorldId].storeCells[_clickerId].cost.text = $"{date.storeDates[currentWorldId].clickerData[_clickerId].cost}";
        worldStoreCells[currentWorldId].storeCells[_clickerId].description.text = $"„T„r„u„|„y„‰„y„r„p„u„„ „„€„|„…„‰„p„u„}„„u „€„‰„{„y „~„p {date.storeDates[currentWorldId].clickerData[_clickerId].scoreAdd}";
        CheckCost();
        OnDateChange.Invoke();
    }

    public void SwapWorld(int _currentLevel)
    {
        worlds[currentWorldId].SetActive(false);
        selectedIndecators[currentWorldId].SetActive(false);
        currentWorldId = _currentLevel;
        CheckCost();
        PlayerPrefs.SetInt("WorldId", currentWorldId);
        worlds[currentWorldId].SetActive(true);
        selectedIndecators[currentWorldId].SetActive(true);
    }

    private void CheckCost()
    {

        WorldData date = saveSystem._worldData;        
            worldStoreCells[currentWorldId].isUnlock = date.storeDates[currentWorldId].isUnlock;
            for (int j = 0; j < date.storeDates[currentWorldId].clickerData.Length; j++)
            {
                if (date.storeDates[currentWorldId].clickerData[j].cost > ScoreManager.scrore)
                {
                    worldStoreCells[currentWorldId].storeCells[j].upgradeButton.interactable = false;
                }
                else 
                {
                    worldStoreCells[currentWorldId].storeCells[j].upgradeButton.interactable = true;
                }
            
        }
    }

}


[System.Serializable]
public class WorldStoreCells
{
    [HideInInspector] string name = "World_UI";
    public bool isUnlock;
    public int idWorldCell;
    public GameObject worldStoreCell;
    public StoreCell[] storeCells;
}


[System.Serializable]
public class StoreCell
{
    public int idCell;
    public bool isUnlock;
    public Text cost;
    public Text description;
    public Button upgradeButton;
}