using UnityEngine;

public class BoitataEMF : MonoBehaviour,IEMF
{
    public Transform GetEMFTransform()
    {
        return transform;
    }
}