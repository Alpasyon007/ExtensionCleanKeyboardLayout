// Copyright (c) Microsoft Corporation
// The Microsoft Corporation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using ExtensionName;
using Microsoft.CommandPalette.Extensions;
using Microsoft.CommandPalette.Extensions.Toolkit;

namespace ExtensionCleanKeyboardLayout;

public partial class ExtensionCleanKeyboardLayoutCommandsProvider : CommandProvider
{
    private readonly ICommandItem[] _commands;

    public ExtensionCleanKeyboardLayoutCommandsProvider()
    {
        DisplayName = "Clean Keyboard Layouts";
        Icon = IconHelpers.FromRelativePath("Assets\\StoreLogo.png");
        _commands = [
            new CommandItem(new CleanKeyboardLayoutCommand()) { Title = DisplayName },
        ];
    }

    public override ICommandItem[] TopLevelCommands()
    {
        return _commands;
    }

}
