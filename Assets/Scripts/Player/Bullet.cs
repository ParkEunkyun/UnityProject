using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    AutoThrowing _AutoThrowing;
    WeaponChange _weaponchange;  
    public float destroytime;    
    public int pierceCount;
   
    void Awake()
    {
        //Destroy(this.gameObject, 3f);
        destroytime = 0;
        _weaponchange = GameObject.Find("BulletPool").GetComponent<WeaponChange>();        
    }
    // Update is called once per frame
    void Update()
    {
        transform.up = GetComponent<Rigidbody2D>().velocity;
        destroytime += Time.deltaTime;
        if(destroytime >= 5)
        {
            destroytime = 0;          
            ObjectPool.ReturnObject(this);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {        
        if(other.gameObject.tag.Equals("Enemy"))
        {            
            if(pierceCount > 0)          
            {
                pierceCount --;
            }
            else if(pierceCount == 0)
            {
                destroytime = 0;
                ObjectPool.ReturnObject(this);
            }                      
        }
        else if(other.gameObject.tag.Equals("wall"))
        {
            destroytime = 0;
            ObjectPool.ReturnObject(this);
        }
    }

    private void OnEnable() 
    {
        pierceCount = BulletSkill.pierceStack;
        if(DataManager.instance.equipmentObject.Slots[1].item.id == 20) {_weaponchange.Itemcode50001();}
        else if(DataManager.instance.equipmentObject.Slots[1].item.id == 21) {_weaponchange.Itemcode50002();}
        else if(DataManager.instance.equipmentObject.Slots[1].item.id == 22) {_weaponchange.Itemcode50003();}
        else if(DataManager.instance.equipmentObject.Slots[1].item.id == 23) {_weaponchange.Itemcode50004();}
        else if(DataManager.instance.equipmentObject.Slots[1].item.id == 24) {_weaponchange.Itemcode50005();}
        else if(DataManager.instance.equipmentObject.Slots[1].item.id == 25) {_weaponchange.Itemcode50006();}
        else if(DataManager.instance.equipmentObject.Slots[1].item.id == 26) {_weaponchange.Itemcode50007();}
        else if(DataManager.instance.equipmentObject.Slots[1].item.id == 27) {_weaponchange.Itemcode50008();}
        else if(DataManager.instance.equipmentObject.Slots[1].item.id == 28) {_weaponchange.Itemcode50009();}
        else if(DataManager.instance.equipmentObject.Slots[1].item.id == -1) {_weaponchange.Itemcode50000();}  
    }


    

   /* private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag.Equals("wall"))
        {
            Destroy(this.gameObject); 
        }
        else if(other.gameObject.tag.Equals("Enemy"))
        {
            _FieldOfView = GameObject.Find("Player").GetComponent<FieldOfView>();
            _Damage = GameObject.FindWithTag("Enemy").GetComponent<Damage>();
            if(_Damage.enemyHP.value > 0)
            {                 
                _Damage.enemyHP.value = _Damage.enemyHP.value - _FieldOfView.Dmg;
                //Destroy(this.gameObject); 
                //Debug.Log("데미지" + _FieldOfView.Dmg);
            }
            if (_Damage.enemyHP.value <= 0)
            {                
                other.gameObject.SetActive(false);
                MonsterSpawner.instance.InsertQueue(other.gameObject);                                
            }
            Destroy(this.gameObject);
        }
    }  */  
}

