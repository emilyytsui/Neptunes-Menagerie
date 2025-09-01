using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class BreakController : MonoBehaviour
{
    public Tilemap groundCeilingTileMap;

    public float castDistance = 1.0f;
    public Transform raycastPoint;
    public LayerMask layer;

    float blockDestroyTime = 0.2f;

    Vector3 direction;
    RaycastHit2D hit;

    bool destroyingBlock = false;

    private Animator anim;

    [SerializeField] AudioSource digSoundEffect;

    void Start()
    {
        anim = GetComponent<Animator>();
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.F) && SwitchCharacters.characterActive == 0)
        {
            RaycastDirection();
            anim.SetBool("digging", true);
            digSoundEffect.Play();
        }
        else
        {
            anim.SetBool("digging", false);
        }
    }
    void RaycastDirection()
    {
        if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
        {
            direction.x = Input.GetAxis("Horizontal");
            direction.y = Input.GetAxis("Vertical");
        }
        hit = Physics2D.Raycast(raycastPoint.position, direction, castDistance, layer.value);

        Vector2 endpos = raycastPoint.position + direction;

        Debug.DrawLine(raycastPoint.position, endpos, Color.red);

        if (Input.GetKey(KeyCode.F))
        {
            if (hit.collider && !destroyingBlock && hit.transform.gameObject.tag == "Breakable")
            {
                destroyingBlock = true;
                StartCoroutine(DestroyBlock(hit.collider.gameObject.GetComponent<Tilemap>(), endpos));
            }
        }
    }

    IEnumerator DestroyBlock(Tilemap map, Vector2 pos)
    {
        yield return new WaitForSeconds(blockDestroyTime);

        pos.y = Mathf.Floor(pos.y);
        pos.x = Mathf.Floor(pos.x);

        map.SetTile(new Vector3Int((int)pos.x, (int)pos.y, 0), null);

        destroyingBlock = false;

    }
}