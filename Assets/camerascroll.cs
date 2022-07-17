using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camerascroll : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    void MovementLoop()
    {
        if (!LeanTween.isTweening(this.gameObject))
        {

        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!LeanTween.isTweening(this.gameObject))
        {
            this.gameObject.transform.position = new Vector3(0, this.gameObject.transform.position.y, this.gameObject.transform.position.z);
            LeanTween.moveX(this.gameObject, 100, 30);
        }
    }
}
