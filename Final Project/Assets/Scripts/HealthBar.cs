using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image fill;

    /* private Vector3 parentPosition;

    void Start()
    {
        parentPosition = transform.parent.position;
    } */

    void Update()
    {
        // Calculate the target position for the child object to look at
        Vector3 targetPosition = transform.position + transform.forward;

        // Make the child object look at the target position
        transform.LookAt(targetPosition);

        //
    }

    public void SetMaxHealth(float health)
    {
        slider.maxValue = health;
        slider.value = health;

        fill.color = gradient.Evaluate(1f);
    }

    public void SetHealth(float health)
    {
        slider.value = health;
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}
