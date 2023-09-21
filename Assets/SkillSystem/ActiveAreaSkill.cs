using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ActiveAreaSkill : MonoBehaviour
{
    public SkillObject _skill;
    //public float AreaSkilltimer = 0;
    public bool Active = false;
    public GameObject[] AreaLv;
    public Stat _stat;
    public float timer;    
    public Slider MPbar;
    public Text MPtext;
    public GameObject OnSkill;
    public GameObject OffSkill;
    
    private void Update()
    {       

        if(Active && _stat.curMP != 0)
        {
            timer += Time.deltaTime;
            //AreaSkilltimer += Time.deltaTime;            
            if(timer >= 1f)
            {
                _stat.curMP = _stat.curMP - (8*_skill.AreaSkillLv);
                MPbar.value = _stat.curMP;
                MPtext.text = MPbar.value.ToString() + " / " + _stat.maxMP.ToString();
                timer = 0;
            }
        }
        
        if(_stat.curMP <= 0 && Active)
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
            if (_skill.AreaSkillLv == 0 || _stat.curMP < 8 * _skill.AreaSkillLv)
            {
                return;
            }
            else
            {

                for (int i = 1; i < 7; i++)
                {
                    if (_skill.AreaSkillLv == i)
                    {
                        Active = true;
                        AreaLv[i].SetActive(true);
                    }
                }
                OffSkill.SetActive(true);
                OnSkill.SetActive(false);
            }
        }
    }
    public void UnActiveSkill()
    {
        for(int i = 1; i < 7; i++)
        {
            if(_skill.AreaSkillLv == i)
            {
                Active = false;
                AreaLv[i].SetActive(false);
                //AreaSkilltimer = 0;
            }               
        }
        OffSkill.SetActive(false);
        OnSkill.SetActive(true);
        Cooltime();

    }

    public Button btn;
    public float coolTime;
    public TMP_Text textCoolTime;

    private Coroutine coolTimeRoutine;

    public Image imgFill;

    private void Start()
    {
        coolTime = _skill.AreaSkillCooltime - _stat.Cooltime;
        this.textCoolTime.gameObject.SetActive(false);
        this.imgFill.fillAmount = 0;
    }
    public void Init()
    {
        coolTime = _skill.AreaSkillCooltime - _stat.Cooltime;
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
