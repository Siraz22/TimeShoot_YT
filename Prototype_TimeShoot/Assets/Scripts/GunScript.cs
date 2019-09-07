using UnityEngine;
using UnityEngine.UI;

public class GunScript : MonoBehaviour
{

    public float range = Mathf.Infinity;
    //No Damage required

    public GameObject MuzzleFlash;
    public Transform MainCam;
    public AudioSource GunShotSound;

    public void Shoot()
    {
        //Called when we press the shoot button
        //Called as long as we hold the button down
        //Need for firerate

        EnableMuzzle();
        GunShotSound.Play();

        RaycastHit hit;
        if(Physics.Raycast(MainCam.transform.position,MainCam.transform.forward, out hit, range))
        {
            //Check if we hit target
            Explosion cubeexplosionscript = hit.transform.GetComponent<Explosion>(); //Get explosion script from the cube we hit

            if(cubeexplosionscript)
            {
                //If the cube has the script it's an exploding target
                cubeexplosionscript.explode();
            }

            //Check for exploded cube remains
            ExplodedCubes explodedcube = hit.transform.GetComponent<ExplodedCubes>();

            if(explodedcube)
            {
                //We hit the remains of an exploded cube
                GameManager.InstanceGM.Score++; //Inc the score

                //Check score after updating the score first
                CheckHighScore();
                explodedcube.ShotAt(); //Destroy the cube 
            }
        }
    }

    private void CheckHighScore()
    {
        //Change score irrespective of wether it crosses the highscore
        GameManager.InstanceGM.ScoreTEXT.text = "SCORE : " + GameManager.InstanceGM.Score.ToString();

        if (GameManager.InstanceGM.Score > PlayerPrefs.GetInt("HighScore"))
        {
            PlayerPrefs.SetInt("HighScore", GameManager.InstanceGM.Score); //A new High Score

            GameManager.InstanceGM.ScoreTEXT.text = "SCORE : " + PlayerPrefs.GetInt("HighScore").ToString();
            GameManager.InstanceGM.HighScoreTEXT.text = "HIGHSCORE " +PlayerPrefs.GetInt("HighScore").ToString();
        }
    }

    public void EnableMuzzle()
    {
        MuzzleFlash.gameObject.SetActive(true);
    }

    void Update()
    {

    }
}
