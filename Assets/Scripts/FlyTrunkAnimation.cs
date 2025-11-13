using UnityEngine;

public class FlyTrunkAnimation : MonoBehaviour
{
    [SerializeField] GameObject flyTrunk;

    void Update()
    {
        flyTrunk.SetActive(Eater.Instance.isPumping);
    }
}
