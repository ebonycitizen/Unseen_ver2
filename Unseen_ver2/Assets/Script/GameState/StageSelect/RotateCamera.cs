using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RotateCamera : MonoBehaviour
{
    const int rotateSpeed = 2;
    const int maxAngle = 60;
    const float zoomSpeed = 0.1f;
    const float maxIntensity = 3f;
    const float increaceLightSpeed = 0.5f;

    [SerializeField]
    private Transform targetCenter;
    [SerializeField]
    private GameObject pointLight;

    public bool IsRotating { get; private set; }
    public int GetRotateSpeed()
    {
        return rotateSpeed;
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public IEnumerator StartRotateAnimation(float rotateDir)
    {
        IsRotating = true;

        Light light = pointLight.GetComponent<Light>();

        light.intensity = 0;

        for (int i = 0; i < maxAngle; i += rotateSpeed)
        {
            transform.RotateAround(targetCenter.position, Vector3.up, rotateDir);
            pointLight.transform.RotateAround(targetCenter.position, Vector3.up, rotateDir);
            yield return null;
        }

        for (float i = 0; i < maxIntensity; i += increaceLightSpeed)
        {
            light.intensity += increaceLightSpeed;
            yield return null;
        }

        IsRotating = false;
    }

    public IEnumerator GoInsideDoor(Vector3 doorTargetPos)
    {
        while (true)
        {
            transform.position = Vector3.MoveTowards(transform.position, doorTargetPos, zoomSpeed);

            if ((int)transform.position.x == (int)doorTargetPos.x && (int)transform.position.z == (int)doorTargetPos.z)
                break;

            yield return null;
        }
        //SceneManager.LoadScene("Loading");
    }
}
