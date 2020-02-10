using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ERPProject.Models;
using ERPProject.Infrastructure;
using ERPProject.Areas.UserManagement.Models;

namespace ERPProject.ViewModels
{
    public static class Dynamic_Menu
    {
        public static List<MenuItems> GetMenus()
        {

            using(var context = new ERPProjectDataContext())
            {
                return context.MenuItem.ToList();
            }
        }

        public static List<MenuItems> GetParentMenus(int userid)
        {
            using(var dbcontext = new ERPProjectDataContext())
            {
                var SQLQuery = @"select MM.* from RoleCapabilities RC
	                                INNER JOIN Capabilities CC on RC.CapabilityId=CC.Id
	                                INNER JOIN MenuItems MM on CC.MenuItemId=MM.Id
	                                INNER JOIN AccUserRoles AC on RC.RoleId=AC.RoleId and AC.UserId = @p0
		                                WHERE MM.ParentMenuItemId IS NULL";

                     return dbcontext.Database.SqlQuery<MenuItems>(SQLQuery, userid).ToList();
            }
        }

        public static List<MenuItems> GetSubMenu(int userid, int parentmenuid)
        {
            using(var dbContext = new ERPProjectDataContext())
            {
                  var SQLQuery = @"SELECT M.* FROM RoleCapabilities RR
	                                INNER join Capabilities CC on RR.CapabilityId=CC.Id
	                                INNER JOIN MenuItems M on CC.MenuItemId =M.Id	
	                                INNER join AccUserRoles AR on AR.RoleId=RR.RoleId and ar.userid=@p0
	                                WHERE M.ParentMenuItemId=@p1 and RR.Accessflag = 1";

                  var data = dbContext.Database.SqlQuery<MenuItems>(SQLQuery, userid, parentmenuid).ToList();
                  return data;
            }

          
           


        }
    }

   

}