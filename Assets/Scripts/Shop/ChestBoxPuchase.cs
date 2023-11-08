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
    public GameObject Alert;
    public Text AlertText;
    public GameObject NomalBox;
    public GameObject RareBox;
    public GameObject PremiumBox;

    public Sprite[] nomalBoxSprite;
    public Sprite[] rareBoxSprite;
    public Sprite[] premiumBoxSprite;

    public GameObject result500;
    public GameObject[] resultImage500;

    public GameObject result1000;
    public GameObject[] resultImage1000;

    public GameObject resultPremium;
    public GameObject[] resultImagePremium;

    public GameObject inventory;
    public GameObject Characterwin;

    public AudioClip ItemSound;
    public AudioSource audioSource;

    private void OnEnable()
    {
        isPuchase = true;
    }

    public void Chestbox500ActiveTure()  // 상점에서 클릭
    {
        if (DataManager.instance.nowPlayer.RubbyPoint >= 500)
        {
            Back.SetActive(true);
            NomalBox.SetActive(true);

            NomalBox.GetComponent<Image>().sprite = nomalBoxSprite[0];
        }
        else
        {
            Alert.SetActive(true);
            AlertText.text = "루비가 부족합니다.";

            Invoke("isPuchasetrue", 2.0f);
        }
    }
    public void Chestbox500ActiveFalse() //닫을 때
    {        
        NomalBox.SetActive(false);
        PremiumBox.SetActive(false);
        RareBox.SetActive(false);
    }
    public void ClosedBack() //닫을 때
    {
        Back.SetActive(false);
        result500.SetActive(false);
        result1000.SetActive(false);
        resultPremium.SetActive(false);
        NomalBox.SetActive(false);
        PremiumBox.SetActive(false);
        RareBox.SetActive(false);
    }
    public void Chestbox500Puchase() // 일반 보물상자 클릭 시
    {
        protector.SetActive(true);
        Characterwin.SetActive(true);
        inventory.SetActive(true);
        StartCoroutine("ChangeImage500");

        Invoke("Chestbox500ActiveFalse", 2.0f);

        if (isPuchase)
        {
            isPuchase = false;

            DataManager.instance.nowPlayer.RubbyPoint -= 500;
            Textudate();

            for (int i = 0; i < 5; i++)
            {
                int ran = Random.Range(0, recipeData.RecipeItem.Length);
                ItemSO item = recipeData.RecipeItem[ran];
                EZInventory.InventoryManager.instance.AddItemToInventory(item, 1);
                resultImage500[i].GetComponent<Image>().sprite = item.itemSlotSprite;
            }
            Invoke("resultChestbox500", 2.0f);
            Invoke("isPuchasetrue", 2.0f);
        }
        DataManager.instance.SaveData();
    }
    IEnumerator ChangeImage500() // 보물상자 열리는 이펙트
    {
        audioSource.PlayOneShot(ItemSound);
        for (int i = 0; i < 7; i++)
        {
            NomalBox.GetComponent<Image>().sprite = nomalBoxSprite[i];
            yield return new WaitForSeconds(0.5f);
        }
    }

    public void resultChestbox500()
    {
        result500.SetActive(true);
    }

    /////////////////////////////////////////////////////////////////////


    public void Chestbox1000ActiveTure()  // 상점에서 클릭
    {
        if (DataManager.instance.nowPlayer.RubbyPoint >= 1000)
        {
            Back.SetActive(true);
            RareBox.SetActive(true);

            RareBox.GetComponent<Image>().sprite = rareBoxSprite[0];
        }
        else
        {
            Alert.SetActive(true);
            AlertText.text = "루비가 부족합니다.";

            Invoke("isPuchasetrue", 2.0f);
        }
    }

    public void Chestbox1000Puchase() // 희귀보물상자 클릭 시
    {
        protector.SetActive(true);
        Characterwin.SetActive(true);
        inventory.SetActive(true);
        StartCoroutine("ChangeImage1000");

        Invoke("Chestbox500ActiveFalse", 2.0f);


        if (isPuchase)
        {
            isPuchase = false;

            DataManager.instance.nowPlayer.RubbyPoint -= 1000;
            Textudate();

            for (int i = 0; i < 10; i++)
            {
                int ran = Random.Range(0, recipeData.RecipeItem.Length);
                ItemSO item = recipeData.RecipeItem[ran];
                EZInventory.InventoryManager.instance.AddItemToInventory(item, 1);
                resultImage1000[i].GetComponent<Image>().sprite = item.itemSlotSprite;
            }

            Invoke("resultChestbox1000", 2.0f);

            Invoke("isPuchasetrue", 2.0f);
        }
        DataManager.instance.SaveData();
    }

    IEnumerator ChangeImage1000() // 보물상자 열리는 이펙트
    {
        audioSource.PlayOneShot(ItemSound);
        for (int i = 0; i < 7; i++)
        {
            RareBox.GetComponent<Image>().sprite = rareBoxSprite[i];
            yield return new WaitForSeconds(0.5f);
        }
    }

    public void resultChestbox1000()
    {
        result1000.SetActive(true);
    }



    public void PremiumActiveTure()  // 상점에서 클릭
    {
        if (DataManager.instance.nowPlayer.CrystalPoint >= 100)
        {
            Back.SetActive(true);
            PremiumBox.SetActive(true);

            PremiumBox.GetComponent<Image>().sprite = premiumBoxSprite[0];
        }
        else
        {
            Alert.SetActive(true);
            AlertText.text = "크리스탈이 부족합니다.";
        }
    }
    public void PremiumPuchase() // 구매버튼 클릭 시
    {
        protector.SetActive(true);
        Characterwin.SetActive(true);
        inventory.SetActive(true);
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
                    int rann = Random.Range(0, recipeData.RecipeItem.Length);
                    ItemSO item = recipeData.RecipeItem[rann];
                    EZInventory.InventoryManager.instance.AddItemToInventory(item, 1);
                    resultImagePremium[i].GetComponent<Image>().sprite = item.itemSlotSprite;
                }
                else
                {
                    int rannn = Random.Range(0, 1001);
                    if (rannn < 701) // 노말
                    {
                        int rannnn = Random.Range(0, 10);// 7%
                        DataManager.instance.AddNewEquipItem(rannnn);
                        resultImagePremium[i].GetComponent<Image>().sprite = DataManager.instance.databaseObject.itemObjects[rannnn].icon;
                    }
                    else if (rannn < 901) // 레어
                    {
                        int rannnn = Random.Range(10, 20);// 2%
                        DataManager.instance.AddNewEquipItem(rannnn);
                        resultImagePremium[i].GetComponent<Image>().sprite = DataManager.instance.databaseObject.itemObjects[rannnn].icon;
                    }
                    else if (rannn < 981) // 에픽
                    {
                        int rannnn = Random.Range(20, 25);// 1.6%
                        DataManager.instance.AddNewEquipItem(rannnn);
                        resultImagePremium[i].GetComponent<Image>().sprite = DataManager.instance.databaseObject.itemObjects[rannnn].icon;
                    }
                    else if (rannn < 1000) // 유니크
                    {
                        int rannnn = Random.Range(25, 28);//0.5%
                        DataManager.instance.AddNewEquipItem(rannnn);
                        resultImagePremium[i].GetComponent<Image>().sprite = DataManager.instance.databaseObject.itemObjects[rannnn].icon;
                    }
                    else // 레전더리
                    {
                        int rannnn = Random.Range(29, 30);//0.1%
                        DataManager.instance.AddNewEquipItem(rannnn);
                        resultImagePremium[i].GetComponent<Image>().sprite = DataManager.instance.databaseObject.itemObjects[rannnn].icon;
                    }

                }
            }
            Invoke("resultChestboxPremium", 2.0f);

            Invoke("isPuchasetrue", 2.0f);
        }
        DataManager.instance.SaveData();
    }

    IEnumerator PremiumImage() // 보물상자 열리는 이펙트
    {
        audioSource.PlayOneShot(ItemSound);
        for (int i = 0; i < 7; i++)
        {
            PremiumBox.GetComponent<Image>().sprite = premiumBoxSprite[i];
            yield return new WaitForSeconds(0.5f);
        }
    }

    public void resultChestboxPremium()
    {
        resultPremium.SetActive(true);
    }


    public void isPuchasetrue()
    {
        isPuchase = true;
        Alert.SetActive(false);
        protector.SetActive(false);

        DataManager.instance.SaveData();
        DataManager.instance.OnClickSaveButton();
        inventory.SetActive(false);
        Characterwin.SetActive(false);
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
