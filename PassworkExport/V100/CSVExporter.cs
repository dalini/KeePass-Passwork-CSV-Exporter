/*
  PassworkExport Plugin
  Based on the works of theVault Export by Bruce based on example export 
  code of the original developer Copyright 
  (C) 2012 Dominik Reichl <dominik.reichl@t-online.de>
  (C) 2016 Bruce A <https://sourceforge.net/u/bruce-nz/profile/>
  (C) 2022 Ives Laaf <develop@dalini.de>

  This program is free software; you can redistribute it and/or modify
  it under the terms of the GNU General Public License as published by
  the Free Software Foundation; either version 2 of the License, or
  (at your option) any later version.

  This program is distributed in the hope that it will be useful,
  but WITHOUT ANY WARRANTY; without even the implied warranty of
  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
  GNU General Public License for more details.

  You should have received a copy of the GNU General Public License
  along with this program; if not, write to the Free Software
  Foundation, Inc., 51 Franklin St, Fifth Floor, Boston, MA  02110-1301  USA
*/


using System;
using System.IO;
using System.Drawing;
using System.Diagnostics;

using KeePass;
using KeePassLib;
using KeePassLib.Delegates;
using KeePassLib.Interfaces;
using KeePassLib.Utility;

using FileFormatProvider = KeePass.DataExchange.FileFormatProvider;
using PwExportInfo = KeePass.DataExchange.PwExportInfo;

namespace PassworkExport.V100
{
    public sealed class CSVExporter : FileFormatProvider
    {
        public override bool SupportsImport { get { return false; } }
        public override bool SupportsExport { get { return true; } }

        public override string FormatName { get { return "Passwork CSV Format"; } }
        public override string DefaultExtension { get { return "csv"; } }
        public override string ApplicationGroup { get { return PassworkExportExt.GroupName; } }

        public override bool SupportsUuids { get { return true; } }
        public override bool RequiresKey { get { return true; } }

        public override Image SmallIcon
        {
            get
            {
                try
                {
                    return Program.MainForm.ClientIcons.Images[
                        (int)PwIcon.PaperLocked];
                }
                catch (Exception) { Debug.Assert(false); }
                return base.SmallIcon;
            }
        }

        public override bool Export(PwExportInfo pwExportInfo, Stream sOutput,
            IStatusLogger slLogger)

        {
            PwGroup pg = (pwExportInfo.DataGroup ?? ((pwExportInfo.ContextDatabase !=
                null) ? pwExportInfo.ContextDatabase.RootGroup : null));

            StreamWriter sw = new StreamWriter(sOutput, StrUtil.Utf8);
            //Name, Login, Password, URL, Note, Folder
            sw.Write("\"Name\",\"Login\",\"Password\",\"URL\",\"Note\",\"Folder\"\r\n");

            EntryHandler eh = delegate (PwEntry pe)
            {
                WriteCsvEntry(sw, pe);
                return true;
            };

            if (pg != null) pg.TraverseTree(TraversalMethod.PreOrder, null, eh);

            sw.Close();
            return true; 
        }

        private static void WriteCsvEntry(StreamWriter sw, PwEntry pe)
        {
            if (sw == null) { Debug.Assert(false); return; }
            if (pe == null) { Debug.Assert(false); return; }

           const string strSep = "\",\"";

            sw.Write("\"");
            WriteCsvString(sw, pe.Strings.ReadSafe(PwDefs.TitleField), strSep);
            WriteCsvString(sw, pe.Strings.ReadSafe(PwDefs.UserNameField), strSep);
            WriteCsvString(sw, pe.Strings.ReadSafe(PwDefs.PasswordField), strSep);
            WriteCsvString(sw, pe.Strings.ReadSafe(PwDefs.UrlField), strSep);
            WriteCsvString(sw, pe.Strings.ReadSafe(PwDefs.NotesField), strSep);       
            WriteCsvString(sw, pe.ParentGroup.GetFullPath(), "\"\r\n");
            
        }

        private static void WriteCsvString(StreamWriter sw, string strText,
            string strAppend)
        {
            string str = strText;
            if (!string.IsNullOrEmpty(str))
            {
                str = str.Replace("\\", "\\\\");
                str = str.Replace("\"", "\\\"");

                sw.Write(str);
            }

            if (!string.IsNullOrEmpty(strAppend)) sw.Write(strAppend);
        }
    }
}
