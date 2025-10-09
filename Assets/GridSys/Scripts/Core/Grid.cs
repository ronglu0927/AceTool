using CodeMonkey.Utils;
using UnityEngine;

public class Grid
{
    private int mWidth;
    private int mHeight;
    private int mCellCount;
    public int Count => mCellCount;
    private float mCellSize;
    private Vector3 mOrginPos;
    private int[,] mGridArr;
    private TextMesh[,] mDebugTxtArr;

    public Grid(int _width, int _height, float _cellSize, Vector3 _orginPos)
    {
        mWidth = _width;
        mHeight = _height;
        mCellSize = _cellSize;
        mOrginPos = _orginPos;
        mGridArr = new int[mWidth, mHeight];
        mDebugTxtArr = new TextMesh[mWidth, mHeight];
        for (int x = 0; x < mGridArr.GetLength(0); x++)
        {
            for (int y = 0; y < mGridArr.GetLength(1); y++)
            {
                mDebugTxtArr[x, y] = UtilsClass.CreateWorldText(
                    mGridArr[x, y].ToString(),
                    null,
                    GetWorldCenterPos(x, y),
                    20,
                    Color.white,
                    TextAnchor.MiddleCenter
                );
                Debug.DrawLine(GetWorldPos(x, y), GetWorldPos(x, y + 1), Color.white, 100);
                Debug.DrawLine(GetWorldPos(x, y), GetWorldPos(x + 1, y), Color.white, 100);
            }
        }
        Debug.DrawLine(GetWorldPos(0, mHeight), GetWorldPos(mWidth, mHeight), Color.white, 100);
        Debug.DrawLine(GetWorldPos(mWidth, 0), GetWorldPos(mWidth, mHeight), Color.white, 100);
    }

    private Vector3 GetWorldPos(int _x, int _y) => new Vector3(_x, _y) * mCellSize + mOrginPos;

    private Vector3 GetWorldCenterPos(int _x, int _y) =>
        GetWorldPos(_x, _y) + mOrginPos + new Vector3(mCellSize, mCellSize) * 0.5f;

    public void SetValue(int _x, int _y, int _value)
    {
        if (_x >= 0 && _y >= 0 && _x < mWidth && _y < mHeight)
        {
            mGridArr[_x, _y] = _value;
            mDebugTxtArr[_x, _y].text = mGridArr[_x, _y].ToString();
        }
    }

    public void SetValue(Vector3 _worldPos, int _value)
    {
        int x;
        int y;
        GetXY(_worldPos, out x, out y);
        SetValue(x, y, _value);
    }

    public void GetXY(Vector3 _worldPos, out int _x, out int _y)
    {
        _x = Mathf.FloorToInt((_worldPos - mOrginPos).x / mCellSize);
        _y = Mathf.FloorToInt((_worldPos - mOrginPos).y / mCellSize);
    }

    public int GetValue(int _x, int _y)
    {
        if (_x >= 0 && _y >= 0 && _x < mWidth && _y < mHeight)
        {
            return mGridArr[_x, _y];
        }
        return -1;
    }

    public int GetValue(Vector3 _worldPos)
    {
        int x;
        int y;
        GetXY(_worldPos, out x, out y);
        return mGridArr[x, y];
    }
}
