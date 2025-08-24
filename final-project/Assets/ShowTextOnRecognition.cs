using UnityEngine;
using Vuforia;

public class FloatingLabelHandler : MonoBehaviour
{
    public GameObject floatingLabel; // assign in Inspector
    private ObserverBehaviour observer;

    void Start()
    {
        observer = GetComponent<ObserverBehaviour>();
        if (observer != null)
        {
            observer.OnTargetStatusChanged += OnTargetStatusChanged;
        }

        if (floatingLabel != null)
            floatingLabel.SetActive(false); // hide at start
    }

    private void OnTargetStatusChanged(ObserverBehaviour behaviour, TargetStatus status)
    {
        if (floatingLabel == null) return;

        // Show ONLY if target is actively tracked in camera view
        if (status.Status == Status.TRACKED && status.StatusInfo == StatusInfo.NORMAL)
        {
            floatingLabel.SetActive(true);
        }
        else
        {
            floatingLabel.SetActive(false); // hide immediately otherwise
        }
    }
}
