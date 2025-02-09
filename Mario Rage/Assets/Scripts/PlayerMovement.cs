using System.Collections;
using TMPro;

using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private int ammo = 30;
    [SerializeField] private Transform aim;
    [SerializeField] private TextMeshProUGUI ammoText;
    [SerializeField] private float impulsePower;
    [SerializeField] private GameObject bullet;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform spp;

    private bool canShoot = true;
    private bool isReloading = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if(canShoot && Input.GetKey(KeyCode.Mouse0) && ammo > 0)
        {
            StartCoroutine(Shoot());
        }
        if((ammo == 0 || Input.GetKey(KeyCode.R)) && !isReloading)
        {
            StartCoroutine(Reload());
        }
        if(transform.position.y < -10)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
    IEnumerator Shoot()
    {
        canShoot = false;
        ammo -= 1;
        rb.AddForce(aim.right * impulsePower, ForceMode2D.Impulse);
        Instantiate(bullet, spp.position, spp.rotation);
        ammoText.text = ammo.ToString();
        yield return new WaitForSeconds(0.15f);
        canShoot = true;
    }
    IEnumerator Reload()
    {
        canShoot=false;
        ammo = 0;
        isReloading = true;
        ammoText.text = ammo.ToString();
        yield return new WaitForSeconds(3);     
        ammo = 20;
        ammoText.text = ammo.ToString();
        isReloading =false;
        canShoot = true;
    }
}
