using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{

    public GameObject Menu;
    public GunManager gunManager;
    public GunMove gunMove;
    public MovementScript movement;
    public Animator menuanim;
    public PanelManager panelmanager;
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Menu.SetActive(true);
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
            StartCoroutine(StopGame());

        }
    }
    
    IEnumerator StopGame()
    {

        yield return new WaitForSeconds(1);
        gunManager.enabled = false;
        gunMove.enabled = false;
        movement.enabled = false;
        //Time.timeScale = 0;
    }

    public void ResumeGame()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        gunManager.enabled = true;
        gunMove.enabled = true;
        movement.enabled = true;
        //Time.timeScale = 1;
        Menu.SetActive(false);


    }
}