using UnityEngine;

public class Levitate : MonoBehaviour
{
    // Height of the levitation
    public float levitationHeight = 0.5f;

    // Speed of the levitation
    public float levitationSpeed = 2.0f;

    // Initial position of the object
    private Vector3 startPosition;

    void Start()
    {
        // Store the initial position of the object
        startPosition = transform.position;
    }

    void Update()
    {
        // Calculate the new Y position using a sine wave for smooth up and down motion
        float newY = startPosition.y + Mathf.Sin(Time.time * levitationSpeed) * levitationHeight;

        // Update the object's position
        transform.position = new Vector3(startPosition.x, newY, startPosition.z);
    }
}