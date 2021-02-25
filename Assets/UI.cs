using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public Text projectileTypeText;
    public Text angleText;
    public Text statusText;
    public Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void updateProjectile(string projectile)
    {
        projectileTypeText.text = "Projectile Type: " + projectile;
    }

    public void updateAngle(int angle)
    {
        angleText.text = "Angle: " + angle;
    }

    public void updateStatus(bool allowed)
    {
        if (allowed)
        {
            statusText.text = "Ready to fire";
        } else
        {
            statusText.text = "Wait";
        }
    }

    public void updateScore(int change)
    {
        scoreText.text = (int.Parse(scoreText.text) + change).ToString();
    }
}
