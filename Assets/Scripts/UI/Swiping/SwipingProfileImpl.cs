﻿
using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SwipingProfileImpl : MonoBehaviour
{
	private GameManager manager;
	public PlayerProfileViewImpl playerProfile;
	public Button acceptButton;
	public Button rejectButton;
	private IUserProfile potentialRecruitProfile;

	public void Awake()
	{
		manager = FindObjectOfType<GameManager>();
		if (manager == null)
		{
			SceneManager.LoadScene(4, LoadSceneMode.Additive);
			
		}

	}

	public void Start()
	{
		manager = FindObjectOfType<GameManager>();
		LoadNewProfile();
		acceptButton.onClick.AddListener(Accept);
		rejectButton.onClick.AddListener(Reject);
	}

	private void LoadNewProfile()
	{
		IUserProfile userProfile = UserProfile.UserProfileGenerator(new System.Random());
		LoadProfile(userProfile);
		this.potentialRecruitProfile = userProfile;
	}

	private void Reject()
	{
		LoadNewProfile();
	}

	private void Accept()
	{
		manager.CurrentMatch = this.potentialRecruitProfile;
		manager.GameState = GameState.Recruiting;
	}

	public void LoadProfile(IUserProfile profile)
	{
		playerProfile.Load(profile);
	}
}

