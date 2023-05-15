using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image fill;

    void Update()
    {
        Vector3 targetPosition = transform.position + transform.forward;
        transform.LookAt(targetPosition);

        Vector3 parentPosition = transform.parent.position;
        float childOffset = transform.localScale.y * 0.5f;

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
