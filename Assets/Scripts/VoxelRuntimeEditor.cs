using UnityEngine;

/// <summary>
/// Runtime editor for the voxel editor, to edit levels
/// for the light vox engine
/// </summary>
public class VoxelRuntimeEditor : MonoBehaviour
{

    public GameObject[] VoxelPallete;

    public int SelectedPaintVoxel = 0;

    void Update ()
    {
	    // If the user has clicked
        if(Input.GetMouseButtonDown(0))
        {
            PaintVoxel();
        }

        // TODO: Check for number input from the keyboard to select
        // A different voxel prefab

    }

    /// <summary>
    /// Check if we should be spawning a voxel at the current mouse position
    /// If so, then spawn one quickly
    /// </summary>
    private void PaintVoxel()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            //draw invisible ray cast/vector
            Debug.DrawLine(ray.origin, hit.point);

            //  Spawn an object at this location
            Vector3 spawnPos = hit.point;

            spawnPos.x = Mathf.Floor(spawnPos.x);
            spawnPos.y = Mathf.Floor(spawnPos.y);
            spawnPos.z = Mathf.Floor(spawnPos.z);

            Instantiate(VoxelPallete[SelectedPaintVoxel], spawnPos, Quaternion.identity);

        }
    }

}
