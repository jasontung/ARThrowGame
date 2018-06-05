using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
public class ThrowController : MonoBehaviour {
    public Slider powerIndicator;
    public float maxPower;
    public Rigidbody ball;
    public Button restartButton;
    private Vector3 originPos;
    private Quaternion originRot;
    private bool canThrow = true;
    private void Awake()
    {
        restartButton.gameObject.SetActive(false);
        ball.isKinematic = true;
        originPos = ball.transform.localPosition;
        originRot = ball.transform.localRotation;
    }
    // Update is called once per frame
    void Update () {
        if (canThrow == false)
            return;
		if(Input.GetMouseButton(0))
        {
            powerIndicator.value += Time.deltaTime;
        }
        else if(Input.GetMouseButtonUp(0))
        {
            Throw();
        }
	}

    public void Throw()
    {
        canThrow = false;
        ball.transform.SetParent(null);
        ball.isKinematic = false;
        ball.AddForce(ball.transform.forward * maxPower * powerIndicator.normalizedValue);
        Invoke("DelayShowRestartButton", 3f);
    }

    private void DelayShowRestartButton()
    {
        restartButton.gameObject.SetActive(true);
    }

    public void ReloadScene()
    {
        ball.isKinematic = true;
        ball.transform.SetParent(transform);
        ball.transform.localPosition = originPos;
        ball.transform.localRotation = originRot;
        restartButton.gameObject.SetActive(false);
        powerIndicator.value = 0;
        Invoke("DelayEnableThrow", 0.5f);
    }

    private void DelayEnableThrow()
    {
        canThrow = true;
    }
}
