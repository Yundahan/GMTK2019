using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCrate : MonoBehaviour
{
	public GameObject player;
	
	float directionCheckRadius = 0.4f;
	
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
		if(GameObject.ReferenceEquals(col.gameObject, player) && Physics2D.OverlapCircle(transform.position + new Vector3(0, 0.5f, 0), directionCheckRadius))
		{
			Destroy(gameObject);
		}
	}
}
