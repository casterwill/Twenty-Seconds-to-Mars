using UnityEngine;
using UnityEngine.UI;

public class ButtonMash : Interactable
{
    [SerializeField] private Button button;
    [SerializeField] private Slider meshProgress;

    protected override void Start()
    {
        base.Start();
    }

    private float decreaseSpeed = 0.2f;
    private float currentValue = 0f;

    private bool decreaseActive = true;

    void Update()
    {
        if (decreaseActive)
        {
            DecreaseProgress();
        }
    }

    private void DecreaseProgress()
    {
        if (currentValue > 0f)
        {
            currentValue -= decreaseSpeed * Time.deltaTime;
            meshProgress.value = currentValue;
        }
        else
        {
            currentValue = 0f;
            meshProgress.value = 0f;
        }
    }

    public void OnMash()
    {
        currentValue += 0.1f; // Tambahkan nilai saat tombol ditekan
        if (currentValue >= 100f ){
            currentValue = 100f;
        }
        meshProgress.value = currentValue; 

        if (meshProgress.value >= 1)
        {
            OnProgressFull();
            
        }
    }

    private void OnProgressFull()
    {
        decreaseActive = false;
        Interact();
    }

    public override void SetActiveInteractable(bool isActive)
    {
        if (isActive)
        {
            currentValue = 0f;
            meshProgress.value = 0f;
        }

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
