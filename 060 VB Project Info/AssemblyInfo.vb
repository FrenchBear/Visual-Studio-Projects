Imports System.Reflection
Imports System.Runtime.InteropServices

' General Information about an assembly is controlled through the following 
' set of attributes. Change these attribute values to modify the information
' associated with an assembly.

<Assembly: AssemblyTitle("Titre de l'assembly")>
<Assembly: AssemblyDescription("Description de l'assembly")>
<Assembly: AssemblyCompany("Bonne compagnie")>
<Assembly: AssemblyProduct("Produit dangereux ?")>
<Assembly: AssemblyCopyright("(c) Pierre VIOLENT 2001")>
<Assembly: AssemblyTrademark("(tm) Pierre VIOLENT 2001")>
<Assembly: CLSCompliant(True)>

' Ajouts PV
<Assembly: AssemblyInformationalVersion("1.2.3.4")>
'<Assembly: AssemblyFlags(0)> 


' Attributs privés
<Assembly: AssemblyPV(47, Info:="Attribut PV")>

'The following GUID is for the ID of the typelib if this project is exposed to COM
<Assembly: Guid("F4247BC9-9C4C-40F0-8C8E-2500329DE00D")>

' Version information for an assembly consists of the following four values:
'      Major Version
'      Minor Version 
'      Build Number
'      Revision
' You can specify all the values or you can default the Build and Revision Numbers 
' by using the '*' as shown below:

<Assembly: AssemblyVersion("3.5.*")>
