<img src="https://github.com/Bender-6502/GitVersioning/blob/master/GitVersioning/assets/GitVersioning.png" width="25%"></img>
# GitVersioning

Version 1.0.0

Build versioning tool for Visual Studio Workflow Actions supporting C# .Net Maui projects.

Build
-----
Open the solution file GitVersioning.slnx in Visual Studio 2026+ and build for Windows

Usage
-----
1. Simply add GitVersioning.dll and dependencies to your project and reference GitVersioning.targets in your project file with the following line:
```xml
<Import Project="GitVersioning\GitVersioning.targets"/>
```

2. In your Workflow file, add the following lines populate the WorkflowFile.def:
```yaml
env:
  workflowFile: WorkflowFile.def
  major: 1
  minor: 2
  build: 3
  revis: ${{ github.run_number }}

  -name: Update resources
    shell: bash
    run: |
      echo 'major: ${{ env.major }}' > "${{ env.workflowFile }}"
      echo 'minor: ${{ env.minor }}' > "${{ env.workflowFile }}"
      echo 'build: ${{ env.build }}' > "${{ env.workflowFile }}"
      echo 'revis: ${{ env.revis }}' >> "${{ env.workflowFile }}"
```

3. For more information, see the GitVersioningTest.csproj
