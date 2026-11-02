using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ButtonClick : Interactable
{
    private Button button;
    private void Awake()
    {
        button = GetComponent<Button>();
    }

    protected override void Start()
    {
        base.Start();
    }

    public override void SetActiveInteractable(bool isActive)
    {
        button.interactable = isActive;
    }

    public override void SetReadyColor(Color color)
    {
        ColorBlock cb = button.colors;

        cb.normalColor = color;

        button.colors = cb;
    }

    public override void SetDefaultColor(Color color)
    {
        ColorBlock cb = button.colors;

        cb.normalColor = color;

        button.colors = cb;
    }
}
