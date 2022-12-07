using UnityEngine;
using UnityEngine.Events;

public class ScoreManager : MonoBehaviour
{
    public static int scrore;
    public static UnityEvent OnScroreChange=new UnityEvent();


    private void Awake()
    {
        scrore = PlayerPrefs.GetInt("Score", 0);
    }

    public static void AddScore(int count)
    {
        scrore += count;
        PlayerPrefs.SetInt("Score", scrore);
        OnScroreChange.Invoke();
    }

    public static void MinusScore(int count)
    {
        scrore -= count;
        PlayerPrefs.SetInt("Score", scrore);
        OnScroreChange.Invoke();
    }

}
