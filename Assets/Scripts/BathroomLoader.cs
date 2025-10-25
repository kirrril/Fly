using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class BathroomLoader : MonoBehaviour
{
    [SerializeField] private GameObject flat;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private FlyMover flyMover;
    private static AsyncOperationHandle<GameObject> roomHandle;
    private GameObject bathroomInstance;

    void OnDestroy()
    {
        Addressables.Release(roomHandle);
    }

    private async void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            flyMover.enabled = false;
            try
            {
                await RoomLoader();
            }
            finally
            {
                flyMover.enabled = true;
            }
        }
    }

    private async Task RoomLoader()
    {
        if (bathroomInstance != null) return;
        
        roomHandle = Addressables.InstantiateAsync("BathroomPrefab", spawnPoint.position, spawnPoint.rotation, flat.transform);
        await roomHandle.Task;
        if (roomHandle.Status == AsyncOperationStatus.Succeeded)
        {
            bathroomInstance = roomHandle.Result;
        }
        else
        {
            Debug.LogError("Échec chargement Bathroom");
        }
    }
}
