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

        Vector3 parentPosition = transform.parent.position;

        // Calculate the offset to move the child object to the bottom
        float childOffset = transform.localScale.y * 0.5f;

        // Set the child object's position
        transform.position = parentPosition + new Vector3(0f, -childOffset, 0f);
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

        //something wrong with the sun
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}
