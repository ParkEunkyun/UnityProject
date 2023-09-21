using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class BulletSkill : MonoBehaviour
{
    public SkillObject _skill;
    public bool Active = false;
    public static int pierceStack;

    public Stat _stat;
    public float timer;
    public Slider MPbar;
    public Text MPtext;
    public GameObject OnSkill;
    public GameObject OffSkill;
    //public int pCounts;
    private void Start()
    {
        pierceStack = 0;
        coolTime = _skill.PierceShotCooltime - _stat.Cooltime;
        this.textCoolTime.gameObject.SetActive(false);
        this.imgFill.fillAmount = 0;
    }

    void Update()
    {
        if (Active && _stat.curMP != 0)
        {
            timer += Time.deltaTime;
            if (timer >= 1f)
            {
                _stat.curMP = _stat.curMP - (4 * _skill.PierceShotCount);
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
    public void ActivePierceShot()
    {
        if (this.coolTimeRoutine != null)
        {
            Debug.Log("쿨타임 중입니다...");
            return;
        }
        else
        {
            if (_skill.PierceShotCount == 0 || _stat.curMP < (4 * _skill.PierceShotCount))
            {
                return;
            }
            else
            {
                Active = true;
                pierceStack = _skill.PierceShotCount;
            }
            OffSkill.SetActive(true);
            OnSkill.SetActive(false);
            //Invoke("pierceShotTime", 10f);
            Debug.Log(pierceStack);
        }
    }
    public void UnActiveSkill()
    {
        Active = false;
        pierceStack = 0;
        OffSkill.SetActive(false);
        OnSkill.SetActive(true);
        Cooltime();
        Debug.Log(pierceStack);
    }

    public Button btn;
    public float coolTime;
    public TMP_Text textCoolTime;

    private Coroutine coolTimeRoutine;

    public Image imgFill;


    public void Init()
    {
        coolTime = _skill.PierceShotCooltime - _stat.Cooltime;
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
