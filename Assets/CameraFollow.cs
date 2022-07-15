using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject start;
    public GameObject end;
    public GameObject plr;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (plr.transform.position.x > start.transform.position.x && plr.transform.position.x < end.transform.position.x)
        {
            this.transform.position = new Vector3(plr.transform.position.x, this.transform.position.y, this.transform.position.z);
        }
    }
}
