using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public static int currentHP;
    public Text healthText;
    public Image fillHealthBar;

    [SerializeField] Canvas loseScreen;
    [SerializeField] Canvas winScreen;
    public bool loseGame;
    public bool midpoint;
    public Vector3 startPoint;
    public Vector3 checkpoint;

    [SerializeField] GameObject midpointStart;
    [SerializeField] GameObject midpointCompleted;

    private void Start()
    {
        currentHP = 100;
        loseScreen.gameObject.SetActive(false);
        winScreen.gameObject.SetActive(false);

        midpoint = false;
        startPoint = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y + 10, this.gameObject.transform.position.z);

        midpointStart.GetComponent<Renderer>().enabled = true;
        midpointCompleted.GetComponent<Renderer>().enabled = false;
    }

    private void Update()
    {
        healthText.text = Mathf.Clamp(currentHP, 0f, 100f) + "%";
        fillHealthBar.fillAmount = Mathf.Clamp((float)currentHP / 100, 0, 1f);
        PlayerRespawns();
        if (currentHP <= 0)
        {
            loseScreen.gameObject.SetActive(true);
            Time.timeScale = 0f;
        }
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (CollectibleCount.collectiblesCollected == 58 && collision.gameObject.CompareTag("Win") && currentHP > 0 && Timer.currentTime > 0)
        {
            StartCoroutine(WonGame());
        }

        if (collision.gameObject.CompareTag("FallingStalactite") || collision.gameObject.CompareTag("Stalagmite"))
        {
            currentHP = Mathf.Clamp(currentHP - 4, 0, 100);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Midpoint"))
        {
            if (!midpoint) {

                checkpoint = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y + 5, this.gameObject.transform.position.z);

                midpointStart.GetComponent<Renderer>().enabled = false;
                midpointCompleted.GetComponent<Renderer>().enabled = true;
            }
            midpoint = true;
        }
    }

    public void PlayerRespawns()
    {

        if(currentHP <= 0 || transform.position.y < -100)
        {
            if (!midpoint)
            {
                this.gameObject.transform.position = startPoint; //serenas code
            }
            else
            {
                this.gameObject.transform.position = checkpoint;
            }
        }
    }

    IEnumerator WonGame()
    {
        yield return new WaitForSeconds(0f);
        winScreen.gameObject.SetActive(true);
        Time.timeScale = 0f;
    }
}