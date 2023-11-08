using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[CreateAssetMenu(fileName ="New Skill", menuName = "Skill System/Skill")]
public class SkillObject : ScriptableObject
{
    public int SkillPoint;
    ////////////////////////////   패시브 스킬
    [Header("자석")]
    public int MagnetLv;
    public int MagnetCurExp;
    public int MagnetMaxExp;

    [Header("사거리")]
    public int ViewRadiusLv;
    public float SkillViewRadius;    
    public int ViewRadiusCurExp;
    public int ViewRadiusMaxExp;

    [Header("공속")]
    public int AttackSpeedLv;
    public int SkillAttackSpeed;    
    public int AttackSpeedCurExp;
    public int AttackSpeedMaxExp;

    [Header("공격")]
    public int AttackLv;
    public int SkillAttack;    
    public int AttackCurExp;
    public int AttackMaxExp;

    [Header("치확")]
    
    public int CriticalLv;
    public int SkillCritical;
    public int CriticalCurExp;
    public int CriticalMaxExp;

    ////////////////////////////   보조 스킬

    [Header("힐")]
    
    public int HealLv;
    public int HealingAmount;
    public int HealCurExp;
    public int HealMaxExp;
    public int HealUseMP;
    public float HealCooltime;    

    [Header("헤이스트")]
    
    public int MoveSpeedLv;
    public int SkillMoveSpeed;
    public float MoveSpeedDuring;
    public int MoveSpeedCurExp;
    public int HMoveSpeedMaxExp;
    public int MoveSpeedUseMP;
    public float MoveSpeedCooltime;

    [Header("장판")]
    public int AreaSkillLv;
    public int AreaSkillDamage;
    public float AreaSkillDuring;
    public int AreaSkillCurExp;
    public int AreaSkillMaxExp;
    public int AreaSkillUseMP;
    public float AreaSkillCooltime;

    [Header("주위회전체")]
    public int AroundSkillLv;
    public int AroundSkillDamage;
    public float AroundSkillDuring;
    public int AroundSkillCurExp;
    public int AroundSkillMaxExp;
    public int AroundSkillUseMP;
    public float AroundSkillCooltime;

    [Header("무적")]
    public int InvincibilityLv;
    public float InvincibilityDuring;
    public int InvincibilityCurExp;
    public int InvincibilityMaxExp;
    public int InvincibilityUseMP;
    public float InvincibilityCooltime;

    ////////////////////////////   공격 스킬

    [Header("멀티샷")]
    public int MultiShotLv;
    public float MultiShotDuring;
    public int MultiShotCurExp;
    public int MultiShotMaxExp;
    public int MultiShotUseMP;
    public float MultiShotCooltime;

    [Header("관통샷")]
    public int PierceShotLv;
    public int PierceShotCount;
    public int PierceShotCurExp;
    public int PierceShotMaxExp;
    public int PierceShotUseMP;
    public float PierceShotCooltime;
}
