using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject start;
    public GameObject end;
    public GameObject plr;
    public bool zoom;
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
        if(this.transform.position.x > 10)
        {
            zoom = true;
        } else
        {
            zoom = false;
        }
    }

    void LateUpdate()
    {
        if(zoom)
        {
            this.gameObject.GetComponent<Camera>().orthographicSize = Mathf.Lerp(this.gameObject.GetComponent<Camera>().orthographicSize, 8, 0.2f);
            this.transform.position = new Vector3(this.transform.position.x, Mathf.Lerp(this.transform.position.y, 3, 0.2f), this.transform.position.z);
        } else
        {
            this.gameObject.GetComponent<Camera>().orthographicSize = Mathf.Lerp(this.gameObject.GetComponent<Camera>().orthographicSize, 5, 0.6f);
            this.transform.position = new Vector3(this.transform.position.x, Mathf.Lerp(this.transform.position.y, 0, 0.6f), this.transform.position.z);
        }
    }
}
