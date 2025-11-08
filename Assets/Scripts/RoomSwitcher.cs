using System.Collections.Generic;
using UnityEngine;

public class RoomSwitcher : MonoBehaviour
{
    [SerializeField] private List<GameObject> room;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        foreach (GameObject entity in room)
        {
            entity.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        foreach (GameObject entity in room)
        {
            entity.SetActive(false);
        }
    }
}
