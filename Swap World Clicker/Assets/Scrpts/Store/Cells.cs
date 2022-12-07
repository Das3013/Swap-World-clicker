using UnityEngine;
using System;



[Serializable]
public class CellData
{
    public int currentLevel;
    public int cost;
    public bool isUnclock;
    public GameObject partUnlock;
}

[Serializable]
public class Cells 
{
    public CellData[] cellData;
}
