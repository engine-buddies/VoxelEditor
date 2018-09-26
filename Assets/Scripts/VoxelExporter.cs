using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

/// <summary>
/// Exporter that will export all current scene object's position
/// so that we cna load them into the light-vox-engine with 
/// custom data formats
/// </summary>
public class VoxelExporter : MonoBehaviour
{

    public string ExportLayerName = "Export";

    private int ExportLayer = 0;


    private string OutputFileName = "scene.lve";

    private void Awake()
    {
        ExportLayer = LayerMask.NameToLayer(ExportLayerName);
    }

    /// <summary>
    /// Export all active objects in the scene to a text file
    /// </summary>
    public void ExportObjects()
    {

        GameObject[] Objs = UnityEngine.Object.FindObjectsOfType<GameObject>();

        StreamWriter s = new StreamWriter(OutputFileName);

        foreach (GameObject go in Objs)
        {
            if (go.activeInHierarchy && go.layer == ExportLayer)
            {
                string val = go.transform.position.ToString();
                Debug.Log("Position: " + val);

                s.WriteLine(val);
            }
        }

        s.Close();
                   
    }
}
