﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs.Extensions;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Azure.WebJobs.Host.Protocols;

namespace Mindscape.Raygun4Net.Azure.WebJob
{
  /// <summary>
  /// Captures and sends exceptions to Raygun for reporting and analysis.  
  /// </summary>
  public class RaygunExceptionHandler
  {
    private readonly RaygunClient _client;

    public RaygunExceptionHandler(string apiKey)
    {
      _client = new RaygunClient(apiKey);
      _client.AddWrapperExceptions(typeof(FunctionInvocationException));
    }

    /// <summary>
    /// Process Web Job Function Invocation Exceptions
    /// </summary>
    /// <param name="filter">The <see cref="TraceFilter"/> containing information about the exception.</param>
    public void Process(TraceFilter filter)
    {
      // Get Web Job scm Host URI: yoursite.scm.azurewebsites.net
      var httpHost = Environment.GetEnvironmentVariable("HTTP_HOST");

      var events = filter.GetEvents().Where(e => e.Exception != null);
      foreach (var traceEvent in events)
      {
        var tags = new List<string>();

        // Add all trace properties to custom data
        var customData = traceEvent.Properties.ToDictionary(traceEventProperty => traceEventProperty.Key, traceEventProperty => traceEventProperty.Value);

        // If the FunctionInvocationId is available to us, we can use it to build a clickable link using the http host
        if (traceEvent.Properties.ContainsKey("MS_FunctionInvocationId") && !string.IsNullOrEmpty(httpHost))
        {
          var functionInvocationId = traceEvent.Properties["MS_FunctionInvocationId"];
          customData["Dashboard URL"] = $"https://{httpHost}/azurejobs/#/functions/invocations/{functionInvocationId}";
        }

        // If the FunctionDescriptor is available to us, we can use it to tag the executed function in raygun
        if (traceEvent.Properties.ContainsKey("MS_FunctionDescriptor"))
        {
          var functionDescriptor = (FunctionDescriptor)traceEvent.Properties["MS_FunctionDescriptor"];
          tags.Add(functionDescriptor.ShortName);
        }

        _client.Send(traceEvent.Exception, tags, customData);
      }
    }
  }
}
