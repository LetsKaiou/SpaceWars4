using System.Collections;
using UnityEngine;

public class SimpleTransition : MonoBehaviour
{

    readonly float waitTime = 1.2f;

    void Start()
    {
        DontDestroyOnLoad(gameObject);

        StartCoroutine(nameof(Transition));
    }

    IEnumerator Transition()
    {
        yield return new WaitForSeconds(waitTime);

        Destroy(gameObject);
    }

}
