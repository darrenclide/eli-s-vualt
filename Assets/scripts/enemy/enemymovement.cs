using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public Transform playerCheck;
    public float playerCheckRadius;
    public GameObject pointA;
    public GameObject pointB;
    private Rigidbody2D rb;
    private Transform currentPoint;
    public GameObject player;
    public float speed;
    private float point;
    private float distance;
    public Animator animator;
    bool enemyMode;
    bool flipped;
    LayerMask playerLayerMask;
    private bool isNearPlayer;
    // Start is called before the first frame update
    void Start()
    {
        playerLayerMask = LayerMask.GetMask("Player");
        speed = Random.Range(4.1f,4.4f);
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        currentPoint = pointB.transform;
    }

// Update is called once per frame
void Update()
    {
        isNearPlayer = Physics2D.OverlapCircle(playerCheck.position, playerCheckRadius, playerLayerMask);
        point = currentPoint.position.x - transform.position.x;
        distance = player.transform.position.x - transform.position.x;
        if(isNearPlayer && distance < 0) 
        {
            transform.localScale = new Vector3(-1, 1, 1);
            flipped = true;
        }
        else if(isNearPlayer && distance > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
            flipped = false;
        }
    // Check if the goblin is near the current point
    if (Vector2.Distance(transform.position, currentPoint.position) < 0.5f)
    {
        // If near point B, flip and move to point A
        if (currentPoint == pointB.transform)
        {
            transform.localScale = new Vector3(-1, 1, 1);
            flipped = true;
            currentPoint = pointA.transform;
        }
        // If near point A, flip and move to point B
        else if (currentPoint == pointA.transform)
        {
            transform.localScale = new Vector3(1, 1, 1);
            flipped = false;
            currentPoint = pointB.transform;
        }
    }
        float rayLength = 4.5f;
        RaycastHit2D hit;
        Color hitColor = Color.white;
        if(flipped == true)
        {
            hit = Physics2D.Raycast(transform.position, Vector2.left, rayLength, playerLayerMask);
            Debug.DrawRay(transform.position,Vector2.left * rayLength, hitColor);
        }
        else
        {
            hit = Physics2D.Raycast(transform.position, Vector2.right, rayLength, playerLayerMask);
            Debug.DrawRay(transform.position,Vector2.right * rayLength, hitColor);
        }
        if(hit.collider != null)
        {
            enemyMode = true;
            hitColor = Color.green;
        }
        else
        {
            enemyMode = false;
        }

        if(enemyMode == false)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, currentPoint.position, speed * Time.deltaTime);
            animator.SetBool("move", true);
        }
        else if(enemyMode == true)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
            animator.SetBool("move", true);
            if(distance < 0.5 && distance > -0.5)
            {
                animator.SetTrigger("attack");
            }
        }
        else
        {
        }
    }
}