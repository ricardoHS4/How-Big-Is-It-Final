using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ModelsTextController : MonoBehaviour
{
    public GameObject modelsParent;
    private GameObject[] modelsList;

    public string defaultText;
    [SerializeField]
    private Text titleObject;
    [SerializeField]
    private Text summaryObject;
    [SerializeField]
    private Text descriptionObject;
    void Start()
    {
        titleObject.text = "";
        summaryObject.text = "";
        descriptionObject.text = "";
        Transform parentTransform = modelsParent.transform;
        List<GameObject> tempList = new();

        for (int i = 0; i < parentTransform.childCount; i++)
        {
            GameObject child = parentTransform.GetChild(i).gameObject;
            tempList.Add(child);
        }
        modelsList = tempList.ToArray();

    }
    public void UpdateTitleFromProperties(int objectIndex)
    {
        if (modelsList[objectIndex].GetComponent<ModelProperties>() != null)
        {
            ModelProperties properties = modelsList[objectIndex].GetComponent<ModelProperties>();
            string text = defaultText;
            if (properties.buildingName != "")
            {
                text += $"{properties.buildingName}";
            }
            titleObject.text = text;
        }
        else
        {
            titleObject.text = "";
        }
    }
    public void UpdateSummaryFromProperties(int objectIndex)
    {
        if (modelsList[objectIndex].GetComponent<ModelProperties>() != null)
        {
            ModelProperties properties = modelsList[objectIndex].GetComponent<ModelProperties>();
            string text = defaultText;
            if (properties.buildingName != "")
            {
                text += $"{properties.location}\n";
                text += $"{properties.height}m\n";
                text += $"{properties.constructionYear}\n";
            }
            summaryObject.text = text;
        }
        else
        {
            summaryObject.text = "";
        }
    }

    public void UpdateDescriptionFromProperties(int objectIndex)
    {
        if (modelsList[objectIndex].GetComponent<ModelProperties>() != null)
        {
            ModelProperties properties = modelsList[objectIndex].GetComponent<ModelProperties>();
            string text = defaultText;
            if (properties.buildingName != "")
            {
                text += $"{properties.shortDescription}\n";
            }
            descriptionObject.text = text;
        }
        else
        {
            descriptionObject.text = "";
        }
    }

    public void UpdateTextFromPropertiesBySliderValue(float value)
    {
        int index = (int)Math.Round(value * (modelsList.Length - 1));
        UpdateDescriptionFromProperties(index);
    }
}
