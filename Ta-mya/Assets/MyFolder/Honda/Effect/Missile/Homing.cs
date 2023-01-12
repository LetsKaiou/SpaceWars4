using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Homing : MonoBehaviour
{
    [SerializeField]
    Transform target;
    [SerializeField, Min(0)]
    float time = 2.5f;
    [SerializeField]
    float lifeTime = 3;
    [SerializeField]
    bool limitAcceleration = false;
    [SerializeField, Min(0)]
    float maxAcceleration = 100;
    [SerializeField]
    Vector3 minInitVelocity;
    [SerializeField]
    Vector3 maxInitVelocity;
    Vector3 position;
    Vector3 velocity;
    Vector3 acceleration;
    Transform thisTransform;

    public GameObject obj;
    Vector3 startPos;
    private bool moveFlag = false;
    [SerializeField] private ParticleSystem particle;

    // �|�������̃G�t�F�N�g
    public GameObject breakEffect;
    

    public Transform Target
    {
        set
        {
            target = value;
        }
        get
        {
            return target;
        }
    }
    void Start()
    {
        Debug.Log("Start");
        thisTransform = transform;
        position = thisTransform.position;
        velocity = new Vector3(Random.Range(minInitVelocity.x, maxInitVelocity.x),
            Random.Range(minInitVelocity.y, maxInitVelocity.y),
            Random.Range(minInitVelocity.z, maxInitVelocity.z));
        startPos = thisTransform.position;
        time = 2.5f;
        
        //particle.Stop(true, ParticleSystemStopBehavior.StopEmitting);
        //StartCoroutine(nameof(Timer));
        //target = GameObject.FindGameObjectWithTag("Target").transform;

        // Instantiate(obj, startPos, Quaternion.identity);

    }
    public void Update()
    {
        Debug.Log("update");
        
        //particle.Pause();

        if (target == null)
            {
                return;
            }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            moveFlag = true;

            //particle.Play();
            //ParticleSystem newParticle = Instantiate(particle);
            //newParticle.transform.position = this.transform.position;
            //newParticle.Play();
            //particle.transform.parent = obj.transform;

            StartCoroutine(nameof(Timer));

            

        }
        if (moveFlag)
        {
            acceleration = 2f / (time * time) * (target.position - position - time * velocity);
            if (limitAcceleration && acceleration.sqrMagnitude > maxAcceleration * maxAcceleration)
            {
                acceleration = acceleration.normalized * maxAcceleration;
            }
            time -= Time.deltaTime;
            if (time < 0f)
            {
                return;
            }
            velocity += acceleration * Time.deltaTime;
            position += velocity * Time.deltaTime;
            thisTransform.position = position;
            thisTransform.rotation = Quaternion.LookRotation(velocity);
        }
            
        

    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Target")
        {
            // �G�t�F�N�g�𔭐�������
            GenerateEffect();

            // �I�u�W�F�N�g���폜����
            Destroy(obj);
            Debug.Log("Destroy");

        }
    }

    IEnumerator Timer()
    {
        //Instantiate(obj, startPos, Quaternion.identity);
        yield return new WaitForSeconds(lifeTime);
        //Destroy(this);
        
        Instantiate(obj, startPos, Quaternion.identity);

        // �G�t�F�N�g�𔭐�������
        GenerateEffect();

        Destroy(this.gameObject);

        Debug.Log("Delete");

    }

    // �G�t�F�N�g�𐶐�����
    void GenerateEffect()
    {
        Debug.Log("Effect");
        // �G�t�F�N�g�𐶐�����
        GameObject effect = Instantiate(breakEffect) as GameObject;
        // �G�t�F�N�g����������ꏊ�����肷��
        effect.transform.position = gameObject.transform.position;
    }
}
