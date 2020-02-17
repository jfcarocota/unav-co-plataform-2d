using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UNAV2DUtils.GameplaySystem;

public class Player : Character2D
{
    //Una vez por frame
    void Update()
    {
        //GameplaySystem.MovementTransform(transform, moveSpeed, spr, FlipSprite);
        //GameplaySystem.MovementImpulse(rb2d, moveSpeed, spr, FlipSprite, maxVel, Grounding);
        GameplaySystem.MovementVelocity(rb2d, moveSpeed, spr, FlipSprite, maxVel);
        
        anim.SetFloat("axisX", Mathf.Abs(GameplaySystem.Axis.x));
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
