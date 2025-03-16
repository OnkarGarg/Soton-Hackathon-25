using UnityEngine;
using System;
using TMPro.Examples;

public class Tuberculosis : Disease
{
    public override void InitializeDisease()
    {
        Debug.Log("Initialised Disease");
        // Set values either via code or Inspector
        spreadProbabilityDuringIncubation = 0.002f;
        spreadProbabilityAfterIncubation = 0.007f;
        interactionRadius = 4f;
        deathProbability = 0.00300f;
        recoveryProbability = 0.00500f;
        incubationPeriodDuration = 30f;


        Renderer rend = GetComponent<Renderer>();
        originalMaterial = rend.material;
        originalColor = originalMaterial.color;
    }

    public override void OnIncubationComplete()
    {
        // Add symptom visual effects or gameplay impacts
        originalMaterial.color = originalColor * new Color(0.5f, 1f, 0.5f);
    }

    protected override void StaySick()
    {
        // Implement persistent effects
    }

    protected override void Recover()
    {
        originalMaterial.color = originalColor * new Color(1f, 0.5f, 0.5f);

        Infectible MyInfectable = gameObject.GetComponent<Infectible>();

        MyInfectable.myImmunity.Add(new Immunity(this.GetType()));
        MyInfectable.myDiseases.Remove(this);
        Debug.Log(MyInfectable.myDiseases);
        base.Recover();
    }
}