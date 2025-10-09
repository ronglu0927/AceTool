using CodeMonkey.Utils;
using UnityEngine;

public class GridTest : MonoBehaviour
{
    private Grid mGrid;

    void Start()
    {
        // AceFox
        mGrid = new Grid(3, 3, 3, this.transform.position);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            mGrid.SetValue(UtilsClass.GetMouseWorldPosition(), 52);
        }
        if (Input.GetMouseButtonDown(1))
        {
            int value = mGrid.GetValue(UtilsClass.GetMouseWorldPosition());
        }
    }
}
