using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PMovement : MonoBehaviour
{
    public GameObject plr;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetAxis("Horizontal") > 0) {
            plr.transform.position = (plr.transform.position + new Vector3(speed, 0, 0));
        } else
        {
            if (Input.GetAxis("Horizontal") < 0)
            {
                plr.transform.position = (plr.transform.position - new Vector3(speed, 0, 0));
            }
        }

    }

}
