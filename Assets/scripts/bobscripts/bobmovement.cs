using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bobmovement : MonoBehaviour
{
    public GameObject pointA;
    public GameObject pointB;
    public float speed;
    private Transform currentPoint;
    private float point;
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        currentPoint = pointB.transform;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
            speed = Random.Range(0.8f,1.4f);
            point = currentPoint.position.x - transform.position.x;
            if (Vector2.Distance(transform.position, currentPoint.position) < 0.5f)
            {
                // If near point B, flip and move to point A
                if (currentPoint == pointB.transform)
                {
                    transform.localScale = new Vector3(-1, 1, 1);
                    currentPoint = pointA.transform;
                }
                // If near point A, flip and move to point B
                else if (currentPoint == pointA.transform)
                {
                    transform.localScale = new Vector3(1, 1, 1);
                    currentPoint = pointB.transform;
                }
            }
        transform.position = Vector2.MoveTowards(this.transform.position, currentPoint.position, speed * Time.deltaTime);
        animator.SetBool("move", true);
    }
}
