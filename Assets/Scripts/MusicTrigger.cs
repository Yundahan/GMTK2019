using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicTrigger : MonoBehaviour
{
	public GameObject player;
	public AudioSource yeetchill;
    public AudioSource yeetnervous;
	private bool chill = false;
	private bool mysterytrue = false;
	private bool isWasPlaying = false;
	
    // Start is called before the first frame update
    void Start()
    {
		yeetchill.Play();
		chill=false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	
	void OnTriggerExit2D(Collider2D col)
	{
		if(GameObject.ReferenceEquals(col.gameObject, player))
		{
			if(player.transform.position.x > transform.position.x)
			{
				yeetchill.Stop();
				if(!mysterytrue)
				{
					isWasPlaying = true;
					yeetnervous.Play();
				}
				else 
				{
					isWasPlaying = false;
				}
				
				chill=true;
			}
			else
			{
				yeetnervous.Stop();
				if(!mysterytrue)
				{
					isWasPlaying = true;
					yeetchill.Play();
				}
				else 
				{
					isWasPlaying = false;
				}
				
				chill=false;
			}
		}
	}
	
	void resume()
	{
		if(player.transform.position.x > transform.position.x)
		{
			yeetchill.Stop();
			if(!mysterytrue)
			{
				isWasPlaying = true;
				yeetnervous.Play();
			}	
			else 
			{
				isWasPlaying = false;
			}
			
			chill=true;
		}
		else
		{
			yeetnervous.Stop();
			if(!mysterytrue)
			{
				isWasPlaying = true;
				yeetchill.Play();
			}
			else 
			{
				isWasPlaying = false;
			}
			
			chill=false;
		}
	}
	
	public void ShutUp()
	{	
		
		yeetchill.Stop();
		yeetnervous.Stop();
	}
	
	public char ShutUpAndDrive()
	{
		if(chill)
		{
			
			return 'c';
		}
		else
		{
		
			
			return 'n';
		}
	}	
	public void pPause()
	{
	
		if(chill)
		{
			yeetnervous.Pause();
			mysterytrue = true;
			
			
		}
		else
		{
			mysterytrue = true;
			yeetchill.Pause();
		
		}

	}

	public void uUnPause()
	{	
	
		if(chill)
		{
			mysterytrue = false;
			if(isWasPlaying)
			{
				yeetnervous.UnPause();
			
			}
			else
			{
				yeetnervous.Play();
			}
		}
		else
		{
			mysterytrue = false;
			if(isWasPlaying)
			{
				yeetchill.UnPause();
			}
			else
			{
				yeetchill.Play();
			}
		
		}
	}		
}

	

