# Creating plugins with Managed Extensibility Framework #

### What is this repository for? ###

Quick demonstration of:

* Exporting types
* Exporting methods
* Exporting with metadata
* Picking up plugins loaded into a folder

######################

# Basics #

* Open "Plugins with MEF\Plugins with MEF.sln" in Visual Studio
* Export types or methods with [Export], and import them using [ImportMany] along with an IEnumerable of your type.
* The folder "Type export plugins" contains types that are exported using the [Export(typeof(<interface>))] attribute.
* Named exports can be done using [Export("named export")], along with [Import("named export")]
* Methods are imported using [Import]... Func<>

# Directory Catalogs #
* A more real life scenario would be to import assemblies from a specified folder (rather than just searching the executing assembly).
* Create a new DirectoryCatalog and give it the folder name to look in and optional filter:


```
#!c#

DirectoryCatalog catalog = new DirectoryCatalog("Plugin dropin folder", "*.dll");
```

* Try this out by building the solution and copying "PluginDll.dll" into the "Plugin dropin folder"