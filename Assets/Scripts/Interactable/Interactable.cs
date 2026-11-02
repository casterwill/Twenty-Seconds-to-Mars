using System;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    private ControlPanel controlPanel;

    protected virtual void Start()
    {
        controlPanel = ControlPanel.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Interact()
    {   
        controlPanel.AddInteraction();
        SetActiveInteractable(false);
    }

    public virtual void SetActiveInteractable(bool isActive)
    {

    }

    public virtual void SetReadyColor(Color color)
    {

    }

    public virtual void SetDefaultColor(Color color)
    {

    }
}
