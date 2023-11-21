using System.Collections;
using System.Collections.Generic;
using Google.XR.ARCoreExtensions;
using UnityEngine;

public class StreetScapeBehaviorManager : MonoBehaviour
{
    public Material streetscapeGeometryMaterial;
    
    [SerializeField]
    private ARStreetscapeGeometryManager streetscapeGeometryManager;
    List<ARStreetscapeGeometry> _addedStreetscapeGeometries = new List<ARStreetscapeGeometry>();
    List<ARStreetscapeGeometry> _updatedStreetscapeGeometries = new List<ARStreetscapeGeometry>();
    List<ARStreetscapeGeometry> _removedStreetscapeGeometries = new List<ARStreetscapeGeometry>();

    public void OnEnable()
    {
        streetscapeGeometryManager.StreetscapeGeometriesChanged +=
            GetStreetscapeGeometry;
    }

    public void Update()
    {
        foreach (ARStreetscapeGeometry streetscapegeometry in _addedStreetscapeGeometries)
        {
            GameObject renderObject = new GameObject(
               "StreetscapeGeometryMesh", typeof(MeshFilter), typeof(MeshRenderer));

            if (renderObject)
            {
                renderObject.transform.position = streetscapegeometry.pose.position;
                renderObject.transform.rotation = streetscapegeometry.pose.rotation;
                renderObject.GetComponent<MeshFilter>().mesh = streetscapegeometry.mesh;
                renderObject.GetComponent<MeshRenderer>().material = streetscapeGeometryMaterial;
            }
        }
    }

    public void OnDisable()
    {
        streetscapeGeometryManager.StreetscapeGeometriesChanged -=
            GetStreetscapeGeometry;
    }

    private void GetStreetscapeGeometry(ARStreetscapeGeometriesChangedEventArgs eventArgs)
    {
        _addedStreetscapeGeometries = eventArgs.Added;
        _updatedStreetscapeGeometries = eventArgs.Updated;
        _removedStreetscapeGeometries = eventArgs.Removed;
    }
}