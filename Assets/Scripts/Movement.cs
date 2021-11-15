using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Movement : MonoBehaviour
{
    public float jumpSpeed = 18f;
    public float forceSpeed = 60f;
    public float maxSpeed = 6f;
    public float maxAngularVelocity = 600f;
    public float velocityBeforePhysicsUpdate;
    public bool onGround;
    public Rigidbody2D body;
    public CircleCollider2D collider;

    float pressKeyX, pressKeyY;
    bool pressBtnLeft, pressBtnRight, pressBtnJump;

    public GameObject dustEfxPrefab;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        collider = GetComponent<CircleCollider2D>();
    }
    
    // Update is called once per frame
    void Update()
    {
        pressKeyX = Input.GetAxisRaw("Horizontal");
        pressKeyY = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()
    {
        // Limit velocity
        if (body.velocity.x > maxSpeed)
        {
            body.velocity = new Vector2(maxSpeed, body.velocity.y);
        }
        else if (body.velocity.x < -maxSpeed)
        {
            body.velocity = new Vector2(-maxSpeed, body.velocity.y);
        }

        // Limit angular velocity
        if (body.angularVelocity > maxAngularVelocity)
        {
            body.angularVelocity = maxAngularVelocity;
        }
        else if (body.angularVelocity < -maxAngularVelocity)
        {
            body.angularVelocity = -maxAngularVelocity;
        }

        if (pressBtnLeft || pressKeyX < 0)
        {
            MoveLeft();
        }
        else if (pressBtnRight || pressKeyX > 0)
        {
            MoveRight();
        }

        if (pressBtnJump || pressKeyY > 0)
        {
            Jump();
        }

        velocityBeforePhysicsUpdate = body.velocity.y;
    }

    public void OnPressButtonLeft()
    {
        pressBtnLeft = true;
    }
    public void StopPressButtonLeft()
    {
        pressBtnLeft = false;
    }
    public void OnPressButtonRight()
    {
        pressBtnRight = true;
    }
    public void StopPressButtonRight()
    {
        pressBtnRight = false;
    }
    public void OnPressButtonJump()
    {
        pressBtnJump = true;
    }
    public void StopPressButtonJump()
    {
        pressBtnJump = false;
    }

    public void TouchLand()
    {
        if (onGround) return;

        onGround = true;
        SoundManager.PlaySound("land", Mathf.Abs(velocityBeforePhysicsUpdate / jumpSpeed));
        SpawnDustEfx(Mathf.Abs(velocityBeforePhysicsUpdate / jumpSpeed * 0.8f));
    }
    public void LeaveLand()
    {
        if (!onGround) return;

        onGround = false;
    }

    private Vector2 getGravityPoint()
    {
        if (onGround)
            return new Vector2(transform.position.x, transform.position.y + 0.2f);
        else
            return new Vector2(transform.position.x, transform.position.y + 0.05f);
    }

    public void MoveLeft()
    {
        //Debug.Log("left");
        body.AddForceAtPosition(new Vector2(-forceSpeed * 4, 0), getGravityPoint());
        if (body.velocity.x > 0.01)
        {
            body.angularVelocity = 0;
            body.velocity = new Vector2(0, body.velocity.y);
        }
    }
    public void MoveRight()
    {
        //Debug.Log("right"); 
        body.AddForceAtPosition(new Vector2(forceSpeed * 4, 0), getGravityPoint());

        if (body.velocity.x < -0.01)
        {
            body.angularVelocity = 0;
            body.velocity = new Vector2(0, body.velocity.y);
        }
    }
    public void Jump()
    {
        //Debug.Log("jump");
        if (onGround)
        {
            onGround = false;
            SoundManager.PlaySound("jump", 1.0f);
            SpawnDustEfx(0.8f);
            body.velocity = new Vector2(body.velocity.x, jumpSpeed);
        }
    }

    public void SpawnDustEfx(float size)
    {
        GameObject dustEfx = Instantiate(dustEfxPrefab) as GameObject;
        dustEfx.transform.position = new Vector2(
            transform.position.x,
            transform.position.y - collider.radius
        );

        dustEfx.transform.localScale = new Vector2(
            size,
            size * 0.6f
        );
    }
}
