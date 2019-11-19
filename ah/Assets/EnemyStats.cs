using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{

	public int hpCurrent = 5;
	public int hpMax = 5;
	public int attackDamage = 2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		if(hpCurrent <= 0)
		{
			Destroy(gameObject);
		}
    }

	public void tookDamage(int amount)
	{
		hpCurrent-=amount;
		Debug.Log(gameObject.name + " took " + amount + " damage.");
	}
	public void healDamage(int amount)
	{
		hpCurrent+=amount;
		if(hpCurrent > hpMax)
			hpCurrent = hpMax;
	}

	public int getHpCurrent()
	{
		return hpCurrent;
	}
	public int getHpMax()
	{
		return hpMax;
	}
	public int getAttackDmg()
	{
		return attackDamage;
	}
}
