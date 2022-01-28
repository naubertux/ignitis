# ignitis

## Instaliavimas

1. Praleidžiame Ignitis/Config/DB/ esančius skriptus failų numeracijos tvarka:

* 01_SYSTEM_skriptai.sql - SYSTEM schemoje
* 02_IGNITIS_skriptai.sql - IGNITIS schemoje
* 03_REGISTRACIJOS_PAKETAS.sql - IGNITIS schemoje

2. Pasikoreguojame connection stringą Ignitis/Config/connectionStrings.config

## Pastabos

Jei po bildinimo pasileidus apsui mestų "Could not find a part of the path '...\Ignitis\bin\roslyn\csc.exe',
pabandykit Package Manager Console praleisti:

  Update-Package Microsoft.CodeDom.Providers.DotNetCompilerPlatform -r

(Daugiau: https://stackoverflow.com/questions/32780315/could-not-find-a-part-of-the-path-bin-roslyn-csc-exe)