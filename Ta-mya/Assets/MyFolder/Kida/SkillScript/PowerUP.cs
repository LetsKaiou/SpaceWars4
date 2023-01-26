using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUP : MonoBehaviour
{
    [SerializeField] private int PowerPoint;
    [SerializeField] private float EffectTime;
    private float TimeCount = 0f;
    private Player py;

    public static PowerUP instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        py = GameObject.Find("Yamato").GetComponent<Player>();
        P_SPDUp();
    }

    // Update is called once per frame
    void Update()
    {
        // å¯â éûä‘åvë™èàóù
        TimeCount += Time.deltaTime;
        if (TimeCount > EffectTime)
        {
            // å¯â éûä‘âﬂÇ¨ÇΩÇÁñﬂÇ∑
            SP1hit.instance.ATKPoint -= PowerPoint;
            SP2hit.instance.ATKPoint -= PowerPoint;
            SP3hit.instance.ATKPoint -= PowerPoint;
            SP4hit.instance.ATKPoint -= PowerPoint;
            Destroy(this.gameObject);
        }
    }

    // ì¡éÍçUåÇÇÃçUåÇóÕè„è∏
    private void P_SPDUp()
    {
        SP1hit.instance.ATKPoint += PowerPoint;
        SP2hit.instance.ATKPoint += PowerPoint;
        SP3hit.instance.ATKPoint += PowerPoint;
        SP4hit.instance.ATKPoint += PowerPoint;
    }
}
