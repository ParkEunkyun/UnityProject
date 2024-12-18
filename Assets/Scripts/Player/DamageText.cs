using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DamageText : MonoBehaviour
{
    public float moveSpeed;
    public float alphaSpeed;
    public float destroyTime;
    TextMeshPro text;
    Color alpha;
    public int damage;

    public AudioClip AttackSound;
    private AudioSource audioSource;
    void Start()
    {
        text = GetComponent<TextMeshPro>();
        //alpha = text.color;
        //text.text = damage.ToString();
        Invoke("DestroyObject", destroyTime);
    }

    void OnEnable()
    {
        audioSource = GetComponent<AudioSource>();
        text = GetComponent<TextMeshPro>();
        if (!audioSource.isPlaying)
        {
            audioSource.PlayOneShot(AttackSound);
        }
        //alpha = text.color;
        //text.text = damage.ToString();
        Invoke("DestroyObject", destroyTime);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(0, moveSpeed * Time.deltaTime, 0));
        //alpha.a = Mathf.Lerp(alpha.a, 0, Time.deltaTime * alphaSpeed);
        //text.color = alpha;
        
    }

    private void DestroyObject()
    {        
        DamageObjectPool.ReturnObject(this.gameObject);
        //Destroy(gameObject);        
    }
}
