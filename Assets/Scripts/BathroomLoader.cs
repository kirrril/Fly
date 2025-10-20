using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class BathroomLoader : MonoBehaviour
{
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private FlyMover flyMover;

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
        var handle = Addressables.LoadAssetAsync<GameObject>("BathroomPrefab");
        await handle.Task;
        if (handle.Status == AsyncOperationStatus.Succeeded)
        {
            Instantiate(handle.Result, spawnPoint.position, spawnPoint.rotation);
        }
        else
        {
            Debug.LogError("Échec chargement Bathroom");
        }
        // Addressables.Release(handle);
    }
}
