using UnityEngine;

public class EnergyController : MonoBehaviour
{
    public float sugar;
    public float protein;
    public float water;
    public float heat;

    public static EnergyController Instance;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        sugar = 100f;
        protein = 100f;
        water = 100f;
        heat = 100f;
    }

    void Update()
    {
        
    }
}
