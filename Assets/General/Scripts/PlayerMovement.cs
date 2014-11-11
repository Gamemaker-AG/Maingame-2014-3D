using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    private CharacterController cc;
    private Vector3 movement;
    public float speed = 10;
    public float jumpPower = 6;
    public float airControl = 10;
    public float maxAirSpeed = 10;
    public int jumpCount = 2;
    public float gravity = 10;
    private int jumpsLeft;

	void Awake()
    {
        cc = GetComponent<CharacterController>();
	}

    private BufferedBoolean jumping = new BufferedBoolean();
	void FixedUpdate()
    {
        var input = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        jumping.Update(Input.GetButton("Jump"));

	    if(cc.isGrounded)
        {
            movement = input * speed;
            if(jumping.hasBecomeTrue)
            {
                movement.y = jumpPower;
                jumpsLeft = jumpCount - 1;
            }
            else
            {
                movement.y = -5;
            }
        }
        else
        {
            if(jumpsLeft > 0 && jumping.hasBecomeTrue)
            {
                movement.y = jumpPower;
                --jumpsLeft;
            }
            else
            {
                movement.y -= gravity * Time.deltaTime;
            }

            movement += input * airControl * Time.deltaTime;
                
            var movementY = movement.y;
            movement.y = 0;
            movement = Vector3.ClampMagnitude(movement, maxAirSpeed);
            movement.y = movementY;
        }

        cc.Move(movement * Time.deltaTime);
	}
}
