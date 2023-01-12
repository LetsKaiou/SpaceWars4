using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectBreaker : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // エフェクトが生成されて2秒後にオブジェクトを削除する
        Invoke("BreakEffect", 2.0f);
    }
    // エフェクトを削除する
    void BreakEffect()
    {
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
