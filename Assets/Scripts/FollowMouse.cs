using UnityEngine;
using UnityEngine.InputSystem; // Required for the new system

public class FollowMouse : MonoBehaviour
{
    public Vector2 rotationScale = new Vector2(-0.5f, 7.5f); // Scale for rotation based on mouse position
    public float speed = 1f; // Speed at which the camera follows the mouse

    [SerializeField]
    Vector3 targetRotation = Vector3.zero; // Target rotation for the camera

    // Update is called once per frame
    void Update()
    {
        Vector2 mouseScreenPosition = Mouse.current.position.ReadValue();
        Vector2 screenSize = new Vector2(Screen.width, Screen.height);
        Vector2 relativeMousePosition = new Vector2(mouseScreenPosition.x / screenSize.x, mouseScreenPosition.y / screenSize.y);
        bool mouseOnScreen = relativeMousePosition.x >= 0 && relativeMousePosition.x <= 1 && relativeMousePosition.y >= 0 && relativeMousePosition.y <= 1;

        if (mouseOnScreen)
        {
            targetRotation.x = (relativeMousePosition.y - 0.5f) * 2f; // Normalize to range [-1, 1]
            targetRotation.y = (relativeMousePosition.x - 0.5f) * 2f; // Normalize to range [-1, 1]
            targetRotation.x *= rotationScale.x; // Apply rotation scale
            targetRotation.y *= rotationScale.y; // Apply rotation scale
            targetRotation.z = 0f; // No roll rotation
        }
        else
        {
            targetRotation = Vector3.zero; // Reset rotation if mouse is off-screen
        }

        // Smoothly interpolate the camera's rotation towards the target rotation
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(targetRotation), speed * Time.deltaTime);
    }
}
