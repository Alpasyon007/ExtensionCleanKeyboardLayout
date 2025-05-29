# ExtensionCleanKeyboardLayout

A PowerToys Command Palette extension to automatically remove any keyboard layout **except** Turkish-Q and Turkish-F.

## 🔧 Purpose

As a Turkish-F user who occasionally switches to Turkish-Q (QWERTY), I noticed that Windows sometimes adds additional keyboard layouts without my input. This extension provides a quick and easy way to remove all unwanted layouts, keeping only the ones I use.

## ⚙️ Customization

If you'd like to keep different layouts, you can customize the list:

1. Open `CleanKeyboardLayoutsCommand.cs`
2. Modify the `ExcludedLayouts` list to include the layouts **you want to keep**
3. Rebuild and run the extension
