using System.Reflection;

//
// Les informations g�n�rales relatives � un assembly d�pendent de
// l'ensemble d'attributs suivant. Pour modifier les informations
// associ�es � un assembly, changez les valeurs de ces attributs.
//
[assembly: AssemblyTitle("Classe Complex")]
[assembly: AssemblyDescription("Impl�mentation d'une classe math�matique")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("P.VIOLENT")]
[assembly: AssemblyProduct("")]
[assembly: AssemblyCopyright("2004-2012 PV")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]

//
// Les informations de version pour un assembly se composent des quatre valeurs suivantes�:
//
//      Version principale
//      Version secondaire
//      Num�ro de build
//      R�vision
//
// Vous pouvez sp�cifier toutes les valeurs ou indiquer des num�ros de r�vision et de build par d�faut
// en utilisant '*', comme ci-dessous :

[assembly: AssemblyVersion("1.0.*")]

//
// Pour signer votre assembly, vous devez sp�cifier la Clé � utiliser. Consultez
// la documentation Microsoft .NET Framework pour plus d'informations sur la signature d'un assembly.
//
// Utilisez les attributs ci-dessous pour contr�ler la Clé utilis�e lors de la signature.
//
// Remarques�:
//   (*) Si aucune Clé n'est sp�cifi�e, l'assembly n'est pas sign�.
//   (*) KeyName fait r�f�rence � une Clé install�e dans le fournisseur de
//       services cryptographiques (CSP) de votre ordinateur. KeyFile fait r�f�rence � un fichier qui contient
//       une Clé.
//   (*) Si les valeurs de KeyFile et de KeyName sont sp�cifi�es, le
//       traitement suivant se produit�:
//       (1) Si KeyName se trouve dans le CSP, la Clé est utilis�e.
//       (2) Si KeyName n'existe pas mais que KeyFile existe, la Clé
//           de KeyFile est install�e dans le CSP et utilis�e.
//   (*) Pour cr�er KeyFile, vous pouvez utiliser l'utilitaire sn.exe (Strong Name, Nom fort).
//        Lors de la sp�cification de KeyFile, son emplacement doit �tre
//        relatif au r�pertoire de sortie du projet qui est
//       %Project Directory%\obj\<configuration>. Par exemple, si votre KeyFile se trouve
//       dans le r�pertoire du projet, vous devez sp�cifier l'attribut
//       AssemblyKeyFile sous la forme [assembly: AssemblyKeyFile("..\\..\\mykey.snk")]
//   (*) DelaySign (signature diff�r�e) est une option avanc�e. Pour plus d'informations, consultez la
//       documentation Microsoft .NET Framework.
//
[assembly: AssemblyDelaySign(false)]
[assembly: AssemblyKeyFile("")]
[assembly: AssemblyKeyName("")]