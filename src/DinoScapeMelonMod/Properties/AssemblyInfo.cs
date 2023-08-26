using MelonLoader;
using System.Reflection;

[assembly: AssemblyTitle(DinoScapeMelonMod.BuildInfo.Description)]
[assembly: AssemblyDescription(DinoScapeMelonMod.BuildInfo.Description)]
[assembly: AssemblyCompany(DinoScapeMelonMod.BuildInfo.Company)]
[assembly: AssemblyProduct(DinoScapeMelonMod.BuildInfo.Name)]
[assembly: AssemblyCopyright("Created by " + DinoScapeMelonMod.BuildInfo.Author)]
[assembly: AssemblyTrademark(DinoScapeMelonMod.BuildInfo.Company)]
[assembly: AssemblyVersion(DinoScapeMelonMod.BuildInfo.Version)]
[assembly: AssemblyFileVersion(DinoScapeMelonMod.BuildInfo.Version)]
[assembly: MelonInfo(typeof(DinoScapeMelonMod.DinoScapeMelonMod), DinoScapeMelonMod.BuildInfo.Name, DinoScapeMelonMod.BuildInfo.Version, DinoScapeMelonMod.BuildInfo.Author, DinoScapeMelonMod.BuildInfo.DownloadLink)]
[assembly: MelonColor()]

// Create and Setup a MelonGame Attribute to mark a Melon as Universal or Compatible with specific Games.
// If no MelonGame Attribute is found or any of the Values for any MelonGame Attribute on the Melon is null or empty it will be assumed the Melon is Universal.
// Values for MelonGame Attribute can be found in the Game's app.info file or printed at the top of every log directly beneath the Unity version.
[assembly: MelonGame(null, null)]