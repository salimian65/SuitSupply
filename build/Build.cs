using System;
using System.Linq;
using Nuke.Common;
using Nuke.Common.CI;
using Nuke.Common.CI.AzurePipelines;
using Nuke.Common.Execution;
using Nuke.Common.Git;
using Nuke.Common.IO;
using Nuke.Common.ProjectModel;
using Nuke.Common.Tooling;
using Nuke.Common.Tools.DotNet;
using Nuke.Common.Tools.Git;
using Nuke.Common.Utilities.Collections;
using Octokit;
using static Nuke.Common.EnvironmentInfo;
using static Nuke.Common.IO.FileSystemTasks;
using static Nuke.Common.IO.PathConstruction;

[AzurePipelines(
    AzurePipelinesImage.UbuntuLatest,
    InvokedTargets = new[] { nameof(Publish) })]
class Build : NukeBuild
{
    /// Support plugins are available for:
    ///   - JetBrains ReSharper        https://nuke.build/resharper
    ///   - JetBrains Rider            https://nuke.build/rider
    ///   - Microsoft VisualStudio     https://nuke.build/visualstudio
    ///   - Microsoft VSCode           https://nuke.build/vscode
    [GitRepository]
    readonly GitRepository Repository;
    public static int Main () => Execute<Build>(x => x.PrivateBuild);

    [Parameter("Configuration to build - Default is 'Debug' (local) or 'Release' (server)")]
    readonly Configuration Configuration = IsLocalBuild ? Configuration.Debug : Configuration.Release;


    [Solution] readonly Solution Solution;

    Target Clean => _ => _
        .Before(RestorePackages)
        .Executes(() =>
        {
            GlobDirectories(Solution.Directory, "**/src/bin", "**/src/obj").ForEach(DeleteDirectory);
            //DotNetTasks.DotNetClean(a=>a.SetProject(Solution));
        });

    Target RestorePackages => _ => _
        .DependsOn(Clean)
        .Executes(() =>
        {
            DotNetTasks.DotNetRestore(a => a.SetProjectFile(Solution));
        });

    Target Compile => _ => _
        .DependsOn(RestorePackages)
        .Executes(() =>
        {
            DotNetTasks.DotNetBuild(a => a.SetProjectFile(Solution).EnableNoRestore());
        });

    Target RunUnitTests => _ => _
                               .DependsOn(Compile)
                               .Executes(() =>
                               {
                                   var testProjects = Solution.Projects
                                                              .Where(a => a.Name.EndsWith("UnitTests", StringComparison.OrdinalIgnoreCase))
                                                              .ToList();

                                   foreach (var testProject in testProjects)
                                   {
                                       DotNetTasks.DotNetTest(a => a.SetProjectFile(testProject)
                                                                  .EnableNoBuild()
                                                                  .EnableNoRestore());
                                   }
                               });

    Target Push => _ => _
        .DependsOn(RunUnitTests)
        .Executes(() =>
        {
            //if (IsLocalBuild = "")
            //{
            //}
            //GitTasks.Git("commit -m ''");
            //GitTasks.Git("push");
        });

    Target PrivateBuild => _ => _.Executes(() =>
    {

    });

    Target Publish => _ => _.DependsOn(RunUnitTests)
        .Executes(() =>
        {
            if (Repository.Tags.Any(t => t == "Stg"))
            {
                //Publish to stg
            }
            else if (Repository.Tags.Any(t => t == "Pro"))
            {
                //publish to production
            }
        });

    Target PublishTarget => _ => _
                           .DependsOn(RunUnitTests)
                           .Executes(() =>
                           {
                               var publishSettings = new DotNetPublishSettings();
                               DotNetTasks.DotNetPublish(s => publishSettings
                                                                                          .SetProject(Solution));
                           });


}
