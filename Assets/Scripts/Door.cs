﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
	public GameObject player;
	
	
	public Movement move;

	public AudioSource yeetvictoreh;
	public MusicTrigger mT;
	public DisplayMessage dM;
	public MusicTriggerTemple mTT;
	

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
	
	void OnTriggerEnter2D(Collider2D col)
	{
		if(GameObject.ReferenceEquals(col.gameObject, player) && move.canWin)
		{
			
			dM.victoryswitch = true;
			dM.victoryswitch3=true;
			dM.victoryswitch4=true;
			if(mT.iamtheone)
			{
				mT.pPause();
				dM.SendMessage("LevelMessage");
			}
			else
			{
				mTT.Glasorgel.Stop();
				mTT.mysteryT.Stop();
				mTT.mysteryI.Stop();
				dM.SendMessage("Level2Message");
				
			}
			yeetvictoreh.Play();

			
			
		}
	}
}
