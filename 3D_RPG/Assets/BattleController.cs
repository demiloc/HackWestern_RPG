using UnityEngine;
using System.Collections;

public class BattleController : MonoBehaviour {
	
	//can user click a button for an action, true = yes, fales = no
	bool ActionInput;
	enum BattleState
	{
		Nothing = 0,
		Attack = 1,
		Recover = 2,
		Defend = 3,
		Heavy = 4
	}
	private BattleState CombatState;

	// Use this for initialization
	void Start () 
	{
		ActionInput = true;
		CombatState = 0;
	}
	
	// Update is called once per frame
	void Update ()
	 {
		if (ActionInput)
		{
			if (CombatState == BattleState.Attack)
			{
				ActionInput = false;
				//call enemy damaged function
				//retrieve enemy action
				//perform relevant function call
				CombatState = BattleState.Nothing;
				ActionInput = true;
			}
			
			if (CombatState == BattleState.Heavy)
			{
				ActionInput = false;
				//call enemy heavy damaged function
				//retrieve enemy action
				//perform relevant function call
				CombatState = BattleState.Nothing;
				ActionInput = true;
			}
			
			if (CombatState == BattleState.Recover)
			{
				ActionInput = false;
				//call player recover function
				//retrieve enemy action
				//perform relevant function call
				CombatState = BattleState.Nothing;
				ActionInput = true;
			}
			
			if (CombatState == BattleState.Defend)
			{
				ActionInput = false;
				//call player defend function
				//retrieve enemy action
				//perform relevant function call
				CombatState = BattleState.Nothing;
				ActionInput = true;
			}
		}
	}
	
	public void UpdateStateAttack()
	{
		if (ActionInput)
			CombatState = BattleState.Attack;
	}
	public void UpdateStateHeavy()
	{
		if (ActionInput)
			CombatState = BattleState.Heavy;
	}
	public void UpdateStateDefend()
	{	
		if (ActionInput)
			CombatState = BattleState.Defend;
	}
	public void UpdateStateRecover()
	{
		if (ActionInput)
			CombatState = BattleState.Recover;
	}
	
}
