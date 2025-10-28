using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class FacadeLoader : MonoBehaviour
{
    [SerializeField] private List<Transform> apptsAnchors;
    [SerializeField] private GameObject sceneRoot;
    private static List<AsyncOperationHandle<GameObject>> facadeHandles = new List<AsyncOperationHandle<GameObject>>();
    private static List<GameObject> facadeInstances = new List<GameObject>();


    private async void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger Entered");
        if (other.CompareTag("CloudLoader"))
        {
            Debug.Log("Tag detected by Facade Trigger");

            FlyMover.isIndoors = false;

            await LoadFacade();

            // await Task.Delay(500);
            if (ApptsLoader.oldAddressableHandle.IsValid())
            {
                Addressables.Release(ApptsLoader.oldAddressableHandle);
                if (ApptsLoader.oldAddressableInstance != null) Destroy(ApptsLoader.oldAddressableInstance);
            }
        }
    }

    private async void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("CloudLoader"))
        {
            await Task.Delay(1000);

            FlyMover.isIndoors = true;

            foreach (var handle in facadeHandles)
            {
                if (handle.IsValid()) Addressables.Release(handle);
            }
            foreach (var instance in facadeInstances)
            {
                if (instance != null) Destroy(instance);
            }
            facadeHandles.Clear();
            facadeInstances.Clear();
        }
    }

    private async Task LoadFacade()
    {
        foreach (Transform anchor in apptsAnchors)
        {
            var handle1 = Addressables.InstantiateAsync("FacadeLivingPrefab", anchor.position, Quaternion.identity,/*anchor.rotation, */transform);
            var handle2 = Addressables.InstantiateAsync("FacadeBedroomPrefab", anchor.position, Quaternion.identity,/*anchor.rotation, */transform);
            await Task.WhenAll(handle1.Task, handle2.Task);

            if (handle1.Status == AsyncOperationStatus.Succeeded && handle2.Status == AsyncOperationStatus.Succeeded)
            {
                facadeHandles.Add(handle1);
                facadeHandles.Add(handle2);
                facadeInstances.Add(handle1.Result);
                facadeInstances.Add(handle2.Result);
            }
            else
            {
                Debug.LogError($"Échec chargement façade à {anchor.name}");
            }
        }
    }

    void OnDestroy()
    {
        foreach (var handle in facadeHandles)
        {
            if (handle.IsValid()) Addressables.Release(handle);
        }
        foreach (var instance in facadeInstances)
        {
            if (instance != null) Destroy(instance);
        }
        facadeHandles.Clear();
        facadeInstances.Clear();
    }
}
