using System;
using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

public class PlayerTests
{
    [SetUp]
    public void Setup()
    {
        SceneManager.LoadScene("Level 1");
    }
    
    [Test]
    public void Sum()
    {
        Assert.AreEqual(1 + 1, 2);
    }
}
