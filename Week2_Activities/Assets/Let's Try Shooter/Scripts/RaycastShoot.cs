using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastShoot : MonoBehaviour
{
    public int gunDamage = 1;
    public float fireRate = .25f;
    public float weaponRange = 50f;
    public float hitForce = 100f;
    public Transform gunEnd;

    private Camera fpsCam;
    private WaitForSeconds shotDuration = new WaitForSeconds(0.7f);
    private AudioSource gunAudio;
    private LineRenderer lazerLine;
    private float nextFire;

    public GameObject bulletPrefab;
    public Transform bulletSpawn;

    void Start()
    {
        lazerLine = GetComponent<LineRenderer>();
        gunAudio = GetComponent<AudioSource>();
        fpsCam = GetComponentInParent<Camera>();
    }

    void Update()
    {
        if(Input.GetButtonDown ("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;

            //for (int i = 0; i < bulletSpawn.Length; i++)
            //{
                //Instantiate(bulletPrefab, bulletSpawn[i].position, bulletSpawn[i].rotation);
                StartCoroutine(ShotEffect());
            //}

            Vector3 rayOrigin = fpsCam.ViewportToWorldPoint(new Vector3(.5f, .5f, 0));
Instantiate(bulletPrefab, gunEnd.transform.position, fpsCam.transform.rotation);
            RaycastHit hit;

            lazerLine.SetPosition(0, gunEnd.position);

            if (Physics.Raycast(rayOrigin, fpsCam.transform.forward, out hit, weaponRange))
            {
                lazerLine.SetPosition(1, hit.point);

                

                ShootableBox health = hit.collider.GetComponent<ShootableBox>();

                if(health != null)
                {
                    health.Damage(gunDamage);
                }

                if(hit.rigidbody != null)
                {
                    hit.rigidbody.AddForce(-hit.normal * hitForce);
                }

            } else
            {
                lazerLine.SetPosition(1, rayOrigin + (fpsCam.transform.forward * weaponRange));
            }
        }   
    }

    IEnumerator ShotEffect()
    {
        

        gunAudio.Play();

        lazerLine.enabled = true;
        yield return shotDuration;
        lazerLine.enabled = false;
    }
}
