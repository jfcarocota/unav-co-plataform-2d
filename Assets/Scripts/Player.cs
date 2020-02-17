using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character2D
{
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
