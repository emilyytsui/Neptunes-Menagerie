using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class Stalactite : MonoBehaviour
{
    public ParticleSystem crumbs;
    private float timeToFall;

    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;

        timeToFall = 0.1f;
    }

    // Update is called once per frame
    void Update()
    {
        // Cast a ray straight down.
        RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector2.up, Mathf.Infinity);

        //Debug.DrawRay(transform.position, Vector2.up);
        
        //Debug.Log(hit.collider);

        // If it hits something...
        if (hit.collider != null && hit.collider.gameObject.CompareTag("Player"))
        {
            StartCoroutine(Fall());
        }
    }

    // WITH TRIGGER
    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.gameObject.CompareTag("Player"))
    //    {
    //        StartCoroutine(Fall());
    //    }
    //}
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(this.gameObject);
        Instantiate(crumbs, transform.position - new Vector3(0, 0.5f, 0), transform.rotation);
    }

    private IEnumerator Fall()
    {
        yield return new WaitForSeconds(timeToFall);
        rb.gravityScale = 0.5f;
    }
}