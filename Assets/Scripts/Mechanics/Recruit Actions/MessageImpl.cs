﻿using UnityEngine;
using UnityEditor;

public class MessageImpl : IMessage
{
    private string msg;

    public MessageImpl(string msg)
    {
        this.msg = msg;
    }

    public string getMessage()
    {
        return msg;
    }
}