using System;
using System.Linq;
using System.Text;

namespace WebStats
{
    public class UserAgent
    {
        public string Family { get; set; }
        public string Major { get; set; }
        public string Minor { get; set; }
        public string Patch { get; set; }

        public UserAgent() { }

        public UserAgent(string family, string major, string minor, string patch)
        {
            Family = family;
            Major = major;
            Minor = minor;
            Patch = patch;
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
                Patch
            }
            .Where(x => !String.IsNullOrEmpty(x)));
        }
    }
}