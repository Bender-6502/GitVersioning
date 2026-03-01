#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitVersioning
{
    internal class WorkflowFile
    {
        public WorkflowFile(string BuildVersionFilename)
        {
            if (File.Exists(BuildVersionFilename))
            {
                //  env:
                //    project: GitVersioning
                //    workflowFile: GitVersioningTest/GitVersioningBuildVersion.def
                //    major: 1
                //    minor: 2
                //    build: 3
                //    revis: 4

                //    -name: Update GitVersioningBuildVersion.def
                //      shell: bash
                //      run: |
                //        echo 'major: ${{ env.major }}' >  "${{ env.workflowFile }}"
                //        echo 'minor: ${{ env.minor }}' >  "${{ env.workflowFile }}"
                //        echo 'build: ${{ env.build }}' >  "${{ env.workflowFile }}"
                //        echo 'revis: ${{ env.revis }}' >> "${{ env.workflowFile }}"

                // Read the version information from the workflow file
                using (var file = System.IO.File.OpenText(BuildVersionFilename))
                {
                    if (file == null)
                        return;

                    while (!file.EndOfStream)
                    {
                        String line = file.ReadLine();
                        if (line != null)
                        {
                            if (line.StartsWith("major:"))
                                Major = line.Substring("major:".Length).Trim();
                            else if (line.StartsWith("minor:"))
                                Minor = line.Substring("minor:".Length).Trim();
                            else if (line.StartsWith("build:"))
                                Build = line.Substring("build:".Length).Trim();
                            else if (line.StartsWith("revis:"))
                                Revision = line.Substring("revis:".Length).Trim();
                        }
                    }
                }

            }
        }

        public string Major { get; set; } = "";
        public string Minor { get; set; } = "";
        public string Build { get; set; } = "";
        public string Revision { get; set; } = "";
    }
}
