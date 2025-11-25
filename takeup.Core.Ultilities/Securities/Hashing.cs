using System.Security.Cryptography;
using System.Text;

namespace takeup.Core.Ultilities.Securities
{
	public static class Hashing
	{
		public static Guid GenerateGuidFromString(string input)
		{
			using (MD5 md5 = MD5.Create())
			{
				byte[] hash = md5.ComputeHash(Encoding.UTF8.GetBytes(input));
				return new Guid(hash);
			}
		}
	}
}
