using UnityEngine;

public class RotateCat : MonoBehaviour
{
    public GameObject carModel;
    public Transform raycastPoint; private float hoverHeight = 1.0f;
    private float speed = 20.0f; private float terrainHeight;
    private float rotationAmount;
    private RaycastHit hit;
    private Vector3 pos;
    private Vector3 forwardDirection; 
    void Update()
    {
        // Find location and slope of ground below the vehicle
        Physics.Raycast(raycastPoint.position, Vector3.down, out hit);    // Keep at specific height above terrain
        pos = transform.position;
        float terrainHeight = hit.point.y;
        //transform.position = new Vector3(pos.x,terrainHeight + hoverHeight, pos.z);

        // Rotate to align with terrain
        transform.up -= (transform.up - hit.normal) * 1f;
    }
}