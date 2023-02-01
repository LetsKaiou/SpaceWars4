using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public GameObject player;
    private Vector3 offset;
    private Quaternion qua;
    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - player.transform.position;
        transform.LookAt(player.transform.position);
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, player.transform.position + offset, 10.0f * Time.deltaTime);

        qua = player.transform.rotation;
        // transform.rotation = qua;
        //transform.rotation = Quaternion.Lerp(transform.rotation, qua, 5.0f * Time.deltaTime);
        transform.LookAt(player.transform.position);
    }
}
