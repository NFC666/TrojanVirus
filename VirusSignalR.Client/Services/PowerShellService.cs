using System;
using System.Collections.Generic;
using System.Management.Automation;
using System.Text;

namespace VirusSignal.Client.Services
{
    public class PowerShellService
    {
        private PowerShell ps = PowerShell.Create();

        public string Execute(string command)
        {
            ps.AddScript(command);
            var results = ps.Invoke();
            return results[0].BaseObject.ToString() + "";
        }
    }
}
