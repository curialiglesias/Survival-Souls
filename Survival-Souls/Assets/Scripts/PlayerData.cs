using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData
{
    public int points;
    public int velocity;
    public int damage;
    public int defense;
    public int soulTime;
    public int decraseRate;
    public int bonusPoints;

    public PlayerData(int points, int velocity, int damage, int defense, int soulTime, int decraseRate, int bonusPoints)
    {
        this.points = points;
        this.velocity = velocity;
        this.damage = damage;
        this.defense = defense;
        this.soulTime = soulTime;
        this.decraseRate = decraseRate;
        this.bonusPoints = bonusPoints;
    }
}
