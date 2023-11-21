using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectActivatorManager : MonoBehaviour
{
    public GameObject[] gameObjectsToToggle;
    public GameObject[] gameObjectsToToggleInversed;
    public bool activateOnEnter = false;
    public bool deactivateOnExit = false;
    public bool activateOnClick = false;
    public bool deactivateOnClick = false;
    private void OnTriggerEnter(Collider other)
    {
        if (activateOnEnter)
        {
            SetActiveToAll(true);
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (deactivateOnExit)
        {
            SetActiveToAll(false);
        }

    }

    private void OnMouseDown()
    {
        if (activateOnClick)
        {
            SetActiveToAll(true);
        }
        if (deactivateOnClick)
        {
            SetActiveToAll(false);
        }

    }
    private void SetActiveToAll(bool active)
    {
        foreach (GameObject gameObject in gameObjectsToToggle)
        {
            gameObject.SetActive(active);
        }
        foreach (GameObject gameObject in gameObjectsToToggleInversed)
        {
            gameObject.SetActive(!active);
        }

    }

    public void DeactivateAllObjects()
    {
        SetActiveToAll(false);
    }
    public void ActivateAllObjects()
    {
        SetActiveToAll(true);
    }
}
