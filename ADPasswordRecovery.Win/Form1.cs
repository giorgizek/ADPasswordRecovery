using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.DirectoryServices.AccountManagement;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ADPasswordRecovery.Win
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private PrincipalContext GetPrincipalContextForGroups()
        {
            return new PrincipalContext(ContextType.Domain, txtDomainName.Text, txtAdminUserName.Text, txtAdminPassword.Text);
        }
        private PrincipalContext GetPrincipalContextForUsers()
        {
            return new PrincipalContext(ContextType.Domain, txtDomainName.Text, txtAdminUserName.Text, txtAdminPassword.Text);
        }

        public List<UserPrincipal> GetUsersForPasswordReset()
        {
            var result = new List<UserPrincipal>();

            foreach (var item in txtManageableRoles.Text.Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries))
            {
                var grp = GroupPrincipal.FindByIdentity(GetPrincipalContextForGroups(), IdentityType.Name, item.Trim());

                if (grp != null)
                {
                    foreach (var user in grp.GetMembers(true))
                    {
                        if (user is UserPrincipal && !result.Contains(user))
                            result.Add((UserPrincipal)user);
                    }
                }
            }

            return result.OrderBy(x => x.UserPrincipalName).ToList();
        }

        private void btnGetUsers_Click(object sender, EventArgs e)
        {
            dgvUsers.DataSource = GetUsersForPasswordReset();
        }
    }
}
