using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
    public int damage;
    public bool isUsingItem = false;
    public ParticleSystem[] effect;
    [HideInInspector] public int _damageMultiply;

    private Charater charater;
    private BlockGenerator gene;

    void Awake()
    {
        charater = GameObject.FindObjectOfType<Charater>();
        gene = GameObject.FindObjectOfType<BlockGenerator>();
        _damageMultiply = 1;
        damage = PlayerData.instance.info.mineCurrDmg;
    }

    public void OnMouseUp()
    {
        // 터치업 
        GetComponent<AudioSource>().Play();
        Invoke("returnState", 0.3f);
        charater.SetAnimation(CharacterState.attack);
        gene.AttackedBlock(damage * _damageMultiply);


        // 이펙트 후처리
        for (int i = 0; i < effect.Length; i++)
        {
            if (!effect[i].gameObject.activeSelf)
            {
                effect[i].gameObject.SetActive(true);
                StartCoroutine("invokeSleep", effect[i]);

                break;
            }
        }

    }

    void returnState()
    {
        charater.SetAnimation(CharacterState.idle);
    }
    IEnumerator invokeSleep(ParticleSystem ps)
    {
        yield return new WaitForSeconds(0.3f);
        ps.gameObject.SetActive(false);
    }
}
