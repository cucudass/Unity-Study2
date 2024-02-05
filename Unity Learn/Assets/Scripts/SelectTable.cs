using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class SelectTable : MonoBehaviour
{
    private Rigidbody rigidbody;
    [SerializeField] bool select;
    [SerializeField] ParticleSystem particle;

    private void Start() {
        rigidbody = GetComponent<Rigidbody>();
    }

    private void OnMouseDown() { //마우스 클릭 시
        particle.Play();
        select = true;
    }

    private void OnMouseDrag() { //마우스 드래그 시
        Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.WorldToScreenPoint(gameObject.transform.position).z);

        transform.position = Camera.main.ScreenToWorldPoint(mousePosition);
    }

    private void OnTriggerEnter(Collider other) {
        string name1 = transform.name;
        string name2 = other.transform.name;

        if (name1 == name2) {
            int num = Convert.ToInt32(name1.Substring(name1.Length - 1)) + Convert.ToInt32(name2.Substring(name2.Length - 1));
            string newName = name1.Split(" ")[0] + " " + num;

            if (select)
                Instantiate(Resources.Load<GameObject>(newName));

            gameObject.SetActive(false);
            other.gameObject.SetActive(false);
        }
    }

    private void OnMouseExit() {
        select = false;
    }
}
