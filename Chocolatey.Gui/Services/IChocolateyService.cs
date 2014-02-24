﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Management.Automation;
using System.Threading.Tasks;
using Chocolatey.Gui.Models;
using Chocolatey.Gui.ViewModels.Items;

namespace Chocolatey.Gui.Services
{
    public interface IChocolateyService
    {
        Task<IEnumerable<IPackageViewModel>> GetInstalledPackages(bool force = false);
        Task<IEnumerable<IPackageViewModel>> GetPackagesFromLocalDirectory(Dictionary<string, string> requestedPackages, string directoryPath);
        Task InstallPackage(string id, SemanticVersion version = null, Uri source = null);
        Task UninstallPackage(string id, SemanticVersion version, bool force = false);
        Task UpdatePackage(string id, Uri source = null);
        bool IsPackageInstalled(string id, SemanticVersion version);

        Task<bool> ExecutePackageCommand(Dictionary<string, object> commandArgs, bool refreshPackages = true);

        Task RunDirectChocolateyCommand(Dictionary<string, object> commandArgs,
            bool refreshPackages = true,
            bool logOutput = true, bool clearBuffer = true);

        Task<Collection<PSObject>> RunIndirectChocolateyCommand(string commandString, bool refreshPackages = true,
            bool logOutput = true, bool clearBuffer = true);

        event PackagesChangedEventHandler PackagesUpdated;
    }
}
