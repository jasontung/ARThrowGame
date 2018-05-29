using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DistanceChecker : MonoBehaviour {
    public Transform target;
    public float distance;
    public Color wrongColor;
    public Color rightColor;
    public Slider distanceIndicator;
    public Image indicatorImage;
    public ThrowController throwController;
	void LateUpdate ()
    {
        distance = Vector3.Distance(transform.position, target.position);
        distanceIndicator.value = distance;
        indicatorImage.color = Color.Lerp(wrongColor, rightColor, distanceIndicator.normalizedValue);
        throwController.enabled = distanceIndicator.value == distanceIndicator.maxValue;
	}
}
