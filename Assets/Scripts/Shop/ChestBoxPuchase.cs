using Cainos.PixelArtPlatformer_VillageProps;
using EZInventory;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChestBoxPuchase : MonoBehaviour
{

    public RecipeDataBase recipeData;
    public Text goldtext;
    public Text Rubytext;
    public Text Crystaltext;
    public bool isPuchase;

    public GameObject Back;
    public GameObject protector;
    public GameObject NomalBox;
    public GameObject RareBox;
    public GameObject PremiumBox;

    public Sprite[] nomalBoxSprite;
    public Sprite[] rareBoxSprite;
    public Sprite[] premiumBoxSprite;
    private void OnEnable()
    {
        isPuchase = true;
    }

    public void Chestbox500ActiveTure()  // �������� Ŭ��
    {
        Back.SetActive(true);
        NomalBox.SetActive(true);
    }
    public void Chestbox500ActiveFalse() //���� ��
    {
        Back.SetActive(false);
        NomalBox.SetActive(false);
        PremiumBox.SetActive(false);
        RareBox.SetActive(false);
    }
    public void Chestbox500Puchase() // �Ϲ� �������� Ŭ�� ��
    {
        protector.SetActive(true);

        StartCoroutine("ChangeImage500");

        Invoke("Chestbox500ActiveFalse", 2.0f);

        if (isPuchase)
        {
            isPuchase = false;
            DataManager.instance.nowPlayer.RubbyPoint -= 500;
            Textudate();

            for (int i = 0; i < 5; i++)
            {
                int ran = Random.Range(0, 2);
                ItemSO item = recipeData.RecipeItem[ran];
                EZInventory.InventoryManager.instance.AddItemToInventory(item, 1);
            }
            Invoke("isPuchasetrue", 2.0f);
            
        }
    }
    IEnumerator ChangeImage500() // �������� ������ ����Ʈ
    { 

        for (int i = 0; i < 8; i++)
        {
            NomalBox.GetComponent<Image>().sprite = nomalBoxSprite[i];
            yield return new WaitForSeconds(0.15f);
        }        
    }
    /////////////////////////////////////////////////////////////////////

    public void Chestbox1000ActiveTure()  // �������� Ŭ��
    {
        Back.SetActive(true);
        RareBox.SetActive(true);
    }

    public void Chestbox1000Puchase() // ��ͺ������� Ŭ�� ��
    {
        protector.SetActive(true);
        StartCoroutine("ChangeImage1000");

        Invoke("Chestbox500ActiveFalse", 2.0f);


        if (isPuchase)
        {
            isPuchase = false;
            DataManager.instance.nowPlayer.RubbyPoint -= 1000;
            Textudate();

            for (int i = 0; i < 10; i++)
            {
                int ran = Random.Range(0, 2);
                ItemSO item = recipeData.RecipeItem[ran];
                EZInventory.InventoryManager.instance.AddItemToInventory(item, 1);
            }

            Invoke("isPuchasetrue", 2.0f);
        }
    }

    IEnumerator ChangeImage1000() // �������� ������ ����Ʈ
    {
        for (int i = 0; i < 8; i++)
        {
            RareBox.GetComponent<Image>().sprite = rareBoxSprite[i];
            yield return new WaitForSeconds(0.15f);
        }
    }



    public void PremiumActiveTure()  // �������� Ŭ��
    {
        Back.SetActive(true);
        PremiumBox.SetActive(true);
    }
    public void PremiumPuchase() // ���Ź�ư Ŭ�� ��
    {
        protector.SetActive(true);
        StartCoroutine("PremiumImage");

        Invoke("Chestbox500ActiveFalse", 2.0f);


        if (isPuchase)
        {
            isPuchase = false;
            DataManager.instance.nowPlayer.CrystalPoint -= 100;
            Textudate();

            for (int i = 0; i < 10; i++)
            {
                int ran = Random.Range(0, 101);
                if (ran < 91)
                {
                    int rann = Random.Range(0, 2);
                    ItemSO item = recipeData.RecipeItem[rann];
                    EZInventory.InventoryManager.instance.AddItemToInventory(item, 1);
                }
                else
                {
                    int rannn = Random.Range(0, 1001); 
                    if(rannn < 701) // �븻
                    {
                        int rannnn = Random.Range(0, 10);// 7%
                        DataManager.instance.AddNewEquipItem(rannnn);
                    }
                    else if (rannn < 901) // ����
                    {
                        int rannnn = Random.Range(10, 20);// 2%
                        DataManager.instance.AddNewEquipItem(rannnn);
                    }
                    else if (rannn < 981) // ����
                    {
                        int rannnn = Random.Range(20, 25);// 1.6%
                        DataManager.instance.AddNewEquipItem(rannnn);
                    }
                    else if (rannn < 1000) // ����ũ
                    {
                        int rannnn = Random.Range(25, 28);//0.5%
                        DataManager.instance.AddNewEquipItem(rannnn);
                    }
                    else // ��������
                    {
                        int rannnn = Random.Range(29, 30);//0.1%
                        DataManager.instance.AddNewEquipItem(rannnn);
                    }

                }
            }

            Invoke("isPuchasetrue", 2.0f);
        }
    }

    IEnumerator PremiumImage() // �������� ������ ����Ʈ
    {
        for (int i = 0; i < 8; i++)
        {
            PremiumBox.GetComponent<Image>().sprite = premiumBoxSprite[i];
            yield return new WaitForSeconds(0.15f);
        }
    }


    public void isPuchasetrue()
    {
        isPuchase = true;
        protector.SetActive(false);
    }


    public void Textudate()
    {
        string goldFomat = string.Format("{0:#,0}", DataManager.instance.nowPlayer.gold);
        goldtext.text = goldFomat;

        string RubyFomat = string.Format("{0:#,0}", DataManager.instance.nowPlayer.RubbyPoint);
        Rubytext.text = RubyFomat;

        string CrystalFomat = string.Format("{0:#,0}", DataManager.instance.nowPlayer.CrystalPoint);
        Crystaltext.text = CrystalFomat;
    }
}
