using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldManager : MonoBehaviour
{
    [SerializeField] private GameObject[] _worlds;
    [SerializeField] private int currentWord;
    [SerializeField] private int maxWorld;

    private void Start()
    {
        maxWorld = _worlds.Length;
        currentWord = PlayerPrefs.GetInt("CurrentWorld", 0);
        _worlds[currentWord].SetActive(true);
    }


    public void SwipeRight()
    {
        if (currentWord < maxWorld-1)
        {
            _worlds[currentWord].SetActive(false);
            currentWord++;
            _worlds[currentWord].SetActive(true);
        }
        else
        {
            Debug.Log(1);
            _worlds[currentWord].SetActive(false);
            currentWord = 0;
            _worlds[currentWord].SetActive(true);
        }
    }

    public void SwipeLeft()
    {
        if (currentWord >0 )
        {
            _worlds[currentWord].SetActive(false);
            currentWord--;
            _worlds[currentWord].SetActive(true);
        }
        else
        {
            _worlds[currentWord].SetActive(false);
            currentWord = maxWorld-1;
            _worlds[currentWord].SetActive(true);
        }
    }
}
