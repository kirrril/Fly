using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class ApptsLoader : MonoBehaviour
{
    [SerializeField] private string adressableName;
    [SerializeField] private GameObject spawnPoint;
    [SerializeField] private GameObject sceneRoot;
    private AsyncOperationHandle<GameObject> addressableHandle;
    private GameObject addressableInstance;
    private bool isLoading = false;
    private int playerInsideCount = 0;

    private async void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        playerInsideCount++;

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

        playerInsideCount--;

        if (playerInsideCount <= 0)
        {
            playerInsideCount = 0;
            UnloadRoom();
        }
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