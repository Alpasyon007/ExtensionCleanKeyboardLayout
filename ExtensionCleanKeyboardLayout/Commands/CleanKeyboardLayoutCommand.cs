using Microsoft.CommandPalette.Extensions.Toolkit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace ExtensionName;

internal sealed partial class CleanKeyboardLayoutCommand : InvokableCommand
{
	public override string Name => "Clear All Non-Turkish Keyboard Layouts";
	public override IconInfo Icon => new("\uE8A7");

	// Replace with your desired excluded layout IDs
	private static readonly HashSet<uint> ExcludedLayouts = new()
	{
		0xF0140809, // Turkish (Turkey) - F Keyboard
		0x041F041F  // Turkish (Turkey) - Q Keyboard
	};

	public override CommandResult Invoke()
	{
		List<int> layouts = GetKeyboardLayoutList();

		int removedCount = 0;
		foreach (var layout in layouts)
		{
			if (!ExcludedLayouts.Contains((uint)layout))
			{
				if (UnloadKeyboardLayout((IntPtr)layout))
					removedCount++;
			}
		}

		return CommandResult.KeepOpen();
	}

	private static List<int> GetKeyboardLayoutList()
	{
		uint count = GetKeyboardLayoutList(0, null);
		IntPtr[] handles = new IntPtr[count];
		_ = GetKeyboardLayoutList(count, handles);

		var list = new List<int>((int)count);
		foreach (var ptr in handles)
		{
			list.Add((int)ptr);
		}
		return list;
	}

	[DllImport("user32.dll")]
	private static extern bool UnloadKeyboardLayout(IntPtr hkl);

	[DllImport("user32.dll")]
	private static extern uint GetKeyboardLayoutList(uint nBuff, [Out] IntPtr[]? lpList);
}