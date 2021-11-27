using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Saitynu_API.Auth.Model
{
    public static class RestUserRoles
    {
        public const string Admin = nameof(Admin);
        public const string Tester = nameof(Tester);
        public const string Player = nameof(Player);

        public static readonly IReadOnlyCollection<string> All = new[] { Admin, Tester, Player };
    }
}
