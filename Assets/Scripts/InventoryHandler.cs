using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryHandler : MonoBehaviour
{
	string currItem = "";
	
	public GameObject DisplayMessage;
	
	public Image image;
	
	public Sprite sword;
	
	public bool swordMessage = false;
	
    // Start is called before the first frame update
    void Start()
    {
        image.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        switch(currItem)
		{
			case "sword":
				image.sprite = sword;
				float desiredScale = 0.4f;
				transform.localScale = new Vector3(desiredScale, desiredScale, desiredScale);
				break;
			default:
				image.sprite = null;
				break;
		}
    }
	
	void ChangeItem(string itemType)
	{
		image.enabled = true;
		currItem = itemType;
		
		switch(currItem)
		{
			case "sword":
				if(!swordMessage)
				{
					DisplayMessage.SendMessage("SwordMessage");
				}
				break;
			default:
				break;
		}
	}
}