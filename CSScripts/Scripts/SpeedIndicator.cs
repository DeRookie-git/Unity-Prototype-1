using UnityEngine;
using TMPro;

public class SpeedIndicator : MonoBehaviour
{
    public TextMeshProUGUI speedText;
    private Car_ZIL130_Cover car;

    void Start()
    {
        car = GetComponent<Car_ZIL130_Cover>() ?? FindObjectOfType<Car_ZIL130_Cover>();

        if (car == null)
        {
            Debug.LogError("RIP bozo");
        }
    }

    void Update()
    {
        UpdateSpeedDisplay();
    }

    void UpdateSpeedDisplay()
    {
        float speedInKmH = car.rb.velocity.magnitude * 3.6f;

        float dotProduct = Vector3.Dot(car.transform.forward, car.rb.velocity.normalized);
        
        speedText.text = dotProduct switch
        {
            float dp when dp < 0 => $"-{(int)speedInKmH} km/h", // atgal
            _ => $"{(int)speedInKmH} km/h" // pirmyn
        };
    }
}
