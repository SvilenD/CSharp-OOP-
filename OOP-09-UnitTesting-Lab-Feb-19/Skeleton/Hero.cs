﻿using Skeleton.Interfaces;

public class Hero
{
    private string name;
    private int experience;

    public Hero(string name, IWeapon weapon)
    {
        this.name = name;
        this.experience = 0;
        this.Weapon = weapon;
    }

    public string Name
    {
        get { return this.name; }
    }

    public int Experience
    {
        get { return this.experience; }
    }
    
    public IWeapon Weapon { get; }

    public void Attack(ITarget target)
    {
        this.Weapon.Attack(target);

        if (target.IsDead())
        {
            this.experience += target.GiveExperience();
        }
    }
}
