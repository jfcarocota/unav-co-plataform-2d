using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    float moveSpeed = 3f;

    SpriteRenderer spr;

    Animator anim; 

    void Awake()
    {
        spr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    Vector2 Axis
    {
        get => new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
    }

    bool FlipSprite
    {
        get => Axis.x > 0 ? false : Axis.x < 0 ? true : spr.flipX;
    }

    //Una vez por frame
    void Update()
    {
        transform.Translate(Axis * moveSpeed * Time.deltaTime);
        spr.flipX = FlipSprite;

        anim.SetFloat("axisX", Mathf.Abs(Axis.x));
    }
}
