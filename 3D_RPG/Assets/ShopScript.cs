using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ShopScript : MonoBehaviour {

	public GameObject GameHandler;
	public GameHandler gHandle;
	
	public GameObject Sword1, Sword2, Sword3, Sword4,
					  Armour1, Armour2, Armour3,
					  Shield1, Shield2,
					  Text1, Text2;

	int wrank, arank, srank, gold;
	int whichup, boost, price = 0;
	// Use this for initialization
	void Start () {
		GameHandler = GameObject.Find("GameHandler");
		gHandle = GameHandler.GetComponent<GameHandler>();
	}
	
	// Update is called once per frame
	void Update () {
		wrank = gHandle.PlayerAttributes[7];
		arank = gHandle.PlayerAttributes[8];
		srank = gHandle.PlayerAttributes[9];
		
		gold = gHandle.PlayerAttributes[6];
		
		switch (wrank)
		{
			case 4:
				Sword4.GetComponent<Button>().interactable = false;
				goto case 3;
			case 3:
				Sword3.GetComponent<Button>().interactable = false;
				goto case 2;
			case 2:
				Sword2.GetComponent<Button>().interactable = false;
				goto case 1;
			case 1:
				Sword1.GetComponent<Button>().interactable = false;
				goto default;
			default:
				break;
		}
		
		switch (arank)
		{
		case 3:
			Armour3.GetComponent<Button>().interactable = false;
			goto case 2;
		case 2:
			Armour2.GetComponent<Button>().interactable = false;
			goto case 1;
		case 1:
			Armour1.GetComponent<Button>().interactable = false;
			goto default;
		default:
			break;
		}
		
		switch (srank)
		{
		case 2:
			Shield2.GetComponent<Button>().interactable = false;
			goto case 1;
		case 1:
			Shield1.GetComponent<Button>().interactable = false;
			goto default;
		default:
			break;
		}
		
		updateValues();
	}
	
	public void updateValues()
	{
		gHandle.PlayerAttributes[7] = wrank;
		gHandle.PlayerAttributes[8] = arank;
		gHandle.PlayerAttributes[9] = srank;
		
		gHandle.PlayerAttributes[6] = gold;
	}
	
	public void Sword1_Press()
	{
		Text1.GetComponent<Text>().text = "10 Gold";
		price = 10;
		Text2.GetComponent<Text>().text = "+1 STR";
		whichup = 1;
		boost = 1;
	}
	public void Sword2_Press()
	{
		Text1.GetComponent<Text>().text = "20 Gold";
		price = 20;
		Text2.GetComponent<Text>().text = "+2 STR";
		whichup = 1;
		boost = 2;
	}
	public void Sword3_Press()
	{
		Text1.GetComponent<Text>().text = "30 Gold";
		price = 30;
		Text2.GetComponent<Text>().text = "+3 STR";
		whichup = 1;
		boost = 3;
	}
	public void Sword4_Press()
	{
		Text1.GetComponent<Text>().text = "40 Gold";
		price = 40;
		Text2.GetComponent<Text>().text = "+4 STR";
		whichup = 1;
		boost = 4;
	}
	
	public void Armour1_Press()
	{
		Text1.GetComponent<Text>().text = "10 Gold";
		price = 10;
		Text2.GetComponent<Text>().text = "+1 DEF";
		whichup = 2;
		boost = 1;
	}
	public void Armour2_Press()
	{
		Text1.GetComponent<Text>().text = "20 Gold";
		price = 20;
		Text2.GetComponent<Text>().text = "+2 DEF";
		whichup = 2;
		boost = 2;
	}
	public void Armour3_Press()
	{
		Text1.GetComponent<Text>().text = "30 Gold";
		price = 30;
		Text2.GetComponent<Text>().text = "+3 DEF";
		whichup = 2;
		boost = 3;
	}
	
	public void Shield1_Press()
	{
		Text1.GetComponent<Text>().text = "10 Gold";
		price = 10;
		Text2.GetComponent<Text>().text = "+1 DEF";
		whichup = 3;
		boost = 1;
	}
	public void Shield2_Press()
	{
		Text1.GetComponent<Text>().text = "20 Gold";
		price = 20;
		Text2.GetComponent<Text>().text = "+2 DEF";
		whichup = 3;
		boost = 2;
	}
	
	public void Purchase()
	{
		if (gold >= price)
		{
			gold -= price;
			switch (whichup)
			{
				case 1:
					wrank = boost;
					break;
				case 2:
					arank = boost;
					break;
				case 3:
					srank = boost;
					break;
			}
		} else {
			Text1.GetComponent<Text>().text = "Insufficient funds!";
			Text2.GetComponent<Text>().text = "";
		}
		updateValues();
		price = 0; whichup = 0; boost = 0;
	}
	public void QuitStore()
	{
		Application.LoadLevel("worldmap");
	}
	
}
