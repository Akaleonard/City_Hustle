using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Vector3 offset;
    [SerializeField] private float smoothSpeed = 0.125f; // Adjust this if camera is jittery

    private bool canMoveLeft = true;
    private bool canMoveRight = true;
    private bool canMoveUp = true;
    private bool canMoveDown = true;

    private void LateUpdate()
    {
        if (player != null)
        {
            Vector3 targetPosition = player.position + offset;

            if (!canMoveLeft) targetPosition.x = Mathf.Max(targetPosition.x, player.position.x + offset.x);
            if (!canMoveRight) targetPosition.x = Mathf.Min(targetPosition.x, player.position.x + offset.x);
            if (!canMoveUp) targetPosition.y = Mathf.Min(targetPosition.y, player.position.y + offset.y);
            if (!canMoveDown) targetPosition.y = Mathf.Max(targetPosition.y, player.position.y + offset.y);

            Vector3 smoothedPosition = Vector3.Lerp(transform.position, targetPosition, smoothSpeed);

            transform.position = smoothedPosition;
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        // When the camera enters a boundary, disable movement in that direction
        if (collider.CompareTag("LeftBoundary"))
        {
            Debug.Log("Triggered!");
            canMoveLeft = false;
        }
        //if (collider.CompareTag("RightBoundary"))
        //{
        //    canMoveRight = false;
        //}
        //if (collider.CompareTag("TopBoundary"))
        //{
        //    canMoveUp = false;
        //}
        //if (collider.CompareTag("BottomBoundary"))
        //{
        //    canMoveDown = false;
        //}
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        // When the camera exits a boundary, enable movement in that direction
        if (collider.CompareTag("LeftBoundary"))
        {
            canMoveLeft = true;
        }
        //if (collider.CompareTag("RightBoundary"))
        //{
        //    canMoveRight = true;
        //}
        //if (collider.CompareTag("TopBoundary"))
        //{
        //    canMoveUp = true;
        //}
        //if (collider.CompareTag("BottomBoundary"))
        //{
        //    canMoveDown = true;
        //}
    }
}
