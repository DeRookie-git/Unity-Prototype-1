using UnityEngine;

public class CameraTruck : MonoBehaviour
{
    public Transform truck;
    public float rotationSpeed = 5f;     public float verticalRotationLimit = 60f;
    public float distanceFromTruck = 10f;

    private float currentVerticalRotation = 0f;
    private Vector3 offset;

    void Start()
    {
        offset = new Vector3(0, 2, -distanceFromTruck);
        transform.position = truck.position + offset;
        transform.LookAt(truck);
    }

    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            float horizontalRotation = Input.GetAxis("Mouse X") * rotationSpeed;
            float verticalRotation = -Input.GetAxis("Mouse Y") * rotationSpeed;

            currentVerticalRotation = Mathf.Clamp(currentVerticalRotation + verticalRotation, -verticalRotationLimit, verticalRotationLimit);

            Quaternion rotation = Quaternion.Euler(currentVerticalRotation, transform.eulerAngles.y + horizontalRotation, 0);

            transform.position = truck.position + rotation * offset;

            transform.LookAt(truck);
        }
        else
        {
            ResetCameraPosition();
        }
    }

    private void ResetCameraPosition()
    {
        transform.position = Vector3.Lerp(transform.position, truck.position + offset, Time.deltaTime);
        transform.LookAt(truck);
    }
}
