using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FxDestroy : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnEnable()
    {
        Invoke("FXfalse", 0.3f);
    }

    public void FXfalse()
    {
        EffectObjectPool.ReturnObject(this.gameObject);
    }

}
