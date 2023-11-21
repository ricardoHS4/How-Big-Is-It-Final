using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextObjectController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private Text textComponent;

    public void UpdateText (string text){
        textComponent.text = text;
    }
}
