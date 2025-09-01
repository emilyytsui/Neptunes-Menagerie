using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TongueScript : MonoBehaviour
{

    public float length = 5;
    public GameObject tongueFrog;

    private Transform myTransform;
    private float frogDirection;
    private Vector3 currentPosition;
    private Vector3 currentScale;
    private IEnumerator extendTongueCoroutine;
    private IEnumerator retractTongueCoroutine;

    // Start is called before the first frame update
    void Start()
    {
        myTransform = GetComponent<Transform>();
        currentPosition = myTransform.position;
        currentScale = myTransform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        frogDirection = tongueFrog.GetComponent<TongueFrogScript>().direction;
        myTransform.position = currentPosition;
        //Debug.Log("tongue direction " + frogDirection);
    }

    public void ExtendTongue()
    {
        StopAllCoroutines();
        StartCoroutine(ExtendTongueCoroutine());
    }

    // public void RetractTongue()
    // {
    //     StopAllCoroutines();
    //     StartCoroutine(RetractTongueCoroutine());
    // }

    public IEnumerator ExtendTongueCoroutine()
    {
        while (currentScale.x < length)
        {
            currentPosition.x += frogDirection*0.05f;
            currentScale.x += 0.1f;
            myTransform.position = currentPosition;
            myTransform.localScale = currentScale;
            yield return new WaitForSeconds(0.01f);
        }
        currentScale.x = length;
        myTransform.localScale = currentScale;
    }

    // public IEnumerator RetractTongueCoroutine()
    // {
    //     while (currentScale.x > 0)
    //     {
    //         currentPosition.x -= frogDirection*0.05f;
    //         currentScale.x -= 0.1f;
    //         myTransform.position = currentPosition;
    //         myTransform.localScale = currentScale;
    //         yield return new WaitForSeconds(0.1f);
    //     }
    //     currentScale.x = 0;
    //     myTransform.localScale = currentScale;
    // }
}
