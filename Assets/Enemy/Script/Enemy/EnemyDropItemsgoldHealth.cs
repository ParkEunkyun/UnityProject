using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyDropItemsgoldHealth : MonoBehaviour
{
    Rigidbody2D r2bd;
    CircleCollider2D triger;
    Vector2 DropPow;
    SpriteRenderer sprite;
    Color alpha;
    public float alphaSpeed;
    public float destroyTime;
    float timer;
    

    // Start is called before the first frame update
    void Start()
    {
        destroyTime = 60.0f;
        StartCoroutine(DropItemTime());
        
        int updown = Random.Range(-5,5);
        int leftright = Random.Range(-5,5);

        r2bd = gameObject.GetComponent<Rigidbody2D>();
        triger = gameObject.GetComponent<CircleCollider2D>();

        DropPow = new Vector2(leftright, updown);
        this.r2bd.AddForce(DropPow, ForceMode2D.Impulse);

        sprite = GetComponent<SpriteRenderer>();
        alpha = sprite.color;        
    }
    void OnEnable()
    {
        Invoke("DestroyObject", destroyTime);
    }
    IEnumerator DropItemTime()
    {
        yield return new WaitForSeconds(0.5f);
        this.gameObject.layer = 12;
        this.GetComponent<CircleCollider2D>().isTrigger = true;
        

        yield return null;
    }

    private void Update()
    {          
        {
            if(timer >= destroyTime - 10f)         
            {
                alpha.a = Mathf.Lerp(alpha.a, 0, Time.deltaTime * alphaSpeed);
                sprite.color = alpha;
                if(alpha.a==0.0f)
                {
                    timer =0;
                }
            }
            else
            {
                timer += Time.deltaTime;
            }
        }        
    }

    private void DestroyObject()
    {
        //Destroy(gameObject);
        HealthPortionObjectPool.ReturnObject(this.gameObject);
    }
    
}

   
