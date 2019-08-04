using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
	public CharacterController2D controller;
	public Animator animator;
	public float hmove = 0f;
	float speed = 100f;
	public bool jump = false;
	
	//powerup booleans
	public bool doubleJump = false;
	public bool fighting = false;
	public bool dash = false;
	public bool gravity = false;
	public bool invinc = false;
	public bool canWin = false;
	
	public bool dJumpSwitch = false;
	bool dJumpDelaySwitch = true;
	public bool dJumpDebugSwitch = true;
	bool dJumpDelayDelay = true;
	int dJumpDelay =1;
	bool airdash = false;
	bool dashswitch=false;
	bool dashaction=false;
	int dashtimer = 20;
	bool dashtimerswitch = false;
	bool dashactiondelay = false;
	float movementdirection = 0f;
	Vector2 m_NewForce;
	public Rigidbody2D _Rigidbody;
	public Sprite mysticRed;
    public SpriteRenderer sr;
	public Texture2D tex;
	bool rotaA,rotaD,rotaS = false;
	Vector2 velocity;
	bool musictrig = true;
	bool musicnew = true;
	char musictype = 'c';
	public AudioSource yeetmystery;
	public MusicTrigger mT;
	
	
	
	
	
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
	
    {
		velocity=_Rigidbody.GetPointVelocity(Vector2.one);
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
		
		if (Input.GetKeyDown(KeyCode.F)&&dash&&dashswitch)
		{
			dashswitch = false;
			dashaction = true;
			animator.SetBool("IsJumping", false);
			animator.SetBool("isAirdash", true);
			airdash = true;
			dashactiondelay = true;
			
		}
		 
		if (gravity)
	    {
			if(Input.GetKey(KeyCode.A))
			{	
				if(!rotaA)
				{	
					if(musicnew)
					{
						mT.pPause();
						yeetmystery.Play();
						musicnew=false;
					}
					else if (musictrig)
					{
						mT.pPause();
						yeetmystery.UnPause();
					}
				}
				controller.m_Rigidbody2D.velocity = Vector2.zero;
				Physics2D.gravity = new Vector2(-100f, 0);
				rotaA=true;
				rotaD=false;
				rotaS=false;
				animator.SetBool("mysteryA",true);
				animator.SetBool("mysteryD",false);
				animator.SetBool("isJump",false);
				
				
			}
			if(Input.GetKey(KeyCode.S))
			{
				if(!rotaS)
				{
					musictrig=true;
					yeetmystery.Pause();
					mT.uUnPause();  
					
				}
				Physics2D.gravity = new Vector2(0, -9.8f);
				rotaA=false;
				rotaD=false;
				rotaS=true;
				animator.SetBool("mysteryD",false);
				animator.SetBool("mysteryA",false);
				animator.SetBool("isJump",true);
				controller.m_Rigidbody2D.velocity = Vector2.zero;
			
			
			}
			if(Input.GetKey(KeyCode.D))
			{
				if(!rotaD)
				{
					if(musicnew)
					{
						mT.pPause();
						yeetmystery.Play();
						musicnew=false;
					}
					else if (musictrig)
					{
						mT.pPause();
						yeetmystery.UnPause();
					}
				}
				animator.SetBool("mysteryD",true);
				animator.SetBool("mysteryA",false);
				animator.SetBool("isJump",false);
				controller.m_Rigidbody2D.velocity = Vector2.zero;
				Physics2D.gravity = new Vector2(100f, 0);
				sr.sprite = mysticRed;
				rotaA=false;
				rotaS=false;
				rotaD=true;
				
			
			}
	   
		}	
	  
    }
	
	void FixedUpdate()
	{
		if(!dashaction&&!dashactiondelay)
		{
			controller.Move(hmove * Time.fixedDeltaTime, false, jump);
		}
		else
		{
			dashaction = false;
			controller.Move(hmove * Time.fixedDeltaTime*5, false, false);
				movementdirection = hmove;
				
			dashtimerswitch=true;
			
			
		}	
		jump=false;
		if(dashtimerswitch)
		{
			dashtimer--;
		}
		if (hmove!=movementdirection && dashtimerswitch)
		{
			dashtimer=0;
		}
		
		if(dashtimer==0)
		{
			controller.m_Rigidbody2D.velocity = Vector2.zero;
			controller.Move(hmove * Time.fixedDeltaTime, false, false);
			dashtimer=20;
			dashtimerswitch=false;
			animator.SetBool("isAirdash", false);
			animator.SetBool("IsJumping", true);
			airdash=false;
			dashactiondelay = false;
		}
		if((rotaA||rotaD)&&(velocity.x>6))
		{	
		
			
				controller.m_Rigidbody2D.velocity = Vector2.zero;
		}
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
		dashaction = false;
		dashswitch = true;
	}
	
	public void ChangeItem(string itemType)
	{
        switch(itemType)
		{
			case "fight enabler":
				fighting = true;
				doubleJump = false;
				dash = false;
				gravity = false;
				invinc = false;
				canWin = false;
				break;
			case "jump enabler":
				doubleJump = true;
				fighting = false;
				dash = false;
				gravity = false;
				invinc = false;
				canWin = false;
				break;
			case "dash enabler":
				doubleJump = false;
				fighting = false;
				dash = true;
				gravity = false;
				invinc = false;
				canWin = false;
				break;
			case "gravity enabler":
				doubleJump = false;
				fighting = false;
				dash = false;
				gravity = true;
				invinc = false;
				canWin = false;
				break;
			case "invincibility enabler":
				doubleJump = false;
				fighting = false;
				dash = false;
				gravity = false;
				invinc = true;
				canWin = false;
				break;
			case "victory enabler":
				doubleJump = false;
				fighting = false;
				dash = false;
				gravity = false;
				invinc = false;
				canWin = true;
				break;
			default:
				doubleJump = false;
				fighting = false;
				dash = false;
				gravity = false;
				invinc = false;
				canWin = false;
				break;
		}
	}
}
