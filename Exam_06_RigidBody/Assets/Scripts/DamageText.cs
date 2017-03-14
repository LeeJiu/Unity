using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageText : MonoBehaviour
{
    public GameObject damageText;
    public Transform HeadTrans;

	void Update ()
    {
		if(Input.GetKeyDown(KeyCode.Space))
        {
            GameObject newGameObject = 
                Instantiate(this.damageText, this.HeadTrans.position, Quaternion.identity) 
                as GameObject;

            Destroy(newGameObject, Random.Range(1.0f, 2.0f));

            newGameObject.gameObject.GetComponent<Rigidbody>().AddForce(
                new Vector3(Random.Range(-1.0f, 1.0f), Random.Range(3.0f, 8.0f), Random.Range(-1.0f, 1.0f)),
                ForceMode.VelocityChange);

            //Damage 적어보기
            TextMesh textMesh = newGameObject.GetComponent<TextMesh>();

            if(textMesh != null)
            {
                int rand = Random.Range(0, 5);
                int damage = Random.Range(100, 200);

                //크리 데미지
                if(rand == 0)
                {
                    textMesh.text = (damage * 2).ToString();
                    textMesh.color = Color.red;
                }
                else
                {
                    textMesh.text = damage.ToString();
                    textMesh.color = Color.white;
                }
            }
        }
	}
}
