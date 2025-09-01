using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchCharacters : MonoBehaviour
{

    public GameObject mayuMiner, farmerSerena;
    public static int characterActive; // 0 is miner; 1 is farmer

    private Renderer minerRend, farmerRend;

    // Start is called before the first frame update
    void Start()
    {
        characterActive = 0;
        minerRend = mayuMiner.GetComponent<Renderer>();
        farmerRend = farmerSerena.GetComponent<Renderer>();

        minerRend.enabled = true;
        farmerRend.enabled = false;
        // mayuMiner.gameObject.SetActive(true);
        // farmerSerena.gameObject.SetActive(false);
    }
    public void Update()
    {
        if (Input.GetKey(KeyCode.Alpha1))
        {
            characterActive = 1;
            minerRend.enabled = false;
            farmerRend.enabled = true;


            // mayuMiner.gameObject.SetActive(false);
            // farmerSerena.gameObject.SetActive(true);
        }
        if (Input.GetKey(KeyCode.Alpha2))
        {
            characterActive = 0;
            minerRend.enabled = true;
            farmerRend.enabled = false;

            // mayuMiner.gameObject.SetActive(true);
            // farmerSerena.gameObject.SetActive(false);
        }
    }
}