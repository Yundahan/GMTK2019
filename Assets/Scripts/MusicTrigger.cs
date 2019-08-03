using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicTrigger : MonoBehaviour
{
	public GameObject player;
	public AudioSource yeetchill;
    public AudioSource yeetnervous;
	
    // Start is called before the first frame update
    void Start()
    {
		yeetnervous.Play();
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
			}
			else{
				yeetnervous.Stop();
				yeetchill.Play();
			}
		}
	}
}
