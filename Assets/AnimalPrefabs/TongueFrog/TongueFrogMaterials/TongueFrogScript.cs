using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TongueFrogScript : MonoBehaviour
{
    public float direction; // referenced by TongueScript.cs
    public GameObject tongue;
    private Animator anim;
    
    // Start is called before the first frame update
    void Start()
    {
        direction = -1*Mathf.Sign(GetComponent<Transform>().localScale.x);
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
    
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Player")
        {
            // if (!activated)
            // {
            //     activated = true;
            tongue.GetComponent<TongueScript>().ExtendTongue();
            // }
            // else
            // {
            //     activated = false;
            //     tongue.GetComponent<TongueScript>().RetractTongue();
            // }
        }
    }
}
