using UnityEngine;

public class CheckMouse : MonoBehaviour
{
    public float timeToHold = 2f;
    private float counter = 0f;

    private void OnMouseDown()
    {
        Debug.Log("Mouse button pressed on " + gameObject.name);
    }

    private void OnMouseOver()
    {
        counter += Time.deltaTime;
        if (counter >= timeToHold)
        {
            Debug.Log("Mouse held over " + gameObject.name + " for " + timeToHold + " seconds.");
            counter = 0f; // Reset counter if you want to detect multiple holds
        }
    }
}
