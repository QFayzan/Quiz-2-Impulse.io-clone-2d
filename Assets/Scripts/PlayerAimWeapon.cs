using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAimWeapon : MonoBehaviour
{
    private Transform aimTransform;

    private void Awake()
    {
        aimTransform = transform.Find("Aim");
    }
    void Start()
    {
        
    }

    // Update is called once per frame
   private void Update()
    {
       HandleAiming();
       HandleShooting();
    }

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
        if(Input.GetMouseButtonDown(0))
        {
            
        }
    }
    public static Vector3 GetMouseWorldPosition()
    {
        Vector3 vec = GetMouseWorldPositionwithZ(Input.mousePosition, Camera.main);
        vec.z = 0.0f;
        return vec;
    }
    //Get world Position with Z = 0F by CodeMonkey
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
}
