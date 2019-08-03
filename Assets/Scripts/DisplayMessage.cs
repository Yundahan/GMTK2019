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
	public Text deathText;
	
    // Start is called before the first frame update
    void Start()
    {
        image.enabled = true;
		image2.enabled = true;
		r.enabled = true;
		startText.enabled = true;
		
		swordText.enabled = false;
		jumpText.enabled = false;
		dashText.enabled = false;
		gravityText.enabled = false;
		deathText.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.R))
		{
			if(deathText.enabled)
			{
				Scene thisScene = SceneManager.GetActiveScene();
				SceneManager.LoadScene(thisScene.name);
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
	
	void DeathMessage()
	{
		image.enabled = true;
		image2.enabled = true;
		r.enabled = true;
		
		deathText.enabled = true;
	}
}