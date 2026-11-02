using System.Collections;
using UnityEngine;

public class ControlPanel : MonoBehaviour
{
    [SerializeField] private Color readyColor;

    [SerializeField] private Interactable[] interactables;

    [SerializeField] private int interactionTarget;
    private int interactionProgress = 0;

    public static ControlPanel Instance;
    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Instance = null;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ReadyRandomInteractable();
    }

    private void ReadyRandomInteractable()
    {
        int randomIndex = Random.Range(0, interactables.Length);

        foreach (Interactable interactable in interactables)
        {
            if (interactable != null)
            {
                if (interactable == interactables[randomIndex])  
                {
                    interactable.SetReadyColor(readyColor);
                    interactable.SetActiveInteractable(true);
                    Debug.Log("Ready Interactable: " + interactable.name);
                }
                else
                {
                    interactable.SetReadyColor(Color.white);
                    interactable.SetActiveInteractable(false);
                }
            }
        }
    }

    public void AddInteraction()
    {
        interactionProgress++;
        StartCoroutine(PrepareForNextInteraction());
    }

    private IEnumerator PrepareForNextInteraction()
    {
        yield return new WaitForSeconds(.5f);
        ReadyRandomInteractable();
    }
}
