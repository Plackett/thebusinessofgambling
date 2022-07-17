using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gamble : MonoBehaviour
{
    public GameScript game;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Gambles()
    {
        if(game.points > 0)
        {
            float moneychange = Random.Range(0, game.points);
            if(Random.value > 0.5f)
            {
                game.points += Mathf.Ceil(moneychange);
            } else
            {
                game.points -= Mathf.Ceil(moneychange);
            }
        }
        this.GetComponent<Button>().interactable = false;
    }

}
