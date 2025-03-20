using System.Runtime.InteropServices;
using System.Runtime.Versioning;

namespace HedgeModManager.ObjectiveC
{
    [SupportedOSPlatform("macos")]
    public readonly partial struct Selector
    {
        [LibraryImport("/usr/lib/libobjc.A.dylib", StringMarshalling = StringMarshalling.Utf8)]
        private static unsafe partial IntPtr sel_getUid(string name);

        public readonly IntPtr SelPtr;

        public Selector(string name)
        {
            var ptr = sel_getUid(name);

            if (ptr == IntPtr.Zero)
            {
                Console.WriteLine($"Failed to get selector {name}!");
            }

            SelPtr = ptr;
        }

        public static implicit operator Selector(string value) => new(value);
        public static implicit operator IntPtr(Selector sel) => sel.SelPtr;
    }
}
