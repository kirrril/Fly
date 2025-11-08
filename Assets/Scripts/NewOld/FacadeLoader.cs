// using System.Collections;
// using System.Collections.Generic;
// using System.Threading.Tasks;
// using UnityEngine;
// using UnityEngine.AddressableAssets;
// using UnityEngine.ResourceManagement.AsyncOperations;

// public class FacadeLoader : MonoBehaviour
// {
//     [SerializeField] private List<Transform> apptsAnchors;
//     [SerializeField] private GameObject sceneRoot;
//     private List<AsyncOperationHandle<GameObject>> facadeHandles = new List<AsyncOperationHandle<GameObject>>();
//     private List<GameObject> facadeInstances = new List<GameObject>();
//     private bool isLoading = false;

//     private async void Start()
//     {
//         await LoadFacade();
//     }

//     private void OnTriggerEnter(Collider other)
//     {
//         if (other.CompareTag("Player"))
//         {
//             UnloadFacades();
//         }
//     }

//     private async void OnTriggerExit(Collider other)
//     {
//         if (other.CompareTag("Player") && !isLoading)
//         {
//             isLoading = true;
//             await LoadFacade();
//             isLoading = false;
//         }
//     }

//     private async Task LoadFacade()
//     {
//         var livingFacadeHandle = Addressables.LoadAssetAsync<GameObject>("FacadeLivingPrefab");
//         var bedroomFacadeHandle = Addressables.LoadAssetAsync<GameObject>("FacadeBedroomPrefab");
//         await Task.WhenAll(livingFacadeHandle.Task, bedroomFacadeHandle.Task);

//         if (livingFacadeHandle.Status != AsyncOperationStatus.Succeeded || bedroomFacadeHandle.Status != AsyncOperationStatus.Succeeded)
//         {
//             Debug.LogError("Échec du chargement des prefabs de façade");
//             return;
//         }

//         GameObject livingFacadePrefab = livingFacadeHandle.Result;
//         GameObject bedroomFacadePrefab = bedroomFacadeHandle.Result;

//         facadeHandles.Add(livingFacadeHandle);
//         facadeHandles.Add(bedroomFacadeHandle);

//         foreach (Transform anchor in apptsAnchors)
//         {
//             GameObject livingFacadeInstance = Instantiate(livingFacadePrefab, anchor.position, anchor.rotation, transform);
//             GameObject bedroomFacadeInstance = Instantiate(bedroomFacadePrefab, anchor.position, anchor.rotation, transform);

//             livingFacadeInstance.layer = LayerMask.NameToLayer("Default");
//             bedroomFacadeInstance.layer = LayerMask.NameToLayer("Default");

//             facadeInstances.Add(livingFacadeInstance);
//             facadeInstances.Add(bedroomFacadeInstance);
//         }
//     }

//     private void UnloadFacades()
//     {
//         foreach (var handle in facadeHandles)
//         {
//             if (handle.IsValid()) Addressables.Release(handle);
//         }
//         foreach (var instance in facadeInstances)
//         {
//             if (instance != null) Destroy(instance);
//         }
//         facadeHandles.Clear();
//         facadeInstances.Clear();
//     }

//     private void OnDestroy()
//     {
//         UnloadFacades();
//     }
// }
