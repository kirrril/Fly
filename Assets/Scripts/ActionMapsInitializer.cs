using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using System.Collections;

public class ActionMapsInitializer : MonoBehaviour
{
    private PlayerInput playerInput;
    [SerializeField] private CanvasManager canvasManager;
    [SerializeField] private TMP_Text debugText;

    void Start()
    {
        playerInput = GetComponent<PlayerInput>();

        ActivateGameplayMaps();

        canvasManager.activateUI += SwitchActionMap;
    }

    private void ActivateGameplayMaps()
    {
        playerInput.actions.FindActionMap("XRI Left Locomotion")?.Enable();
        playerInput.actions.FindActionMap("XRI Left Interaction")?.Enable();
        playerInput.actions.FindActionMap("XRI Right Locomotion")?.Enable();
        playerInput.actions.FindActionMap("XRI Right Interaction")?.Enable();
        playerInput.actions.FindActionMap("XRI Head")?.Enable();
        playerInput.actions.FindActionMap("XRI UI")?.Disable();

        debugText.text = $"ActivateGameplayMaps() called";
    }

    private void ActivateUIMaps()
    {
        playerInput.actions.FindActionMap("XRI Left Locomotion")?.Disable();
        playerInput.actions.FindActionMap("XRI Left Interaction")?.Disable();
        playerInput.actions.FindActionMap("XRI Right Locomotion")?.Disable();
        playerInput.actions.FindActionMap("XRI Right Interaction")?.Disable();
        playerInput.actions.FindActionMap("XRI Head")?.Enable();
        playerInput.actions.FindActionMap("XRI UI")?.Enable();

        debugText.text = $"ActivateUIMaps() called";
    }

    public void SwitchActionMap(bool activateUI)
    {
        StartCoroutine(SwitchActionMapNextFrame(activateUI));
    }

    private IEnumerator SwitchActionMapNextFrame(bool activateUI)
    {
        yield return null;

        if (activateUI)
        {
            ActivateUIMaps();
        }
        else
        {
            ActivateGameplayMaps();
        }
    }
}
