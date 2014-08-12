﻿using System;
using System.Collections.Generic;
using MVCForum.Utilities;

namespace MVCForum.Domain.DomainModel
{
    public partial class MembershipRole : Entity
    {
        public MembershipRole()
        {
            Id = GuidComb.GenerateComb();
        }

        public Guid Id { get; set; }
        public string RoleName { get; set; }
        public virtual IList<MembershipUser> Users { get; set; }
        public virtual Settings Settings { get; set; }

        // Permissions
        public virtual IList<CategoryPermissionForRole> CategoryPermissionForRole { get; set; }

        public virtual Dictionary<Guid, Dictionary<Permission, bool>> GetFullPermissionTable()
        {
            var permissionRows = new Dictionary<Guid, Dictionary<Permission, bool>>();

            foreach (var catPermissionForRole in CategoryPermissionForRole)
            {
                if (!permissionRows.ContainsKey(catPermissionForRole.Category.Id))
                {
                    var permissionList = new Dictionary<Permission, bool>();

                    permissionRows.Add(catPermissionForRole.Category.Id, permissionList);
                }

                if (!permissionRows[catPermissionForRole.Category.Id].ContainsKey(catPermissionForRole.Permission))
                {
                    permissionRows[catPermissionForRole.Category.Id].Add(catPermissionForRole.Permission, catPermissionForRole.IsTicked);
                }
                else
                {
                    permissionRows[catPermissionForRole.Category.Id][catPermissionForRole.Permission] = catPermissionForRole.IsTicked;
                }
                

            }
            return permissionRows;
        }
    }
}
