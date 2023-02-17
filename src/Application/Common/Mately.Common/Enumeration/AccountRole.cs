using System.ComponentModel.DataAnnotations;
using Mately.Common.Constants;

namespace Mately.Common.Enumeration;

public enum AccountRole
{
    [Display(Name = RoleContant.SuperAdmin)]
    SuperAdmin = 0,
    [Display(Name = RoleContant.Admin)]
    Admin = 1,
    [Display(Name = RoleContant.TestUser)]
    TestUser = 2,
    [Display(Name = RoleContant.FreeUser)]
    FreeUser = 3,
    [Display(Name = RoleContant.Premium)]
    Premium = 5
}