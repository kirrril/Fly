using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class DoorsLoader : MonoBehaviour
{
    [SerializeField] private GameObject spawnPoint;
    [SerializeField] private GameObject sceneRoot;
    private AsyncOperationHandle<GameObject> bathDoorHandle;
    private AsyncOperationHandle<GameObject> bedDoorHandle;
    private GameObject bathDoorInstance;
    private GameObject bedDoorInstance;
    private bool isLoading = false;

    private async void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        if (isLoading)
        {
            return;
        }

        isLoading = true;
        bathDoorHandle = Addressables.InstantiateAsync("DoorBathroomPrefab", spawnPoint.transform.position, spawnPoint.transform.rotation, transform);
        bedDoorHandle = Addressables.InstantiateAsync("DoorBedroomPrefab", spawnPoint.transform.position, spawnPoint.transform.rotation, transform);
        await bathDoorHandle.Task;
        await bedDoorHandle.Task;

        if (bathDoorHandle.Status == AsyncOperationStatus.Succeeded && bedDoorHandle.Status == AsyncOperationStatus.Succeeded)
        {
            bathDoorInstance = bathDoorHandle.Result;
            bedDoorInstance = bedDoorHandle.Result;
        }
        isLoading = false;
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        UnloadDoors();
    }

    private void UnloadDoors()
    {
        if (bathDoorHandle.IsValid())
        {
            Addressables.Release(bathDoorHandle);
            if (bathDoorInstance != null) Destroy(bathDoorInstance);
            bathDoorHandle = default;
            bathDoorInstance = null;
        }

        if (bedDoorHandle.IsValid())
        {
            Addressables.Release(bedDoorHandle);
            if (bedDoorInstance != null) Destroy(bedDoorInstance);
            bedDoorHandle = default;
            bedDoorInstance = null;
        }
    }

    void OnDestroy()
    {
        UnloadDoors();
    }
}