using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Envorements
{
    [Header("Envoriment")]
    public GameObject envorement;

    [Header("Skybox setting")]
    public Material skybox;

    [Header("Lighting Settinh")]
    public Color skyColor;
    public Color equatorColor;
    public Color groundColor;

    [Header("Fog settig")]
    public bool isFogEnable;
    public Color fogColor;
    public float fogDistance;

}

public class WordController : MonoBehaviour 
{ 
    public List<Envorements> envorements;
    int indexEnvorement;

    void Start() => Initialization();

    void Initialization()
    {
        indexEnvorement = PlayerPrefs.GetInt("CurrentWorld", 0);
        SetEnvorementSetting();
    }

    void SetEnvorementSetting()
    {
        envorements[indexEnvorement].envorement.gameObject.SetActive(true);
        RenderSettings.ambientSkyColor= envorements[indexEnvorement].skyColor;
        RenderSettings.ambientEquatorColor = envorements[indexEnvorement].equatorColor;
        RenderSettings.ambientGroundColor = envorements[indexEnvorement].groundColor;
        RenderSettings.fog = envorements[indexEnvorement].isFogEnable;
        RenderSettings.skybox = envorements[indexEnvorement].skybox;
        RenderSettings.fogColor = envorements[indexEnvorement].fogColor;
    }

    public void SetEnvorimet(int index)
    {
        envorements[indexEnvorement].envorement.gameObject.SetActive(false);
        indexEnvorement = index;
        PlayerPrefs.SetInt("CurrentWorld", indexEnvorement);
        envorements[indexEnvorement].envorement.gameObject.SetActive(true);
        RenderSettings.ambientSkyColor = envorements[indexEnvorement].skyColor;
        RenderSettings.ambientEquatorColor = envorements[indexEnvorement].equatorColor;
        RenderSettings.ambientGroundColor = envorements[indexEnvorement].groundColor;
        RenderSettings.fog = envorements[indexEnvorement].isFogEnable;
        RenderSettings.skybox = envorements[indexEnvorement].skybox;
        RenderSettings.fogColor = envorements[indexEnvorement].fogColor;
    }
}

