using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public float speed = 2f;
    public float radius = 5f;
    private Transform target;
    private Rigidbody2D rb;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        rb = this.GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        transform.position = moveTowards();
        rb.rotation = getAngle();
    }

    private float getDistanceByTarget()
	{
        return Vector2.Distance(transform.position, target.position);
    }
    private Vector2 moveTowards()
    {
        if (getDistanceByTarget() < radius)
		{
            return Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
		}
        return transform.position;
    }

    private float getAngle()
    {
        Vector3 direction = target.position - transform.position;
        return Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
    }
}
