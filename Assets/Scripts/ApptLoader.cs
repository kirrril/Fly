using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class ApptLoader : MonoBehaviour
{
    [SerializeField] private string adressableName;
    [SerializeField] private GameObject spawnPoint;
    private AsyncOperationHandle<GameObject> addressableHandle;
    private GameObject addressableInstance;
    private bool isLoading = false;


    private async void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        if (isLoading || addressableHandle.IsValid())
        {
            Debug.Log($"Handle {adressableName} a déjà été chargé.");
            return;
        }

        isLoading = true;
        addressableHandle = Addressables.InstantiateAsync(adressableName, spawnPoint.transform.position, spawnPoint.transform.rotation, transform);
        await addressableHandle.Task;

        if (addressableHandle.Status == AsyncOperationStatus.Succeeded)
        {
            addressableInstance = addressableHandle.Result;
        }
        else
        {
            Debug.LogError($"Échec chargement {adressableName}");
        }
        isLoading = false;

    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        UnloadRoom();
    }

    private void UnloadRoom()
    {
        if (addressableHandle.IsValid())
        {
            Addressables.Release(addressableHandle);
            if (addressableInstance != null) Destroy(addressableInstance);
            addressableHandle = default;
            addressableInstance = null;
        }
    }

    void OnDestroy()
    {
        UnloadRoom();
    }
}