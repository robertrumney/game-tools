using UnityEngine;

// Get cost based on a curve you can edit visually in the inspector
public class GetCostFromCurve : MonoBehaviour
{ 
    public AnimationCurve costCurve;

    public float GetCostFromCurve(float amount)
    {
        float maxQuantity = 200;
        float normalizedAmount = amount / maxQuantity;
        float normalizedCost = costCurve.Evaluate(normalizedAmount);
        float maxCost = 100f; // example value, change as needed
        float minCost = 10f; // example value, change as needed
        float cost = normalizedCost * maxCost;

        if (cost < minCost) cost = minCost;

        return cost;
    }
}
