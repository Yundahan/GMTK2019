using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayMessage : MonoBehaviour
{
	public Image image;
	public Image image2;
	public Text r;
	
	public Text startText;
	public Text swordText;
	public Text jumpText;
	public Text dashText;
	
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
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.R))
		{
			image.enabled = false;
			image2.enabled = false;
			r.enabled = false;
			startText.enabled = false;
		
			swordText.enabled = false;
			jumpText.enabled = false;
			dashText.enabled = false;
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
}