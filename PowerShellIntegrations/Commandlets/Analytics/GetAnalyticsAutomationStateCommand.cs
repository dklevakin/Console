﻿using System.Data.Objects;
using System.Management.Automation;

namespace Cognifide.PowerShell.PowerShellIntegrations.Commandlets.Analytics
{
    [Cmdlet("Get", "AnalyticsAutomationState")]
    [OutputType(new[] {typeof (AutomationStates)})]
    public class GetAnalyticsAutomationStateCommand : AnalyticsBaseCommand
    {
        protected override void ProcessRecord()
        {
            ObjectQuery<AutomationStates> automationStates = Context.AutomationStates;

            PipeQuery(automationStates);
        }
    }
}