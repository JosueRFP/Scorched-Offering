using UnityEngine;

public class PlayerLigth : MonoBehaviour
{
    public Transform player;      
    public Vector3 offset = new Vector3(0, 2, 0);  

    void Update()
    {
        if (player != null)
        {
            transform.position = player.position + offset;
        }
    }
}
