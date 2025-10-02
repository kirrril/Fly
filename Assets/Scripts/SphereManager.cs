using UnityEngine;

public class SphereManager : MonoBehaviour
{
    [SerializeField]
    private Transform followTarget;
    [SerializeField] TextureTrigger[] textureTriggers;
    [SerializeField] Material sphereMaterial;

    public static bool isTeleporting;

    // private void Start()
    // {
    //     foreach (TextureTrigger trigger in textureTriggers)
    //     {
    //         trigger.TriggerTexture += ApplyTexture;
    //     }
    // }

    // void LateUpdate()
    // {
    //     if (!isTeleporting)
    //     {
    //         transform.position = followTarget.transform.position + new Vector3(0, 0.3f, 1);
    //     }
        // transform.rotation = Quaternion.identity;
    // }

//     private void ApplyTexture(Texture2D texture)
//     {
//         sphereMaterial.mainTexture = texture;
//     }
}
