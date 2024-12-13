using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class Gun : MonoBehaviour
{
    //GUN ELEMENT INSTANCES
    [Header("Gun")]
    [SerializeField] private GameObject _bulletPrefab_1;
    [SerializeField] private GameObject _bulletPrefab_2;
    [SerializeField] private Transform _gunTip;

    [Header("cooldown")]
    [SerializeField] float _gunCooldown;
    [SerializeField] Material _Material;
    private bool _onCoolDown = false;
    Color lerpedColor;
    public new Renderer renderer;

    private void Awake()
    {
        renderer = GetComponent<Renderer>();
    }

    private void Update()
    {
        if(Input.GetButtonDown("Fire1") && _onCoolDown == false)
        {
            //StartCoroutine(lerpColor(Color.black, Color.green, _gunCooldown / 2 ));
            FireProjectile(RandomProjectile());
            StartCoroutine(lerpColor(Color.green, Color.black, _gunCooldown));
        }
    }

    protected IEnumerator lerpColor(Color startColor, Color endColor, float overTime)
    {
        float startTime = Time.time;

        while (Time.time < startTime + overTime)
        {
            lerpedColor = Color.Lerp(startColor, endColor, (Time.time - startTime)/overTime);
            renderer.material.color = lerpedColor;
            yield return null;
        }
       
    }
       


    void LerpWandColor(Color startColor, Color endColor)
    {
      
       _Material.SetColor("_Color", Color.blue);
        //lerpedColor = Color.Lerp(startColor, endColor, _gunCooldown/2);
        //renderer.material.color = lerpedColor;
    }


    private int RandomProjectile()
    {
        int RandNum = Random.Range(0, 2);
        Debug.Log("Projectile in Gun rand : " + RandNum);
        return RandNum;
    }

    

    private void FireProjectile(int projectileIndex)
    {
        switch (projectileIndex)
        {
            case 0:
                {
                    GameObject.Instantiate(_bulletPrefab_1, _gunTip.position, _gunTip.rotation); 
                    break;
                }
            case 1:
                {
                    GameObject.Instantiate(_bulletPrefab_2, _gunTip.position, _gunTip.rotation);
                    break;
                }
            default:
                {
                    GameObject.Instantiate(_bulletPrefab_1, _gunTip.position, _gunTip.rotation);
                    break;
                }
        }
        StartCoroutine(CoolDownCoroutine());
    }

    protected IEnumerator CoolDownCoroutine()
    {
        _onCoolDown = true;
        yield return new WaitForSeconds(_gunCooldown);
        //LerpWandColor(Color.white, Color.black);
        _onCoolDown = false ;
        
    }
}
