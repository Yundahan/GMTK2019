using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicTrigger : MonoBehaviour
{
	public GameObject player;
	public AudioSource yeetchill;
    public AudioSource yeetnervous;
	private bool chill = false;
	
	
    // Start is called before the first frame update
    void Start()
    {
		yeetnervous.Play();
		chill=true;
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
				yeetnervous.Play();
				chill=false;
			}
			else{
				yeetnervous.Stop();
				yeetchill.Play();
				chill=true;
			}
		}
	}
	
	void resume()
	{
		if(player.transform.position.x > transform.position.x)
		{
			yeetchill.Stop();
			yeetnervous.Play();
			chill=false;
		}
		else{
			yeetnervous.Stop();
			yeetchill.Play();
			chill=true;
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
			
			Debug.Log("ich sollte gechillt pausiert sein");
			
		}
		else
		{
			yeetchill.Pause();
		Debug.Log("ich sollte nervös pausiert sein");
		}

	}

	public void uUnPause()
	{	
	
		if(chill)
		{
			
			yeetnervous.UnPause();
		}
		else
		{
			yeetchill.UnPause();
		
		}
	}		
}

	

