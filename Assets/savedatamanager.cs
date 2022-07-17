using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class savedatamanager : MonoBehaviour
{
    public string LevelProg;
    [SerializeField] private GameObject moneydisplay;
    [SerializeField] private GameObject Tutorial;
    // Start is called before the first frame update
    void Start()
    {
        LoadGame();
        moneydisplay.GetComponent<TMP_Text>().text = "$ " + LevelProg;
        if(LevelProg == "0")
        {
            Tutorial.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SaveGame(string data)
    {
        PlayerPrefs.SetString("Money", data);
        PlayerPrefs.Save();
    }

    public void ResetData()
    {
        PlayerPrefs.DeleteAll();
        LevelProg = "0";
        SaveGame(LevelProg);
    }

    void LoadGame()
    {
        if (PlayerPrefs.HasKey("Money"))
        {
            LevelProg = PlayerPrefs.GetString("Money");
        }
        else
        {
            ResetData();
        }
    }
}
