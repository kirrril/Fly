using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class ApptsLoader : MonoBehaviour
{
    [SerializeField] private string adressableName;
    [SerializeField] private GameObject spawnPoint;
    [SerializeField] private GameObject sceneRoot;
    public static AsyncOperationHandle<GameObject> oldAddressableHandle;
    public static AsyncOperationHandle<GameObject> newAddressableHandle;
    public static GameObject oldAddressableInstance;
    public static GameObject newAddressableInstance;

    private async void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("CloudLoader"))
        {
            Debug.Log("Tag detected by Appart Trigger");
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

            if (oldAddressableHandle.IsValid())
            {
                await Task.Delay(3000);
                Addressables.Release(oldAddressableHandle);
                if (oldAddressableInstance != null) Destroy(oldAddressableInstance);
            }

            oldAddressableHandle = newAddressableHandle;
            oldAddressableInstance = newAddressableInstance;
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