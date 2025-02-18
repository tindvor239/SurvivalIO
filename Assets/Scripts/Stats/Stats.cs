
using System;

[Serializable]
public struct Stats
{
    public float health;
    public float damage;
    public float defence;
    public float attackRate;
    public float movementSpeed;

    public Stats(float health, float damage, float defence, float attackRate, float movementSpeed)
    {
        this.health = health;
        this.damage = damage;
        this.defence = defence;
        this.attackRate = attackRate;
        this.movementSpeed = movementSpeed;
    }

    public static Stats operator +(Stats a, Stats b)
    {
        return new Stats(a.health + b.health, a.damage + b.damage, a.defence + b.defence, a.attackRate + b.attackRate, a.movementSpeed + b.movementSpeed);
    }

    public static Stats operator -(Stats a, Stats b)
    {
        return new Stats(a.health - b.health, a.damage - b.damage, a.defence - b.defence, a.attackRate + b.attackRate, a.movementSpeed + b.movementSpeed);
    }
}