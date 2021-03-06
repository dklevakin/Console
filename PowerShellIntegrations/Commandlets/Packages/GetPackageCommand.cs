﻿using System.IO;
using System.Management.Automation;
using Sitecore.Install;
using Sitecore.Install.Serialization;
using Sitecore.IO;

namespace Cognifide.PowerShell.PowerShellIntegrations.Commandlets.Packages
{
    [Cmdlet("Get", "Package")]
    [OutputType(new[] {typeof (PackageProject)})]
    public class GetPackageCommand : BasePackageCommand
    {
        [Parameter(Position = 0, Mandatory = true)]
        [Alias("FullName", "FileName")]
        public string Path { get; set; }

        protected override void ProcessRecord()
        {
            PerformInstallAction(() =>
            {
                PackageProject packageProject = null;
                if (Path != null)
                {
                    string fileName = Path;

                    if (!System.IO.Path.IsPathRooted(Path))
                    {
                        fileName = FullPackageProjectPath(Path);
                    }

                    if (File.Exists(fileName))
                    {
                        packageProject =
                            IOUtils.LoadObject(
                                FileUtil.ReadFromFile(fileName))
                                as PackageProject;
                    }
                    WriteObject(packageProject, false);
                }
            });
        }
    }
}