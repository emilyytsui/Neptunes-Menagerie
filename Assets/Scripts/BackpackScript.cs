using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BackpackScript : MonoBehaviour
{
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
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
            CollectibleCount.backpackInventory += 10;
            Destroy(gameObject);
        }
    }
}
