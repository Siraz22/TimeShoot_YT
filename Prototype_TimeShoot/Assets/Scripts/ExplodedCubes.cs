using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodedCubes : MonoBehaviour
{
    //The cubes we get after the explosion will have this script

    public GameObject DyingVFX;

    private void Awake()
    {
        DyingVFX = GameManager.InstanceGM.DeathVFX;
    }

    public void ShotAt()
    {
        //Getting Shot At

        //Instantiate a death vfx
        GameObject VFX = Instantiate(DyingVFX, transform.position, Quaternion.identity);
        VFX.transform.SetParent(null); //To stop it from being destroyed when the cube dies
        VFX.gameObject.SetActive(true);

        Destroy(gameObject, 0.2f);
    }
}
