using UnityEngine;

public class Player : MonoBehaviour
{
    public static void Turn(Rigidbody2D rb, float movement)
    {
        SpriteRenderer spriteRenderer = rb.gameObject.GetComponent<SpriteRenderer>();

        spriteRenderer.flipX = movement switch
        {
            > 0 => true,
            < 0 => false,
            _ => spriteRenderer.flipX
        };
    }
}
