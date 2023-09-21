using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.RuleTile.TilingRuleOutput;

public struct GridBox
{
    public Vector3 centerPosition;
    public Vector2 size;

    public bool IsInPosition(Vector3 targetPosition)
    {
        if (targetPosition.x < centerPosition.x - size.x
            || targetPosition.x > centerPosition.x + size.x)
            return false;

        if (targetPosition.y < centerPosition.y - size.y
            || targetPosition.y > centerPosition.y + size.y)
            return false;

        return true;
    }

    public Vector2Int GetRepositionDirection(Vector3 targetPosition)
    {
        if (targetPosition.x < centerPosition.x - size.x && targetPosition.y > centerPosition.y + size.y)       // ���� ��� �밢��
            return new Vector2Int(-1, 1);
        else if (targetPosition.x > centerPosition.x + size.x && targetPosition.y > centerPosition.y + size.y)  // ������ ��� �밢��
            return new Vector2Int(1, 1);
        else if(targetPosition.x > centerPosition.x + size.x && targetPosition.y < centerPosition.y - size.y)   // ������ �ϴ� �밢��
            return new Vector2Int(1, -1);
        else if(targetPosition.x < centerPosition.x - size.x && targetPosition.y < centerPosition.y - size.y)   // ���� �ϴ� �밢��
            return new Vector2Int(-1, -1);
        else if(targetPosition.x < centerPosition.x - size.x)   // ����
            return new Vector2Int(-1, 0);
        else if(targetPosition.x > centerPosition.x + size.x)   // ������
            return new Vector2Int(1, 0);
        else if(targetPosition.y > centerPosition.y + size.y)   // ��
            return new Vector2Int(0, 1);
        else if(targetPosition.y < centerPosition.y - size.y)   // �Ʒ�
            return new Vector2Int(0, -1);


        return Vector2Int.zero;
    }
}

public class GridSystem : MonoBehaviour
{
    public static float tileSize = 40.0f;    
    public static float tiletileHalfSizeSize = 20.0f;

    public List<GameObject> tileList = new List<GameObject>();

    private GridBox _gridBox = new GridBox();

    Movement Char;

    private void Start()
    {
        Char = GameObject.Find("Char").GetComponent<Movement>();

        _gridBox.centerPosition = Vector3.zero;
        _gridBox.size = new Vector2(tiletileHalfSizeSize, tiletileHalfSizeSize);
    }


    private void Update()
    {
        Vector3 charPosition = Char.transform.position;

        if (_gridBox.IsInPosition(charPosition) == true)
            return;

        Vector2Int direction = _gridBox.GetRepositionDirection(charPosition);

        for (int i = 0; i < tileList.Count; i++)
            tileList[i].transform.Translate(direction.x * tileSize, direction.y * tileSize, 0);

        _gridBox.centerPosition += new Vector3(direction.x * tileSize, direction.y * tileSize, 0.0f);
    }
}
