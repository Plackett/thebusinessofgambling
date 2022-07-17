using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OrderClock : MonoBehaviour
{
    public float time;
    private float Rich;
    public GameScript GameScript;
    public GameObject Pizza;
    public List<bool> expecteddata = new List<bool>(4);
    // Start is called before the first frame update
    void Start()
    {
        Rich = (float)(GameScript.RichFactor / 128 + 1);
        if(Rich <= 0.6f)
        {
            Rich = 0.6f;
        }
        if(GameScript.RichFactor <= 128)
        {
            Rich = 1;
        }
        time = 45 / Rich;
        Pizza = Instantiate(Pizza, GameScript.game.transform);
        Pizza.GetComponent<datascript>().expecteddata = this.expecteddata;
        LeanTween.moveY(Pizza, -195f, (float)(800 / Rich));
    }

    // Update is called once per frame
    void Update()
    {
        List<bool> data = Pizza.GetComponent<datascript>().data;
        GameObject neworder = this.gameObject;
        time -= Time.deltaTime;
        if (time <= 45/Rich && time > 0)
        {
            if (time < 23 * Rich)
            {
                neworder.transform.GetChild(4).transform.GetChild(1).transform.GetChild(0).GetComponent<Image>().color = new Color32(0xFF, 0xE8, 0x00, 0xFF);
            }
            if (time < 15 * Rich)
            {
                neworder.transform.GetChild(4).transform.GetChild(1).transform.GetChild(0).GetComponent<Image>().color = new Color32(0xEF, 0x07, 0x00, 0xFF);
            }
            neworder.transform.GetChild(4).GetComponent<Slider>().value = time / (45 / Rich);
        } else
        {
            GameScript.points = Mathf.Floor(GameScript.points - (float) (1*Rich));
            GameScript.RandomizeToppings();
            Destroy(Pizza);
            Destroy(this.gameObject);
        }
        if(Pizza.transform.position.y == -195)
        {
            if (data[0] == true && data[1] == true && data[2] == true && data[3] == true)
            {
                GameScript.points = Mathf.Floor(GameScript.points + (float)(3 * Rich));
                GameScript.RandomizeToppings();
                GameScript.RichFactor += 0.1f;
                Destroy(Pizza);
                Destroy(this.gameObject);
            } else
            {
                GameScript.points = Mathf.Floor(GameScript.points - (float)(1 * Rich));
                GameScript.RandomizeToppings();
                Destroy(Pizza);
                Destroy(this.gameObject);
            }
        }
        if(data[0] == true && data[1] == true && data[2] == true && data[3] == true)
        {
            GameScript.points = Mathf.Floor(GameScript.points + (float)(3 * Rich));
            GameScript.RandomizeToppings();
            GameScript.RichFactor += 0.1f;
            Destroy(this.gameObject);
            Destroy(Pizza);
        }
    }

}
