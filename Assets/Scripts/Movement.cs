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
	public bool rotaA,rotaD,rotaS = false;
	Vector2 velocity;
	bool musictrig = true;
	bool musicnew = true;
	char musictype = 'c';
	public AudioSource yeetmystery;
	public AudioSource yeetinvinc;
	public AudioSource yeetyouded;
	public AudioSource yeetdeadandsad;
	public AudioSource landing;
	public AudioSource dashA;
	public AudioSource dashN;
	public AudioSource Glasorgel;
	public AudioSource mysteryT;
	public AudioSource mysteryI;
	public MusicTrigger mT;
	public Vector2 antiVelocity = new Vector2(0, 50f);
	private bool mainSwitch = true;
	public bool ibility = false;
	private float ibilityTimer = 0;
	private float ibilityCompare = 0;
	private bool ibilityreset= false;
	public bool ded;
	private bool deadswitch=true;
	private bool deadswitch2=true;
	public float deathtimer;
	public float deathtimercontrol;
	public MusicTriggerTemple mTT;
	public bool Temple = false;
	public float TempleVolume =0.5f;
	public float GravityVolume =0f;
	public bool GravityM=false;
	
    // Start is called before the first frame update
    void Start()
    {
		
    }

    // Update is called once per frame
    void Update()
	
    {
		if(ded)
		{
			deathtimer=Time.time;
			if(deadswitch)
			{
				Physics2D.gravity = new Vector2(0, -9.8f);
				controller.m_Rigidbody2D.velocity = Vector2.zero;
				StopAllMovement();
				if(rotaA||rotaD||rotaS)
				{
					mTT.Glasorgel.Stop();
					mTT.mysteryT.Stop();
					mTT.mysteryI.Stop();
				}
				else
				{
				mT.ShutUp();
				}
				
				deathtimercontrol=Time.time+11.5f;
				yeetyouded.Play();
				deadswitch=false;
			}
			else if(deathtimer >=deathtimercontrol&&deadswitch2)
			{
				deadswitch2=false;
				yeetdeadandsad.Play();
			}
		}
		if(mainSwitch)
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
					dashA.Play();
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
				dashN.Play();
				airdash = true;
				dashactiondelay = true;
				
			}
			 
			if (gravity)
			{
				if(Input.GetKey(KeyCode.A))
				{	
					if(!rotaA)
					{	
						GravityM=true;
						Temple=false;
					}
					controller.m_Rigidbody2D.velocity = Vector2.zero;
					Physics2D.gravity = new Vector2(-50f, 0);
					rotaA=true;
					rotaD=false;
					rotaS=false;
					animator.SetBool("mysteryA",true);
					animator.SetBool("mysteryD",false);
					animator.SetBool("IsJumping",false);
					
					
				}
				if(Input.GetKey(KeyCode.S))
				{
					if(!rotaS)
					{
						GravityM=false;
						Temple=true;
						
					}
					Physics2D.gravity = new Vector2(0, -9.8f);
					rotaA=false;
					rotaD=false;
					rotaS=true;
					animator.SetBool("mysteryD",false);
					animator.SetBool("mysteryA",false);
					animator.SetBool("IsJumping",true);
					controller.m_Rigidbody2D.velocity = Vector2.zero;
				
				
				}
				if(Input.GetKey(KeyCode.D))
				{
					if(!rotaD)
					{	
						GravityM=true;
						Temple=false;
					}
					animator.SetBool("mysteryD",true);
					animator.SetBool("mysteryA",false);
					animator.SetBool("IsJumping",false);
					controller.m_Rigidbody2D.velocity = Vector2.zero;
					Physics2D.gravity = new Vector2(50f, 0);
					sr.sprite = mysticRed;
					rotaA=false;
					rotaS=false;
					rotaD=true;
					
				
				}
		   
			}
			if(invinc)
			{
				if(Input.GetKey(KeyCode.W)&&!ibilityreset&&!ibility)
				{
					
					ibilityTimer = Time.time+10.6f;
					ibility=true;
					Debug.Log("invincible!");
					mT.pPause();
					yeetinvinc.Play();
					
				}
				if(ibility)
				{
					ibilityCompare = Time.time;
					if(ibilityCompare >= ibilityTimer)
					{
						ibilityreset = true;
						ibility = false;
						ibilityTimer = Time.time+25;
						Debug.Log("invincibleCooldown");
						mT.uUnPause();
					}
				}
				if(ibilityreset)
				{
					ibilityCompare=Time.time;
					if(ibilityCompare >= ibilityTimer)
					{
						
						ibilityreset = false;
						Debug.Log("invincibleCooldownEnd");	
					}
				}
			}	
		}
    }
	
	void FixedUpdate()
	{	
		if(mainSwitch)
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
			if((rotaA||rotaD)&&(velocity.y>2))
			{	
				if(rotaA)
				{
					Physics2D.gravity = new Vector2(-100f, -9.8f);
				}
				else
				{
					Physics2D.gravity = new Vector2(100f, -9.8f);
				}	
					
			}
		}
		if(Temple&&TempleVolume<0.5f)
		
		{
			TempleVolume =TempleVolume+0.05f;
			GravityVolume=GravityVolume-0.05f;
			mTT.mysteryI.volume=GravityVolume;
			mTT.mysteryT.volume=TempleVolume;	
		}
		if(GravityM&&GravityVolume<0.5f)
		
		{
			TempleVolume =TempleVolume-0.05f;
			GravityVolume=GravityVolume+0.05f;
			mTT.mysteryI.volume=GravityVolume;
			mTT.mysteryT.volume=TempleVolume;	
		}
		
	}
	public void OnLanding()
	{
		if (animator.GetBool("IsJumping"))
		{
			landing.Play();
		}
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
	public void StopAllMovement()
	{
		controller.m_Rigidbody2D.velocity = Vector2.zero;
		mainSwitch = false;
		
	}
	
	public void ResumeAllMovement()
	{	
		mainSwitch = true;
	}
}
