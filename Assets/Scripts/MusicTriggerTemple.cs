using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicTriggerTemple : MonoBehaviour
{
	public GameObject player;
	public AudioSource yeetchill;
    public AudioSource mysteryI;
	public AudioSource mysteryT;
	public AudioSource Glasorgel;
	private bool chill = false;
	private bool mysterytrue = false;
	private bool isWasPlaying = false;
	public MusicTrigger mT;
	public Movement move;
	
	
    // Start is called before the first frame update
    void Start()
    {
	
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	
	void OnTriggerExit2D(Collider2D col)
	{
		if(move.ibility)
		{
			move.yeetinvinc.Stop();	
		}
		if(mT.iamtheone)
		{
			mT.yeetchill.Stop();

			mT.iamtheone=false;
		}
		if(GameObject.ReferenceEquals(col.gameObject, player))
		{
			if(player.transform.position.x > transform.position.x)
			{
				yeetchill.Stop();
				if(!mysterytrue)
				{
					isWasPlaying = true;
					Glasorgel.PlayDelayed(0);
					mysteryT.PlayDelayed(0);
					mysteryI.PlayDelayed(0);
					mysteryT.volume=0.5f;
					mysteryI.volume=0;
					
				}
				else 
				{
					isWasPlaying = false;
				}
				
				chill=true;
			}
			else
			{
				mysteryT.Stop();
				mysteryI.Stop();
				Glasorgel.Stop();
				mysteryT.volume=0.5f;
				mysteryI.volume=0.5f;
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
	
	
	public void ShutUp()
	{	
		
		yeetchill.Stop();
		mysteryT.Stop();
		mysteryI.Stop();
		Glasorgel.Stop();
		mysteryT.volume=1;
		mysteryI.volume=1;

	}
	
}

	

