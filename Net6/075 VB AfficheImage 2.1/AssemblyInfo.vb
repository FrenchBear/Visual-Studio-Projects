Imports System.Reflection
Imports System.Resources
Imports System.Runtime.InteropServices

#Disable Warning IDE1006 ' Naming Styles

' Les informations générales relatives à un assembly dépendent de l'ensemble
' d'attributs suivant. Pour modifier les informations associées à un assembly,
'changez les valeurs de ces attributs.

' Vérifiez les valeurs des attributs de l'assembly

<Assembly: AssemblyTitle("AfficheImage")>
<Assembly: AssemblyDescription("Affichage d'images simple")>
<Assembly: AssemblyCompany("")>
<Assembly: AssemblyProduct("AfficheImage2")>
<Assembly: AssemblyCopyright("P.VIOLENT 1997-2005")>
<Assembly: AssemblyTrademark("")>
<Assembly: CLSCompliant(True)>

'Le GUID suivant est pour l'ID de la typelib si ce projet est exposé à COM
<Assembly: Guid("A117CD04-A389-4586-AA79-9A24B9B69058")>

' Les informations de version pour un assembly se composent des quatre valeurs suivantes :
'
'      Version principale
'      Version secondaire
'      Numéro de build
'      Révision
'
' Vous pouvez spécifier toutes les valeurs ou indiquer les numéros de build et de révision par défaut
' en utilisant '*', comme indiqué ci-dessous :

<Assembly: AssemblyVersion("2.1.*")>
<Assembly: ComVisible(False)>
<Assembly: NeutralResourcesLanguage("fr-FR")>

Public Module InfoVersion

    Function sGetVersion() As String
        'Return System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly.Location).FileMajorPart & "." & System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly.Location).FileMinorPart & "." & System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly.Location).FileBuildPart
        Return My.Application.Info.Version.ToString
    End Function

End Module