param($installPath, $toolsPath, $package, $project)

$item = $project.ProjectItems.Item("Models").ProjectItems.Item("ResourcesModels.resx")
$item.Properties.Item("BuildAction").Value = [int]3
$item.Properties.Item("CustomTool").Value = "PublicResXFileCodeGenerator" 

$item = $project.ProjectItems.Item("Views").ProjectItems.Item("ResourcesLabels.resx")
$item.Properties.Item("BuildAction").Value = [int]3
$item.Properties.Item("CustomTool").Value = "PublicResXFileCodeGenerator" 

