using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soul : MonoBehaviour {
    const float scaleSpeed = 0.5f;
    const float moveSpeed = 1.5f;
    const float minRadiusY = 2f;

    Vector3 minScale;
    Vector3 maxScale;
    Vector3 deadPos;
    Vector3 scaleVec;

    Vector2 radius;
    float elsapedTime;

    Transform startPosition;
    ParticleSystem effect;  
    Light soulLight;

    public bool showSoul { get; private set; }

	// Use this for initialization
	void Start () {
        effect = this.GetComponentInChildren<ParticleSystem>();
        soulLight = this.GetComponentInChildren<Light>();

        startPosition = GameObject.Find("StartPosition").transform;

        minScale = Vector3.zero;
        maxScale = new Vector3(0.8f, 0.8f, 0.8f);
        deadPos = Vector3.zero;
        scaleVec = new Vector3(scaleSpeed, scaleSpeed, scaleSpeed);
        showSoul = false;
        elsapedTime = 0f;
    }
	
	// Update is called once per frame
	void Update () {
        if (!showSoul)
            return;

        Move();
        Enlarge();
        End();
    }

    public void Initialize(Vector3 deadPos)
    {
        this.deadPos = deadPos;
        transform.position = this.deadPos;
        transform.localScale = minScale;

        this.GetComponent<Renderer>().enabled = true;
        effect.Play();
        soulLight.intensity = 3f;

        radius.x = (this.deadPos - startPosition.position).magnitude / 2;
        radius.y = minRadiusY;

        showSoul = true;
        elsapedTime = 0f;
    }

    private void Enlarge()
    {
        if (transform.localScale.x >= maxScale.x)
            return;

        transform.localScale += scaleVec * Time.fixedDeltaTime;
    }

    private void Move()
    {
        //開始⇔死亡位置の角度
        float direction = Mathf.Atan2(this.deadPos.y - startPosition.position.y,
            this.deadPos.x - startPosition.position.x);

        float x = Mathf.Sin(-elsapedTime * moveSpeed + (Mathf.PI / 2)) * radius.x + startPosition.position.x + radius.x;
        float y = Mathf.Cos(-elsapedTime * moveSpeed + (Mathf.PI / 2)) * radius.y + startPosition.position.y;
        float z = deadPos.z;

        float tmpX = x; float tmpY = y;

        //direction分だけ点を回転する
        x = tmpX * Mathf.Cos(direction) - tmpY * Mathf.Sin(direction);
        y = tmpX * Mathf.Sin(direction) + tmpY * Mathf.Cos(direction);

        if (Mathf.Rad2Deg * elsapedTime * moveSpeed > 180)
        {
            showSoul = false;
            return;
        }

        transform.position = new Vector3(x, y , z);
        elsapedTime += Time.fixedDeltaTime;
    }

    private void End()
    {
        if (showSoul)
            return;

        this.GetComponent<Renderer>().enabled = false;
        effect.Stop();
        soulLight.intensity = 0f;
    }
}
