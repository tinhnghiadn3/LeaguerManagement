using System;
using System.Collections.Generic;
using System.Linq;
using LeaguerManagement.Entities.ViewModels;

namespace LeaguerManagement.Entities.Utilities.Helper {
	public static class UserTokenHelper {
		private static readonly List<UserTokenModel> UserTokens;

		static UserTokenHelper()
		{
			UserTokens = new List<UserTokenModel>();
		}

		public static void AddToken(UserTokenModel token)
		{
			lock (UserTokens) {
				UserTokens.Add(token);
			}
		}

		public static void InitUserTokens(IList<UserTokenModel> tokens)
		{
			lock (UserTokens) {
				UserTokens.Clear();
				UserTokens.AddRange(tokens);
			}
		}

		public static void RemoveExpiredTokens(DateTime toDate)
		{
			lock (UserTokens) {
				UserTokens.RemoveAll(_ => _.ExpireAt < toDate);
			}
		}

		public static UserTokenModel GetUserToken(string token, TokenType tokenType)
		{
			lock (UserTokens) {
				switch (tokenType) {
					case TokenType.ImageToken:
						return UserTokens.FirstOrDefault(_ => _.ImageToken == token);
					default:
						return UserTokens.FirstOrDefault(_ => _.Token == token);
				}
			}
		}
	}
}
