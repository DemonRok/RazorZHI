﻿#region license

// Razor: An Ultima Online Assistant
// Copyright (c) 2022 Razor Development Community on GitHub <https://github.com/markdwags/Razor>
// 
// This program is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
// 
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
// 
// You should have received a copy of the GNU General Public License
// along with this program.  If not, see <http://www.gnu.org/licenses/>.

#endregion


namespace Assistant.Gumps.Internal
{
    public sealed class TestMessageGump : Gump
    {
        public TestMessageGump(string message) : base(500, 250, -1)
        {
            X = 300;
            Y = 200;

            Movable = true;
            Closable = true;
            Disposable = false;

            AddPage(0);
            AddBackground(0, 0, 500, 400, 9270);
            AddHtml(20, 20, 460, 330, message, true, true);
            AddButton(200, 360, 247, 248, 0, GumpButtonType.Reply, 0);
            AddButton(420, 360, 247, 248, 1, GumpButtonType.Reply, 0);
        }

        public override void OnResponse(int buttonId, int[] switches, GumpTextEntry[] textEntries = null)
        {
            World.Player.OverheadMessage($"Button {buttonId}");
            base.OnResponse(buttonId, switches, textEntries);
        }
    }
}