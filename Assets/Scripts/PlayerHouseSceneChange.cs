using UnityEngine;

public class PlayerHouseSceneChange : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Collision detected");
        }
    }
}
