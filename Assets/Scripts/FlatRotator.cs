using UnityEngine;

public class FlatRotator : MonoBehaviour
{
    [SerializeField] private Transform flatOrbit;

    void Update()
    {
        Vector3 flatEuler = transform.eulerAngles;
        flatEuler = flatOrbit.eulerAngles;
        transform.eulerAngles = flatEuler;
    }
}