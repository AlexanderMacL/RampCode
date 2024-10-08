﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Security.Principal;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Leaderboard
{
   [RunInstaller(true)]
   public partial class CustomActions : System.Configuration.Install.Installer
   {
      public override void Install(IDictionary stateSaver)
      {
         base.Install(stateSaver);
      }
      [System.Security.Permissions.SecurityPermission(System.Security.Permissions.SecurityAction.Demand)]
      public override void Commit(IDictionary savedState)
      {
         base.Commit(savedState);
         string targetdir = Path.GetDirectoryName(Context.Parameters["targetdir"]);
         File.SetAttributes(targetdir, FileAttributes.Normal);
         // Retrieve the Directory Security descriptor for the directory
         var dSecurity = Directory.GetAccessControl(targetdir, AccessControlSections.Access);
         // Build a temp domainSID using the Null SID passed in as a SDDL string.
         // The constructor will accept the traditional notation or the SDDL notation interchangeably.
         var domainSid = new SecurityIdentifier("S-1-0-0");
         // Create a security Identifier for the BuiltinUsers Group to be passed to the new accessrule
         var ident = new SecurityIdentifier(WellKnownSidType.BuiltinUsersSid, domainSid);
         // Create a new Access Rule.
         // ContainerInherit AND ObjectInherit covers both target folder, child folder and child object.
         // However, when using both (combined with AND), the permissions aren't applied.
         // So use two rules.
         // Propagate.none means child and grandchild objects inherit.
         var accessRule1 = new FileSystemAccessRule(ident, FileSystemRights.FullControl, InheritanceFlags.ObjectInherit, PropagationFlags.None, AccessControlType.Allow);
         var accessRule2 = new FileSystemAccessRule(ident, FileSystemRights.FullControl, InheritanceFlags.ContainerInherit, PropagationFlags.None, AccessControlType.Allow);
         // Add the access rules to the Directory Security Descriptor
         dSecurity.AddAccessRule(accessRule1);
         dSecurity.AddAccessRule(accessRule2);
         // Persist the Directory Security Descriptor to the directory
         Directory.SetAccessControl(targetdir, dSecurity);

         //var ac = Directory.GetAccessControl(targetdir);
         //ac.AddAccessRule(new FileSystemAccessRule(new SecurityIdentifier(WellKnownSidType.BuiltinUsersSid, new SecurityIdentifier("S-1-0-0")), FileSystemRights.FullControl, AccessControlType.Allow));
         //Directory.SetAccessControl(targetdir, ac);
         //MessageBox.Show("Boom");

      }

      public override void Rollback(IDictionary savedState)
      {
         base.Rollback(savedState);
      }

      public override void Uninstall(IDictionary savedState)
      {
         base.Uninstall(savedState);
      }
   }
}