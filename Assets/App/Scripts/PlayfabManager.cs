using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;

public class PlayfabManager : Singleton<PlayfabManager>
{
    public event Action OnSignIn;
    public void SignIn(string email, string pw)
    {
        var request = new LoginWithEmailAddressRequest
        {
            Email = email,
            Password = pw
        };
        PlayFabClientAPI.LoginWithEmailAddress(request, OnSignInSuccess, OnError);
    }
    public void SignUp(string email, string pw, string name)
    {
        var request = new RegisterPlayFabUserRequest
        {
            Email = email,
            Password = pw,
            Username = name
        };
        PlayFabClientAPI.RegisterPlayFabUser(request, OnSignUpSuccess, OnError);
    }
    private void OnSignInSuccess(LoginResult result)
    {
        Debug.Log("�α��� ����");
        OnSignIn();
    }
    private void OnSignUpSuccess(RegisterPlayFabUserResult result)
    {
        Debug.Log("ȸ������ ����");

    }
    private void OnError(PlayFabError error)
    {
        Debug.Log("�����߻�\n"+ error.HttpCode);
        Debug.Log(error.ErrorMessage);

    }
}
