using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayMessage : MonoBehaviour
{
	public Image image;
	
	public Text swordText;
	
    // Start is called before the first frame update
    void Start()
    {
        image.enabled = false;
		swordText.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Space))
		{
			image.enabled = false;
			swordText.enabled = false;
		}
    }
	
	void SwordMessage()
	{
		image.enabled = true;
		swordText.enabled = true;
	}
}