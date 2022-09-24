using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroVitality : MonoBehaviour
{
    [SerializeField] EnergySliderDisplayer energy;
    [SerializeField] HealthSliderDisplayer health;

    [SerializeField] float energyCost = 0.003f;
    [SerializeField] float attackEnergyCost = 10f;

    public void ChangeEnergy(float diff)
    {
        energy.ChangeValue(diff);
    }

    public void ChangeHealth(float diff)
    {
        health.ChangeValue(diff);
    }

    public float GetEnergy()
    {
        return energy.GetValue();
    }

    public float GeetHealth()
    {
        return health.GetValue();
    }

    public void AttackEnergyCost(bool isAttacking)
    {
        if (!isAttacking)
            { return; }

        energy.ChangeValue(-energyCost * attackEnergyCost);
        
    }

    public void RunningEnergyCost() // bieganie i atak równoczeniśnie mogą zabierać więcej energii (**)
    {
        energy.ChangeValue(-energyCost);
    }
}
