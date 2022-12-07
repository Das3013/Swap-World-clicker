using UnityEngine;

public abstract class Clicker : MonoBehaviour
{
    public int worldId;
    public int clickerId;
    [SerializeField] protected int score;
    [SerializeField] protected SaveSystem saveSystem;
    protected int currentLevel;

    public abstract void AddScore();

    protected void SetDataClicker()
    {
        WorldData date = saveSystem._worldData;
        currentLevel=date.storeDates[worldId].clickerData[clickerId].currentLevel;
        score= date.storeDates[worldId].clickerData[clickerId].scoreAdd;
    }
}
