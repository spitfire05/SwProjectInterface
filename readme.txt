SwProjectInterface - A workflow helper for SolidWorks. Integrates project’s part library with SolidWorks API.

Requires:

* .NET framework 3.5 or newer.
* SolidWorks (tested with 2013 SP4)

USAGE: Unzip the files to the folder of your choice and run SwProjectInterface.exe

CHANGELOG:

0.1.0.0
=======
- BUGFIX: Now reading user settings from previours program version if present are missing.
- Added option to change the custom property value of existing files.
- User will now be notified when new version is available online.
- Cleaned up some SW api code
- GUI is now a little more sane.
- Added option to close open project and change the custom preperty name value without restarting the app.
- Minor CSVImport bugfixes and features
- Fix bug where it was possible to add same file to project multiple times

0.0.2.0
=======
- Program version stored in project file for future compatibility purposes.
- Database "Open", "Update name" and "Remove" buttons moved to right-click context menu.
- Added option to find missing files manually.
- Improved file status updating.
- Custom property key un-hardcoded.
- Added prefix and suffix text boxes to number input form.
- Avoiding opening multiple Solidworks instances in background when reading file properties.
- BUG: when file gets created, it is reported as "FILE MISSING" - FIXED
- simple CSV import added.
- simple CSV export added.
- Few minor bugfixes.

0.0.1.0
=======
- First version ready to testing. The custom property key value is hardcoded, to be opened in next version.