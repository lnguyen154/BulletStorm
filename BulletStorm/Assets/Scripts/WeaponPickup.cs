using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponPickup : MonoBehaviour
{
    public GameObject weapon;
    public Transform weaponParent;
    void Start()
    {
        weapon.GetComponent<Rigidbody>().isKinematic = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Z))
        {
            Drop();
        }
    }

    private void Drop()
    {
        weapon.transform.eulerAngles = new Vector3(weapon.transform.position.x, weapon.transform.position.z, weapon.transform.position.y);
        weapon.GetComponent<Rigidbody>().isKinematic = false;
        weapon.GetComponent<MeshCollider>().enabled = true;
    }
    
    private void EquipWeapon()
    {
        weapon.GetComponent<Rigidbody>().isKinematic = true;
        
        weapon.transform.position = weaponParent.transform.position;
        weapon.transform.rotation = weaponParent.transform.rotation;    

        weapon.GetComponent<MeshCollider>().enabled = false;

        weapon.transform.SetParent(weaponParent);

    }
    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            Debug.Log("Touched");
            if (Input.GetKey(KeyCode.X))
            {
                Debug.Log("Pick");
                EquipWeapon();
                
            }
        }
    }
}
