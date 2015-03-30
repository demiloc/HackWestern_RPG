using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TravelScript : MonoBehaviour {

	public GameObject GameHandler;
	public GameHandler gHandle;
	
	public GameObject player;
	public Text LvlNum, GoldNum, ExpNum;
	public GameObject nArr, sArr, wArr, eArr;
	public Image HPBar, MPBar;
	
	public Image EHPBar, EMPBar;
	
	public int lvl, hp, mp, str, def, exp, gold;
	
	public int enemyHP;
	public int enemyMP;
	public int enemySTR;
	public int enemyDEF;
	public int enemyEXP;
	public int enemyGOLD;
	

	// Use this for initialization
	void Start () {
		GameHandler = GameObject.Find("GameHandler");
		gHandle = GameHandler.GetComponent<GameHandler>();
		
		InitValues();
		
		if (lvl > 2)
		{
			enemyHP = 20*2;
			enemyMP = 10*2;
			enemySTR = 2*2;
			enemyDEF = 1*2;
			enemyEXP = 10*2;
			enemyGOLD = 10*2;
		} else {
			enemyHP = 20;
			enemyMP = 10;
			enemySTR = 2;
			enemyDEF = 1;
			enemyEXP = 10;
			enemyGOLD = 10;
		}
	}
	
	// Update is called once per frame
	void Update () {
		/*if (nArr.GetComponent<Button>().onClick)
		{
			float adjustedDir = player.GetComponent<Image>().transform.position.y;
			player.GetComponent<Image>().transform.position = new Vector3 (player.GetComponent<Image>().transform.position.x,adjustedDir-=32, 0);
		}
		if (sArr.GetComponent<Button>().onClick)
		{
			float adjustedDir = player.GetComponent<Image>().transform.position.y;
			player.GetComponent<Image>().transform.position.Set(player.GetComponent<Image>().transform.position.x,adjustedDir += 32, 0);
		}
		if (wArr.GetComponent<Button>().onClick)
		{
			float adjustedDir = player.GetComponent<Image>().transform.position.x;
			player.GetComponent<Image>().transform.position.Set(adjustedDir += 32, player.GetComponent<Image>().transform.position.y, 0);
		}
		if (eArr.GetComponent<Button>().onClick)
		{
			float adjustedDir = player.GetComponent<Image>().transform.position.x;
			player.GetComponent<Image>().transform.position.Set(adjustedDir -= 32, player.GetComponent<Image>().transform.position.y, 0);
		}*/
		
		HPBar.fillAmount = (hp / (lvl*10.0f));
		MPBar.fillAmount = (mp / (lvl*5.0f));
		LvlNum.text = ""+lvl;
		GoldNum.text = ""+gold;
		ExpNum.text = ""+exp;
		
		EHPBar.fillAmount = (enemyHP / 20.0f);
		EMPBar.fillAmount = (enemyMP / 10.0f);
		
		if (enemyHP <= 0)
		{
			gold += enemyGOLD;
			exp += enemyEXP;
		}
		
		if (hp <= 0)
		{
			gold -= enemyGOLD;
			if (gold < 0)
			{
				gold = 0;
			}
			exp -= enemyEXP;
			if (exp < 0)
			{
				exp = 0;
			}
		}
		
		UpdateValues();
		
		if (enemyHP <= 0 || hp <= 0)
		{
			if (hp <= 0)
				hp = lvl*10/2;
			Application.LoadLevel ("worldmap");
		}
	}
	
	public void InitValues()
	{
		lvl = gHandle.PlayerAttributes[0];
		hp = gHandle.PlayerAttributes[1];
		mp = gHandle.PlayerAttributes[2];
		str = gHandle.PlayerAttributes[3] + gHandle.PlayerAttributes[7];
		def = gHandle.PlayerAttributes[4];
		exp = gHandle.PlayerAttributes[5];
		gold = gHandle.PlayerAttributes[6];
	}
	
	public void UpdateValues()
	{
		gHandle.PlayerAttributes[0] = lvl;
		gHandle.PlayerAttributes[1] = hp;
		gHandle.PlayerAttributes[2] = mp;
		gHandle.PlayerAttributes[3] = str;
		gHandle.PlayerAttributes[4] = def;
		gHandle.PlayerAttributes[5] = exp;
		gHandle.PlayerAttributes[6] = gold;
	}
	
	/*public void MoveNorth()
	{
		float adjustedDir = player.GetComponent<Image>().transform.position.y;
		player.GetComponent<Image>().transform.position = new Vector3 (player.GetComponent<Image>().transform.position.x,adjustedDir + 64, 0);
		//player.GetComponent<Image>().transform.localScale = new Vector3 (3,3,0);
	}
	public void MoveSouth()
	{
		float adjustedDir = player.GetComponent<Image>().transform.position.y;
		player.GetComponent<Image>().transform.position = new Vector3 (player.GetComponent<Image>().transform.position.x,adjustedDir - 64, 0);
		//player.GetComponent<Image>().transform.localScale = new Vector3 (3,3,0);
	}
	public void MoveWest()
	{
		float adjustedDir = player.GetComponent<Image>().transform.position.x;
		player.GetComponent<Image>().transform.position = new Vector3 (adjustedDir + 64, player.GetComponent<Image>().transform.position.y, 0);
		//player.GetComponent<Image>().transform.localScale = new Vector3 (3,3,0);
	}
	public void MoveEast()
	{
		float adjustedDir = player.GetComponent<Image>().transform.position.x;
		player.GetComponent<Image>().transform.position = new Vector3 (adjustedDir - 64, player.GetComponent<Image>().transform.position.y, 0);
		//player.GetComponent<Image>().transform.localScale = new Vector3 (3,3,0);
	}*/
	
	public void attack()
	{
		enemyHP -= str;
		if (enemyHP > 0)
		{
			hp -= Mathf.Max(enemySTR-def, 0);
		}
		UpdateValues();
	}
	
	public void flee()
	{
		UpdateValues();
		Application.LoadLevel("worldmap");
	}
	
	public void defend()
	{
		if (enemyHP > 0)
		{
			hp -= enemySTR/2;
		}
		UpdateValues();
	}
	
	public void heal()
	{
		if (mp > 0)
		{
			mp -= 3;
			hp = 10*lvl;
		}
		if (enemyHP > 0)
		{
			hp -= enemySTR;
		}
		UpdateValues();
	}
}
