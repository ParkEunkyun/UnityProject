using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ActiveAroundSkill : MonoBehaviour
{
    public SkillObject _skill;
    //public float AroundSkilltimer = 0;
    public bool Active = false;
    public GameObject[] AroundLv;
    WeaponChange _weaponchange;

    public Stat _stat;
    public float timer;
    public Slider MPbar;
    public Text MPtext;
    public GameObject OnSkill;
    public GameObject OffSkill;

    private void Update()
    {
        if (Active && _stat.curMP != 0)
        {
            timer += Time.deltaTime;
            if (timer >= 1f)
            {
                _stat.curMP = _stat.curMP - (16 * _skill.AroundSkillLv);
                MPbar.value = _stat.curMP;
                MPtext.text = MPbar.value.ToString() + " / " + _stat.maxMP.ToString();
                timer = 0;
            }
        }

        if (_stat.curMP <= 0 && Active)
        {
            UnActiveSkill();
            timer = 0;
            _stat.curMP = 0;
        }
    }

    public void ActiveSkill()
    {
        if (this.coolTimeRoutine != null)
        {
            Debug.Log("쿨타임 중입니다...");
            return;
        }
        else
        {
            if (_skill.AroundSkillLv == 0 || _stat.curMP < (16 * _skill.AroundSkillLv))
            {
                return;
            }
            else
            {

                for (int i = 1; i < 7; i++)
                {

                    if (_skill.AroundSkillLv == i)
                    {
                        _weaponchange = AroundLv[i].GetComponent<WeaponChange>();
                        changeimage();
                        Active = true;
                        AroundLv[i].SetActive(true);
                    }
                }
                OffSkill.SetActive(true);
                OnSkill.SetActive(false);
            }
        }
    }
    public void UnActiveSkill()
    {
        for (int i = 1; i < 7; i++)
        {
            if (_skill.AroundSkillLv == i)
            {
                Active = false;
                AroundLv[i].SetActive(false);
                //timer = 0;
            }
        }
        OffSkill.SetActive(false);
        OnSkill.SetActive(true);
        Cooltime();
    }
    private void changeimage()
    {
        if (DataManager.instance.equipmentObject.Slots[1].item.id == 4) { _weaponchange.Itemcode50001(); }
        else if (DataManager.instance.equipmentObject.Slots[1].item.id == 9) { _weaponchange.Itemcode50002(); }
        else if (DataManager.instance.equipmentObject.Slots[1].item.id == 14) { _weaponchange.Itemcode50003(); }
        else if (DataManager.instance.equipmentObject.Slots[1].item.id == 19) { _weaponchange.Itemcode50004(); }
        else if (DataManager.instance.equipmentObject.Slots[1].item.id == 24) { _weaponchange.Itemcode50005(); }
        else if (DataManager.instance.equipmentObject.Slots[1].item.id == 25) { _weaponchange.Itemcode50006(); }
        else if (DataManager.instance.equipmentObject.Slots[1].item.id == 26) { _weaponchange.Itemcode50007(); }
        else if (DataManager.instance.equipmentObject.Slots[1].item.id == 27) { _weaponchange.Itemcode50008(); }
        else if (DataManager.instance.equipmentObject.Slots[1].item.id == 28) { _weaponchange.Itemcode50009(); }
        else if (DataManager.instance.equipmentObject.Slots[1].item.id == 29) { _weaponchange.Itemcode50010(); }
        else if (DataManager.instance.equipmentObject.Slots[1].item.id == 30) { _weaponchange.Itemcode50011(); }
        else if (DataManager.instance.equipmentObject.Slots[1].item.id == -1) { _weaponchange.Itemcode50000(); }
    }

    public Button btn;
    public float coolTime;
    public TMP_Text textCoolTime;

    private Coroutine coolTimeRoutine;

    public Image imgFill;

    private void Start()
    {
        coolTime = _skill.AroundSkillCooltime - _stat.Cooltime;
        this.textCoolTime.gameObject.SetActive(false);
        this.imgFill.fillAmount = 0;
    }
    public void Init()
    {
        coolTime = _skill.AroundSkillCooltime - _stat.Cooltime;
        this.textCoolTime.gameObject.SetActive(false);
        this.imgFill.fillAmount = 0;
    }
    // Start is called before the first frame update
    public void Cooltime()
    {
        this.btn = this.GetComponent<Button>();
        {
            if (this.coolTimeRoutine != null)
            {
                Debug.Log("쿨타임 중입니다...");
            }
            else
            {
                this.coolTimeRoutine = this.StartCoroutine(this.CoolTimeRoutine());
            }
        }
    }

    private IEnumerator CoolTimeRoutine()
    {
        Debug.Log(textCoolTime);
        this.textCoolTime.gameObject.SetActive(true);
        var time = this.coolTime;

        while (true)
        {
            time -= Time.deltaTime;
            this.textCoolTime.text = time.ToString("F0");

            var per = time / this.coolTime;
            //Debug.Log(per);
            this.imgFill.fillAmount = per;

            if (time <= 0)
            {
                this.textCoolTime.gameObject.SetActive(false);
                break;
            }
            yield return null;
        }

        this.coolTimeRoutine = null;
        Init();
    }
}

