using UnityEngine;

// Get cost based on a curve you can edit visually in the inspector
[RequireComponent(typeof(Product))]
public class GetCostFromCurve : MonoBehaviour
{
    // The curve to define the cost based on the amount
    [SerializeField] private AnimationCurve costCurve; 
    // The maximum quantity that can be used to normalize the input amount
    [SerializeField] private float maxQuantity = 200; 
    // The maximum cost that can be applied to the output
    [SerializeField] private float maxCost = 100f; 
    // The minimum cost that can be applied to the output
    [SerializeField] private float minCost = 10f; 

    // Calculate the cost based on the input amount and the cost curve
    public float GetCostFromCurve(float amount)
    {
        // Normalize the input amount between 0 and 1
        float normalizedAmount = Mathf.Clamp01(amount / maxQuantity);
        // Evaluate the cost based on the normalized amount using the cost curve
        float normalizedCost = costCurve.Evaluate(normalizedAmount);
        // Calculate the actual cost by scaling the normalized cost using the maxCost value
        float cost = normalizedCost * maxCost;

        // Ensure the cost doesn't go below the minimum cost value
        if (cost < minCost) cost = minCost;

        return cost;
    }
}

[System.Serializable]
public class Product
{
    public string Name; // The name of the product
    public float Cost; // The current cost of the product
}
