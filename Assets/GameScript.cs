using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameScript : MonoBehaviour
{
    [SerializeField] private GameObject title;
    public GameObject game;
    [SerializeField] private GameObject gameui;
    [SerializeField] private GameObject gamblescreen;
    [SerializeField] private GameObject Order;
    private float LevelProg;
    public float RichFactor;
    public AudioSource PizzaClick;
    [SerializeField] private GameObject OrderScreen;
    public GameObject neworder;
    [SerializeField] private List<GameObject> topbuttons;
    public float points;
    [SerializeField] private GameObject pointdisplay;
    // Start is called before the first frame update
    void Start()
    {
        LoadGame();
        RichFactor = LevelProg;
    }

    // Update is called once per frame
    void Update()
    {
        pointdisplay.GetComponent<TMP_Text>().text = "$ " + points;
        if(points >= 99999)
        {
            game.SetActive(false);
            gameui.SetActive(false);
            gamblescreen.SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.Escape)){
            game.SetActive(false);
            gameui.SetActive(false);
            gamblescreen.SetActive(true);
        }
    }

    public void EndGame()
    {
        LoadGame();
        SaveGame((LevelProg + points).ToString());
        SceneManager.LoadScene(1);
    }

    public void Work()
    {
        LoadGame();
        SaveGame((LevelProg + points).ToString());
        SceneManager.LoadScene(2);
    }

    void SaveGame(string data)
    {
        PlayerPrefs.SetString("Money", data);
        PlayerPrefs.Save();
    }

    void LoadGame()
    {
        if (PlayerPrefs.HasKey("Money"))
        {
            LevelProg = float.Parse(PlayerPrefs.GetString("Money"));
        }
        else
        {
            LevelProg = 0f;
        }
    }

    public void StartGame()
    {
        title.SetActive(false);
        wait(3);
        game.SetActive(true);
        gameui.SetActive(true);
        pointdisplay.SetActive(true);
        RandomizeToppings();
    }

    public void RandomizeToppings()
    {
        neworder = Instantiate(Order, OrderScreen.transform);
        neworder.GetComponent<OrderClock>().GameScript = this;
        for (int i = 0; i < 4; i++){
            Debug.Log(i);
            if(Random.value > 0.5f)
            {
                neworder.transform.GetChild(i).GetComponent<Image>().color = new Color32(0x00, 0xFF, 0x00, 0xFF);
                neworder.GetComponent<OrderClock>().expecteddata[i] = true;
            } else
            {
                neworder.transform.GetChild(i).GetComponent<Image>().color = new Color32(0xFF, 0x00, 0x00, 0xFF);
                neworder.GetComponent<OrderClock>().expecteddata[i] = false;
            }
        }
        if(neworder.GetComponent<OrderClock>().expecteddata[0] == false && neworder.GetComponent<OrderClock>().expecteddata[1] == false && neworder.GetComponent<OrderClock>().expecteddata[2] == false && neworder.GetComponent<OrderClock>().expecteddata[3] == false)
        {
            neworder.GetComponent<OrderClock>().expecteddata[0] = true;
            neworder.transform.GetChild(0).GetComponent<Image>().color = new Color32(0x00, 0xFF, 0x00, 0xFF);
        }
    }

    IEnumerator wait(float time)
    {
        yield return new WaitForSeconds(time);
    }
}
