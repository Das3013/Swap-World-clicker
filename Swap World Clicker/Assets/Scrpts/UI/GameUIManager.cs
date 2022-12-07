using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameUIManager : MonoBehaviour
{
    [SerializeField] private GameObject updaterStore;
    [SerializeField] private GameObject wordSwaper;

    public void OpenUpdaterStore()
    {
        updaterStore.SetActive(true);
    }

    public void CloseUpdaterStore()
    {
        updaterStore.SetActive(false);
    }

    public void OpenWorldSwaper()
    {
        wordSwaper.SetActive(true);
    }

    public void CloceWorldSwaper()
    {
        wordSwaper.SetActive(false);
    }
}
