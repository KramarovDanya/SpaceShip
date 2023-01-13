using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LaserGunSpawner : MonoBehaviour
{
    public Laser laserPrefab;
    [SerializeField]private float coolDown = 1f;
    [SerializeField] float maxValueShoot = 10;
    [SerializeField] float currentValueShoot;
    [SerializeField] Text ammo;

    private bool canShoot = true;

    string ammoText;

    public AudioSource shootSound;
    public AudioSource reloadSound;

    private void Start()
    {
        currentValueShoot = maxValueShoot;

        ammoText = ammo.text;
    }

    // Update is called once per frame
    void Update()
    {
        if (Pause.gameIsPaused != true)
        {
            if (Input.GetMouseButtonDown(0) && canShoot)
            {
                if (currentValueShoot != 0)
                {
                    Shoot();
                    currentValueShoot--;
                    ammoText = currentValueShoot + "/10";
                    shootSound.Play();
                    if (currentValueShoot < 4)
                    {
                        shootSound.pitch = 1.5f;
                    }
                }

            }
            if (currentValueShoot == 0 || Input.GetKeyDown(KeyCode.R))
            {
                StartCoroutine(coolDownLaserBar());
                reloadSound.Play();
                reloadSound.pitch = Random.Range(1f, 1.5f);
            }
        }
    }

    private void Shoot()
    {
        Instantiate(laserPrefab, transform.position, transform.rotation);
    }

    private IEnumerator coolDownLaserBar()
    {
        canShoot = false;
        while (currentValueShoot < maxValueShoot)
        {
            currentValueShoot++;
            ammoText = currentValueShoot + "/10";
            yield return new WaitForSeconds(coolDown);
        }
        shootSound.pitch = 1;
        canShoot = true;
    }

    public void SetAmmo()
    {
        currentValueShoot = 0;
        ammoText = currentValueShoot + "/10";
    }
}
