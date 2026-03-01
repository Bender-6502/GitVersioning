using Microsoft.Build.Framework;
using Microsoft.Build.Tasks;
using System.Xml.Linq;

namespace GitVersioning
{
    public class Request : Microsoft.Build.Utilities.Task
    {
        public override bool Execute()
        {
            try
            {
                var workflowFile = new WorkflowFile(BuildVersionFilename);

                FourDigitVersion  = string.Format("{0}.{1}.{2}.{3}", workflowFile.Major, workflowFile.Minor, workflowFile.Build, workflowFile.Revision);
                ThreeDigitVersion = string.Format("{0}.{1}.{2}", workflowFile.Major, workflowFile.Minor, workflowFile.Build);
                TwoDigitVersioon  = string.Format("{0}.{1}", workflowFile.Major, workflowFile.Minor);
                OneDigitVersion   = string.Format("{0}", workflowFile.Revision);

                return true;
            }
            catch (Exception)
            {}

            return false;
        }

        [Required]
        public string BuildVersionFilename { get; set; } = "";
        [Output]
        public string FourDigitVersion { get; set; } = "";
        [Output]
        public string ThreeDigitVersion { get; set; } = "";
        [Output]
        public string TwoDigitVersioon { get; set; } = "";
        [Output]
        public string OneDigitVersion { get; set; } = "";

    }
}
