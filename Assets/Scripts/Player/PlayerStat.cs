using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Playerstat
{
    public string Name;
    public float health;
    public float maxHealth;
    public int killCount;
    public int money;

    /*public override string ToString()
    {
        return $"{Name} is at {health} HP with {ammo} ammo with ammo speed of {ammoSpeed} with Attack Power {attackPower} with speed of {speed}";
    }*/
}
