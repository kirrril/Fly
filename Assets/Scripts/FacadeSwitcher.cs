using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class FacadeSwitcher : MonoBehaviour
{
    private GameObject facade;

    void Start()
    {
        facade = GameObject.Find("FacadeAll");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            facade.SetActive(false);
        }
    }

    private async void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            facade.SetActive(true);
        }
    }
}
