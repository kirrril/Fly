using UnityEngine;

public class NutritionalValue : MonoBehaviour
{
    public float availableSugar;
    public float availableProtein;
    public float availableWater;
    public float heat;

    void Update()
    {
        if (availableSugar <= 0 && availableProtein <= 0 && availableWater <= 0 && heat <= 0) Destroy(transform.parent.gameObject);

        
    }
}
