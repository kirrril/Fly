using UnityEngine;
using UnityEngine.InputSystem;

public class FlatRotator : MonoBehaviour
{
    [SerializeField] private GameObject gizmo;
    [SerializeField] private Transform flatGizmo;
    [SerializeField] private Transform orbitGizmo;

    void Update()
    {
        flatGizmo.localRotation = orbitGizmo.localRotation;
    }

    public void ToggleGizmoNoParam()
    {   
        gizmo.SetActive(!gizmo.activeSelf);
    }
}