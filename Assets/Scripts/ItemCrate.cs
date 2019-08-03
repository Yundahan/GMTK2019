using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCrate : MonoBehaviour
{
	public GameObject player;
	
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	
	void OnCollisionEnter2D(Collision2D col)
	{
		if(GameObject.ReferenceEquals(col.gameObject, player) && player.transform.position.y - transform.position.y >= 1.3f)
		{
			Destroy(gameObject);
		}
	}
}
