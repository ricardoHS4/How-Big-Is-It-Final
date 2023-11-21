using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectsController : MonoBehaviour
{
    public void HideGameObjects(GameObject[] gameObjectsList)
    {
        foreach (GameObject gameObject in gameObjectsList)
        {
            gameObject.SetActive(false);
        }

    }

    public void HideGameObjectsByTag(string tag)
    {
        GameObject[] gameObjects = GameObject.FindGameObjectsWithTag(tag);
        HideGameObjects(gameObjects);
    }
}
