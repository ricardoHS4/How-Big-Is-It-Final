using System;
using System.Collections;
using System.Collections.Generic;
using Unity.XR.CoreUtils;
using UnityEngine;

public class ModelsManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject modelsParent;
    private GameObject[] modelsList;

    [SerializeField]
    private GameObjectsController gameObjectsController;

    void Start(){
        Transform parentTransform = modelsParent.transform;
        List<GameObject> tempList = new();

        for (int i = 0; i < parentTransform.childCount; i++)
        {
            GameObject child = parentTransform.GetChild(i).gameObject;
            tempList.Add(child);
        }
        modelsList = tempList.ToArray();
;
    }

    public void ShowModel(int index)
    {
        if (true)
        {
            gameObjectsController.HideGameObjects(modelsList);
        }
        modelsList[index].SetActive(true);
    }

    public void ShowModelBySliderValue(float value)
    {
        int index = (int)Math.Round(value * (modelsList.Length-1));
        ShowModel(index);
    }
}
