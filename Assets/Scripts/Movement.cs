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
			animator.SetBool("IsJumping", true);
			jump=true;
			
	   }
	   animator.SetFloat("HeroSpeed",Mathf.Abs(hmove));
    }
	
	void FixedUpdate()
	{
		controller.Move(hmove * Time.fixedDeltaTime, false, jump);
		
		jump=false;
		
	}
	public void OnLanding()
	{
		animator.SetBool("IsJumping", false);
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
