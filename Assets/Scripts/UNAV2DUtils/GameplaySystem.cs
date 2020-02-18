using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UNAV2DUtils.GameplaySystem
{
    public class GameplaySystem 
    {
        ///<summary>
        ///This function returns the axis Horizontal and Vertical in a Vector2.
        ///</summary>
        public static Vector2 Axis
        {
            get => new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        }

         public static bool JumpButton
        {
            get => Input.GetButtonDown("Jump");
        }

        ///<summary>
        ///This function moves the player using Transform.
        ///</summary>
        ///<param name="t">The Transform component of player.</param>
        ///<param name="moveSpeed">The speed of the player.</param>
        ///<param name="spr">The SpriteRenderer component of player.</param>
        ///<param name="flip">Indicates when can i flip the sprite of player.</param>

        public static void MovementTransform(Transform t, float moveSpeed, SpriteRenderer spr, bool flip)
        {
            t.Translate(Vector2.right * Axis.x * moveSpeed * Time.deltaTime);
            spr.flipX = flip;
        }
        ///<summary>
        ///This function moves the player using Impulse.
        ///</summary>
        ///<param name="rb2d">The Rigidbody2D component of player.</param>
        ///<param name="moveSpeed">The speed of the player.</param>
        ///<param name="spr">The SpriteRenderer component of player.</param>
        ///<param name="flip">Indicates when can i flip the sprite of player.</param>
        ///<param name="maxVel">Indicates the maximum velocity on x.</param>
        ///<param name="grounding">Indicates if im stand on ground.</param>
        public static void MovementImpulse(Rigidbody2D rb2d, float moveSpeed,SpriteRenderer spr, bool flip, float maxVel, bool grounding)
        {
            rb2d.AddForce(Vector2.right * moveSpeed * Axis.x, ForceMode2D.Impulse);
            float velXClmaped = Axis.x == 0 && grounding ? 0 : Mathf.Clamp(rb2d.velocity.x, -maxVel, maxVel);
            Vector2 velClamped = new Vector2(velXClmaped, rb2d.velocity.y);
            rb2d.velocity = velClamped;
            spr.flipX = flip;
        }

        ///<summary>
        ///This function moves the player using Velocity.
        ///</summary>
        ///<param name="rb2d">The Rigidbody2D component of player.</param>
        ///<param name="moveSpeed">The speed of the player.</param>
        ///<param name="spr">The SpriteRenderer component of player.</param>
        ///<param name="flip">Indicates when can i flip the sprite of player.</param>
        ///<param name="maxVel">Indicates the maximum velocity on x.</param>
        public static void MovementVelocity(Rigidbody2D rb2d, float moveSpeed,SpriteRenderer spr, bool flip, float maxVel)
        {
            rb2d.velocity = new Vector2(Axis.x * moveSpeed, rb2d.velocity.y);
            Vector2 clampVel = Vector2.ClampMagnitude(rb2d.velocity, maxVel);
            Vector2 finalVel = new Vector2(clampVel.x, rb2d.velocity.y);
            rb2d.velocity = finalVel;
            spr.flipX = flip;
        }

        ///<summary>
        ///This function moves the player using Rigidbody2D Position.
        ///</summary>
        ///<param name="rb2d">The Rigidbody2D component of player.</param>
        ///<param name="moveSpeed">The speed of the player.</param>
        ///<param name="spr">The SpriteRenderer component of player.</param>
        ///<param name="flip">Indicates when can i flip the sprite of player.</param>
        public static void MovementPosition(Rigidbody2D rb2d, float moveSpeed,SpriteRenderer spr, bool flip)
        {
            Vector2 velocity = new Vector2(moveSpeed * Axis.x * Time.fixedDeltaTime * 100f, 0);
            rb2d.MovePosition(rb2d.position + velocity);
            spr.flipX = flip;
        }

        ///<summary>
        ///This function make jump the player using Rigidbody2D Position.
        ///</summary>
        ///<param name="rb2d">The Rigidbody2D component of player.</param>
        ///<param name="jumpForce">The jump force of the player.</param>
        public static void JumpPosition(Rigidbody2D rb2d, float jumpForce)
        {
            Vector2 velocity = new Vector2(0, jumpForce * Time.fixedDeltaTime * 100f);
            rb2d.MovePosition(rb2d.position + velocity);
        }
    }
}

