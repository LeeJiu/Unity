using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Renderer))]
public class MaterialControl : MonoBehaviour
{
    public Color changeColor = Color.red;
    private Renderer myRenderer;

    private void Awake()
    {
        this.myRenderer = this.GetComponent<Renderer>();
        
    }

    void Update ()
    {
		if(Input.GetKeyDown(KeyCode.Space))
        {
            //this.ChangeColor_00();
            this.ChangeColor_01();
        }
	}

    void ChangeColor_00()
    {
        //인스턴스 메테리얼 항목에 접근해서 컬러를 변경한다.
        //실행시 생성된 인스턴스에 접근해서 변경하기 때문에 실행 후 원본으로 돌아간다.
        this.myRenderer.material.SetColor("_Color", this.changeColor);
    }

    void ChangeColor_01()
    {
        //원본 메테리얼에 접근해서 컬러를 변경한다.
        //실행 후 원본이 변경되어 있다.
        //메테이얼이 여러 개 있는 경우, materials 를 사용.
        this.myRenderer.sharedMaterial.SetColor("_Color", this.changeColor);
    }
}
