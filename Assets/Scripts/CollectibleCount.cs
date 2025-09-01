using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CollectibleCount : MonoBehaviour
{
    public static int collectiblesCollected;
    public static int backpackInventory;
    private int backpackCount;
    private int crabCount;
    private int frogCount;
    private int spyCrabCount;
    private int bottomEggCount;
    private int topEggCount;

    [SerializeField] TMP_Text backpackText;
    [SerializeField] TMP_Text crabText;
    [SerializeField] TMP_Text frogText;
    [SerializeField] TMP_Text spyCrabText;
    [SerializeField] TMP_Text bottomEggText;
    [SerializeField] TMP_Text topEggText;

    public static bool canCollect;

    [SerializeField] AudioSource collectionDing;

    // Start is called before the first frame update
    void Start()
    {
        collectiblesCollected = 0;
        backpackInventory = 0;
        backpackCount = 0;
        crabCount = 0;
        frogCount = 0;
        spyCrabCount = 0;
        bottomEggCount = 0;
        topEggCount = 0;
        canCollect = false;
    }

    // Update is called once per frame
    void Update()
    {
        backpackText.text = backpackCount.ToString() + "/6";
        crabText.text = crabCount.ToString() + "/21";
        frogText.text = frogCount.ToString() + "/8";
        spyCrabText.text = spyCrabCount.ToString() + "/16";
        bottomEggText.text = bottomEggCount.ToString() + "/6";
        topEggText.text = topEggCount.ToString() + "/7";

        if (collectiblesCollected < backpackInventory)
        {
            canCollect = true;
        }
        else
        {
            canCollect = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Backpack"))
        {
            backpackCount++;
            collectionDing.Play();
        }

        if (collision.gameObject.CompareTag("Crab") && GeneralCollectibleScript.isHydrated && canCollect)
        {
            crabCount++;
            collectiblesCollected += 1;
            GeneralCollectibleScript.isHydrated = false;
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.CompareTag("Frog") && GeneralCollectibleScript.isHydrated && canCollect)
        {
            frogCount++;
            collectiblesCollected += 1;
            GeneralCollectibleScript.isHydrated = false;
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.CompareTag("SpyCrab") && GeneralCollectibleScript.isHydrated && canCollect)
        {
            spyCrabCount++;
            collectiblesCollected += 1;
            GeneralCollectibleScript.isHydrated = false;
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.CompareTag("BottomEgg") && GeneralCollectibleScript.isHydrated && canCollect)
        {
            bottomEggCount++;
            collectiblesCollected += 1;
            GeneralCollectibleScript.isHydrated = false;
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.CompareTag("TopEgg") && GeneralCollectibleScript.isHydrated && canCollect)
        {
            topEggCount++;
            collectiblesCollected += 1;
            GeneralCollectibleScript.isHydrated = false;
            Destroy(collision.gameObject);
        }
    }
}