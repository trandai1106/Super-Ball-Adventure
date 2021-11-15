using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSensor : MonoBehaviour
{
    public Transform playerTransform;
    public Movement playerMovement;
    public Collider2D body;

    void Start()
    {
        body = GetComponent<Collider2D>();
    }

    void Update()
    {
        // Move the sensor towards the ball
        transform.position = Vector2.MoveTowards(transform.position, playerTransform.position, 5);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Collider2D>().name != "Ball")
        {
            playerMovement.TouchLand();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<Collider2D>().name != "Ball")
        {
            playerMovement.LeaveLand();
        }
    }
}
