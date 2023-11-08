using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TipText : MonoBehaviour
{
    public Text _Text;
    void OnEnable()
    {
        // �� �Ŵ����� sceneLoaded�� ü���� �Ǵ�.
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {        
        InvokeRepeating("Textupdate", 0.1f, 3.0f);
    }
    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    public void Textupdate()
    {
        int ran = Random.Range(0, 13);
        if (ran < 1)
        {
            _Text.text = "���������� ������ ������ ������� ���� 5���� ��� �޽��ϴ�.";
        }
        else if (ran < 2)
        {
            _Text.text = "STR �� ���ݷ�, CON�� �ִ�ü��, DEX�� ���ݼӵ�, INT�� �ִ븶��, LUK�� ġ��ŸȮ���� ��½����ݴϴ�.";
        }
        else if (ran < 3)
        {
            _Text.text = "���۹��� ������ ����Ʈ�� ��͵� ������ �����Ǿ� �ֽ��ϴ�.";
        }
        else if (ran < 4)
        {
            _Text.text = "�� ���������� �⺻ �ɷ�ġ�� ���� �ٸ��ϴ�.";
        }
        else if (ran < 5)
        {
            _Text.text = "'������ �����'�� �ټ��� ���� ����ϱ� ���մϴ�. (������ ����)";
        }
        else if (ran < 6)
        {
            _Text.text = "'���׳�'��ų�� ������ ȹ���� ���Ǽ��� ��� �����ݴϴ�.(������ ����)";
        }
        else if (ran < 7)
        {
            _Text.text = "�κ��丮�� ������ ���� ���Ͱ� �����, ü�°� ����ȸ���� ������ �ݴϴ�.";
        }
        else if (ran < 8)
        {
            _Text.text = "�߿�!! ���� ��û�� �����ڰ� ������ ��ϴµ� ū ������ �˴ϴ�.";
        }
        else if (ran < 9)
        {
            _Text.text = "�Ϲ� ���ʹ� 50 ~ 100���, ����Ʈ ���ʹ� 5,000���, ���� ���ʹ� 10,000��带 ����Ѵ�.";
        }
        else if (ran < 10)
        {
            _Text.text = "��� ��ȭ�� Ư������ �߰��ϸ� ���� �ɷ�ġ�� 2��(5���� ��� 3��)�� ��½����ش�.";
        }
        else if (ran < 11)
        {
            _Text.text = "������ ��ȭ�� �����ϸ� ���� �ɷ�ġ�� 2�谡 ����Ѵ�.";
        }
        else
        {
            _Text.text = "�߿�!! ���� ��û�� �����ڰ� ������ ��ϴµ� ū ������ �˴ϴ�.";
        }

    }
}
