using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class button_behavior : MonoBehaviour
{
    // Start is called before the first frame update
    public Sprite defaultSprite;
    public Sprite onPressedSprite;

    public void UpdateImages()
    {
        GameObject[] buttons = GameObject.FindGameObjectsWithTag("Button");
        foreach (GameObject button in buttons)
        {
            var defSprite = button.GetComponent<button_behavior>().defaultSprite;
            button.GetComponent<Image>().sprite = defSprite;
        }
        gameObject.GetComponent<Image>().sprite = onPressedSprite;


    }
}
