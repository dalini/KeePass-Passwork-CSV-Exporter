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
using KeePass.Plugins;
using PassworkExport.V100;

namespace PassworkExport
{
	public sealed class PassworkExportExt : Plugin
	{
		internal const string GroupName = "PassworkExport Plugin";

		private IPluginHost m_host = null;

		private CSVExporter m_v100 = new CSVExporter();

		public override bool Initialize(IPluginHost host)
		{
			Terminate();

			m_host = host;
			if(m_host == null) return false;

			m_host.FileFormatPool.Add(m_v100);

			return true;
		}

		public override void Terminate()
		{
			if(m_host == null) return;

			m_host.FileFormatPool.Remove(m_v100);

			m_host = null;
		}
	}
}
