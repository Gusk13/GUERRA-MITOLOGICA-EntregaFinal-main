using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public AudioSource hit;
    public int MaxHealth = 300;
    public int CurrentHealth;
    Animator Ani;
    public Slider BarraVida;
    void Start()
    {
        CurrentHealth = MaxHealth;
        Ani = GetComponent<Animator>();
    }

    public void TakeDamage(int Damage)
    {
        CurrentHealth -= Damage;
        hit.Play();
        Ani.SetTrigger("Daño");
        GetComponent<ParticleSystem>().Play();
        if (CurrentHealth <= 0)
        {
            Dead();
            over.show();
        }
    }
    void Dead()
    {
        Debug.Log("enemigo morido");
    }
    private void Update()
    {
        BarraVida.value = CurrentHealth;
        if (CurrentHealth <= 0)
        {
            Debug.Log("murio saco provecho de mi y abuso");

            Destroy(gameObject);


        }
    }

}
