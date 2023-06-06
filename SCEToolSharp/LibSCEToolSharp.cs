﻿using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using System.Text;

namespace SCEToolSharp;

[SuppressMessage("ReSharper", "UnusedType.Global")]
[SuppressMessage("ReSharper", "UnusedMember.Global")]
public static unsafe partial class LibSceToolSharp
{
	[LibraryImport("scetool")]
	private static partial int libscetool_init();
	
	[LibraryImport("scetool")]
	private static partial void frontend_print_infos(byte* file);

	[LibraryImport("scetool")]
	private static partial void frontend_decrypt(byte* fileIn, byte* fileOut);

	[LibraryImport("scetool")]
	private static partial void frontend_encrypt(byte* fileIn, byte* fileOut);

	[LibraryImport("scetool")]
	private static partial void rap_set_directory(byte* dirPath);

	static LibSceToolSharp()
	{
		libscetool_init();
	}

	public static void Decrypt(string input, string output)
	{
		fixed (byte* inputPtr = Encoding.ASCII.GetBytes(input + "\0"))
			fixed (byte* outputPtr = Encoding.ASCII.GetBytes(output + "\0"))
				frontend_decrypt(inputPtr, outputPtr);
	}
	
	public static void Encrypt(string input, string output)
	{
		fixed (byte* inputPtr = Encoding.ASCII.GetBytes(input + "\0"))
			fixed (byte* outputPtr = Encoding.ASCII.GetBytes(output + "\0"))
				frontend_encrypt(inputPtr, outputPtr);
	}
	
	public static void PrintInfos(string file)
	{
		fixed (byte* filePtr = Encoding.ASCII.GetBytes(file + "\0"))
			frontend_print_infos(filePtr);
	}

	public static void SetRapDirectory(string dirPath)
	{
		if (!Directory.Exists(dirPath)) throw new DirectoryNotFoundException(dirPath);
		
		fixed (byte* dirPtr = Encoding.ASCII.GetBytes(dirPath + '\0'))
			rap_set_directory(dirPtr);
	}
}
