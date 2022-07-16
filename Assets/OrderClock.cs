using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OrderClock : MonoBehaviour
{
    public float time;
    private bool colorchanged;
    public GameScript GameScript;
    // Start is called before the first frame update
    void Start()
    {
        colorchanged = true;
        time = 45;
    }

    // Update is called once per frame
    void Update()
    {
        GameObject neworder = this.gameObject;
        time -= Time.deltaTime;
        if (time <= 45 && time > 0)
        {
            if (time < 23 && colorchanged == true)
            {
                colorchanged = false;
                neworder.transform.GetChild(4).transform.GetChild(1).transform.GetChild(0).GetComponent<Image>().color = new Color32(0xFF, 0xE8, 0x00, 0xFF);
                GameScript.RandomizeToppings();
                this.gameObject.transform.position = this.gameObject.transform.position + new Vector3(65, 0, 0);
            }
            if (time < 15)
            {
                neworder.transform.GetChild(4).transform.GetChild(1).transform.GetChild(0).GetComponent<Image>().color = new Color32(0xEF, 0x07, 0x00, 0xFF);
            }
            neworder.transform.GetChild(4).GetComponent<Slider>().value = time / 45;
        } else
        {
            Destroy(this.gameObject);
        }
    }
}
