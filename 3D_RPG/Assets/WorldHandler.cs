using UnityEngine;
using System.Collections;

public class WorldHandler : MonoBehaviour {

	public GameObject GameHandler;
	public GameHandler gHandle;
	
	
	// Use this for initialization
	void Start () {
		GameHandler = GameObject.Find("GameHandler");
		gHandle = GameHandler.GetComponent<GameHandler>();
	} 
	
	// Update is called once per frame
	void Update () {
	}
	
	//WORLD MAP BUTTONS
	public void ShopButton()
	{
		//go to shop screen
		Application.LoadLevel("shop");
	}
	
	public void SaveButton()
	{
	}
	
	public void HealButton()
	{
		gHandle.HealButton();
	}
	
	public void TravelButton()
	{
		Application.LoadLevel("forest2d");
	}
	
	public void Save(string filename)
	{
	}
}
