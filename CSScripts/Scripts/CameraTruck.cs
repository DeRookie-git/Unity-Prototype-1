using UnityEngine;
using UnityEngine.SceneManagement;

public class SimpleCameraController : MonoBehaviour
{
    public Transform truck;
    public float rotationSpeed = 5f;
    public float verticalRotationLimit = 60f;

    private float currentVerticalRotation = 0f;
void Start()
{
            float horizontalRotation = Input.GetAxis("Mouse X") * rotationSpeed * Time.deltaTime;
            transform.RotateAround(truck.position, Vector3.up, horizontalRotation);
            float verticalRotation = -Input.GetAxis("Mouse Y") * rotationSpeed * Time.deltaTime;

            Vector3 cameraPosition = transform.position;
            Quaternion cameraRotation = Quaternion.Euler(currentVerticalRotation, transform.eulerAngles.y, 0f);
            Vector3 direction = cameraRotation * Vector3.back;

    transform.position = truck.position + direction * (cameraPosition - truck.position).magnitude;
            transform.LookAt(truck);
}
    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            float horizontalRotation = Input.GetAxis("Mouse X") * rotationSpeed * Time.deltaTime;
            transform.RotateAround(truck.position, Vector3.up, horizontalRotation);
            float verticalRotation = -Input.GetAxis("Mouse Y") * rotationSpeed * Time.deltaTime;
            
            currentVerticalRotation = Mathf.Clamp(currentVerticalRotation + verticalRotation, -verticalRotationLimit, verticalRotationLimit);

            Vector3 cameraPosition = transform.position;
            Quaternion cameraRotation = Quaternion.Euler(currentVerticalRotation, transform.eulerAngles.y, 0f);
            Vector3 direction = cameraRotation * Vector3.back;

            transform.position = truck.position + direction * (cameraPosition - truck.position).magnitude;
            transform.LookAt(truck);
        }
        if (Input.GetMouseButton(3))
        {
            SceneManager.LoadScene(0); //back to main menu
        }
    }
}

