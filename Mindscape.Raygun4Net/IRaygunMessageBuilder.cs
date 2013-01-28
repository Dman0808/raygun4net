﻿using System;
#if !WINRT
using System.Web;
#endif
using System.Collections.Generic;
using Mindscape.Raygun4Net.Messages;

namespace Mindscape.Raygun4Net
{
  public interface IRaygunMessageBuilder
  {
    RaygunMessage Build();

    IRaygunMessageBuilder SetMachineName(string machineName);

    IRaygunMessageBuilder SetExceptionDetails(Exception exception);

    IRaygunMessageBuilder SetClientDetails();

    IRaygunMessageBuilder SetEnvironmentDetails();

    IRaygunMessageBuilder SetVersion();

    IRaygunMessageBuilder SetTags(List<string> tags);
  }
}