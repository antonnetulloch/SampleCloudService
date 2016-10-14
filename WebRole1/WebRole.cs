using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.Diagnostics;
using Microsoft.WindowsAzure.ServiceRuntime;

namespace WebRole1
{
    public class WebRole : RoleEntryPoint
    {
        public override bool OnStart()
        {
            // For information on handling configuration changes
            // see the MSDN topic at http://go.microsoft.com/fwlink/?LinkId=166357.

            LocalResource localResource = RoleEnvironment.GetLocalResource("MyTempStorage");
            System.Diagnostics.Trace.Write(localResource.RootPath);

            string text = "Hopefully on the next deploy a file gets created on local drive";
            System.IO.File.WriteAllText(localResource.RootPath + "\\startmessage.txt", text);
            return base.OnStart();
        }
    }
}
