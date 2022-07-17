using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class dragscript : MonoBehaviour
{
    private GameObject toppingclone;
    public GameScript game;
    private OrderClock order;
    [SerializeField] private int toppingid;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(game.neworder)
        {
            order = game.neworder.GetComponent<OrderClock>();
        }
    }

    public void OnMouseDown()
    {
        toppingclone = Instantiate(this.gameObject, order.Pizza.transform);
        toppingclone.transform.position = order.Pizza.transform.position;
        toppingclone.transform.localScale = new Vector3(1.4f, 1.4f, 1f);
        if (order.expecteddata[toppingid] == true)
        {
            order.Pizza.GetComponent<datascript>().data[toppingid] = true;
        } else
        {
            order.Pizza.GetComponent<datascript>().data[toppingid] = false;
        }
        game.PizzaClick.Play();
    }
    
}
