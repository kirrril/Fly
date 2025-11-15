using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Management;

public class Eater : MonoBehaviour
{
    public float consumedSugar;
    public float consumedProtein;
    public float consumedWater;
    public float consumedHeat;
    public static Eater Instance;
    public bool isPumping;
    public bool isEating;
    private LayerMask foodLayer;
    private GameObject food;
    private NutritionalValue nutritionalValue;
    public float absorbSpeed = 5f;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        consumedSugar = 100f;
        consumedProtein = 100f;
        consumedWater = 100f;
        consumedHeat = 100f;

        foodLayer = LayerMask.GetMask("Food");
    }

    void Update()
    {
        if (isPumping)
        {
            isEating = Physics.Raycast(transform.position, (-transform.up + transform.forward).normalized, out RaycastHit frontForwardHit, 0.5f, foodLayer);
            Debug.DrawRay(transform.position, (-transform.up + transform.forward).normalized * 0.5f, Color.red, 5f);
            food = frontForwardHit.collider.gameObject;
            nutritionalValue = food.GetComponent<NutritionalValue>();
            nutritionalValue.enabled = true;
            FlyConsuming();
        }
        else
        {
            isEating = false;
            if (food != null)
            {
                nutritionalValue.enabled = false;
                food = null;
            }
        }
    }

    private void FlyConsuming()
    {
        if (nutritionalValue.availableSugar > 0)
        {
            nutritionalValue.availableSugar -= absorbSpeed * Time.deltaTime;
            consumedSugar += absorbSpeed * Time.deltaTime;
        }
        if (nutritionalValue.availableProtein > 0)
        {
            nutritionalValue.availableProtein -= absorbSpeed * Time.deltaTime;
            consumedProtein += absorbSpeed * Time.deltaTime;
        }
        if (nutritionalValue.availableWater > 0)
        {
            nutritionalValue.availableWater -= absorbSpeed * Time.deltaTime;
            consumedWater += absorbSpeed * Time.deltaTime;
        }
        if (nutritionalValue.heat > 0)
        {
            consumedHeat += absorbSpeed * Time.deltaTime;
        }
    }

    public void OnEat(InputAction.CallbackContext ctx)
    {
        isPumping = ctx.ReadValue<float>() > 0.5f;
    }
}
