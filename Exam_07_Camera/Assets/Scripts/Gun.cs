using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Light))]
public class Gun : MonoBehaviour
{
    private Light fireLight;

    public GameObject SrcBullet;        //복사 생성해 쓸 프리팹
    public float errorAngle = 2.5f;     //사격 오차각
    public float firePerSec = 10.0f;    //초당 발사 속도
    private bool bFireReady = true;     //발사 준비여부

    public GameObject hitEffect;
    public GameObject fireEffect;

    void Awake()
    {
        //lightSetting
        this.fireLight = this.GetComponent<Light>();
        this.fireLight.color = new Color(1.0f, 0.5f, 0.3f);
        this.fireLight.enabled = false; //활성화 여부
    }

    void Update()
    {
        //왼쪽 마우스 버튼을 누르면~
        if (Input.GetMouseButton(0))
        {
            this.Fire();
        }
    }

    public void Fire()
    {
        if (this.SrcBullet == null)
        {
            print("총알을 물려 이 녀석아~!");
            return;
        }
        if (this.bFireReady == false)
        {
            return;
        }

        Quaternion rotFire = Quaternion.identity;
        //총알 랜덤 원뿔 발사축
        float radRandomAngle = Random.Range(0, Mathf.PI * 2);
        Vector3 rotVec = new Vector3(
            Mathf.Cos(radRandomAngle),
            Mathf.Sin(radRandomAngle),
            0.0f
            );

        Vector3 shotDir = Vector3.forward;

        Quaternion oneBBulRot = Quaternion.AngleAxis(
            Random.Range(0, this.errorAngle), rotVec
            );

        //발사방향 (진행방향으로 곱해줌)
        shotDir = oneBBulRot * shotDir;

        //최종 발사 회전값(발사방향에 자신의 회전 방향까지 곱해줌)
        rotFire = Quaternion.LookRotation(shotDir) *
            this.transform.rotation;

        //총알 생성
        GameObject bulletObject = Instantiate(
            this.SrcBullet,
            this.transform.position,
            Quaternion.identity
            ) as GameObject;

        GameObject.Destroy(bulletObject, 0.5f);

        //총알 꼬리처리
        BulletLine bulletLine =
            bulletObject.GetComponent<BulletLine>();

        if (bulletLine != null)
        {
            Vector3 dirToFire = rotFire * Vector3.forward;
            Ray ray = new Ray(this.transform.position, dirToFire);

            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100.0f))
            {
                bulletLine.SetPos(
                    this.transform.position,
                    hit.point);
                if (this.hitEffect != null)
                {
                    Instantiate(
                        this.hitEffect,
                        hit.point,
                        Quaternion.Euler(90.0f, 0, 0)
                        );
                }
            }
            else
            {
                bulletLine.SetPos(
                    ray.origin,
                    ray.origin + ray.direction * 100.0f
                    );
            }
        }
        if (this.fireEffect != null)
        {
            Instantiate(
                this.fireEffect,
                this.transform.position,
                this.transform.rotation
                );
        }

        this.bFireReady = false;

        this.StartFireLight();

        StartCoroutine(CoReady());
        
        //센드메세지로 불러와 실행시킨다.
        this.SendMessageUpwards("OnFireShock");
    }

    IEnumerator CoReady()
    {
        //초당 10발
        yield return new WaitForSeconds(1.0f / this.firePerSec);
        this.bFireReady = true;
    }

    void StartFireLight()
    {
        this.fireLight.enabled = true;
        this.fireLight.intensity = 5.0f;
        StopCoroutine("CoFireLightDie");
        StartCoroutine("CoFireLightDie");
    }

    IEnumerator CoFireLightDie()
    {
        while (true)
        {
            yield return null;
            //빛 세기 감소
            this.fireLight.intensity -= Time.deltaTime * 5.0f;
            if (this.fireLight.intensity <= 0.0f)
            {
                break;
            }
        }
        this.fireLight.enabled = false;
    }
}
