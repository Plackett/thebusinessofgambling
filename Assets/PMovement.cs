using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PMovement : MonoBehaviour
{
    public GameObject plr;
    private int direction;
    public float speed;
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = this.GetComponent<Animator>();
        direction = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetAxis("Horizontal") > 0) {
            animator.SetInteger("State", 1);
            direction = 0;
            plr.transform.position = (plr.transform.position + new Vector3(speed, 0, 0));
        } else
        {
            if (Input.GetAxis("Horizontal") < 0)
            {
                animator.SetInteger("State", 1);
                direction = 1;
                plr.transform.position = (plr.transform.position - new Vector3(speed, 0, 0));
            } else
            {
                animator.SetInteger("State", 0);
            }
        }
        if(direction == 0)
        {
            this.gameObject.GetComponent<SpriteRenderer>().flipX = false;
        }
        if (direction == 1)
        {
            this.gameObject.GetComponent<SpriteRenderer>().flipX = true;
        }

    }

}
