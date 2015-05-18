/*
SkillCalc Copyright (c) 2015 sstheno@gmail.com

This file is part of SkillCalc.

    SkillCalc is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    SkillCalc is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with SkillCalc.  If not, see <http://www.gnu.org/licenses/>.
*/

using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SkillCalc
{
    public partial class Main : Form
    {
        // Handles the display and retention of clicked skill levels.
        private void refreshIcons(string page)
        {
            int profNumBegin;
            int profNumEnd;
            switch (page)
            {
                case "Basic":
                    {
                        profNumEnd = 6;
                        var profnames = new List<string>();
                        for (profNumBegin = 0; profNumBegin <= profNumEnd; profNumBegin++) { profnames.Add(professions[profNumBegin]); }
                        foreach (string profname in profnames) { displayIcons(profname); }
                    }
                    break;
                case "Advanced":
                    {
                        profNumEnd = 32;
                        var profnames = new List<string>();
                        for (profNumBegin = 7; profNumBegin <= profNumEnd; profNumBegin++) { profnames.Add(professions[profNumBegin]); }
                        foreach (string profname in profnames) { displayIcons(profname); }
                    }
                    break;
                case "Force":
                    {
                        profNumEnd = 41;
                        var profnames = new List<string>();
                        for (profNumBegin = 33; profNumBegin <= profNumEnd; profNumBegin++) { profnames.Add(professions[profNumBegin]); }
                        foreach (string profname in profnames) { displayIcons(profname); }
                    }
                    break;
                case "Jedi":
                    {
                        profNumEnd = 46;
                        var profnames = new List<string>();
                        for (profNumBegin = 42; profNumBegin <= profNumEnd; profNumBegin++) { profnames.Add(professions[profNumBegin]); }
                        foreach (string profname in profnames) { displayIcons(profname); }
                    }
                    break;
            }
        }
        private void togglepreqSkillsON(string name)
        {
            if (selectedprof == professions[7]) // fill preq on Artisan and scout for Architect
            {
                string tempskillvalue = getskills(name, professions[0]);
                string tempskillvalue1 = ReplaceAt(tempskillvalue, 0, '1');
                string tempskillvalue2 = ReplaceAt(tempskillvalue1, 2, '1');
                string tempskillvalue3 = ReplaceAt(tempskillvalue2, 3, '1');
                string tempskillvalue4 = ReplaceAt(tempskillvalue3, 4, '1');
                string tempskillvalue5 = ReplaceAt(tempskillvalue4, 5, '1');
                updateskills(name, professions[0], tempskillvalue5);
            }
            if (selectedprof == professions[8]) // fill preq on Artisan for Armorsmith
            {
                string tempskillvalue = getskills(name, professions[0]);
                string tempskillvalue1 = ReplaceAt(tempskillvalue, 0, '1');
                string tempskillvalue2 = ReplaceAt(tempskillvalue1, 2, '1');
                string tempskillvalue3 = ReplaceAt(tempskillvalue2, 3, '1');
                string tempskillvalue4 = ReplaceAt(tempskillvalue3, 4, '1');
                string tempskillvalue5 = ReplaceAt(tempskillvalue4, 5, '1');
                updateskills(name, professions[0], tempskillvalue5);
            }
            if (selectedprof == professions[9]) // fill preq on medic for bio-engineer
            {
                string tempskillvalue = getskills(name, professions[4]);
                string tempskillvalue1 = ReplaceAt(tempskillvalue, 0, '1');
                string tempskillvalue2 = ReplaceAt(tempskillvalue1, 17, '1');
                string tempskillvalue3 = ReplaceAt(tempskillvalue2, 18, '1');
                string tempskillvalue4 = ReplaceAt(tempskillvalue3, 19, '1');
                string tempskillvalue5 = ReplaceAt(tempskillvalue4, 20, '1');
                updateskills(name, professions[4], tempskillvalue5);
            }
            if (selectedprof == professions[9]) // fill preq on scout for bio-engineer
            {
                string tempskillvalue = getskills(name, professions[6]);
                string tempskillvalue1 = ReplaceAt(tempskillvalue, 0, '1');
                string tempskillvalue2 = ReplaceAt(tempskillvalue1, 12, '1');
                string tempskillvalue3 = ReplaceAt(tempskillvalue2, 13, '1');
                string tempskillvalue4 = ReplaceAt(tempskillvalue3, 14, '1');
                string tempskillvalue5 = ReplaceAt(tempskillvalue4, 15, '1');
                updateskills(name, professions[6], tempskillvalue5);
            }
            if (selectedprof == professions[10]) { updateskills(name, professions[3], "1-1111-1111-1111-1111-1"); } // max Marksman if Bounty Hunter
            if (selectedprof == professions[10]) // fill preq on Scout for Bounty Hunter
            {
                string tempskillvalue = getskills(name, professions[6]);
                string tempskillvalue1 = ReplaceAt(tempskillvalue, 0, '1');
                string tempskillvalue2 = ReplaceAt(tempskillvalue1, 2, '1');
                string tempskillvalue3 = ReplaceAt(tempskillvalue2, 3, '1');
                string tempskillvalue4 = ReplaceAt(tempskillvalue3, 4, '1');
                string tempskillvalue5 = ReplaceAt(tempskillvalue4, 5, '1');
                updateskills(name, professions[6], tempskillvalue5);
            }
            if (selectedprof == professions[11]) // fill preq on Marksman for Carbineer
            {
                string tempskillvalue = getskills(name, professions[3]);
                string tempskillvalue1 = ReplaceAt(tempskillvalue, 0, '1');
                string tempskillvalue2 = ReplaceAt(tempskillvalue1, 12, '1');
                string tempskillvalue3 = ReplaceAt(tempskillvalue2, 13, '1');
                string tempskillvalue4 = ReplaceAt(tempskillvalue3, 14, '1');
                string tempskillvalue5 = ReplaceAt(tempskillvalue4, 15, '1');
                updateskills(name, professions[3], tempskillvalue5);
            }
            if (selectedprof == professions[12]) // fill preq on Artisan for Chef
            {
                string tempskillvalue = getskills(name, professions[0]);
                string tempskillvalue1 = ReplaceAt(tempskillvalue, 0, '1');
                string tempskillvalue2 = ReplaceAt(tempskillvalue1, 7, '1');
                string tempskillvalue3 = ReplaceAt(tempskillvalue2, 8, '1');
                string tempskillvalue4 = ReplaceAt(tempskillvalue3, 9, '1');
                string tempskillvalue5 = ReplaceAt(tempskillvalue4, 10, '1');
                updateskills(name, professions[0], tempskillvalue5);
            }
            if (selectedprof == professions[13]) // fill preq on Marksman for Combat Medic
            {
                string tempskillvalue = getskills(name, professions[3]);
                string tempskillvalue1 = ReplaceAt(tempskillvalue, 0, '1');
                string tempskillvalue2 = ReplaceAt(tempskillvalue1, 17, '1');
                string tempskillvalue3 = ReplaceAt(tempskillvalue2, 18, '1');
                string tempskillvalue4 = ReplaceAt(tempskillvalue3, 19, '1');
                string tempskillvalue5 = ReplaceAt(tempskillvalue4, 20, '1');
                updateskills(name, professions[3], tempskillvalue5);
            }
            if (selectedprof == professions[13]) { updateskills(name, professions[4], "1-1111-1111-1111-1111-1"); } // max Medic if Combat Medic
            if (selectedprof == professions[14]) // fill preq on Brawler for Commando
            {
                string tempskillvalue = getskills(name, professions[1]);
                string tempskillvalue1 = ReplaceAt(tempskillvalue, 0, '1');
                string tempskillvalue2 = ReplaceAt(tempskillvalue1, 2, '1');
                string tempskillvalue3 = ReplaceAt(tempskillvalue2, 3, '1');
                string tempskillvalue4 = ReplaceAt(tempskillvalue3, 4, '1');
                string tempskillvalue5 = ReplaceAt(tempskillvalue4, 5, '1');
                updateskills(name, professions[1], tempskillvalue5);
            }
            if (selectedprof == professions[14]) { updateskills(name, professions[3], "1-1111-1111-1111-1111-1"); } // max Marksman if Commando
            if (selectedprof == professions[15]) // fill preq on Scout for Creature Handler
            {
                string tempskillvalue = getskills(name, professions[6]);
                string tempskillvalue1 = ReplaceAt(tempskillvalue, 0, '1');
                string tempskillvalue2 = ReplaceAt(tempskillvalue1, 2, '1');
                string tempskillvalue3 = ReplaceAt(tempskillvalue2, 3, '1');
                string tempskillvalue4 = ReplaceAt(tempskillvalue3, 4, '1');
                string tempskillvalue5 = ReplaceAt(tempskillvalue4, 5, '1');
                string tempskillvalue6 = ReplaceAt(tempskillvalue5, 12, '1');
                string tempskillvalue7 = ReplaceAt(tempskillvalue6, 13, '1');
                string tempskillvalue8 = ReplaceAt(tempskillvalue7, 14, '1');
                string tempskillvalue9 = ReplaceAt(tempskillvalue8, 15, '1');
                updateskills(name, professions[6], tempskillvalue9);
            }
            if (selectedprof == professions[16]) // fill preq on Entertainer for Dancer
            {
                string tempskillvalue = getskills(name, professions[2]);
                string tempskillvalue1 = ReplaceAt(tempskillvalue, 0, '1');
                string tempskillvalue2 = ReplaceAt(tempskillvalue1, 12, '1');
                string tempskillvalue3 = ReplaceAt(tempskillvalue2, 13, '1');
                string tempskillvalue4 = ReplaceAt(tempskillvalue3, 14, '1');
                string tempskillvalue5 = ReplaceAt(tempskillvalue4, 15, '1');
                string tempskillvalue6 = ReplaceAt(tempskillvalue5, 17, '1');
                string tempskillvalue7 = ReplaceAt(tempskillvalue6, 18, '1');
                string tempskillvalue8 = ReplaceAt(tempskillvalue7, 19, '1');
                string tempskillvalue9 = ReplaceAt(tempskillvalue8, 20, '1');
                updateskills(name, professions[2], tempskillvalue9);
            }
            if (selectedprof == professions[17]) { updateskills(name, professions[4], "1-1111-1111-1111-1111-1"); } // max Medic if Doctor
            if (selectedprof == professions[18]) // fill preq on Artisan for Droid Engineer
            {
                string tempskillvalue = getskills(name, professions[0]);
                string tempskillvalue1 = ReplaceAt(tempskillvalue, 0, '1');
                string tempskillvalue2 = ReplaceAt(tempskillvalue1, 2, '1');
                string tempskillvalue3 = ReplaceAt(tempskillvalue2, 3, '1');
                string tempskillvalue4 = ReplaceAt(tempskillvalue3, 4, '1');
                string tempskillvalue5 = ReplaceAt(tempskillvalue4, 5, '1');
                updateskills(name, professions[0], tempskillvalue5);
            }
            if (selectedprof == professions[19]) // fill preq on Brawler for Fencer
            {
                string tempskillvalue = getskills(name, professions[1]);
                string tempskillvalue1 = ReplaceAt(tempskillvalue, 0, '1');
                string tempskillvalue2 = ReplaceAt(tempskillvalue1, 7, '1');
                string tempskillvalue3 = ReplaceAt(tempskillvalue2, 8, '1');
                string tempskillvalue4 = ReplaceAt(tempskillvalue3, 9, '1');
                string tempskillvalue5 = ReplaceAt(tempskillvalue4, 10, '1');
                updateskills(name, professions[1], tempskillvalue5);
            }
            if (selectedprof == professions[20]) // fill preq on Entertainer for Image Designer
            {
                string tempskillvalue = getskills(name, professions[2]);
                string tempskillvalue1 = ReplaceAt(tempskillvalue, 0, '1');
                string tempskillvalue2 = ReplaceAt(tempskillvalue1, 2, '1');
                string tempskillvalue3 = ReplaceAt(tempskillvalue2, 3, '1');
                string tempskillvalue4 = ReplaceAt(tempskillvalue3, 4, '1');
                string tempskillvalue5 = ReplaceAt(tempskillvalue4, 5, '1');
                updateskills(name, professions[2], tempskillvalue5);
            }
            if (selectedprof == professions[21]) // fill preq on Artisan for Merchant
            {
                string tempskillvalue = getskills(name, professions[0]);
                string tempskillvalue1 = ReplaceAt(tempskillvalue, 0, '1');
                string tempskillvalue2 = ReplaceAt(tempskillvalue1, 12, '1');
                string tempskillvalue3 = ReplaceAt(tempskillvalue2, 13, '1');
                string tempskillvalue4 = ReplaceAt(tempskillvalue3, 14, '1');
                string tempskillvalue5 = ReplaceAt(tempskillvalue4, 15, '1');
                updateskills(name, professions[0], tempskillvalue5);
            }
            if (selectedprof == professions[22]) // fill preq on Entertainer for Musician
            {
                string tempskillvalue = getskills(name, professions[2]);
                string tempskillvalue1 = ReplaceAt(tempskillvalue, 0, '1');
                string tempskillvalue2 = ReplaceAt(tempskillvalue1, 7, '1');
                string tempskillvalue3 = ReplaceAt(tempskillvalue2, 8, '1');
                string tempskillvalue4 = ReplaceAt(tempskillvalue3, 9, '1');
                string tempskillvalue5 = ReplaceAt(tempskillvalue4, 10, '1');
                string tempskillvalue6 = ReplaceAt(tempskillvalue5, 17, '1');
                string tempskillvalue7 = ReplaceAt(tempskillvalue6, 18, '1');
                string tempskillvalue8 = ReplaceAt(tempskillvalue7, 19, '1');
                string tempskillvalue9 = ReplaceAt(tempskillvalue8, 20, '1');
                updateskills(name, professions[2], tempskillvalue9);
            }
            if (selectedprof == professions[23]) // fill preq on Brawler for Pikeman
            {
                string tempskillvalue = getskills(name, professions[1]);
                string tempskillvalue1 = ReplaceAt(tempskillvalue, 0, '1');
                string tempskillvalue2 = ReplaceAt(tempskillvalue1, 17, '1');
                string tempskillvalue3 = ReplaceAt(tempskillvalue2, 18, '1');
                string tempskillvalue4 = ReplaceAt(tempskillvalue3, 19, '1');
                string tempskillvalue5 = ReplaceAt(tempskillvalue4, 20, '1');
                updateskills(name, professions[1], tempskillvalue5);
            }
            if (selectedprof == professions[24]) // fill preq on Marksman for Pistoleer
            {
                string tempskillvalue = getskills(name, professions[3]);
                string tempskillvalue1 = ReplaceAt(tempskillvalue, 0, '1');
                string tempskillvalue2 = ReplaceAt(tempskillvalue1, 7, '1');
                string tempskillvalue3 = ReplaceAt(tempskillvalue2, 8, '1');
                string tempskillvalue4 = ReplaceAt(tempskillvalue3, 9, '1');
                string tempskillvalue5 = ReplaceAt(tempskillvalue4, 10, '1');
                updateskills(name, professions[3], tempskillvalue5);
            }
            if (selectedprof == professions[25]) { updateskills(name, professions[6], "1-1111-1111-1111-1111-1"); } // max Scout if Ranger
            if (selectedprof == professions[26]) // fill preq on Marksman for Rifleman
            {
                string tempskillvalue = getskills(name, professions[3]);
                string tempskillvalue1 = ReplaceAt(tempskillvalue, 0, '1');
                string tempskillvalue2 = ReplaceAt(tempskillvalue1, 2, '1');
                string tempskillvalue3 = ReplaceAt(tempskillvalue2, 3, '1');
                string tempskillvalue4 = ReplaceAt(tempskillvalue3, 4, '1');
                string tempskillvalue5 = ReplaceAt(tempskillvalue4, 5, '1');
                updateskills(name, professions[3], tempskillvalue5);
            }
            if (selectedprof == professions[27]) // fill preq on Brawler for Smuggler
            {
                string tempskillvalue = getskills(name, professions[1]);
                string tempskillvalue1 = ReplaceAt(tempskillvalue, 0, '1');
                string tempskillvalue2 = ReplaceAt(tempskillvalue1, 2, '1');
                string tempskillvalue3 = ReplaceAt(tempskillvalue2, 3, '1');
                string tempskillvalue4 = ReplaceAt(tempskillvalue3, 4, '1');
                string tempskillvalue5 = ReplaceAt(tempskillvalue4, 5, '1');
                updateskills(name, professions[1], tempskillvalue5);
            }
            if (selectedprof == professions[27]) // fill preq on Marksman for Smuggler
            {
                string tempskillvalue = getskills(name, professions[3]);
                string tempskillvalue1 = ReplaceAt(tempskillvalue, 0, '1');
                string tempskillvalue2 = ReplaceAt(tempskillvalue1, 7, '1');
                string tempskillvalue3 = ReplaceAt(tempskillvalue2, 8, '1');
                string tempskillvalue4 = ReplaceAt(tempskillvalue3, 9, '1');
                string tempskillvalue5 = ReplaceAt(tempskillvalue4, 10, '1');
                updateskills(name, professions[3], tempskillvalue5);
            }
            if (selectedprof == professions[28]) // fill preq on Marksman for Squad Leader
            {
                string tempskillvalue = getskills(name, professions[3]);
                string tempskillvalue1 = ReplaceAt(tempskillvalue, 0, '1');
                string tempskillvalue2 = ReplaceAt(tempskillvalue1, 17, '1');
                string tempskillvalue3 = ReplaceAt(tempskillvalue2, 18, '1');
                string tempskillvalue4 = ReplaceAt(tempskillvalue3, 19, '1');
                string tempskillvalue5 = ReplaceAt(tempskillvalue4, 20, '1');
                updateskills(name, professions[3], tempskillvalue5);
            }
            if (selectedprof == professions[28]) // fill preq on Scout for Squad Leader
            {
                string tempskillvalue = getskills(name, professions[6]);
                string tempskillvalue1 = ReplaceAt(tempskillvalue, 0, '1');
                string tempskillvalue2 = ReplaceAt(tempskillvalue1, 2, '1');
                string tempskillvalue3 = ReplaceAt(tempskillvalue2, 3, '1');
                string tempskillvalue4 = ReplaceAt(tempskillvalue3, 4, '1');
                string tempskillvalue5 = ReplaceAt(tempskillvalue4, 5, '1');
                string tempskillvalue6 = ReplaceAt(tempskillvalue5, 17, '1');
                string tempskillvalue7 = ReplaceAt(tempskillvalue6, 18, '1');
                string tempskillvalue8 = ReplaceAt(tempskillvalue7, 19, '1');
                string tempskillvalue9 = ReplaceAt(tempskillvalue8, 20, '1');
                updateskills(name, professions[6], tempskillvalue9);
            }
            if (selectedprof == professions[29]) // fill preq on Brawler for Swordsman
            {
                string tempskillvalue = getskills(name, professions[1]);
                string tempskillvalue1 = ReplaceAt(tempskillvalue, 0, '1');
                string tempskillvalue2 = ReplaceAt(tempskillvalue1, 12, '1');
                string tempskillvalue3 = ReplaceAt(tempskillvalue2, 13, '1');
                string tempskillvalue4 = ReplaceAt(tempskillvalue3, 14, '1');
                string tempskillvalue5 = ReplaceAt(tempskillvalue4, 15, '1');
                updateskills(name, professions[1], tempskillvalue5);
            }
            if (selectedprof == professions[30]) // fill preq on Artisan for Tailor
            {
                string tempskillvalue = getskills(name, professions[0]);
                string tempskillvalue1 = ReplaceAt(tempskillvalue, 0, '1');
                string tempskillvalue2 = ReplaceAt(tempskillvalue1, 7, '1');
                string tempskillvalue3 = ReplaceAt(tempskillvalue2, 8, '1');
                string tempskillvalue4 = ReplaceAt(tempskillvalue3, 9, '1');
                string tempskillvalue5 = ReplaceAt(tempskillvalue4, 10, '1');
                updateskills(name, professions[0], tempskillvalue5);
            }
            if (selectedprof == professions[31]) // fill preq on Brawler for Teras Kasi Artist
            {
                string tempskillvalue = getskills(name, professions[1]);
                string tempskillvalue1 = ReplaceAt(tempskillvalue, 0, '1');
                string tempskillvalue2 = ReplaceAt(tempskillvalue1, 2, '1');
                string tempskillvalue3 = ReplaceAt(tempskillvalue2, 3, '1');
                string tempskillvalue4 = ReplaceAt(tempskillvalue3, 4, '1');
                string tempskillvalue5 = ReplaceAt(tempskillvalue4, 5, '1');
                updateskills(name, professions[1], tempskillvalue5);
            }
            if (selectedprof == professions[32]) // fill preq on Artisan for Weaponsmith
            {
                string tempskillvalue = getskills(name, professions[0]);
                string tempskillvalue1 = ReplaceAt(tempskillvalue, 0, '1');
                string tempskillvalue2 = ReplaceAt(tempskillvalue1, 2, '1');
                string tempskillvalue3 = ReplaceAt(tempskillvalue2, 3, '1');
                string tempskillvalue4 = ReplaceAt(tempskillvalue3, 4, '1');
                string tempskillvalue5 = ReplaceAt(tempskillvalue4, 5, '1');
                updateskills(name, professions[0], tempskillvalue5);
            }
            if (selectedprof == professions[43]) // max Light Journeyman if Light Master
            {
                updateskills(name, professions[44], "1-1111-1111-1111-1111-1");
                refreshIcons("Jedi");
            }
            if (selectedprof == professions[43]) // max Padawan if Light Master
            {
                updateskills(name, professions[42], "1-1111-1111-1111-1111-1");
                refreshIcons("Jedi");
            }
            if (selectedprof == professions[44]) // max Padawan if Light Journeyman
            {
                updateskills(name, professions[42], "1-1111-1111-1111-1111-1");
                refreshIcons("Jedi");
            }
            if (selectedprof == professions[45]) // max Dark Journeyman if Dark Master
            {
                updateskills(name, professions[46], "1-1111-1111-1111-1111-1");
                refreshIcons("Jedi");
            }
            if (selectedprof == professions[45]) // max Padawan if Dark Master
            {
                updateskills(name, professions[42], "1-1111-1111-1111-1111-1");
                refreshIcons("Jedi");
            }
            if (selectedprof == professions[46]) // max Padawan if Dark Journeyman
            {
                updateskills(name, professions[42], "1-1111-1111-1111-1111-1");
                refreshIcons("Jedi");
            }
        }
        private void togglepreqSkillsOFF(string sender)
        {
            string name = this.charName.Text;

            if (selectedprof == professions[0]) // remove from tiers above Artisan.
            {
                if (sender == "1" || sender == "0")
                {
                    updateskills(name, professions[7], "0-0000-0000-0000-0000-0");
                    updateskills(name, professions[8], "0-0000-0000-0000-0000-0");
                    updateskills(name, professions[18], "0-0000-0000-0000-0000-0");
                    updateskills(name, professions[32], "0-0000-0000-0000-0000-0");
                }
                if (sender == "2" || sender == "0")
                {
                    updateskills(name, professions[12], "0-0000-0000-0000-0000-0");
                    updateskills(name, professions[30], "0-0000-0000-0000-0000-0");
                }
                if (sender == "3" || sender == "0")
                {
                    updateskills(name, professions[21], "0-0000-0000-0000-0000-0");
                }
            }
            if (selectedprof == professions[1]) // remove from tiers above Brawler.
            {
                if (sender == "1" || sender == "0")
                {
                    updateskills(name, professions[14], "0-0000-0000-0000-0000-0");
                    updateskills(name, professions[27], "0-0000-0000-0000-0000-0");
                    updateskills(name, professions[31], "0-0000-0000-0000-0000-0");
                }
                if (sender == "2" || sender == "0")
                {
                    updateskills(name, professions[19], "0-0000-0000-0000-0000-0");
                }
                if (sender == "3" || sender == "0")
                {
                    updateskills(name, professions[29], "0-0000-0000-0000-0000-0");
                }
                if (sender == "4" || sender == "0")
                {
                    updateskills(name, professions[23], "0-0000-0000-0000-0000-0");
                }
            }
            if (selectedprof == professions[2]) // remove from tiers above Entertainer.
            {
                if (sender == "1" || sender == "0")
                {
                    updateskills(name, professions[20], "0-0000-0000-0000-0000-0");
                }
                if (sender == "2" || sender == "0")
                {
                    updateskills(name, professions[22], "0-0000-0000-0000-0000-0");
                }
                if (sender == "3" || sender == "0")
                {
                    updateskills(name, professions[16], "0-0000-0000-0000-0000-0");
                }
                if (sender == "4" || sender == "0")
                {
                    updateskills(name, professions[16], "0-0000-0000-0000-0000-0");
                    updateskills(name, professions[22], "0-0000-0000-0000-0000-0");
                }
            }
            if (selectedprof == professions[3]) // remove from tiers above Marksman.
            {
                if (sender == "1" || sender == "0")
                {
                    updateskills(name, professions[10], "0-0000-0000-0000-0000-0");
                    updateskills(name, professions[14], "0-0000-0000-0000-0000-0");
                    updateskills(name, professions[26], "0-0000-0000-0000-0000-0");
                }
                if (sender == "2" || sender == "0")
                {
                    updateskills(name, professions[10], "0-0000-0000-0000-0000-0");
                    updateskills(name, professions[14], "0-0000-0000-0000-0000-0");
                    updateskills(name, professions[24], "0-0000-0000-0000-0000-0");
                    updateskills(name, professions[27], "0-0000-0000-0000-0000-0");
                }
                if (sender == "3" || sender == "0")
                {
                    updateskills(name, professions[10], "0-0000-0000-0000-0000-0");
                    updateskills(name, professions[14], "0-0000-0000-0000-0000-0");
                    updateskills(name, professions[11], "0-0000-0000-0000-0000-0");
                }
                if (sender == "4" || sender == "0")
                {
                    updateskills(name, professions[10], "0-0000-0000-0000-0000-0");
                    updateskills(name, professions[14], "0-0000-0000-0000-0000-0");
                    updateskills(name, professions[13], "0-0000-0000-0000-0000-0");
                    updateskills(name, professions[28], "0-0000-0000-0000-0000-0");
                }
                if (sender == "5" || sender == "0")
                {
                    updateskills(name, professions[10], "0-0000-0000-0000-0000-0");
                    updateskills(name, professions[14], "0-0000-0000-0000-0000-0");
                }
            }
            if (selectedprof == professions[4]) // remove from tiers above Medic.
            {
                if (sender == "1" || sender == "0")
                {
                    updateskills(name, professions[13], "0-0000-0000-0000-0000-0");
                    updateskills(name, professions[17], "0-0000-0000-0000-0000-0");
                }
                if (sender == "2" || sender == "0")
                {
                    updateskills(name, professions[13], "0-0000-0000-0000-0000-0");
                    updateskills(name, professions[17], "0-0000-0000-0000-0000-0");
                }
                if (sender == "3" || sender == "0")
                {
                    updateskills(name, professions[13], "0-0000-0000-0000-0000-0");
                    updateskills(name, professions[17], "0-0000-0000-0000-0000-0");
                }
                if (sender == "4" || sender == "0")
                {
                    updateskills(name, professions[9], "0-0000-0000-0000-0000-0");
                    updateskills(name, professions[13], "0-0000-0000-0000-0000-0");
                    updateskills(name, professions[17], "0-0000-0000-0000-0000-0");
                }
                if (sender == "5" || sender == "0")
                {
                    updateskills(name, professions[13], "0-0000-0000-0000-0000-0");
                    updateskills(name, professions[17], "0-0000-0000-0000-0000-0");
                }
            }
            if (selectedprof == professions[6]) // remove from tiers above Scout.
            {
                if (sender == "1" || sender == "0")
                {
                    updateskills(name, professions[10], "0-0000-0000-0000-0000-0");
                    updateskills(name, professions[15], "0-0000-0000-0000-0000-0");
                    updateskills(name, professions[25], "0-0000-0000-0000-0000-0");
                    updateskills(name, professions[28], "0-0000-0000-0000-0000-0");
                }
                if (sender == "2" || sender == "0")
                {
                    updateskills(name, professions[25], "0-0000-0000-0000-0000-0");
                }
                if (sender == "3" || sender == "0")
                {
                    updateskills(name, professions[9], "0-0000-0000-0000-0000-0");
                    updateskills(name, professions[15], "0-0000-0000-0000-0000-0");
                    updateskills(name, professions[25], "0-0000-0000-0000-0000-0");
                }
                if (sender == "4" || sender == "0")
                {
                    updateskills(name, professions[25], "0-0000-0000-0000-0000-0");
                    updateskills(name, professions[28], "0-0000-0000-0000-0000-0");
                }
                if (sender == "5" || sender == "0")
                {
                    updateskills(name, professions[25], "0-0000-0000-0000-0000-0");
                }
            }
            if (selectedprof == professions[42]) // remove from tiers above Padawan.
            {
                if (sender == "0" || sender == "1" || sender == "2" || sender == "3" || sender == "4" || sender == "5")
                {
                    updateskills(name, professions[43], "0-0000-0000-0000-0000-0"); // Light Master
                    updateskills(name, professions[44], "0-0000-0000-0000-0000-0"); // Light Journeyman
                    updateskills(name, professions[45], "0-0000-0000-0000-0000-0"); // Dark Master
                    updateskills(name, professions[46], "0-0000-0000-0000-0000-0"); // Dark Journeyman
                    refreshIcons("Jedi");
                }
            }
            if (selectedprof == professions[44]) // remove from tiers above Light Journeyman.
            {
                if (sender == "0" || sender == "1" || sender == "2" || sender == "3" || sender == "4" || sender == "5")
                {
                    updateskills(name, professions[43], "0-0000-0000-0000-0000-0"); // Light Master
                    refreshIcons("Jedi");
                }
            }
            if (selectedprof == professions[46]) // remove from tiers above Dark Journeyman.
            {
                if (sender == "0" || sender == "1" || sender == "2" || sender == "3" || sender == "4" || sender == "5")
                {
                    updateskills(name, professions[45], "0-0000-0000-0000-0000-0"); // Dark Master
                    refreshIcons("Jedi");
                }
            }
        }
        private void clickedProf(string profclicked, string button)
        {
            string name = this.charName.Text;
            string skillvalue = getskills(name, selectedprof);

            switch (profclicked)
            {
                case "labelNovice_MouseDown":
                    {
                        if (button == "left")
                        {
                            if (projectedvaluesearch(skillvalue, 0) == false)
                            {
                                skillvalue = "1-0000-0000-0000-0000-0";
                                togglepreqSkillsON(name);
                            }
                            else
                            {
                                togglepreqSkillsOFF("0");
                                skillvalue = "0-0000-0000-0000-0000-0";
                            }
                        }
                        if (button == "right") { }
                        updateskills(name, selectedprof, skillvalue);
                        updateDisplay();
                        displayIcons(selectedprof);
                        calcpoints(name);
                    }
                    break;
                case "labelfirstI_MouseDown":
                    {
                        if (button == "left")
                        {
                            if (projectedvaluesearch(skillvalue, 2) == false)
                            {// turn skill on and all priors if all off
                                string skillvalue1 = ReplaceAt(skillvalue, 0, '1');
                                skillvalue = ReplaceAt(skillvalue1, 2, '1');
                                togglepreqSkillsON(name);
                            }
                            else if (projectedvaluesearch(skillvalue, 2) == true)
                            {//turn skill off and others above if on
                                togglepreqSkillsOFF("1");
                                string skillvalue1 = ReplaceAt(skillvalue, 2, '0');
                                string skillvalue2 = ReplaceAt(skillvalue1, 3, '0');
                                string skillvalue3 = ReplaceAt(skillvalue2, 4, '0');
                                string skillvalue4 = ReplaceAt(skillvalue3, 5, '0');
                                skillvalue = ReplaceAt(skillvalue4, 22, '0');
                            }
                        }
                        if (button == "right") { }
                        updateskills(name, selectedprof, skillvalue);
                        updateDisplay();
                        displayIcons(selectedprof);
                        calcpoints(name);
                    }
                    break;
                case "labelfirstII_MouseDown":
                    {
                        if (button == "left")
                        {
                            if (projectedvaluesearch(skillvalue, 3) == false)
                            {// turn skill on and all priors if all off
                                string skillvalue1 = ReplaceAt(skillvalue, 0, '1');
                                string skillvalue2 = ReplaceAt(skillvalue1, 2, '1');
                                skillvalue = ReplaceAt(skillvalue2, 3, '1');
                                togglepreqSkillsON(name);
                            }
                            else if (projectedvaluesearch(skillvalue, 3) == true)
                            {//turn skill off and others above if on
                                togglepreqSkillsOFF("1");
                                string skillvalue1 = ReplaceAt(skillvalue, 3, '0');
                                string skillvalue2 = ReplaceAt(skillvalue1, 4, '0');
                                string skillvalue3 = ReplaceAt(skillvalue2, 5, '0');
                                skillvalue = ReplaceAt(skillvalue3, 22, '0');
                            }
                        }
                        if (button == "right") { }
                        updateskills(name, selectedprof, skillvalue);
                        updateDisplay();
                        displayIcons(selectedprof);
                        calcpoints(name);
                    }
                    break;
                case "labelfirstIII_MouseDown":
                    {
                        if (button == "left")
                        {
                            if (projectedvaluesearch(skillvalue, 4) == false)
                            {// turn skill on and all priors if all off
                                string skillvalue1 = ReplaceAt(skillvalue, 0, '1');
                                string skillvalue2 = ReplaceAt(skillvalue1, 2, '1');
                                string skillvalue3 = ReplaceAt(skillvalue2, 3, '1');
                                skillvalue = ReplaceAt(skillvalue3, 4, '1');
                                togglepreqSkillsON(name);
                            }
                            else if (projectedvaluesearch(skillvalue, 4) == true)
                            {//turn skill off and others above if on
                                togglepreqSkillsOFF("1");
                                string skillvalue1 = ReplaceAt(skillvalue, 4, '0');
                                string skillvalue2 = ReplaceAt(skillvalue1, 5, '0');
                                skillvalue = ReplaceAt(skillvalue2, 22, '0');
                            }
                        }
                        if (button == "right") { }
                        updateskills(name, selectedprof, skillvalue);
                        updateDisplay();
                        displayIcons(selectedprof);
                        calcpoints(name);
                    }
                    break;
                case "labelfirstIV_MouseDown":
                    {
                        if (button == "left")
                        {
                            if (projectedvaluesearch(skillvalue, 5) == false)
                            {// turn skill on and all priors if all off
                                string skillvalue1 = ReplaceAt(skillvalue, 0, '1');
                                string skillvalue2 = ReplaceAt(skillvalue1, 2, '1');
                                string skillvalue3 = ReplaceAt(skillvalue2, 3, '1');
                                string skillvalue4 = ReplaceAt(skillvalue3, 4, '1');
                                skillvalue = ReplaceAt(skillvalue4, 5, '1');
                                togglepreqSkillsON(name);
                            }
                            else if (projectedvaluesearch(skillvalue, 5) == true)
                            {//turn skill off and others above if on
                                togglepreqSkillsOFF("1");
                                string skillvalue1 = ReplaceAt(skillvalue, 5, '0');
                                string skillvalue2 = ReplaceAt(skillvalue1, 22, '0');
                                skillvalue = ReplaceAt(skillvalue2, 22, '0');
                            }
                        }
                        if (button == "right") { }
                        updateskills(name, selectedprof, skillvalue);
                        updateDisplay();
                        displayIcons(selectedprof);
                        calcpoints(name);
                    }
                    break;
                case "labelsecondI_MouseDown":
                    {
                        if (button == "left")
                        {
                            if (projectedvaluesearch(skillvalue, 7) == false)
                            {// turn skill on and all priors if all off
                                string skillvalue1 = ReplaceAt(skillvalue, 0, '1');
                                skillvalue = ReplaceAt(skillvalue1, 7, '1');
                                togglepreqSkillsON(name);
                            }
                            else if (projectedvaluesearch(skillvalue, 7) == true)
                            {//turn skill off and others above if on
                                togglepreqSkillsOFF("2");
                                string skillvalue1 = ReplaceAt(skillvalue, 7, '0');
                                string skillvalue2 = ReplaceAt(skillvalue1, 8, '0');
                                string skillvalue3 = ReplaceAt(skillvalue2, 9, '0');
                                string skillvalue4 = ReplaceAt(skillvalue3, 10, '0');
                                skillvalue = ReplaceAt(skillvalue4, 22, '0');
                            }
                        }
                        if (button == "right") { }
                        updateskills(name, selectedprof, skillvalue);
                        updateDisplay();
                        displayIcons(selectedprof);
                        calcpoints(name);
                    }
                    break;
                case "labelsecondII_MouseDown":
                    {
                        if (button == "left")
                        {
                            if (projectedvaluesearch(skillvalue, 8) == false)
                            {// turn skill on and all priors if all off
                                string skillvalue1 = ReplaceAt(skillvalue, 0, '1');
                                string skillvalue2 = ReplaceAt(skillvalue1, 7, '1');
                                skillvalue = ReplaceAt(skillvalue2, 8, '1');
                                togglepreqSkillsON(name);
                            }
                            else if (projectedvaluesearch(skillvalue, 8) == true)
                            {//turn skill off and others above if on
                                togglepreqSkillsOFF("2");
                                string skillvalue1 = ReplaceAt(skillvalue, 8, '0');
                                string skillvalue2 = ReplaceAt(skillvalue1, 9, '0');
                                string skillvalue3 = ReplaceAt(skillvalue2, 10, '0');
                                skillvalue = ReplaceAt(skillvalue3, 22, '0');
                            }
                        }
                        if (button == "right") { }
                        updateskills(name, selectedprof, skillvalue);
                        updateDisplay();
                        displayIcons(selectedprof);
                        calcpoints(name);
                    }
                    break;
                case "labelsecondIII_MouseDown":
                    {
                        if (button == "left")
                        {
                            if (projectedvaluesearch(skillvalue, 9) == false)
                            {// turn skill on and all priors if all off
                                string skillvalue1 = ReplaceAt(skillvalue, 0, '1');
                                string skillvalue2 = ReplaceAt(skillvalue1, 7, '1');
                                string skillvalue3 = ReplaceAt(skillvalue2, 8, '1');
                                skillvalue = ReplaceAt(skillvalue3, 9, '1');
                                togglepreqSkillsON(name);
                            }
                            else if (projectedvaluesearch(skillvalue, 9) == true)
                            {//turn skill off and others above if on
                                togglepreqSkillsOFF("2");
                                string skillvalue1 = ReplaceAt(skillvalue, 9, '0');
                                string skillvalue2 = ReplaceAt(skillvalue1, 10, '0');
                                skillvalue = ReplaceAt(skillvalue2, 22, '0');
                            }
                        }
                        if (button == "right") { }
                        updateskills(name, selectedprof, skillvalue);
                        updateDisplay();
                        displayIcons(selectedprof);
                        calcpoints(name);
                    }
                    break;
                case "labelsecondIV_MouseDown":
                    {
                        if (button == "left")
                        {
                            if (projectedvaluesearch(skillvalue, 10) == false)
                            {// turn skill on and all priors if all off
                                string skillvalue1 = ReplaceAt(skillvalue, 0, '1');
                                string skillvalue2 = ReplaceAt(skillvalue1, 7, '1');
                                string skillvalue3 = ReplaceAt(skillvalue2, 8, '1');
                                string skillvalue4 = ReplaceAt(skillvalue3, 9, '1');
                                skillvalue = ReplaceAt(skillvalue4, 10, '1');
                                togglepreqSkillsON(name);
                            }
                            else if (projectedvaluesearch(skillvalue, 10) == true)
                            {//turn skill off and others above if on
                                togglepreqSkillsOFF("2");
                                string skillvalue1 = ReplaceAt(skillvalue, 10, '0');
                                skillvalue = ReplaceAt(skillvalue1, 22, '0');
                            }
                        }
                        if (button == "right") { }
                        updateskills(name, selectedprof, skillvalue);
                        updateDisplay();
                        displayIcons(selectedprof);
                        calcpoints(name);
                    }
                    break;
                case "labelthirdI_MouseDown":
                    {
                        if (button == "left")
                        {
                            if (projectedvaluesearch(skillvalue, 12) == false)
                            {// turn skill on and all priors if all off
                                string skillvalue1 = ReplaceAt(skillvalue, 0, '1');
                                skillvalue = ReplaceAt(skillvalue1, 12, '1');
                                togglepreqSkillsON(name);
                            }
                            else if (projectedvaluesearch(skillvalue, 12) == true)
                            {//turn skill off and others above if on
                                togglepreqSkillsOFF("3");
                                string skillvalue1 = ReplaceAt(skillvalue, 12, '0');
                                string skillvalue2 = ReplaceAt(skillvalue1, 13, '0');
                                string skillvalue3 = ReplaceAt(skillvalue2, 14, '0');
                                string skillvalue4 = ReplaceAt(skillvalue3, 15, '0');
                                skillvalue = ReplaceAt(skillvalue4, 22, '0');
                            }
                        }
                        if (button == "right") { }
                        updateskills(name, selectedprof, skillvalue);
                        updateDisplay();
                        displayIcons(selectedprof);
                        calcpoints(name);
                    }
                    break;
                case "labelthirdII_MouseDown":
                    {
                        if (button == "left")
                        {
                            if (projectedvaluesearch(skillvalue, 13) == false)
                            {// turn skill on and all priors if all off
                                string skillvalue1 = ReplaceAt(skillvalue, 0, '1');
                                string skillvalue2 = ReplaceAt(skillvalue1, 12, '1');
                                skillvalue = ReplaceAt(skillvalue2, 13, '1');
                                togglepreqSkillsON(name);
                            }
                            else if (projectedvaluesearch(skillvalue, 13) == true)
                            {//turn skill off and others above if on
                                togglepreqSkillsOFF("3");
                                string skillvalue1 = ReplaceAt(skillvalue, 13, '0');
                                string skillvalue2 = ReplaceAt(skillvalue1, 14, '0');
                                string skillvalue3 = ReplaceAt(skillvalue2, 15, '0');
                                skillvalue = ReplaceAt(skillvalue3, 22, '0');
                            }
                        }
                        if (button == "right") { }
                        updateskills(name, selectedprof, skillvalue);
                        updateDisplay();
                        displayIcons(selectedprof);
                        calcpoints(name);
                    }
                    break;
                case "labelthirdIII_MouseDown":
                    {
                        if (button == "left")
                        {
                            if (projectedvaluesearch(skillvalue, 14) == false)
                            {// turn skill on and all priors if all off
                                string skillvalue1 = ReplaceAt(skillvalue, 0, '1');
                                string skillvalue2 = ReplaceAt(skillvalue1, 12, '1');
                                string skillvalue3 = ReplaceAt(skillvalue2, 13, '1');
                                skillvalue = ReplaceAt(skillvalue3, 14, '1');
                                togglepreqSkillsON(name);
                            }
                            else if (projectedvaluesearch(skillvalue, 14) == true)
                            {//turn skill off and others above if on
                                togglepreqSkillsOFF("3");
                                string skillvalue1 = ReplaceAt(skillvalue, 14, '0');
                                string skillvalue2 = ReplaceAt(skillvalue1, 15, '0');
                                skillvalue = ReplaceAt(skillvalue2, 22, '0');
                            }
                        }
                        if (button == "right") { }
                        updateskills(name, selectedprof, skillvalue);
                        updateDisplay();
                        displayIcons(selectedprof);
                        calcpoints(name);
                    }
                    break;
                case "labelthirdIV_MouseDown":
                    {
                        if (button == "left")
                        {
                            if (projectedvaluesearch(skillvalue, 15) == false)
                            {// turn skill on and all priors if all off
                                string skillvalue1 = ReplaceAt(skillvalue, 0, '1');
                                string skillvalue2 = ReplaceAt(skillvalue1, 12, '1');
                                string skillvalue3 = ReplaceAt(skillvalue2, 13, '1');
                                string skillvalue4 = ReplaceAt(skillvalue3, 14, '1');
                                skillvalue = ReplaceAt(skillvalue4, 15, '1');
                                togglepreqSkillsON(name);
                            }
                            else if (projectedvaluesearch(skillvalue, 15) == true)
                            {//turn skill off and others above if on
                                togglepreqSkillsOFF("3");
                                string skillvalue1 = ReplaceAt(skillvalue, 15, '0');
                                skillvalue = ReplaceAt(skillvalue1, 22, '0');
                            }
                        }
                        if (button == "right") { }
                        updateskills(name, selectedprof, skillvalue);
                        updateDisplay();
                        displayIcons(selectedprof);
                        calcpoints(name);
                    }
                    break;
                case "labelfourthI_MouseDown":
                    {
                        if (button == "left")
                        {
                            if (projectedvaluesearch(skillvalue, 17) == false)
                            {// turn skill on and all priors if all off
                                string skillvalue1 = ReplaceAt(skillvalue, 0, '1');
                                skillvalue = ReplaceAt(skillvalue1, 17, '1');
                                togglepreqSkillsON(name);
                            }
                            else if (projectedvaluesearch(skillvalue, 17) == true)
                            {//turn skill off and others above if on
                                togglepreqSkillsOFF("4");
                                string skillvalue1 = ReplaceAt(skillvalue, 17, '0');
                                string skillvalue2 = ReplaceAt(skillvalue1, 18, '0');
                                string skillvalue3 = ReplaceAt(skillvalue2, 19, '0');
                                string skillvalue4 = ReplaceAt(skillvalue3, 20, '0');
                                skillvalue = ReplaceAt(skillvalue4, 22, '0');
                            }
                        }
                        if (button == "right") { }
                        updateskills(name, selectedprof, skillvalue);
                        updateDisplay();
                        displayIcons(selectedprof);
                        calcpoints(name);
                    }
                    break;
                case "labelfourthII_MouseDown":
                    {
                        if (button == "left")
                        {
                            if (projectedvaluesearch(skillvalue, 18) == false)
                            {// turn skill on and all priors if all off
                                string skillvalue1 = ReplaceAt(skillvalue, 0, '1');
                                string skillvalue2 = ReplaceAt(skillvalue1, 17, '1');
                                skillvalue = ReplaceAt(skillvalue2, 18, '1');
                                togglepreqSkillsON(name);
                            }
                            else if (projectedvaluesearch(skillvalue, 18) == true)
                            {//turn skill off and others above if on
                                togglepreqSkillsOFF("4");
                                string skillvalue1 = ReplaceAt(skillvalue, 18, '0');
                                string skillvalue2 = ReplaceAt(skillvalue1, 19, '0');
                                string skillvalue3 = ReplaceAt(skillvalue2, 20, '0');
                                skillvalue = ReplaceAt(skillvalue3, 22, '0');
                            }
                        }
                        if (button == "right") { }
                        updateskills(name, selectedprof, skillvalue);
                        updateDisplay();
                        displayIcons(selectedprof);
                        calcpoints(name);
                    }
                    break;
                case "labelfourthIII_MouseDown":
                    {
                        if (button == "left")
                        {
                            if (projectedvaluesearch(skillvalue, 19) == false)
                            {// turn skill on and all priors if all off
                                string skillvalue1 = ReplaceAt(skillvalue, 0, '1');
                                string skillvalue2 = ReplaceAt(skillvalue1, 17, '1');
                                string skillvalue3 = ReplaceAt(skillvalue2, 18, '1');
                                skillvalue = ReplaceAt(skillvalue3, 19, '1');
                                togglepreqSkillsON(name);
                            }
                            else if (projectedvaluesearch(skillvalue, 19) == true)
                            {//turn skill off and others above if on
                                togglepreqSkillsOFF("4");
                                string skillvalue1 = ReplaceAt(skillvalue, 19, '0');
                                string skillvalue2 = ReplaceAt(skillvalue1, 20, '0');
                                skillvalue = ReplaceAt(skillvalue2, 22, '0');
                            }
                        }
                        if (button == "right") { }
                        updateskills(name, selectedprof, skillvalue);
                        updateDisplay();
                        displayIcons(selectedprof);
                        calcpoints(name);
                    }
                    break;
                case "labelfourthIV_MouseDown":
                    {
                        if (button == "left")
                        {
                            if (projectedvaluesearch(skillvalue, 20) == false)
                            {// turn skill on and all priors if all off
                                string skillvalue1 = ReplaceAt(skillvalue, 0, '1');
                                string skillvalue2 = ReplaceAt(skillvalue1, 17, '1');
                                string skillvalue3 = ReplaceAt(skillvalue2, 18, '1');
                                string skillvalue4 = ReplaceAt(skillvalue3, 19, '1');
                                skillvalue = ReplaceAt(skillvalue4, 20, '1');
                                togglepreqSkillsON(name);
                            }
                            else if (projectedvaluesearch(skillvalue, 20) == true)
                            {//turn skill off and others above if on
                                togglepreqSkillsOFF("4");
                                string skillvalue1 = ReplaceAt(skillvalue, 20, '0');
                                skillvalue = ReplaceAt(skillvalue1, 22, '0');
                            }
                        }
                        if (button == "right") { }
                        updateskills(name, selectedprof, skillvalue);
                        updateDisplay();
                        displayIcons(selectedprof);
                        calcpoints(name);
                    }
                    break;
                case "labelMaster_MouseDown":
                    {
                        if (button == "left")
                        {
                            if (projectedvaluesearch(skillvalue, 22) == false)
                            {// turn skill on and all priors if all off
                                string skillvalue1 = ReplaceAt(skillvalue, 0, '1');
                                string skillvalue2 = ReplaceAt(skillvalue1, 2, '1');
                                string skillvalue3 = ReplaceAt(skillvalue2, 3, '1');
                                string skillvalue4 = ReplaceAt(skillvalue3, 4, '1');
                                string skillvalue5 = ReplaceAt(skillvalue4, 5, '1');
                                string skillvalue6 = ReplaceAt(skillvalue5, 7, '1');
                                string skillvalue7 = ReplaceAt(skillvalue6, 8, '1');
                                string skillvalue8 = ReplaceAt(skillvalue7, 9, '1');
                                string skillvalue9 = ReplaceAt(skillvalue8, 10, '1');
                                string skillvalue10 = ReplaceAt(skillvalue9, 12, '1');
                                string skillvalue11 = ReplaceAt(skillvalue10, 13, '1');
                                string skillvalue12 = ReplaceAt(skillvalue11, 14, '1');
                                string skillvalue13 = ReplaceAt(skillvalue12, 15, '1');
                                string skillvalue14 = ReplaceAt(skillvalue13, 17, '1');
                                string skillvalue15 = ReplaceAt(skillvalue14, 18, '1');
                                string skillvalue16 = ReplaceAt(skillvalue15, 19, '1');
                                string skillvalue17 = ReplaceAt(skillvalue16, 20, '1');
                                skillvalue = ReplaceAt(skillvalue17, 22, '1');
                                togglepreqSkillsON(name);
                            }
                            else if (projectedvaluesearch(skillvalue, 22) == true)
                            {//turn skill off and others above if on
                                togglepreqSkillsOFF("5");
                                skillvalue = ReplaceAt(skillvalue, 22, '0');
                            }
                        }
                        if (button == "right") { }
                        updateskills(name, selectedprof, skillvalue);
                        updateDisplay();
                        displayIcons(selectedprof);
                        calcpoints(name);
                    }
                    break;
            }
        }
        private void setASmith(string name)
        {
            string tempskillvalue = getskills(name, professions[0]);
            string tempskillvalue1 = ReplaceAt(tempskillvalue, 0, '1');
            string tempskillvalue2 = ReplaceAt(tempskillvalue1, 2, '1');
            string tempskillvalue3 = ReplaceAt(tempskillvalue2, 3, '1');
            string tempskillvalue4 = ReplaceAt(tempskillvalue3, 4, '1');
            string tempskillvalue5 = ReplaceAt(tempskillvalue4, 5, '1');
            updateskills(name, professions[0], tempskillvalue5);
            updateskills(name, professions[8], "1-1111-1111-1111-1111-1");
        }
        private void setBE(string name)
        {
            string tempskillvalue = getskills(name, professions[4]);
            string tempskillvalue1 = ReplaceAt(tempskillvalue, 0, '1');
            string tempskillvalue2 = ReplaceAt(tempskillvalue1, 17, '1');
            string tempskillvalue3 = ReplaceAt(tempskillvalue2, 18, '1');
            string tempskillvalue4 = ReplaceAt(tempskillvalue3, 19, '1');
            string tempskillvalue5 = ReplaceAt(tempskillvalue4, 20, '1');
            updateskills(name, professions[4], tempskillvalue5);
            string tempskillvalue6 = getskills(name, professions[6]);
            string tempskillvalue7 = ReplaceAt(tempskillvalue6, 0, '1');
            string tempskillvalue8 = ReplaceAt(tempskillvalue7, 12, '1');
            string tempskillvalue9 = ReplaceAt(tempskillvalue8, 13, '1');
            string tempskillvalue10 = ReplaceAt(tempskillvalue9, 14, '1');
            string tempskillvalue11 = ReplaceAt(tempskillvalue10, 15, '1');
            updateskills(name, professions[6], tempskillvalue11);
            updateskills(name, professions[9], "1-1111-1111-1111-1111-1");
        }
        private void setCH(string name)
        {
            string tempskillvalue = getskills(name, professions[6]);
            string tempskillvalue1 = ReplaceAt(tempskillvalue, 0, '1');
            string tempskillvalue2 = ReplaceAt(tempskillvalue1, 2, '1');
            string tempskillvalue3 = ReplaceAt(tempskillvalue2, 3, '1');
            string tempskillvalue4 = ReplaceAt(tempskillvalue3, 4, '1');
            string tempskillvalue5 = ReplaceAt(tempskillvalue4, 5, '1');
            string tempskillvalue6 = ReplaceAt(tempskillvalue5, 12, '1');
            string tempskillvalue7 = ReplaceAt(tempskillvalue6, 13, '1');
            string tempskillvalue8 = ReplaceAt(tempskillvalue7, 14, '1');
            string tempskillvalue9 = ReplaceAt(tempskillvalue8, 15, '1');
            updateskills(name, professions[6], tempskillvalue9);
            updateskills(name, professions[15], "1-1111-1111-1111-1111-1");
        }
        private void setCM(string name)
        {
            string tempskillvalue = getskills(name, professions[3]);
            string tempskillvalue1 = ReplaceAt(tempskillvalue, 0, '1');
            string tempskillvalue2 = ReplaceAt(tempskillvalue1, 17, '1');
            string tempskillvalue3 = ReplaceAt(tempskillvalue2, 18, '1');
            string tempskillvalue4 = ReplaceAt(tempskillvalue3, 19, '1');
            string tempskillvalue5 = ReplaceAt(tempskillvalue4, 20, '1');
            updateskills(name, professions[3], tempskillvalue5);
            updateskills(name, professions[4], "1-1111-1111-1111-1111-1");
            updateskills(name, professions[13], "1-1111-1111-1111-1111-1");
        }
        private void setComm(string name)
        {
            string tempskillvalue = getskills(name, professions[1]);
            string tempskillvalue1 = ReplaceAt(tempskillvalue, 0, '1');
            string tempskillvalue2 = ReplaceAt(tempskillvalue1, 2, '1');
            string tempskillvalue3 = ReplaceAt(tempskillvalue2, 3, '1');
            string tempskillvalue4 = ReplaceAt(tempskillvalue3, 4, '1');
            string tempskillvalue5 = ReplaceAt(tempskillvalue4, 5, '1');
            updateskills(name, professions[1], tempskillvalue5);
            updateskills(name, professions[3], "1-1111-1111-1111-1111-1");
            updateskills(name, professions[14], "1-1111-1111-1111-1111-1");
        }
        private void setDance(string name)
        {
            string tempskillvalue = getskills(name, professions[2]);
            string tempskillvalue1 = ReplaceAt(tempskillvalue, 0, '1');
            string tempskillvalue2 = ReplaceAt(tempskillvalue1, 12, '1');
            string tempskillvalue3 = ReplaceAt(tempskillvalue2, 13, '1');
            string tempskillvalue4 = ReplaceAt(tempskillvalue3, 14, '1');
            string tempskillvalue5 = ReplaceAt(tempskillvalue4, 15, '1');
            string tempskillvalue6 = ReplaceAt(tempskillvalue5, 17, '1');
            string tempskillvalue7 = ReplaceAt(tempskillvalue6, 18, '1');
            string tempskillvalue8 = ReplaceAt(tempskillvalue7, 19, '1');
            string tempskillvalue9 = ReplaceAt(tempskillvalue8, 20, '1');
            updateskills(name, professions[2], tempskillvalue9);
            updateskills(name, professions[16], "1-1111-1111-1111-1111-1");
        }
        private void setDoc(string name)
        {
            updateskills(name, professions[4], "1-1111-1111-1111-1111-1");
            updateskills(name, professions[17], "1-1111-1111-1111-1111-1");
        }
        private void setID(string name)
        {
            string tempskillvalue = getskills(name, professions[2]);
            string tempskillvalue1 = ReplaceAt(tempskillvalue, 0, '1');
            string tempskillvalue2 = ReplaceAt(tempskillvalue1, 2, '1');
            string tempskillvalue3 = ReplaceAt(tempskillvalue2, 3, '1');
            string tempskillvalue4 = ReplaceAt(tempskillvalue3, 4, '1');
            string tempskillvalue5 = ReplaceAt(tempskillvalue4, 5, '1');
            updateskills(name, professions[2], tempskillvalue5);
            updateskills(name, professions[20], "1-1111-1111-1111-1111-1");
        }
        private void setMus(string name)
        {
            string tempskillvalue = getskills(name, professions[2]);
            string tempskillvalue1 = ReplaceAt(tempskillvalue, 0, '1');
            string tempskillvalue2 = ReplaceAt(tempskillvalue1, 7, '1');
            string tempskillvalue3 = ReplaceAt(tempskillvalue2, 8, '1');
            string tempskillvalue4 = ReplaceAt(tempskillvalue3, 9, '1');
            string tempskillvalue5 = ReplaceAt(tempskillvalue4, 10, '1');
            string tempskillvalue6 = ReplaceAt(tempskillvalue5, 17, '1');
            string tempskillvalue7 = ReplaceAt(tempskillvalue6, 18, '1');
            string tempskillvalue8 = ReplaceAt(tempskillvalue7, 19, '1');
            string tempskillvalue9 = ReplaceAt(tempskillvalue8, 20, '1');
            updateskills(name, professions[2], tempskillvalue9);
            updateskills(name, professions[22], "1-1111-1111-1111-1111-1");
        }
        private void setPistol(string name)
        {
            string tempskillvalue = getskills(name, professions[3]);
            string tempskillvalue1 = ReplaceAt(tempskillvalue, 0, '1');
            string tempskillvalue2 = ReplaceAt(tempskillvalue1, 7, '1');
            string tempskillvalue3 = ReplaceAt(tempskillvalue2, 8, '1');
            string tempskillvalue4 = ReplaceAt(tempskillvalue3, 9, '1');
            string tempskillvalue5 = ReplaceAt(tempskillvalue4, 10, '1');
            updateskills(name, professions[3], tempskillvalue5);
            updateskills(name, professions[24], "1-1111-1111-1111-1111-1");
        }
        private void setSmug(string name)
        {
            string tempskillvalue = getskills(name, professions[1]);
            string tempskillvalue1 = ReplaceAt(tempskillvalue, 0, '1');
            string tempskillvalue2 = ReplaceAt(tempskillvalue1, 2, '1');
            string tempskillvalue3 = ReplaceAt(tempskillvalue2, 3, '1');
            string tempskillvalue4 = ReplaceAt(tempskillvalue3, 4, '1');
            string tempskillvalue5 = ReplaceAt(tempskillvalue4, 5, '1');
            updateskills(name, professions[1], tempskillvalue5);
            updateskills(name, professions[27], "1-1111-1111-1111-1111-1");
        }
        private void setTailor(string name)
        {
            string tempskillvalue = getskills(name, professions[0]);
            string tempskillvalue1 = ReplaceAt(tempskillvalue, 0, '1');
            string tempskillvalue2 = ReplaceAt(tempskillvalue1, 7, '1');
            string tempskillvalue3 = ReplaceAt(tempskillvalue2, 8, '1');
            string tempskillvalue4 = ReplaceAt(tempskillvalue3, 9, '1');
            string tempskillvalue5 = ReplaceAt(tempskillvalue4, 10, '1');
            updateskills(name, professions[0], tempskillvalue5);
            updateskills(name, professions[30], "1-1111-1111-1111-1111-1");
        }
        private void setTK(string name)
        {
            string tempskillvalue = getskills(name, professions[1]);
            string tempskillvalue1 = ReplaceAt(tempskillvalue, 0, '1');
            string tempskillvalue2 = ReplaceAt(tempskillvalue1, 2, '1');
            string tempskillvalue3 = ReplaceAt(tempskillvalue2, 3, '1');
            string tempskillvalue4 = ReplaceAt(tempskillvalue3, 4, '1');
            string tempskillvalue5 = ReplaceAt(tempskillvalue4, 5, '1');
            updateskills(name, professions[1], tempskillvalue5);
            updateskills(name, professions[31], "1-1111-1111-1111-1111-1");
        }
        private void setWSmith(string name)
        {
            string tempskillvalue = getskills(name, professions[0]);
            string tempskillvalue1 = ReplaceAt(tempskillvalue, 0, '1');
            string tempskillvalue2 = ReplaceAt(tempskillvalue1, 2, '1');
            string tempskillvalue3 = ReplaceAt(tempskillvalue2, 3, '1');
            string tempskillvalue4 = ReplaceAt(tempskillvalue3, 4, '1');
            string tempskillvalue5 = ReplaceAt(tempskillvalue4, 5, '1');
            updateskills(name, professions[0], tempskillvalue5);
            updateskills(name, professions[32], "1-1111-1111-1111-1111-1");
        }
    }
}