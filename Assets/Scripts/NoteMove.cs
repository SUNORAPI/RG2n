using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.CompilerServices;

public class NoteMove : MonoBehaviour
{
    public GameObject destination;
    private float px;
    private float pz;
    private float dx;
    private float dz;
    private float mx;
    private float mz;
    private float h;

    private void Start()
    {
        px =this.gameObject.GetComponent<Transform>().position.x;
        pz =this.gameObject.GetComponent<Transform>().position.z;
        dx =destination.transform.position.x;
        dz = destination.transform.position.z;
        mx = dx-px; 
        mz = dz -pz;
    }
    public void Move(float Movetime)
    {
        StartCoroutine(NM(Movetime, h)) ;
    }

    IEnumerator NM (float moveT, float h)
    {
        for (int i = 0; i < 100; i++)
        {
            Transform tN = this.transform;
            Vector3 fwdN = tN.transform.position;
            fwdN += new Vector3(mx / 100, 0, mz / 100);
            tN.transform.position = fwdN;
            yield return new WaitForSeconds(moveT / 100);
        }
    }
}