using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wandering : MonoBehaviour
{
    public bool isWandering = true;
    public Vector3 finishPos = Vector3.zero;
    public float speed = 0.1f;
    public float idleTime = 5;

    private Vector3 startPos;
    private float trackPercent = 0;
    private int direction = 1;
    private bool coroutineStarted = false;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        anim = GetComponent<Animator>();

        Vector3 scale = transform.localScale;
        if (finishPos.x - startPos.x > 0)
            scale.x = -1;
        else
            scale.x = 1;
        transform.localScale = scale;
    }

    // Update is called once per frame
    void Update()
    {
        if (isWandering && !coroutineStarted)
        {
            trackPercent += direction * speed * Time.deltaTime;
            float x = (finishPos.x - startPos.x) * trackPercent + startPos.x;
            float y = (finishPos.y - startPos.y) * trackPercent + startPos.y;
            transform.position = new Vector3(x, y, startPos.z);

            if ((direction == 1 && trackPercent > 0.9f) || (direction == -1 && trackPercent < 0.1f))
            {
                direction *= -1;
                StartCoroutine(Idling(idleTime));
            }
        }
        else if (!isWandering)
        {
            anim.SetBool("idle", true);
        }
    }

    IEnumerator Idling(float idleTime)
    {
        coroutineStarted = true;

        anim.SetBool("idle", true);
        yield return new WaitForSeconds(idleTime);

        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;

        coroutineStarted = false;
        anim.SetBool("idle", false);
    }

    private void OnDrawGizmos()
    {
        if (isWandering)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(transform.position, finishPos);
        }
    }
}