using UnityEngine;

public class Test : MonoBehaviour
{
    [SerializeField] private Material cubeMaterial;
    [SerializeField] private Transform xrOrigin;
    [SerializeField] private Transform destination;

    public void DisplayLog()
    {
        Debug.Log("Display this");
    }

    // public void ChangeColor()
    // {
    //     cubeMaterial.color = cubeMaterial.color == Color.yellow ? Color.red : Color.yellow;

    //     Debug.Log("Color changed");
    // }

    public void TeleportMe()
    {
        xrOrigin.position = destination.position;
    }
}
