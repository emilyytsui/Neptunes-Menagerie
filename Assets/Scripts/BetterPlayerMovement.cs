using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BetterPlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    public float moveSpeed;
    public float jumpSpeed;
    public float moveInput;

    public Animator anim_miner;
    public Animator anim_farmer;

    private bool isOnGround;
    public Transform playerPos;
    public float positionRadius;

    public LayerMask ground;

    private float airTimeCount;
    public float airTime;
    private bool inAir;

    [SerializeField] AudioSource jumpSoundEffect;
    [SerializeField] AudioSource walkingSoundEffect;
    [SerializeField] AudioSource watergunSoundEffect;

    private BoxCollider2D box;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        box = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(!TurtleMineScript.exploded) {
            moveInput = Input.GetAxisRaw("Horizontal");
            rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);

            anim_miner.SetFloat("speed", Mathf.Abs(moveInput));
            anim_farmer.SetFloat("speed", Mathf.Abs(moveInput));
        }
    }

    void Update()
    {
        if(!TurtleMineScript.exploded) {
            if (DialogueManager.isActive == true)
            {
                Time.timeScale = 0f;
            }

            isOnGround = Physics2D.OverlapCircle(playerPos.position, positionRadius, ground);

            if (isOnGround == true && Input.GetKeyDown(KeyCode.Space)) 
            {
                inAir = true;
                airTimeCount = airTime;
                rb.velocity = Vector2.up * jumpSpeed;
                walkingSoundEffect.Pause();
                jumpSoundEffect.Play();
            }


            if (Input.GetKey(KeyCode.Space) && inAir == true)
            {
                if (airTimeCount > 0)
                {
                    rb.velocity = Vector2.up * jumpSpeed;
                    airTimeCount -= Time.deltaTime;
                }
                else
                {
                    inAir = false;
                }
            }
            if (Input.GetKeyUp(KeyCode.Space))
            {
                inAir = false;
            }

            //this section down here might be completely broken

            Vector3 max = box.bounds.max;
            Vector3 min = box.bounds.min;

            Vector2 corner = new Vector2(max.x, min.y - 0.1f);
            Vector2 corner2 = new Vector2(min.x, min.y - 0.2f);
            Collider2D hit = Physics2D.OverlapArea(corner, corner2);

            MovingPlatform platform = null;
            if (hit != null)
            {
                platform = hit.GetComponent<MovingPlatform>();
            }
            if (platform != null)
            {
                transform.parent = platform.transform;
            }
            else
            {
                transform.parent = null;
            }

            Vector3 pScale = new Vector3(1f, 1f, 1f);
            //if (platform != null)
            //{
            //    pScale = platform.transform.localScale;
            //}
            if (moveInput != 0)
            {
                transform.localScale = new Vector3(-1 * Mathf.Sign(moveInput) / pScale.x, 1 / pScale.y, 1);
                walkingSoundEffect.Play();
            }

            anim_miner.SetBool("grounded", isOnGround);
            anim_farmer.SetBool("grounded", isOnGround);

            if (!isOnGround && !inAir)
            {
                walkingSoundEffect.Pause();
            }
        }
    }
}