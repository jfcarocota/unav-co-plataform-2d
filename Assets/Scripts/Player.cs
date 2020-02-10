using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField, Range(0.1f, 7f)]
    float moveSpeed = 3f;
    [SerializeField, Range(0.1f, 10f)]
    float jumpForce = 7f;

    SpriteRenderer spr;

    Animator anim; 

    Rigidbody2D rb2d;

    [SerializeField]
    Color rayColor = Color.magenta;
    [SerializeField, Range(0.1f, 5f)]
    float rayDistance = 2f;
    [SerializeField]
    LayerMask groundLayer;

    void Awake()
    {
        spr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
    }

    Vector2 Axis
    {
        get => new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
    }

    bool FlipSprite
    {
        get => Axis.x > 0 ? false : Axis.x < 0 ? true : spr.flipX;
    }

    bool JumpButton
    {
        get => Input.GetButtonDown("Jump");
    }

    bool Grounding
    {
        get => Physics2D.Raycast(transform.position, Vector2.down, rayDistance, groundLayer);
    }

    //Una vez por frame
    void Update()
    {
        transform.Translate(Vector2.right * Axis.x * moveSpeed * Time.deltaTime);
        spr.flipX = FlipSprite;

        anim.SetFloat("axisX", Mathf.Abs(Axis.x));
        anim.SetBool("grounding", Grounding);

        if(JumpButton)
        {
            //salto
            if(Grounding)
            {
                rb2d.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
                anim.SetTrigger("jump");
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = rayColor;
        Gizmos.DrawRay(transform.position, Vector2.down * rayDistance);
    }
}
