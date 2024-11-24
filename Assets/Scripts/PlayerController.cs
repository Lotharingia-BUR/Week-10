using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rB;
    public float speed = 10;
    public float speedCap = 2;
    public enum FacingDirection
    {
        left, right
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 playerInput = new Vector2();
        // The input from the player needs to be determined and
        // then passed in the to the MovementUpdate which should
        // manage the actual movement of the character.
        if (Input.GetKey(KeyCode.RightArrow))
        {
            playerInput = Vector2.right;
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            playerInput = Vector2.left;
        }

        MovementUpdate(playerInput*Time.deltaTime * 100 *speed);
    }

    private void MovementUpdate(Vector2 playerInput)
    {
        rB.AddForce(playerInput);
        
        if (rB.totalForce.x > speedCap)
        {
            rB.totalForce = new Vector2 (speedCap, 0f);
        }
        else if (rB.totalForce.x < -speedCap)
        {
            rB.totalForce = new Vector2(-speedCap, 0f);
        }
        Debug.Log(rB.totalForce);

    }

    public bool IsWalking()
    {
        return false;
    }
    public bool IsGrounded()
    {
        return false;
    }

    public FacingDirection GetFacingDirection()
    {
        return FacingDirection.left;
    }
}
