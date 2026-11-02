using UnityEngine;
using UnityEngine.UI;

public class LeverPush : Interactable
{
    private Slider leverSlider;
    private void Awake()
    {
        leverSlider = GetComponent<Slider>();
    }

    protected override void Start()
    {
        base.Start();
    }

    private float currentLeverValue = 0f;

    public void OnLeverSwitch()
    {
        if (leverSlider.value >= 1 && currentLeverValue == 0f)
        {
            Interact();
            currentLeverValue = 1f;
        } else if (leverSlider.value <= 0 && currentLeverValue == 1f)
        {
            Interact();
            currentLeverValue = 0f;
        }
    }

    public override void SetActiveInteractable(bool isActive)
    {
        leverSlider.interactable = isActive;
    }

    public override void SetReadyColor(Color color)
    {
        ColorBlock cb = leverSlider.colors;

        cb.normalColor = color;

        leverSlider.colors = cb;
    }

    public override void SetDefaultColor(Color color)
    {
        ColorBlock cb = leverSlider.colors;

        cb.normalColor = color;

        leverSlider.colors = cb;
    }
}
