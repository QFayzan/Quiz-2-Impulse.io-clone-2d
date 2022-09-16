using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAimWeapon : MonoBehaviour
{
    private Transform aimTransform;            //used by codemonkey
    private float knockBackStrength = 8.0f;   //used to set strength of knockbacks
    public GameObject bullet;                  //the "pushing" mechanic
    public GameObject bulletSpawnPoint;        //Making a nested empty object to use its transform for coordinates


    private void Awake()
    {
        aimTransform = transform.Find("Aim"); //Codemonkey way to get position of object
    }
  
    // Update is called once per frame
   private void Update()
    {
       HandleAiming();
       HandleShooting();
    }
    //CodeMonkey way to move player according to mouse
    private void HandleAiming()
    {
        Vector3 mousePosition = GetMouseWorldPosition();
        aimTransform.LookAt(mousePosition);
        Vector3 aimDirection = (mousePosition - transform.position).normalized;
        float angle =Mathf.Atan2(aimDirection.y , aimDirection.x)*Mathf.Rad2Deg;
        aimTransform.eulerAngles = new Vector3(0,0,angle);
    }
    private void HandleShooting()
    {
        //Basially we get on click position which is also the aiming position as well and spawn object there
        //Destroy with delay is used to make sure too many large objects dont pile up
        //to keep the illusion of invisible force the sprite renderer is simply turned off
        if(Input.GetMouseButtonDown(0))
        {
            Vector3 mousePosition = GetMouseWorldPosition();
            var instance =  Instantiate(bullet, bulletSpawnPoint.transform.position, bullet.transform.rotation);
            instance.GetComponent<Rigidbody2D>().AddForce(mousePosition *knockBackStrength, ForceMode2D.Impulse);
            Destroy(instance, 0.2f);
        }
    }
    //Get world Position with Z = 0F by CodeMonkey
    public static Vector3 GetMouseWorldPosition()
    {
        Vector3 vec = GetMouseWorldPositionwithZ(Input.mousePosition, Camera.main);
        vec.z = 0.0f;
        return vec;
    }
    public static Vector3 GetMouseWorldPositionwithZ()
    {
        return GetMouseWorldPositionwithZ(Input.mousePosition , Camera.main);
    }
    public static Vector3 GetMousePositionwithZ(Camera worldCamera)
    {
        return GetMouseWorldPositionwithZ(Input.mousePosition , worldCamera);
    }
     public static Vector3 GetMouseWorldPositionwithZ(Vector3 screenPosition , Camera worldCamera)
     {
        Vector3 worldPosition = worldCamera.ScreenToWorldPoint(screenPosition);
        return worldPosition;
     }
    //World Position by Codemonkey ends
    
}
