using System.Collections.Generic;
using UnityEngine;

public class DisabledManager : MonoBehaviour
{
    public bool isDisabled;
    private Dictionary<GameObject, (Vector2, float)> objectVelocities = new Dictionary<GameObject, (Vector2, float)>();

    void Start()
    {
        isDisabled = true;
    }

    void Update()
    {
        isDisabled = PlayerController.GetisDisable();
        OnInteractSwitching();
    }

    private void OnInteractSwitching()
    {
        GameObject[] interactObjects = GameObject.FindGameObjectsWithTag("InteractObject");
        if (interactObjects != null && interactObjects.Length > 0)
        {
            foreach (GameObject obj in interactObjects)
            {
                Rigidbody2D rb = obj.GetComponent<Rigidbody2D>();
                if (rb != null)
                {
                    if (isDisabled)
                    {
                        if (!objectVelocities.ContainsKey(obj))
                        {
                            // Store the velocity and angular velocity before making the object static
                            objectVelocities[obj] = (rb.velocity, rb.angularVelocity);
                        }
                        rb.bodyType = RigidbodyType2D.Static; // 设置为静态物理对象
                    }
                    else
                    {
                        rb.bodyType = RigidbodyType2D.Dynamic; // 恢复为动态物理对象
                        // Reapply the stored velocity and angular velocity
                        if (objectVelocities.ContainsKey(obj))
                        {
                            var velocities = objectVelocities[obj];
                            rb.velocity = velocities.Item1;
                            rb.angularVelocity = velocities.Item2;
                            objectVelocities.Remove(obj); // Optionally remove the entry after reapplying
                        }
                    }
                }
            }
        }
    }
}
