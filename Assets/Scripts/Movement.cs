using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
	public CharacterController2D controller;
	public Animator animator;
	public float hmove = 0f;
	float speed = 70f;
	public bool jump = false;
	
	public bool doubleJump = false;
	public bool fighting = false;
	public bool dJumpSwitch = false;
	bool dJumpDelaySwitch = true;
	public bool dJumpDebugSwitch = true;
	bool dJumpDelayDelay = true;
	int dJumpDelay =1;
	bool airdash = false;
	
	
	
	
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
		hmove = (Input.GetAxisRaw("Horizontal") * speed); 
       if (Input.GetKey(KeyCode.Space)||Input.GetKey(KeyCode.UpArrow))
	   {
			if(doubleJump)
			{
				dJumpDelayDelay = false;
			}
			if (doubleJump && dJumpSwitch && dJumpDebugSwitch)
			{
				dJumpSwitch=false;
				animator.SetBool("IsJumping", false);
				animator.SetBool("isAirdash", true);
				airdash = true;
				controller.m_Grounded = true;
				controller.m_Rigidbody2D.velocity = Vector2.zero;
				controller.Move(hmove * Time.fixedDeltaTime, false, true);
				dJumpDebugSwitch=false;
			}
			else
			{
				if (!airdash)
				{
				
					animator.SetBool("IsJumping", true);
				}
				jump=true;
				if(dJumpDelaySwitch)
				{
					dJumpSwitch=false;
					dJumpDelaySwitch=false;
					
				}
			
			}
	   }
	   if (!dJumpDelaySwitch && dJumpDelay ==0 &&(Input.GetKeyUp(KeyCode.Space) ||Input.GetKeyUp(KeyCode.UpArrow))) 
	   {
			dJumpDelay=-1;			
			dJumpSwitch=true;
			
	   
		}	
	   animator.SetFloat("HeroSpeed",Mathf.Abs(hmove));
	   if (!dJumpDelayDelay&&dJumpDelay>0)
	   {
			dJumpDelay--;
	   }
	  
    }
	
	void FixedUpdate()
	
	{
		  
			
	   
		controller.Move(hmove * Time.fixedDeltaTime, false, jump);
		
		jump=false;
		
	}
	public void OnLanding()
	{
		animator.SetBool("IsJumping", false);
		animator.SetBool("isAirdash", false);
		dJumpDelaySwitch=true;
		dJumpDebugSwitch = true;
		dJumpDelayDelay = true;
		dJumpDelay = 1;
		airdash = false;
	}
	
	public void ChangeItem(string itemType)
	{
        switch(itemType)
		{
			case "fight enabler":
				fighting = true;
				doubleJump = false;
				break;
			case "jump enabler":
				doubleJump = true;
				fighting = false;
				break;
			default:
				doubleJump = false;
				fighting = false;
				break;
		}
	}
}
