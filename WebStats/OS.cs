using System;
using System.Linq;
using System.Text;

namespace WebStats
{
    public class OS
    {
        public string Family { get; set; }
        public string Major { get; set; }
        public string Minor { get; set; }
        public string Patch { get; set; }
        public string PatchMinor { get; set; }

        public OS() { }

        public OS(string family, string major, string minor, string patch, string patchMinor)
        {
            Family = family;
            Major = major;
            Minor = minor;
            Patch = patch;
            PatchMinor = patchMinor;
        }

        public override string ToString()
        {
            var stringBuilder = new StringBuilder(Family);

            var str = ToVersionString();
            if (!String.IsNullOrEmpty(str))
            {
                stringBuilder
                    .Append(' ')
                    .Append(str);
            }

            return stringBuilder.ToString();
        }

        public string ToVersionString()
        {
            return String.Join(".", new[]
            {
                Major,
                Minor,
                Patch,
                PatchMinor
            }
            .Where(x => !String.IsNullOrEmpty(x)));
        }
    }
}