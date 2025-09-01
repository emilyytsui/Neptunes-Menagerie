using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] private Transform _gunPoint;
    [SerializeField] private GameObject _bulletTrail;
    [SerializeField] private float _weaponRange = 10f;
    private Animator anim;

    [SerializeField] AudioSource watergunSoundEffect;

    [SerializeField] SettingsPopup settingsPopup;
    [SerializeField] CreditsPopup creditsPopup;
    [SerializeField] Canvas dialogueCanvas;
    [SerializeField] Canvas loseScreen;
    [SerializeField] Canvas winScreen;

    [SerializeField] AudioSource crabSound;
    [SerializeField] AudioSource frogSound;
    [SerializeField] AudioSource eggSound;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Shoot();
        if (settingsPopup.gameObject.activeSelf || creditsPopup.gameObject.activeSelf || dialogueCanvas.gameObject.activeSelf || loseScreen.gameObject.activeSelf || winScreen.gameObject.activeSelf)
        {
            watergunSoundEffect.Pause();
            anim.SetBool("shooting", false);
        }
    }

    private void Shoot()
    {

        if (Input.GetMouseButtonDown(0) && SwitchCharacters.characterActive == 1)
        {
            anim.SetBool("shooting", true);
            watergunSoundEffect.Play();

            //Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            float posX = Camera.main.ScreenToWorldPoint(Input.mousePosition).x;
            float posY = Camera.main.ScreenToWorldPoint(Input.mousePosition).y;
            Vector2 direction = new Vector2(posX - _gunPoint.position.x, posY - _gunPoint.position.y);


            var hit = Physics2D.Raycast(

                    _gunPoint.position,
                    direction,
                    _weaponRange

                    );

            // if it's the player or backpack, don't instantiate a bullettrail
            //if (!hit.collider.gameObject.CompareTag("Player") || !hit.collider.gameObject.CompareTag("Backpack"))

            var trail = Instantiate(

                _bulletTrail,
                _gunPoint.position,
                transform.rotation

                );


            var trailScript = trail.GetComponent<BulletTrail>();

            if (hit.collider != null)
            {
                if (hit.collider.gameObject.CompareTag("Crab") || hit.collider.gameObject.CompareTag("SpyCrab"))
                {
                    //Debug.Log("crab");
                    crabSound.Play();
                }

                if (hit.collider.gameObject.CompareTag("Frog"))
                {
                    //Debug.Log("frog");
                    frogSound.Play();
                }

                if (hit.collider.gameObject.CompareTag("BottomEgg") || hit.collider.gameObject.CompareTag("TopEgg"))
                {
                    //Debug.Log("egg");
                    eggSound.Play();
                }

                trailScript.SetTargetPosition(hit.point);
                var hittable = hit.collider.GetComponent<IHittable>();
                if (hittable != null)
                {
                    hittable.ReceiveHit(hit);
                }

            }
            else
            {
                float posX3 = Camera.main.ScreenToWorldPoint(Input.mousePosition).x;
                float posY3 = Camera.main.ScreenToWorldPoint(Input.mousePosition).y;
                float posZ3 = Camera.main.ScreenToWorldPoint(Input.mousePosition).z;

                Vector3 direction3 = new Vector3(posX3 - _gunPoint.position.x, posY3 - _gunPoint.position.y, posZ3);

                var endPosition = _gunPoint.position + direction3 * _weaponRange;
                trailScript.SetTargetPosition(endPosition);
            }
        }
        else
        {
            anim.SetBool("shooting", false);
        }
    }
}