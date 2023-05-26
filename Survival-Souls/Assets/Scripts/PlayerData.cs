using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData
{
    public float points;
    public float velocity;
    public float damage;
    public float defense;
    public float soulTime;
    public float decraseRate;
    public float bonusPoints;
    public bool dash;
    public bool doubleShot;
    public bool chargedShot;
    public bool map2unlocked;

    public PlayerData(float points, float velocity, float damage, float defense, float soulTime, float decraseRate, float bonusPoints, bool dash, bool doubleShot, bool chargedShot, bool map2unlocked)
    {
        this.points = points;
        this.velocity = velocity;
        this.damage = damage;
        this.defense = defense;
        this.soulTime = soulTime;
        this.decraseRate = decraseRate;
        this.bonusPoints = bonusPoints;
        this.dash = dash;
        this.doubleShot = doubleShot;
        this.chargedShot = chargedShot;
        this.map2unlocked = map2unlocked;
    }
}
