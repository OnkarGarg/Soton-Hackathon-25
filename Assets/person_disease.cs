using UnityEngine;

public class person_disease : Disease
{
    public override void InitializeDisease()
    {
        Debug.Log("Initialised Disease");
        // Set values either via code or Inspector
        spreadProbabilityDuringIncubation = 1f;
        spreadProbabilityAfterIncubation = 1f;
        interactionRadius = 3f;
        deathProbability = 0.000f;
        recoveryProbability = 0.002f;
        incubationPeriodDuration = 10f;

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
        gameObject.GetComponent<Infectible>().myDiseases.Remove(this);
        base.Recover();
    }
}