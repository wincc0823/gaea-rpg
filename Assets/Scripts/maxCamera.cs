using UnityEngine;
using System.Collections;

public class maxCamera : MonoBehaviour
{
    public Vector3 targetOffset;
    public float distance = 5.0f;
    public float maxDistance = 20;
    public float minDistance = .6f;
    public int zoomRate = 40;
    public float zoomDampening = 5.0f;

    private float currentDistance;
    private float desiredDistance;
    private Vector3 position;
    private Quaternion rotation;
    private Transform padre;

    public void Start()
    {
        distance = Vector3.Distance(transform.position, transform.parent.position);
        currentDistance = distance;
        desiredDistance = distance;

        position = transform.position;
        rotation = transform.rotation;
        padre = transform.parent;
    }

    /*
     * Camera logic on LateUpdate to only update after all character movement logic has been handled. 
     */
    void LateUpdate()
    {

        // affect the desired Zoom distance if we roll the scrollwheel
        desiredDistance -= Input.GetAxis("Mouse ScrollWheel") * Time.deltaTime * zoomRate * Mathf.Abs(desiredDistance);
        //clamp the zoom min/max
        desiredDistance = Mathf.Clamp(desiredDistance, minDistance, maxDistance);
        // For smoothing of the zoom, lerp distance
        currentDistance = Mathf.Lerp(currentDistance, desiredDistance, Time.deltaTime * zoomDampening);

        // calculate position based on the new currentDistance 
        position = padre.position - (rotation * Vector3.forward * currentDistance + targetOffset);
        transform.position = position;
    }
}