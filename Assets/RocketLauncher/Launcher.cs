using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Launcher : MonoBehaviour
{
    public Transform effect;

    public int angle = 0;

    public int timeout;
    private int timer;

    public int limit = 30;

    private bool allowed = true;

    public enum ProjectileType { Explosive, Heavy, Fast};
    public ProjectileType current = ProjectileType.Explosive;

    public GameObject explosive;
    public GameObject heavy;
    public GameObject fast;

    // Use this for initialization
    void Start()
    {
        timeout = 200;
        timer = 0;
    }



    // Update is called once per frame
    void Update()
    {
        Quaternion rotation = transform.rotation;

        if (timer == timeout)
        {
            allowed = true;
            timer = 0;
            GameObject.Find("Canvas").GetComponent<UI>().updateStatus(true);

        }

        if (Input.GetKey(KeyCode.UpArrow) && angle < limit)
        {
            transform.Rotate(new Vector3(0, 0, 1));
            rotation = transform.rotation;
            angle++;
        }
        if (Input.GetKey(KeyCode.DownArrow) && angle > -limit)
        {
            transform.Rotate(new Vector3(0, 0, -1));
            rotation = transform.rotation;
            angle--;

        }

        GameObject.Find("Canvas").GetComponent<UI>().updateAngle(angle);


        if (Input.GetKeyDown(KeyCode.S))
        {
            if (current == ProjectileType.Fast)
            {
                current = 0;
            }
            else
            {
                current++;
            }

            GameObject.Find("Canvas").GetComponent<UI>().updateProjectile(current.ToString());

        }

        //Reading user input, only launching once before reset. will set initial lauch velocity
        if (Input.GetKeyDown(KeyCode.L) && allowed)
        {
            allowed = false;
            GameObject.Find("Canvas").GetComponent<UI>().updateStatus(false);

            Vector3 position = transform.localToWorldMatrix * new Vector4(18, 1, 0, 1);
            Vector3 difference = -position;

            Quaternion r = Quaternion.Euler(90 - angle, 90, 0);
            Quaternion rWorld = transform.rotation * r;

            Vector3 v = new Vector3(8 * difference.normalized.x, angle, 8 * difference.normalized.z);
            
            if (current == ProjectileType.Explosive)
            {
                GameObject projectile = Instantiate(explosive, position, rWorld);
                projectile.GetComponent<ExplosiveProjectile>().Launch(v);
            } else if (current == ProjectileType.Heavy)
            {
                GameObject projectile = Instantiate(heavy, position, rWorld);
                projectile.GetComponent<HeavyProjectile>().Launch(v);

            }
            else if (current == ProjectileType.Fast)
            {
                GameObject projectile = Instantiate(fast, position, rWorld);
                projectile.GetComponent<FastProjectile>().Launch(v);

            }

        }

        if (!allowed)
        {
            timer++;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Transform effectInstance = (Transform)Instantiate(effect, transform.position, transform.rotation);
        Destroy(this.gameObject);

    }
}