using System.Runtime.InteropServices;
using System.Text;

namespace SCEToolSharp;

public static unsafe class LibSceToolSharp {
	[DllImport("scetool")]
	private static extern void frontend_print_infos(byte* file);

	[DllImport("scetool")]
	private static extern void frontend_decrypt(byte* fileIn, byte* fileOut);

	[DllImport("scetool")]
	private static extern void frontend_encrypt(byte* fileIn, byte* fileOut);

	public static void Decrypt(string input, string output) {
		fixed (byte* inputPtr = Encoding.ASCII.GetBytes(input + "\0"))
			fixed (byte* outputPtr = Encoding.ASCII.GetBytes(output + "\0"))
				frontend_decrypt(inputPtr, outputPtr);
	}
	
	public static void Encrypt(string input, string output) {
		fixed (byte* inputPtr = Encoding.ASCII.GetBytes(input + "\0"))
			fixed (byte* outputPtr = Encoding.ASCII.GetBytes(output + "\0"))
				frontend_encrypt(inputPtr, outputPtr);
	}
	
	public static void PrintInfos(string file) {
		fixed (byte* filePtr = Encoding.ASCII.GetBytes(file + "\0"))
			frontend_print_infos(filePtr);
	}
}
