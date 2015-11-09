SwProjectInterface - A workflow helper for SolidWorks. Integrates project’s part library with SolidWorks API.

Requires:

* .NET framework 3.5 or newer.
* SolidWorks (tested with 2013, 2014 and 2015)

USAGE: Unzip the files to the folder of your choice and run SwProjectInterface.exe

CHANGELOG:

0.3.0
=====
- Added simple filtering feature in database view window.

0.2.1
=====
- Fixed crash occuring when trying to open fifth project in a row.

0.2.0
=====
- Added possibility to batch-add existing files.
- Added tracking of recently opened projects.
- Added option to show empty rows, in numerical order (switch in right-click menu in database view).
- Added possibility of registering .swpi extension with current exe (under "Tools" menu).

0.1.1
=====
- Fix crash when attempting to save imported project.
- Change "Prefix + Name + Suffix" to "Prefix + Number + Suffix" in import fields.
- Will now ask for save when closing project.

0.1.0
=====
- BUGFIX: Now reading user settings from previours program version if present are missing.
- Added option to change the custom property value of existing files.
- User will now be notified when new version is available online.
- Cleaned up some SW api code
- GUI is now a little more sane.
- Added option to close open project and change the custom preperty name value without restarting the app.
- Minor CSVImport bugfixes and features
- Fix bug where it was possible to add same file to project multiple times

0.0.2
=====
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

0.0.1
=====
- First version ready to testing. The custom property key value is hardcoded, to be opened in next version.
