using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using System.Collections;
using UnityEngine.UI;


public class FlySpirit : MonoBehaviour
{

    public GameObject _all;
    public float _speed = 5;
    public float _speeding = 1;
    public float leftright = 5;
    public Slider _slideBoost;

    
    private void Start()
    {
        //  _player = transform.parent;
    }

    private void FixedUpdate()
    {
        if (UIManager.Instance.State == PanelState.GameOverPanel)
            return;


        MoveCharacter();
    }

    private void MoveCharacter()
    {
        float vertical = CrossPlatformInputManager.GetAxis("Vertical");
        float horizontal = CrossPlatformInputManager.GetAxis("Horizontal");

        // transform.GetComponent<Rigidbody>().velocity = transform.up * speed * Time.fixedDeltaTime;

        ForwardCharacter();

        if (transform.rotation.x < 0.4 && transform.rotation.x > -0.4)
        {
            transform.Rotate(new Vector3(vertical, 0, 0));
        }
        else
        {
            if (transform.rotation.x > 0.4 && vertical < 0)//Trying to get up
            {
                transform.Rotate(new Vector3(vertical, 0, 0));
            }
            if (transform.rotation.x < -0.4 && vertical > 0)//Trying to get down
                transform.Rotate(new Vector3(vertical, 0, 0));
        }

        // Left Right movements
        // Horizontal can be positive or negative
        var pos = transform.position + Vector3.right * horizontal * leftright;
        if (pos.x > 4400 && pos.x < 7378)
            transform.position = pos;
    }
    

    public void ForwardCharacter()
    {
        _all.transform.Translate(-_all.transform.forward * _speed * _speeding);
    }

    public void BoostSpeed()
    {

        var b = _slideBoost.gameObject.transform.GetChild(3).GetComponent<Image>();


        if (_slideBoost.value == _slideBoost.maxValue)
        {
            b.enabled = true;
            Debug.Log("Activated");
            
        }
        else
        {
            b.enabled = false;
            Debug.Log("Deactivated");
        }
    }

    public void BoostSpeedCoroutine()
    {
    }

}
