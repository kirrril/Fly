using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class ApptsLoaderModif : MonoBehaviour
{
    [SerializeField] private string adressableName;
    [SerializeField] private GameObject spawnPoint;
    [SerializeField] private GameObject sceneRoot;
    private AsyncOperationHandle<GameObject> oldAddressableHandle;
    private AsyncOperationHandle<GameObject> newAddressableHandle;
    private GameObject oldAddressableInstance;
    private GameObject newAddressableInstance;

    private async void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            newAddressableHandle = Addressables.InstantiateAsync(adressableName, spawnPoint.transform.position, spawnPoint.transform.rotation, transform);
            await newAddressableHandle.Task;

            if (newAddressableHandle.Status == AsyncOperationStatus.Succeeded)
            {
                newAddressableInstance = newAddressableHandle.Result;
            }
            else
            {
                Debug.LogError($"Échec chargement {adressableName}");
            }

            oldAddressableHandle = newAddressableHandle;
            oldAddressableInstance = newAddressableInstance;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (oldAddressableHandle.IsValid())
            {
                Addressables.Release(oldAddressableHandle);
                if (oldAddressableInstance != null) Destroy(oldAddressableInstance);
            }
        }
    }

    void OnDestroy()
    {
        if (oldAddressableHandle.IsValid() && oldAddressableInstance != null)
        {
            Addressables.Release(oldAddressableHandle);
            Destroy(oldAddressableInstance);
        }

        if (newAddressableHandle.IsValid() && newAddressableInstance != null)
        {
            Addressables.Release(newAddressableHandle);
            Destroy(newAddressableInstance);
        }
    }
}