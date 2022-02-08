// See https://aka.ms/new-console-template for more information
using System.Runtime.InteropServices;
using Stride.TTF;

namespace Stride.TTF;

public static class Program 
{
    public static void Main(String[] args)
    {
        Console.WriteLine("Hello, World!");
        var bytes = File.ReadAllBytes("./nes.TTF");
        var ptr = TTFInterop.char_mesh_2d(bytes, (uint)bytes.Length, 'e', 8);
        MarshalUnmananagedArray2Struct(ptr.data,(int)ptr.len, out Vector2[] verts);
        var x = 0;
    }
    public static void MarshalUnmananagedArray2Struct<T>(IntPtr unmanagedArray, int length, out T[] mangagedArray)
    {
        var size = Marshal.SizeOf(typeof(T));
        mangagedArray = new T[length];

        for (int i = 0; i < length; i++)
        {
            IntPtr ins = new IntPtr(unmanagedArray.ToInt64() + i * size);
            mangagedArray[i] = Marshal.PtrToStructure<T>(ins);
        }
    }
}

