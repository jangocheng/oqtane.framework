﻿using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using Oqtane.Models;

namespace Oqtane.Repository
{
    public class UserRoleRepository : IUserRoleRepository
    {
        private TenantDBContext db;

        public UserRoleRepository(TenantDBContext context)
        {
            db = context;
        }

        public IEnumerable<UserRole> GetUserRoles()
        {
            return db.UserRole;
        }
        public IEnumerable<UserRole> GetUserRoles(int UserId)
        {
            return db.UserRole.Where(item => item.UserId == UserId)
                .Include(item => item.Role); // eager load roles
        }

        public IEnumerable<UserRole> GetUserRoles(int UserId, int SiteId)
        {
            return db.UserRole.Where(item => item.UserId == UserId)
                .Include(item => item.Role) // eager load roles
                .Where(item => item.Role.SiteId == SiteId);
        }

        public UserRole AddUserRole(UserRole UserRole)
        {
            db.UserRole.Add(UserRole);
            db.SaveChanges();
            return UserRole;
        }

        public UserRole UpdateUserRole(UserRole UserRole)
        {
            db.Entry(UserRole).State = EntityState.Modified;
            db.SaveChanges();
            return UserRole;
        }

        public UserRole GetUserRole(int UserRoleId)
        {
            return db.UserRole.Include(item => item.Role) // eager load roles
                .SingleOrDefault(item => item.UserRoleId == UserRoleId);
        }

        public void DeleteUserRole(int UserRoleId)
        {
            UserRole UserRole = db.UserRole.Find(UserRoleId);
            db.UserRole.Remove(UserRole);
            db.SaveChanges();
        }
    }
}