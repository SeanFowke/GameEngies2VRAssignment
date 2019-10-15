using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LookAtUI : MonoBehaviour
{
	public float defaultPosZ;
	public Slider slider;
	public float increment;
	GameObject lastHit;
	private Image image;

	// Start is called before the first frame update
	void Start()
	{
		defaultPosZ = transform.localPosition.z;
		slider.value = 0;
		slider.GetComponent<Image>();
	}

	// Update is called once per frame
	void Update()
	{
		Move();
	}

	public void Move()
	{
		Transform camera = Camera.main.transform;
		Ray ray = new Ray(camera.position, camera.rotation * Vector3.forward);
		RaycastHit[] hit = new RaycastHit[1];
		Debug.DrawRay(camera.position, camera.rotation * Vector3.forward, Color.red);

		if (Physics.RaycastNonAlloc(ray, hit) > 0 && hit[0].collider.gameObject.CompareTag("UIElement"))
		{
			transform.position = new Vector3(hit[0].collider.gameObject.transform.position.x, hit[0].collider.gameObject.transform.position.y, hit[0].collider.gameObject.transform.position.z - 0.5f);
			transform.rotation = camera.rotation;
			lastHit = hit[0].collider.gameObject;
			HandleAnim();
			lastHit = hit[0].collider.gameObject;
			lastHit.GetComponent<VRButton>().wasLookedAt = true;
		}
		else
		{
			if (lastHit != null)
			{
				lastHit.GetComponent<VRButton>().wasLookedAt = false;
			}
			transform.position = new Vector3(0, 0, defaultPosZ);
			slider.value = 0;
		}
	}

	public void HandleAnim()
	{
		slider.value += increment;
	}
}
