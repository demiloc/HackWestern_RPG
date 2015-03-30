using UnityEngine;
using System.Collections;
using System.Text;
using System.IO;

public class GameHandler : MonoBehaviour {

	static int LINES_IN_FILE = 10;
	static string FILE_NAME = "savefile.txt";

	public int[] PlayerAttributes = new int [10] {1, 10, 5, 1, 1, 0, 0,1,0,0};  //Level, Health, Mana, Strength, Defense, EXP, Gold, Weapon Rank, Armour Rank, Shield Rank
	
	void Awake()
	{
		DontDestroyOnLoad(this);
	}
	
	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		PlayerAttributes[3] = PlayerAttributes[0] + PlayerAttributes[7];
		PlayerAttributes[4] = PlayerAttributes[0] + PlayerAttributes[8] + PlayerAttributes[9];
		LevelUp();
	}
	
	//START SCREEN BUTTONS
	public void NewGameButton()
	{
		//open the world map screen
		Application.LoadLevel("worldmap");
	}
	public void ContinueButton()
	{
		if (Load(FILE_NAME))
		{
			//open the world map screen
			Application.LoadLevel("worldmap");
		}
	}
	public void OptionsButton()
	{
		//do nothing atm
	}
	public void QuitButton()
	{
		//end game
		Application.Quit();
	}
	
	private bool Load(string fileName)
	{
		try
		{
			string line;
			StreamReader filereader = new StreamReader(fileName, Encoding.Default);
			using (filereader)
			{
				int i = 0;
				int placeholder = 0;
				do
				{
					line = filereader.ReadLine();
					if (line != null)
					{
						int.TryParse(line, out placeholder);
						PlayerAttributes[i] = placeholder;
					}
					i++;
				}while (line != null);
				filereader.Close();
				return true;
			}
		}
		catch(IOException e)
		{
			Debug.Log("{0}\n"+e.Message);
			return false;
		}
	}
	
	public void HealButton()
	{
		if (PlayerAttributes[6] >= PlayerAttributes[0]*5 && PlayerAttributes[1] < PlayerAttributes[0]*10)
		{
			//lose Lvl*5 gold
			PlayerAttributes[6] -= PlayerAttributes[0]*5;
			//heal to make hp (Lvl*10)
			PlayerAttributes[1] = PlayerAttributes[0]*10;
			PlayerAttributes[2] = PlayerAttributes[0]*5;
		}
	}
	
	public void LevelUp()
	{
		if (PlayerAttributes[5] >= 100 && PlayerAttributes[0] < 10)
		{
			PlayerAttributes[5] -= 100;
			PlayerAttributes[0] += 1;
			
			PlayerAttributes[1] += 10;
			PlayerAttributes[2] += 5;
		}
	}
}
