using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
public class ThrowController : MonoBehaviour {
    public Slider powerIndicator;
    private bool isThrew;
    public float maxPower;
    public Rigidbody ball;
    public Transform throwPos;
    public Button restartButton;
    private void Awake()
    {
        restartButton.gameObject.SetActive(false);
    }
    // Update is called once per frame
    void Update () {
        if (isThrew)
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
        isThrew = true;
        ball.transform.SetParent(null);
        ball.isKinematic = false;
        ball.AddForce(throwPos.forward * maxPower * powerIndicator.normalizedValue);
        Invoke("DelayShowRestartButton", 3f);
    }

    private void DelayShowRestartButton()
    {
        restartButton.gameObject.SetActive(true);
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
}
