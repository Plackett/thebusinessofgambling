using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class datascript : MonoBehaviour
{
    public List<bool> data = new List<bool>(4);
    public List<bool> expecteddata = new List<bool>(4);
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < 4; i++)
        {
            if (expecteddata[i] == false)
            {
                data[i] = true;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
    }

}
