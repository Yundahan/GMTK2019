using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DisplayMessage : MonoBehaviour
{
	public Image image;
	public Image image2;
	public Text r;
	
	public Text startText;
	public Text swordText;
	public Text jumpText;
	public Text dashText;
	public Text gravityText;
	public Text invincText;
	public Text victoryText;
	public Text deathText;
	public Text levelText;
	public Text level2Text;
	private string yeetusleveleetus;
	
	int level = 1;
	
	private float victorytime=2000000f;
	private float victorytimecontrol;
	public bool victoryswitch=false;
	private bool victoryswitch2=true;
	public bool victoryswitch3=false;
	public bool victoryswitch4=false;
	public GameObject player;
	public bool teleport=false;
	public MusicTrigger mT;
	public Movement move;
	public AudioSource doorlock;
	public MusicTriggerTemple mTT;
	public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
		if(System.IO.File.ReadAllText(@"C:\Users\Public\AppData\Local\temp\level.txt")=="2")
		{	
			level = 2;
        }
		else
		{
			level =1;
		}
        image.enabled = true;
		image2.enabled = true;
		r.enabled = true;
		startText.enabled = true;
		
		swordText.enabled = false;
		jumpText.enabled = false;
		dashText.enabled = false;
		gravityText.enabled = false;
		deathText.enabled = false;
		invincText.enabled = false;
		victoryText.enabled = false;
		levelText.enabled = false;
		level2Text.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
		if(victoryswitch&&victoryswitch2)
		{
			move.StopAllMovement();
			victorytime=Time.time+5.5f;
			victoryswitch = false;
			victoryswitch2 = false;
			

		}
		victorytimecontrol=Time.time;
		if(victorytimecontrol>=(victorytime-0.85f)&&victoryswitch4)
		{
			doorlock.Play();
			victoryswitch4 = false;
		}
		if(victorytimecontrol>=victorytime&&victoryswitch3)
		{
	
			
			image.enabled = false;
			if(mT.iamtheone)
			{
				levelText.enabled = false;
				mT.uUnPause();
			}
			else
			{
				level2Text.enabled = false;
				
				mT.yeetchill.Play();
				
			}
			teleport=true;
			victoryswitch3=false;
			if(mT.iamtheone)
			{
			player.transform.position = new Vector3(401, 23.7f, 0);
			level=2;
			move.ResumeAllMovement();
			}
			else
			{
			level=1;
			mT.iamtheone=true;
			player.transform.position = new Vector3(-14, 6.7f, 0);
			animator.SetBool("EndofGame",true);
			}
			
			
		}
        if(Input.GetKey(KeyCode.R))
		{
			if(deathText.enabled)
			{
				resetOnDeath();
			}
			
			image.enabled = false;
			image2.enabled = false;
			r.enabled = false;
			startText.enabled = false;
		
			swordText.enabled = false;
			jumpText.enabled = false;
			dashText.enabled = false;
			gravityText.enabled = false;
			deathText.enabled = false;
			invincText.enabled = false;
			victoryText.enabled = false;
		}
    }
	
	void SwordMessage()
	{
		image.enabled = true;
		image2.enabled = true;
		r.enabled = true;
		
		swordText.enabled = true;
	}
	
	void JumpMessage()
	{
		image.enabled = true;
		image2.enabled = true;
		r.enabled = true;
		
		jumpText.enabled = true;
	}
	
	void DashMessage()
	{
		image.enabled = true;
		image2.enabled = true;
		r.enabled = true;
		
		dashText.enabled = true;
	}
	
	void GravityMessage()
	{
		image.enabled = true;
		image2.enabled = true;
		r.enabled = true;
		
		gravityText.enabled = true;
	}
	
	void InvincibilityMessage()
	{
		image.enabled = true;
		image2.enabled = true;
		r.enabled = true;
		
		invincText.enabled = true;
	}
	
	void VictoryMessage()
	{
		image.enabled = true;
		image2.enabled = true;
		r.enabled = true;
		
		victoryText.enabled = true;
	}
	
	void DeathMessage()
	{
		image.enabled = true;
		image2.enabled = true;
		r.enabled = true;
		
		deathText.enabled = true;
	}
	
	void LevelMessage()
	{
		image.enabled = true;
		levelText.enabled = true;
	}
	void Level2Message()
	{
		image.enabled = true;
		level2Text.enabled = true;
	}
	
	public void resetOnDeath(){
		Scene thisScene = SceneManager.GetActiveScene();
		switch(level)
		{
			case 1:
				yeetusleveleetus ="1";
				System.IO.File.WriteAllText(@"C:\Users\Public\AppData\Local\temp\level.txt", yeetusleveleetus);
				SceneManager.LoadScene(thisScene.name);
				player.transform.position = new Vector3(-8, 0.7f, 0);
				break;
			case 2:
				yeetusleveleetus ="2";
				System.IO.File.WriteAllText(@"C:\Users\Public\AppData\Local\temp\level.txt", yeetusleveleetus);
				SceneManager.LoadScene(thisScene.name);
				player.transform.position = new Vector3(401, 23.7f, 0);
				break;
			default:
				yeetusleveleetus ="1";
				System.IO.File.WriteAllText(@"C:\Users\Public\AppData\Local\temp\level.txt", yeetusleveleetus);
				SceneManager.LoadScene(thisScene.name);
				player.transform.position = new Vector3(-8, 0.7f, 0);
				break;
		}
	}
}