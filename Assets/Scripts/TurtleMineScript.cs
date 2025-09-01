using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurtleMineScript : MonoBehaviour
{
    private Animator anim;
    public static bool exploded;
    public static bool explode;
    [SerializeField] Canvas loseScreen;
    [SerializeField] AudioSource explosionSoundEffect;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        exploded = false;
        explode = true;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && explode)
        {
            anim.SetBool("triggered", true);
            exploded = true;
            StartCoroutine(PlayExplosionSound());
            StartCoroutine(Explosion());
            loseScreen.gameObject.SetActive(true);
        }
    }

    IEnumerator PlayExplosionSound()
    {
        yield return new WaitForSeconds(0.75f);
        explosionSoundEffect.Play();
    }

    IEnumerator Explosion()
    {
        yield return new WaitForSeconds(1.5f);
        Destroy(gameObject);
        Time.timeScale = 0f;
    }
}