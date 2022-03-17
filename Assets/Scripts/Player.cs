using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 10f;
    public bool isGrounded;
    private float dirx;
    public SpriteRenderer renderer;
    Rigidbody2D _rBody;

    void Awake()
    {
        _rBody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        dirx = Input.GetAxisRaw("Horizontal");

        Debug.Log(dirx);

        if (dirx == -1)
        {
            renderer.flipX = true;
        }

        else if (dirx == 1)
        {
            renderer.flipX = false;
        }

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            _rBody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }

    }

    void FixedUpdate()
    {
        _rBody.velocity = new Vector2(dirx * speed, _rBody.velocity.y);
    }
}
