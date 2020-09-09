using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Managers;

public class UIManager : MonoBehaviour
{

	[SerializeField]
	Slider energySlider;

	[SerializeField]
	Slider foodSlider;

	[SerializeField]
	Slider woodSlider;



	[SerializeField]
	private GameObject villageMenu;

	private void Start()
	{
		GameEvents.current.onVillageCenter += OpenVillageMenu;
		GameEvents.current.onVillageCenterExit += CloseVillageMenu;
		ResourceManager.resourceManager.onBuildGenerator += TestFunction;
	}

	private void OnGUI()
	{
		foodSlider.value = ResourceManager.resourceManager.resources["food"];
		woodSlider.value = ResourceManager.resourceManager.resources["wood"];
		energySlider.value = ResourceManager.resourceManager.resources["energy"];
	}

	void OpenVillageMenu()
	{
		villageMenu.SetActive(true);
	}

	void CloseVillageMenu()
	{
		villageMenu.SetActive(false);
	}

	void TestFunction()
	{
		Debug.Log("TEsting Events");
	}
}
