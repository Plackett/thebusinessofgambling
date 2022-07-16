using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameScript : MonoBehaviour
{
    [SerializeField] private GameObject title;
    [SerializeField] private GameObject game;
    [SerializeField] private GameObject Order;
    [SerializeField] private GameObject OrderScreen;
    [SerializeField] private List<GameObject> topbuttons;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StartGame()
    {
        title.SetActive(false);
        wait(3);
        game.SetActive(true);
        RandomizeToppings();
    }

    public void RandomizeToppings()
    {
        GameObject neworder = Instantiate(Order, OrderScreen.transform);
        neworder.GetComponent<OrderClock>().GameScript = this;
        for (int i = 0; i < 4; i++){
            if(Random.value > 0.5f)
            {
                neworder.transform.GetChild(i).GetComponent<Image>().color = new Color32(0x00, 0xFF, 0x00, 0xFF);
            } else
            {
                neworder.transform.GetChild(i).GetComponent<Image>().color = new Color32(0xFF, 0x00, 0x00, 0xFF);
            }
        }
    }

    IEnumerator wait(float time)
    {
        yield return new WaitForSeconds(time);
    }
}
