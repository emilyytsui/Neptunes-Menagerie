using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneralCollectibleScript : MonoBehaviour, IHittable
{
    public static bool isHydrated;
    public ParticleSystem bubbles;

    void Start()
    {
        isHydrated = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ReceiveHit(RaycastHit2D hit)
    {
        isHydrated = true;
        Instantiate(bubbles, transform.position, transform.rotation);
    }
}