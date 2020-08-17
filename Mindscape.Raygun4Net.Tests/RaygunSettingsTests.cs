﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace Mindscape.Raygun4Net.Tests
{
  [TestFixture]
  public class RaygunSettingsTests
  {
    [Test]
    public void Apikey_EmptyByDefault()
    {
      Assert.IsEmpty(RaygunSettings.Settings.ApiKey);
    }

    [Test]
    public void ApiEndPoint_DefaultValue()
    {
      Assert.AreEqual("https://api.raygun.com/entries", RaygunSettings.Settings.ApiEndpoint.AbsoluteUri);
    }

    [Test]
    public void MediumTrust_FalseByDefault()
    {
      Assert.IsFalse(RaygunSettings.Settings.MediumTrust);
    }

    [Test]
    public void ThrowOnError_FalseByDefault()
    {
      Assert.IsFalse(RaygunSettings.Settings.ThrowOnError);
    }

    [Test]
    public void ExcludeHttpStatusCodesList_EmptyByDefault()
    {
      Assert.IsEmpty(RaygunSettings.Settings.ExcludeHttpStatusCodesList);
    }

    [Test]
    public void ExcludeErrorsFromLocal_FalseByDefault()
    {
      Assert.IsFalse(RaygunSettings.Settings.ExcludeErrorsFromLocal);
    }

    [Test]
    public void IgnoreFormFieldNames_EmptyByDefault()
    {
      Assert.IsEmpty(RaygunSettings.Settings.IgnoreFormFieldNames);
    }

    [Test]
    public void IgnoreHeaderNames_EmptyByDefault()
    {
      Assert.IsEmpty(RaygunSettings.Settings.IgnoreHeaderNames);
    }

    [Test]
    public void IgnoreCookieNames_EmptyByDefault()
    {
      Assert.IsEmpty(RaygunSettings.Settings.IgnoreCookieNames);
    }

    [Test]
    public void IgnoreServerVariableNames_EmptyByDefault()
    {
      Assert.IsEmpty(RaygunSettings.Settings.IgnoreServerVariableNames);
    }

    [Test]
    public void IsRawDataIgnored_FalseByDefault()
    {
      Assert.IsFalse(RaygunSettings.Settings.IsRawDataIgnored);
    }

    [Test]
    public void ApplicationVersion_EmptyByDefault()
    {
      Assert.IsEmpty(RaygunSettings.Settings.ApplicationVersion);
    }

    [Test]
    public void IsNotReadOnly()
    {
      Assert.IsFalse(RaygunSettings.Settings.IsReadOnly());
    }
  }
}
