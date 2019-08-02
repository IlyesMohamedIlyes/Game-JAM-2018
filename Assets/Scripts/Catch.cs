using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Effects;


public class Catch : MonoBehaviour
{
    public int _catched = 0;
    Animator _animator;
    

    private void Start()
    {
        _animator = transform.GetComponent<Animator>();
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Obstacle")
        {
            Debug.Log("Obstacle");

            return;
        }

        if (other.tag == "PowerUp")
        {
            Debug.Log("PowerUp");

            UIManager.Instance.UpdateMemoryCatch(++_catched);

            other.GetComponent<Animator>().SetBool("Catched", true);
            
            return;
        }

        if (other.tag == "Ground")
        {
            //Destroy animation
            _animator.SetBool("Destroy", true);
            transform.GetChild(2).GetComponent<ParticleSystemMultiplier>().Launch();
        }
    }


}
