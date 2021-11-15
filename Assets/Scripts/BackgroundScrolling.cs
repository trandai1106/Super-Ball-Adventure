using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScrolling : MonoBehaviour
{
    public SpriteRenderer sprite;
    public Rigidbody2D playerBody;
    float width;

    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        width = sprite.size.x * transform.localScale.x;
    }

    private void Update()
    {
        if (playerBody.velocity.x > 0)
        {
            ScrollRight();
        }
        else if (playerBody.velocity.x < 0)
        {
            ScrollLeft();
        }
    }

    public void ScrollRight()
    {
        if (transform.position.x < Camera.main.ViewportToWorldPoint(new Vector2(0f, 0f)).x - width / 2)
        {
            transform.position = new Vector3(
                transform.position.x + width * 3,
                transform.position.y,
                transform.position.z
            );
        }
    }

    public void ScrollLeft()
    {

        if (transform.position.x > Camera.main.ViewportToWorldPoint(new Vector2(1f, 0f)).x + width / 2)
        {
            transform.position = new Vector3(
                transform.position.x - width * 3,
                transform.position.y,
                transform.position.z
            );
        }
    }
}
