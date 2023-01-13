using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData
{
    public int points;
    public int velocity;
    public int attack;
    public int soulTime;
    public int decraseRate;
    public int bonusPoints;

    public PlayerData(int points, int velocity, int attack, int soulTime, int decraseRate, int bonusPoints)
    {
        this.points = points;
        this.velocity = velocity;
        this.attack = attack;
        this.soulTime = soulTime;
        this.decraseRate = decraseRate;
        this.bonusPoints = bonusPoints;
    }
}
