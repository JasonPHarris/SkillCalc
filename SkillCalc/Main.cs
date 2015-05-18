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
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace SkillCalc
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
            this.labelversion.Text = "1.3";
            mouseHovering();
            checkFile();
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            close.BackColor = Color.Transparent;
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            help.BackColor = Color.Transparent;
            defaultname();
            clearnamescroll();
            namescroll(0);
            if (debugme == true)
            {
                this.BackgroundImage = global::SkillCalc.Properties.Resources.program_br_bug_nosum;
                this.ClientSize = new System.Drawing.Size(925, 670);
                this.debugbox.Visible = true;
                this.clearDebug.Visible = true;
            }
        }
        private void debug(string stuff) { if (debugme == true) { this.debugbox.Text += stuff + "\r\n"; } }
        private void mouseHovering()
        {
            this.labelNovice.MouseHover += new EventHandler(labelNovice_MouseEnter);
            this.labelNovice.MouseLeave += new EventHandler(labelNovice_MouseLeave);

            this.labelfirstI.MouseHover += new EventHandler(labelfirstI_MouseEnter);
            this.labelfirstI.MouseLeave += new EventHandler(labelfirstI_MouseLeave);
            this.labelfirstII.MouseHover += new EventHandler(labelfirstII_MouseEnter);
            this.labelfirstII.MouseLeave += new EventHandler(labelfirstII_MouseLeave);
            this.labelfirstIII.MouseHover += new EventHandler(labelfirstIII_MouseEnter);
            this.labelfirstIII.MouseLeave += new EventHandler(labelfirstIII_MouseLeave);
            this.labelfirstIV.MouseHover += new EventHandler(labelfirstIV_MouseEnter);
            this.labelfirstIV.MouseLeave += new EventHandler(labelfirstIV_MouseLeave);

            this.labelsecondI.MouseHover += new EventHandler(labelsecondI_MouseEnter);
            this.labelsecondI.MouseLeave += new EventHandler(labelsecondI_MouseLeave);
            this.labelsecondII.MouseHover += new EventHandler(labelsecondII_MouseEnter);
            this.labelsecondII.MouseLeave += new EventHandler(labelsecondII_MouseLeave);
            this.labelsecondIII.MouseHover += new EventHandler(labelsecondIII_MouseEnter);
            this.labelsecondIII.MouseLeave += new EventHandler(labelsecondIII_MouseLeave);
            this.labelsecondIV.MouseHover += new EventHandler(labelsecondIV_MouseEnter);
            this.labelsecondIV.MouseLeave += new EventHandler(labelsecondIV_MouseLeave);

            this.labelthirdI.MouseHover += new EventHandler(labelthirdI_MouseEnter);
            this.labelthirdI.MouseLeave += new EventHandler(labelthirdI_MouseLeave);
            this.labelthirdII.MouseHover += new EventHandler(labelthirdII_MouseEnter);
            this.labelthirdII.MouseLeave += new EventHandler(labelthirdII_MouseLeave);
            this.labelthirdIII.MouseHover += new EventHandler(labelthirdIII_MouseEnter);
            this.labelthirdIII.MouseLeave += new EventHandler(labelthirdIII_MouseLeave);
            this.labelthirdIV.MouseHover += new EventHandler(labelthirdIV_MouseEnter);
            this.labelthirdIV.MouseLeave += new EventHandler(labelthirdIV_MouseLeave);

            this.labelfourthI.MouseHover += new EventHandler(labelfourthI_MouseEnter);
            this.labelfourthI.MouseLeave += new EventHandler(labelfourthI_MouseLeave);
            this.labelfourthII.MouseHover += new EventHandler(labelfourthII_MouseEnter);
            this.labelfourthII.MouseLeave += new EventHandler(labelfourthII_MouseLeave);
            this.labelfourthIII.MouseHover += new EventHandler(labelfourthIII_MouseEnter);
            this.labelfourthIII.MouseLeave += new EventHandler(labelfourthIII_MouseLeave);
            this.labelfourthIV.MouseHover += new EventHandler(labelfourthIV_MouseEnter);
            this.labelfourthIV.MouseLeave += new EventHandler(labelfourthIV_MouseLeave);

            this.labelMaster.MouseHover += new EventHandler(labelMaster_MouseEnter);
            this.labelMaster.MouseLeave += new EventHandler(labelMaster_MouseLeave);
        }
        private string ReplaceAt(string input, int index, char newChar)
        {
            if (input == null) { return ""; }
            char[] array = input.ToCharArray();
            array[index] = newChar;
            string output = new string(array);
            return output;
        }

        // Sets the variable for correct skill display for each profession clicked.
        private string viewtab;
        private string selectedprof;
        private bool debugme = false;
        private bool showhelp = false;

        // Sets global saved name list.
        private int scroll;
        List<string> namelist = new List<string>();

        string[] professions = { "Artisan", "Brawler", "Entertainer", "Marksman", "Medic", "Politician", "Scout", "Architect",
                                 "Armorsmith", "Bio-Engineer", "Bounty Hunter", "Carbineer", "Chef", "Combat Medic", "Commando",
                                 "Creature Handler", "Dancer", "Doctor", "Droid Engineer", "Fencer", "Image Designer", "Merchant",
                                 "Musician", "Pikeman", "Pistoleer", "Ranger", "Rifleman", "Smuggler", "Squad Leader", "Swordsman",
                                 "Tailor", "Teras Kasi Artist", "Weaponsmith", "Combat Prowess", "Crafting Mastery", "Enhanced Reflexes",
                                 "Heightened Senses", "Force Defense", "Force Enhancement", "Force Healing", "Lightsaber", "Force Powers",
                                 "Padawan", "Light Master", "Light Journeyman", "Dark Master", "Dark Journeyman" };

        // Handles points and professions selected.
        private void calcpoints(string name)
        {

            string[] basic = { "Artisan", "Brawler", "Entertainer", "Marksman", "Medic", "Politician", "Scout" };
            string[] advanced = { "Architect", "Armorsmith", "Bio-Engineer", "Bounty Hunter", "Carbineer", "Chef", "Combat Medic",
                                  "Commando", "Creature Handler", "Dancer", "Doctor", "Droid Engineer", "Fencer", "Merchant",
                                 "Musician", "Pikeman", "Pistoleer", "Ranger", "Rifleman", "Smuggler", "Squad Leader", "Swordsman",
                                 "Tailor", "Teras Kasi Artist", "Weaponsmith" };
            string[] force1 = { "Combat Prowess", "Crafting Mastery", "Enhanced Reflexes", "Heightened Senses" };
            string[] force2 = { "Force Defense", "Force Enhancement", "Force Healing", "Lightsaber", "Force Powers" };
            string ID = "Image Designer";

            int total = 0;
            foreach (string prof in basic)
            {
                if (getskills(name, prof).Substring(0, 1) == "1") { total += 15; }
                if (getskills(name, prof).Substring(2, 1) == "1") { total += 2; }
                if (getskills(name, prof).Substring(3, 1) == "1") { total += 3; }
                if (getskills(name, prof).Substring(4, 1) == "1") { total += 4; }
                if (getskills(name, prof).Substring(5, 1) == "1") { total += 5; }
                if (getskills(name, prof).Substring(7, 1) == "1") { total += 2; }
                if (getskills(name, prof).Substring(8, 1) == "1") { total += 3; }
                if (getskills(name, prof).Substring(9, 1) == "1") { total += 4; }
                if (getskills(name, prof).Substring(10, 1) == "1") { total += 5; }
                if (getskills(name, prof).Substring(12, 1) == "1") { total += 2; }
                if (getskills(name, prof).Substring(13, 1) == "1") { total += 3; }
                if (getskills(name, prof).Substring(14, 1) == "1") { total += 4; }
                if (getskills(name, prof).Substring(15, 1) == "1") { total += 5; }
                if (getskills(name, prof).Substring(17, 1) == "1") { total += 2; }
                if (getskills(name, prof).Substring(18, 1) == "1") { total += 3; }
                if (getskills(name, prof).Substring(19, 1) == "1") { total += 4; }
                if (getskills(name, prof).Substring(20, 1) == "1") { total += 5; }
                if (getskills(name, prof).Substring(22, 1) == "1") { total += 6; }
            }
            foreach (string prof in advanced)
            {
                if (getskills(name, prof).Substring(0, 1) == "1") { total += 6; }
                if (getskills(name, prof).Substring(2, 1) == "1") { total += 5; }
                if (getskills(name, prof).Substring(3, 1) == "1") { total += 4; }
                if (getskills(name, prof).Substring(4, 1) == "1") { total += 3; }
                if (getskills(name, prof).Substring(5, 1) == "1") { total += 2; }
                if (getskills(name, prof).Substring(7, 1) == "1") { total += 5; }
                if (getskills(name, prof).Substring(8, 1) == "1") { total += 4; }
                if (getskills(name, prof).Substring(9, 1) == "1") { total += 3; }
                if (getskills(name, prof).Substring(10, 1) == "1") { total += 2; }
                if (getskills(name, prof).Substring(12, 1) == "1") { total += 5; }
                if (getskills(name, prof).Substring(13, 1) == "1") { total += 4; }
                if (getskills(name, prof).Substring(14, 1) == "1") { total += 3; }
                if (getskills(name, prof).Substring(15, 1) == "1") { total += 2; }
                if (getskills(name, prof).Substring(17, 1) == "1") { total += 5; }
                if (getskills(name, prof).Substring(18, 1) == "1") { total += 4; }
                if (getskills(name, prof).Substring(19, 1) == "1") { total += 3; }
                if (getskills(name, prof).Substring(20, 1) == "1") { total += 2; }
                if (getskills(name, prof).Substring(22, 1) == "1") { total += 1; }
            }
            if (getskills(name, ID).Substring(0, 1) == "1") { total += 6; }
            if (getskills(name, ID).Substring(2, 1) == "1") { total += 4; }
            if (getskills(name, ID).Substring(3, 1) == "1") { total += 3; }
            if (getskills(name, ID).Substring(4, 1) == "1") { total += 2; }
            if (getskills(name, ID).Substring(5, 1) == "1") { total += 1; }
            if (getskills(name, ID).Substring(7, 1) == "1") { total += 4; }
            if (getskills(name, ID).Substring(8, 1) == "1") { total += 3; }
            if (getskills(name, ID).Substring(9, 1) == "1") { total += 2; }
            if (getskills(name, ID).Substring(10, 1) == "1") { total += 1; }
            if (getskills(name, ID).Substring(12, 1) == "1") { total += 4; }
            if (getskills(name, ID).Substring(13, 1) == "1") { total += 3; }
            if (getskills(name, ID).Substring(14, 1) == "1") { total += 2; }
            if (getskills(name, ID).Substring(15, 1) == "1") { total += 1; }
            if (getskills(name, ID).Substring(17, 1) == "1") { total += 4; }
            if (getskills(name, ID).Substring(18, 1) == "1") { total += 3; }
            if (getskills(name, ID).Substring(19, 1) == "1") { total += 2; }
            if (getskills(name, ID).Substring(20, 1) == "1") { total += 1; }
            if (getskills(name, ID).Substring(22, 1) == "1") { total += 1; }
            if (getskills(name, "Padawan").Substring(0, 1) == "1") { total += 250; }

            if (total > 250)
            {
                int overload = total - 250;
                this.labelSkillPoints.Text = "Skill Points Overload:";
                this.projectedPointsBar.Maximum = 2411;
                this.projectedPointsBar.Value = total - 250;
                this.labelPointsRemain.Text = overload.ToString();
                this.projectedPointsBar.RightToLeftLayout = true;
                this.projectedPointsBar.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
                this.projectedPointsBar.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                this.labelSkillPoints.Text = "Projected Skill Points Available:";
                this.projectedPointsBar.Maximum = 250;
                this.projectedPointsBar.Value = 250 - total;
                this.projectedPointsBar.RightToLeftLayout = false;
                this.labelPointsRemain.Text = this.projectedPointsBar.Value.ToString();
                this.projectedPointsBar.RightToLeft = System.Windows.Forms.RightToLeft.No;
                this.projectedPointsBar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(240)))), ((int)(((byte)(8)))));
                this.projectedPointsBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(96)))), ((int)(((byte)(117)))));
            }
        }
        private string spentcheck(string sender)
        {
            string name = this.charName.Text;
            string skillvalue = getskills(name, sender);

            if (skillvalue == "0-0000-0000-0000-0000-0") { return "none"; }
            else if (skillvalue == "1-1111-1111-1111-1111-1") { return "master"; }
            else { return "novice"; }
        }
        private void displayIcons(string sender)
        {
            switch (sender)
            {
                case "Artisan":
                    {
                        if (spentcheck("Artisan") == "none")
                        {
                            this.profIcon1.Image = null;
                            this.profIcon1.Visible = false;
                        }
                        else if (spentcheck("Artisan") == "novice")
                        {
                            this.profIcon1.Image = global::SkillCalc.Properties.Resources.prof_points_experimented;
                            this.profIcon1.Visible = true;
                        }
                        else if (spentcheck("Artisan") == "master")
                        {
                            this.profIcon1.Image = global::SkillCalc.Properties.Resources.prof_points_experimentmax;
                            this.profIcon1.Visible = true;
                        }
                    }
                    break;
                case "Brawler":
                    {
                        if (spentcheck("Brawler") == "none")
                        {
                            this.profIcon2.Image = null;
                            this.profIcon2.Visible = false;
                        }
                        else if (spentcheck("Brawler") == "novice")
                        {
                            this.profIcon2.Image = global::SkillCalc.Properties.Resources.prof_points_experimented;
                            this.profIcon2.Visible = true;
                        }
                        else if (spentcheck("Brawler") == "master")
                        {
                            this.profIcon2.Image = global::SkillCalc.Properties.Resources.prof_points_experimentmax;
                            this.profIcon2.Visible = true;
                        }
                    }
                    break;
                case "Entertainer":
                    {
                        if (spentcheck("Entertainer") == "none")
                        {
                            this.profIcon3.Image = null;
                            this.profIcon3.Visible = false;
                        }
                        else if (spentcheck("Entertainer") == "novice")
                        {
                            this.profIcon3.Image = global::SkillCalc.Properties.Resources.prof_points_experimented;
                            this.profIcon3.Visible = true;
                        }
                        else if (spentcheck("Entertainer") == "master")
                        {
                            this.profIcon3.Image = global::SkillCalc.Properties.Resources.prof_points_experimentmax;
                            this.profIcon3.Visible = true;
                        }
                    }
                    break;
                case "Marksman":
                    {
                        if (spentcheck("Marksman") == "none")
                        {
                            this.profIcon4.Image = null;
                            this.profIcon4.Visible = false;
                        }
                        else if (spentcheck("Marksman") == "novice")
                        {
                            this.profIcon4.Image = global::SkillCalc.Properties.Resources.prof_points_experimented;
                            this.profIcon4.Visible = true;
                        }
                        else if (spentcheck("Marksman") == "master")
                        {
                            this.profIcon4.Image = global::SkillCalc.Properties.Resources.prof_points_experimentmax;
                            this.profIcon4.Visible = true;
                        }
                    }
                    break;
                case "Medic":
                    {
                        if (spentcheck("Medic") == "none")
                        {
                            this.profIcon5.Image = null;
                            this.profIcon5.Visible = false;
                        }
                        else if (spentcheck("Medic") == "novice")
                        {
                            this.profIcon5.Image = global::SkillCalc.Properties.Resources.prof_points_experimented;
                            this.profIcon5.Visible = true;
                        }
                        else if (spentcheck("Medic") == "master")
                        {
                            this.profIcon5.Image = global::SkillCalc.Properties.Resources.prof_points_experimentmax;
                            this.profIcon5.Visible = true;
                        }
                    }
                    break;
                case "Politician":
                    {
                        if (spentcheck("Politician") == "none")
                        {
                            this.profIcon6.Image = null;
                            this.profIcon6.Visible = false;
                        }
                        else if (spentcheck("Politician") == "novice")
                        {
                            this.profIcon6.Image = global::SkillCalc.Properties.Resources.prof_points_experimented;
                            this.profIcon6.Visible = true;
                        }
                        else if (spentcheck("Politician") == "master")
                        {
                            this.profIcon6.Image = global::SkillCalc.Properties.Resources.prof_points_experimentmax;
                            this.profIcon6.Visible = true;
                        }
                    }
                    break;
                case "Scout":
                    {
                        if (spentcheck("Scout") == "none")
                        {
                            this.profIcon7.Image = null;
                            this.profIcon7.Visible = false;
                        }
                        else if (spentcheck("Scout") == "novice")
                        {
                            this.profIcon7.Image = global::SkillCalc.Properties.Resources.prof_points_experimented;
                            this.profIcon7.Visible = true;
                        }
                        else if (spentcheck("Scout") == "master")
                        {
                            this.profIcon7.Image = global::SkillCalc.Properties.Resources.prof_points_experimentmax;
                            this.profIcon7.Visible = true;
                        }
                    }
                    break;
                case "Architect":
                    {
                        if (spentcheck("Architect") == "none")
                        {
                            this.profIcon1.Image = null;
                            this.profIcon1.Visible = false;
                        }
                        else if (spentcheck("Architect") == "novice")
                        {
                            this.profIcon1.Image = global::SkillCalc.Properties.Resources.prof_points_experimented;
                            this.profIcon1.Visible = true;
                        }
                        else if (spentcheck("Architect") == "master")
                        {
                            this.profIcon1.Image = global::SkillCalc.Properties.Resources.prof_points_experimentmax;
                            this.profIcon1.Visible = true;
                        }
                    }
                    break;
                case "Armorsmith":
                    {
                        if (spentcheck("Armorsmith") == "none")
                        {
                            this.profIcon2.Image = null;
                            this.profIcon2.Visible = false;
                        }
                        else if (spentcheck("Armorsmith") == "novice")
                        {
                            this.profIcon2.Image = global::SkillCalc.Properties.Resources.prof_points_experimented;
                            this.profIcon2.Visible = true;
                        }
                        else if (spentcheck("Armorsmith") == "master")
                        {
                            this.profIcon2.Image = global::SkillCalc.Properties.Resources.prof_points_experimentmax;
                            this.profIcon2.Visible = true;
                        }
                    }
                    break;
                case "Bio-Engineer":
                    {
                        if (spentcheck("Bio-Engineer") == "none")
                        {
                            this.profIcon3.Image = null;
                            this.profIcon3.Visible = false;
                        }
                        else if (spentcheck("Bio-Engineer") == "novice")
                        {
                            this.profIcon3.Image = global::SkillCalc.Properties.Resources.prof_points_experimented;
                            this.profIcon3.Visible = true;
                        }
                        else if (spentcheck("Bio-Engineer") == "master")
                        {
                            this.profIcon3.Image = global::SkillCalc.Properties.Resources.prof_points_experimentmax;
                            this.profIcon3.Visible = true;
                        }
                    }
                    break;
                case "Bounty Hunter":
                    {
                        if (spentcheck("Bounty Hunter") == "none")
                        {
                            this.profIcon4.Image = null;
                            this.profIcon4.Visible = false;
                        }
                        else if (spentcheck("Bounty Hunter") == "novice")
                        {
                            this.profIcon4.Image = global::SkillCalc.Properties.Resources.prof_points_experimented;
                            this.profIcon4.Visible = true;
                        }
                        else if (spentcheck("Bounty Hunter") == "master")
                        {
                            this.profIcon4.Image = global::SkillCalc.Properties.Resources.prof_points_experimentmax;
                            this.profIcon4.Visible = true;
                        }
                    }
                    break;
                case "Carbineer":
                    {
                        if (spentcheck("Carbineer") == "none")
                        {
                            this.profIcon5.Image = null;
                            this.profIcon5.Visible = false;
                        }
                        else if (spentcheck("Carbineer") == "novice")
                        {
                            this.profIcon5.Image = global::SkillCalc.Properties.Resources.prof_points_experimented;
                            this.profIcon5.Visible = true;
                        }
                        else if (spentcheck("Carbineer") == "master")
                        {
                            this.profIcon5.Image = global::SkillCalc.Properties.Resources.prof_points_experimentmax;
                            this.profIcon5.Visible = true;
                        }
                    }
                    break;
                case "Chef":
                    {
                        if (spentcheck("Chef") == "none")
                        {
                            this.profIcon6.Image = null;
                            this.profIcon6.Visible = false;
                        }
                        else if (spentcheck("Chef") == "novice")
                        {
                            this.profIcon6.Image = global::SkillCalc.Properties.Resources.prof_points_experimented;
                            this.profIcon6.Visible = true;
                        }
                        else if (spentcheck("Chef") == "master")
                        {
                            this.profIcon6.Image = global::SkillCalc.Properties.Resources.prof_points_experimentmax;
                            this.profIcon6.Visible = true;
                        }
                    }
                    break;
                case "Combat Medic":
                    {
                        if (spentcheck("Combat Medic") == "none")
                        {
                            this.profIcon7.Image = null;
                            this.profIcon7.Visible = false;
                        }
                        else if (spentcheck("Combat Medic") == "novice")
                        {
                            this.profIcon7.Image = global::SkillCalc.Properties.Resources.prof_points_experimented;
                            this.profIcon7.Visible = true;
                        }
                        else if (spentcheck("Combat Medic") == "master")
                        {
                            this.profIcon7.Image = global::SkillCalc.Properties.Resources.prof_points_experimentmax;
                            this.profIcon7.Visible = true;
                        }
                    }
                    break;
                case "Commando":
                    {
                        if (spentcheck("Commando") == "none")
                        {
                            this.profIcon8.Image = null;
                            this.profIcon8.Visible = false;
                        }
                        else if (spentcheck("Commando") == "novice")
                        {
                            this.profIcon8.Image = global::SkillCalc.Properties.Resources.prof_points_experimented;
                            this.profIcon8.Visible = true;
                        }
                        else if (spentcheck("Commando") == "master")
                        {
                            this.profIcon8.Image = global::SkillCalc.Properties.Resources.prof_points_experimentmax;
                            this.profIcon8.Visible = true;
                        }
                    }
                    break;
                case "Creature Handler":
                    {
                        if (spentcheck("Creature Handler") == "none")
                        {
                            this.profIcon9.Image = null;
                            this.profIcon9.Visible = false;
                        }
                        else if (spentcheck("Creature Handler") == "novice")
                        {
                            this.profIcon9.Image = global::SkillCalc.Properties.Resources.prof_points_experimented;
                            this.profIcon9.Visible = true;
                        }
                        else if (spentcheck("Creature Handler") == "master")
                        {
                            this.profIcon9.Image = global::SkillCalc.Properties.Resources.prof_points_experimentmax;
                            this.profIcon9.Visible = true;
                        }
                    }
                    break;
                case "Dancer":
                    {
                        if (spentcheck("Dancer") == "none")
                        {
                            this.profIcon10.Image = null;
                            this.profIcon10.Visible = false;
                        }
                        else if (spentcheck("Dancer") == "novice")
                        {
                            this.profIcon10.Image = global::SkillCalc.Properties.Resources.prof_points_experimented;
                            this.profIcon10.Visible = true;
                        }
                        else if (spentcheck("Dancer") == "master")
                        {
                            this.profIcon10.Image = global::SkillCalc.Properties.Resources.prof_points_experimentmax;
                            this.profIcon10.Visible = true;
                        }
                    }
                    break;
                case "Doctor":
                    {
                        if (spentcheck("Doctor") == "none")
                        {
                            this.profIcon11.Image = null;
                            this.profIcon11.Visible = false;
                        }
                        else if (spentcheck("Doctor") == "novice")
                        {
                            this.profIcon11.Image = global::SkillCalc.Properties.Resources.prof_points_experimented;
                            this.profIcon11.Visible = true;
                        }
                        else if (spentcheck("Doctor") == "master")
                        {
                            this.profIcon11.Image = global::SkillCalc.Properties.Resources.prof_points_experimentmax;
                            this.profIcon11.Visible = true;
                        }
                    }
                    break;
                case "Droid Engineer":
                    {
                        if (spentcheck("Droid Engineer") == "none")
                        {
                            this.profIcon12.Image = null;
                            this.profIcon12.Visible = false;
                        }
                        else if (spentcheck("Droid Engineer") == "novice")
                        {
                            this.profIcon12.Image = global::SkillCalc.Properties.Resources.prof_points_experimented;
                            this.profIcon12.Visible = true;
                        }
                        else if (spentcheck("Droid Engineer") == "master")
                        {
                            this.profIcon12.Image = global::SkillCalc.Properties.Resources.prof_points_experimentmax;
                            this.profIcon12.Visible = true;
                        }
                    }
                    break;
                case "Fencer":
                    {
                        if (spentcheck("Fencer") == "none")
                        {
                            this.profIcon13.Image = null;
                            this.profIcon13.Visible = false;
                        }
                        else if (spentcheck("Fencer") == "novice")
                        {
                            this.profIcon13.Image = global::SkillCalc.Properties.Resources.prof_points_experimented;
                            this.profIcon13.Visible = true;
                        }
                        else if (spentcheck("Fencer") == "master")
                        {
                            this.profIcon13.Image = global::SkillCalc.Properties.Resources.prof_points_experimentmax;
                            this.profIcon13.Visible = true;
                        }
                    }
                    break;
                case "Image Designer":
                    {
                        if (spentcheck("Image Designer") == "none")
                        {
                            this.profIcon14.Image = null;
                            this.profIcon14.Visible = false;
                        }
                        else if (spentcheck("Image Designer") == "novice")
                        {
                            this.profIcon14.Image = global::SkillCalc.Properties.Resources.prof_points_experimented;
                            this.profIcon14.Visible = true;
                        }
                        else if (spentcheck("Image Designer") == "master")
                        {
                            this.profIcon14.Image = global::SkillCalc.Properties.Resources.prof_points_experimentmax;
                            this.profIcon14.Visible = true;
                        }
                    }
                    break;
                case "Merchant":
                    {
                        if (spentcheck("Merchant") == "none")
                        {
                            this.profIcon15.Image = null;
                            this.profIcon15.Visible = false;
                        }
                        else if (spentcheck("Merchant") == "novice")
                        {
                            this.profIcon15.Image = global::SkillCalc.Properties.Resources.prof_points_experimented;
                            this.profIcon15.Visible = true;
                        }
                        else if (spentcheck("Merchant") == "master")
                        {
                            this.profIcon15.Image = global::SkillCalc.Properties.Resources.prof_points_experimentmax;
                            this.profIcon15.Visible = true;
                        }
                    }
                    break;
                case "Musician":
                    {
                        if (spentcheck("Musician") == "none")
                        {
                            this.profIcon16.Image = null;
                            this.profIcon16.Visible = false;
                        }
                        else if (spentcheck("Musician") == "novice")
                        {
                            this.profIcon16.Image = global::SkillCalc.Properties.Resources.prof_points_experimented;
                            this.profIcon16.Visible = true;
                        }
                        else if (spentcheck("Musician") == "master")
                        {
                            this.profIcon16.Image = global::SkillCalc.Properties.Resources.prof_points_experimentmax;
                            this.profIcon16.Visible = true;
                        }
                    }
                    break;
                case "Pikeman":
                    {
                        if (spentcheck("Pikeman") == "none")
                        {
                            this.profIcon17.Image = null;
                            this.profIcon17.Visible = false;
                        }
                        else if (spentcheck("Pikeman") == "novice")
                        {
                            this.profIcon17.Image = global::SkillCalc.Properties.Resources.prof_points_experimented;
                            this.profIcon17.Visible = true;
                        }
                        else if (spentcheck("Pikeman") == "master")
                        {
                            this.profIcon17.Image = global::SkillCalc.Properties.Resources.prof_points_experimentmax;
                            this.profIcon17.Visible = true;
                        }
                    }
                    break;
                case "Pistoleer":
                    {
                        if (spentcheck("Pistoleer") == "none")
                        {
                            this.profIcon18.Image = null;
                            this.profIcon18.Visible = false;
                        }
                        else if (spentcheck("Pistoleer") == "novice")
                        {
                            this.profIcon18.Image = global::SkillCalc.Properties.Resources.prof_points_experimented;
                            this.profIcon18.Visible = true;
                        }
                        else if (spentcheck("Pistoleer") == "master")
                        {
                            this.profIcon18.Image = global::SkillCalc.Properties.Resources.prof_points_experimentmax;
                            this.profIcon18.Visible = true;
                        }
                    }
                    break;
                case "Ranger":
                    {
                        if (spentcheck("Ranger") == "none")
                        {
                            this.profIcon19.Image = null;
                            this.profIcon19.Visible = false;
                        }
                        else if (spentcheck("Ranger") == "novice")
                        {
                            this.profIcon19.Image = global::SkillCalc.Properties.Resources.prof_points_experimented;
                            this.profIcon19.Visible = true;
                        }
                        else if (spentcheck("Ranger") == "master")
                        {
                            this.profIcon19.Image = global::SkillCalc.Properties.Resources.prof_points_experimentmax;
                            this.profIcon19.Visible = true;
                        }
                    }
                    break;
                case "Rifleman":
                    {
                        if (spentcheck("Rifleman") == "none")
                        {
                            this.profIcon20.Image = null;
                            this.profIcon20.Visible = false;
                        }
                        else if (spentcheck("Rifleman") == "novice")
                        {
                            this.profIcon20.Image = global::SkillCalc.Properties.Resources.prof_points_experimented;
                            this.profIcon20.Visible = true;
                        }
                        else if (spentcheck("Rifleman") == "master")
                        {
                            this.profIcon20.Image = global::SkillCalc.Properties.Resources.prof_points_experimentmax;
                            this.profIcon20.Visible = true;
                        }
                    }
                    break;
                case "Smuggler":
                    {
                        if (spentcheck("Smuggler") == "none")
                        {
                            this.profIcon21.Image = null;
                            this.profIcon21.Visible = false;
                        }
                        else if (spentcheck("Smuggler") == "novice")
                        {
                            this.profIcon21.Image = global::SkillCalc.Properties.Resources.prof_points_experimented;
                            this.profIcon21.Visible = true;
                        }
                        else if (spentcheck("Smuggler") == "master")
                        {
                            this.profIcon21.Image = global::SkillCalc.Properties.Resources.prof_points_experimentmax;
                            this.profIcon21.Visible = true;
                        }
                    }
                    break;
                case "Squad Leader":
                    {
                        if (spentcheck("Squad Leader") == "none")
                        {
                            this.profIcon22.Image = null;
                            this.profIcon22.Visible = false;
                        }
                        else if (spentcheck("Squad Leader") == "novice")
                        {
                            this.profIcon22.Image = global::SkillCalc.Properties.Resources.prof_points_experimented;
                            this.profIcon22.Visible = true;
                        }
                        else if (spentcheck("Squad Leader") == "master")
                        {
                            this.profIcon22.Image = global::SkillCalc.Properties.Resources.prof_points_experimentmax;
                            this.profIcon22.Visible = true;
                        }
                    }
                    break;
                case "Swordsman":
                    {
                        if (spentcheck("Swordsman") == "none")
                        {
                            this.profIcon23.Image = null;
                            this.profIcon23.Visible = false;
                        }
                        else if (spentcheck("Swordsman") == "novice")
                        {
                            this.profIcon23.Image = global::SkillCalc.Properties.Resources.prof_points_experimented;
                            this.profIcon23.Visible = true;
                        }
                        else if (spentcheck("Swordsman") == "master")
                        {
                            this.profIcon23.Image = global::SkillCalc.Properties.Resources.prof_points_experimentmax;
                            this.profIcon23.Visible = true;
                        }
                    }
                    break;
                case "Tailor":
                    {
                        if (spentcheck("Tailor") == "none")
                        {
                            this.profIcon24.Image = null;
                            this.profIcon24.Visible = false;
                        }
                        else if (spentcheck("Tailor") == "novice")
                        {
                            this.profIcon24.Image = global::SkillCalc.Properties.Resources.prof_points_experimented;
                            this.profIcon24.Visible = true;
                        }
                        else if (spentcheck("Tailor") == "master")
                        {
                            this.profIcon24.Image = global::SkillCalc.Properties.Resources.prof_points_experimentmax;
                            this.profIcon24.Visible = true;
                        }
                    }
                    break;
                case "Teras Kasi Artist":
                    {
                        if (spentcheck("Teras Kasi Artist") == "none")
                        {
                            this.profIcon25.Image = null;
                            this.profIcon25.Visible = false;
                        }
                        else if (spentcheck("Teras Kasi Artist") == "novice")
                        {
                            this.profIcon25.Image = global::SkillCalc.Properties.Resources.prof_points_experimented;
                            this.profIcon25.Visible = true;
                        }
                        else if (spentcheck("Teras Kasi Artist") == "master")
                        {
                            this.profIcon25.Image = global::SkillCalc.Properties.Resources.prof_points_experimentmax;
                            this.profIcon25.Visible = true;
                        }
                    }
                    break;
                case "Weaponsmith":
                    {
                        if (spentcheck("Weaponsmith") == "none")
                        {
                            this.profIcon26.Image = null;
                            this.profIcon26.Visible = false;
                        }
                        else if (spentcheck("Weaponsmith") == "novice")
                        {
                            this.profIcon26.Image = global::SkillCalc.Properties.Resources.prof_points_experimented;
                            this.profIcon26.Visible = true;
                        }
                        else if (spentcheck("Weaponsmith") == "master")
                        {
                            this.profIcon26.Image = global::SkillCalc.Properties.Resources.prof_points_experimentmax;
                            this.profIcon26.Visible = true;
                        }
                    }
                    break;
                case "Combat Prowess":
                    {
                        if (spentcheck("Combat Prowess") == "none")
                        {
                            this.profIcon2.Image = null;
                            this.profIcon2.Visible = false;
                        }
                        else if (spentcheck("Combat Prowess") == "novice")
                        {
                            this.profIcon2.Image = global::SkillCalc.Properties.Resources.prof_points_experimented;
                            this.profIcon2.Visible = true;
                        }
                        else if (spentcheck("Combat Prowess") == "master")
                        {
                            this.profIcon2.Image = global::SkillCalc.Properties.Resources.prof_points_experimentmax;
                            this.profIcon2.Visible = true;
                        }
                    }
                    break;
                case "Crafting Mastery":
                    {
                        if (spentcheck("Crafting Mastery") == "none")
                        {
                            this.profIcon3.Image = null;
                            this.profIcon3.Visible = false;
                        }
                        else if (spentcheck("Crafting Mastery") == "novice")
                        {
                            this.profIcon3.Image = global::SkillCalc.Properties.Resources.prof_points_experimented;
                            this.profIcon3.Visible = true;
                        }
                        else if (spentcheck("Crafting Mastery") == "master")
                        {
                            this.profIcon3.Image = global::SkillCalc.Properties.Resources.prof_points_experimentmax;
                            this.profIcon3.Visible = true;
                        }
                    }
                    break;
                case "Enhanced Reflexes":
                    {
                        if (spentcheck("Enhanced Reflexes") == "none")
                        {
                            this.profIcon4.Image = null;
                            this.profIcon4.Visible = false;
                        }
                        else if (spentcheck("Enhanced Reflexes") == "novice")
                        {
                            this.profIcon4.Image = global::SkillCalc.Properties.Resources.prof_points_experimented;
                            this.profIcon4.Visible = true;
                        }
                        else if (spentcheck("Enhanced Reflexes") == "master")
                        {
                            this.profIcon4.Image = global::SkillCalc.Properties.Resources.prof_points_experimentmax;
                            this.profIcon4.Visible = true;
                        }
                    }
                    break;
                case "Heightened Senses":
                    {
                        if (spentcheck("Heightened Senses") == "none")
                        {
                            this.profIcon5.Image = null;
                            this.profIcon5.Visible = false;
                        }
                        else if (spentcheck("Heightened Senses") == "novice")
                        {
                            this.profIcon5.Image = global::SkillCalc.Properties.Resources.prof_points_experimented;
                            this.profIcon5.Visible = true;
                        }
                        else if (spentcheck("Heightened Senses") == "master")
                        {
                            this.profIcon5.Image = global::SkillCalc.Properties.Resources.prof_points_experimentmax;
                            this.profIcon5.Visible = true;
                        }
                    }
                    break;
                case "Force Defense":
                    {
                        if (spentcheck("Force Defense") == "none")
                        {
                            this.profIcon8.Image = null;
                            this.profIcon8.Visible = false;
                        }
                        else if (spentcheck("Force Defense") == "novice")
                        {
                            this.profIcon8.Image = global::SkillCalc.Properties.Resources.prof_points_experimented;
                            this.profIcon8.Visible = true;
                        }
                        else if (spentcheck("Force Defense") == "master")
                        {
                            this.profIcon8.Image = global::SkillCalc.Properties.Resources.prof_points_experimentmax;
                            this.profIcon8.Visible = true;
                        }
                    }
                    break;
                case "Force Enhancement":
                    {
                        if (spentcheck("Force Enhancement") == "none")
                        {
                            this.profIcon9.Image = null;
                            this.profIcon9.Visible = false;
                        }
                        else if (spentcheck("Force Enhancement") == "novice")
                        {
                            this.profIcon9.Image = global::SkillCalc.Properties.Resources.prof_points_experimented;
                            this.profIcon9.Visible = true;
                        }
                        else if (spentcheck("Force Enhancement") == "master")
                        {
                            this.profIcon9.Image = global::SkillCalc.Properties.Resources.prof_points_experimentmax;
                            this.profIcon9.Visible = true;
                        }
                    }
                    break;
                case "Force Healing":
                    {
                        if (spentcheck("Force Healing") == "none")
                        {
                            this.profIcon10.Image = null;
                            this.profIcon10.Visible = false;
                        }
                        else if (spentcheck("Force Healing") == "novice")
                        {
                            this.profIcon10.Image = global::SkillCalc.Properties.Resources.prof_points_experimented;
                            this.profIcon10.Visible = true;
                        }
                        else if (spentcheck("Force Healing") == "master")
                        {
                            this.profIcon10.Image = global::SkillCalc.Properties.Resources.prof_points_experimentmax;
                            this.profIcon10.Visible = true;
                        }
                    }
                    break;
                case "Lightsaber":
                    {
                        if (spentcheck("Lightsaber") == "none")
                        {
                            this.profIcon11.Image = null;
                            this.profIcon11.Visible = false;
                        }
                        else if (spentcheck("Lightsaber") == "novice")
                        {
                            this.profIcon11.Image = global::SkillCalc.Properties.Resources.prof_points_experimented;
                            this.profIcon11.Visible = true;
                        }
                        else if (spentcheck("Lightsaber") == "master")
                        {
                            this.profIcon11.Image = global::SkillCalc.Properties.Resources.prof_points_experimentmax;
                            this.profIcon11.Visible = true;
                        }
                    }
                    break;
                case "Force Powers":
                    {
                        if (spentcheck("Force Powers") == "none")
                        {
                            this.profIcon12.Image = null;
                            this.profIcon12.Visible = false;
                        }
                        else if (spentcheck("Force Powers") == "novice")
                        {
                            this.profIcon12.Image = global::SkillCalc.Properties.Resources.prof_points_experimented;
                            this.profIcon12.Visible = true;
                        }
                        else if (spentcheck("Force Powers") == "master")
                        {
                            this.profIcon12.Image = global::SkillCalc.Properties.Resources.prof_points_experimentmax;
                            this.profIcon12.Visible = true;
                        }
                    }
                    break;
                case "Light Master":
                    {
                        if (spentcheck("Light Master") == "none")
                        {
                            this.profIcon1.Image = null;
                            this.profIcon1.Visible = false;
                        }
                        else if (spentcheck("Light Master") == "novice")
                        {
                            this.profIcon1.Image = global::SkillCalc.Properties.Resources.prof_points_experimented;
                            this.profIcon1.Visible = true;
                        }
                        else if (spentcheck("Light Master") == "master")
                        {
                            this.profIcon1.Image = global::SkillCalc.Properties.Resources.prof_points_experimentmax;
                            this.profIcon1.Visible = true;
                        }
                    }
                    break;
                case "Light Journeyman":
                    {
                        if (spentcheck("Light Journeyman") == "none")
                        {
                            this.profIcon2.Image = null;
                            this.profIcon2.Visible = false;
                        }
                        else if (spentcheck("Light Journeyman") == "novice")
                        {
                            this.profIcon2.Image = global::SkillCalc.Properties.Resources.prof_points_experimented;
                            this.profIcon2.Visible = true;
                        }
                        else if (spentcheck("Light Journeyman") == "master")
                        {
                            this.profIcon2.Image = global::SkillCalc.Properties.Resources.prof_points_experimentmax;
                            this.profIcon2.Visible = true;
                        }
                    }
                    break;
                case "Dark Master":
                    {
                        if (spentcheck("Dark Master") == "none")
                        {
                            this.profIcon3.Image = null;
                            this.profIcon3.Visible = false;
                        }
                        else if (spentcheck("Dark Master") == "novice")
                        {
                            this.profIcon3.Image = global::SkillCalc.Properties.Resources.prof_points_experimented;
                            this.profIcon3.Visible = true;
                        }
                        else if (spentcheck("Dark Master") == "master")
                        {
                            this.profIcon3.Image = global::SkillCalc.Properties.Resources.prof_points_experimentmax;
                            this.profIcon3.Visible = true;
                        }
                    }
                    break;
                case "Dark Journeyman":
                    {
                        if (spentcheck("Dark Journeyman") == "none")
                        {
                            this.profIcon4.Image = null;
                            this.profIcon4.Visible = false;
                        }
                        else if (spentcheck("Dark Journeyman") == "novice")
                        {
                            this.profIcon4.Image = global::SkillCalc.Properties.Resources.prof_points_experimented;
                            this.profIcon4.Visible = true;
                        }
                        else if (spentcheck("Dark Journeyman") == "master")
                        {
                            this.profIcon4.Image = global::SkillCalc.Properties.Resources.prof_points_experimentmax;
                            this.profIcon4.Visible = true;
                        }
                    }
                    break;
                case "Padawan":
                    {
                        if (spentcheck("Padawan") == "none")
                        {
                            this.profIcon5.Image = null;
                            this.profIcon5.Visible = false;
                        }
                        else if (spentcheck("Padawan") == "novice")
                        {
                            this.profIcon5.Image = global::SkillCalc.Properties.Resources.prof_points_experimented;
                            this.profIcon5.Visible = true;
                        }
                        else if (spentcheck("Padawan") == "master")
                        {
                            this.profIcon5.Image = global::SkillCalc.Properties.Resources.prof_points_experimentmax;
                            this.profIcon5.Visible = true;
                        }
                    }
                    break;
            }
        }

        // This handles being able to move the window around
        // since we don't have a standard windows border.
        // As well as the ability to close the window.
        private Point mouseOffset;
        private bool isMouseDown = false;
        private void Main_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            int xOffset;
            int yOffset;

            if (e.Button == MouseButtons.Left)
            {
                xOffset = -e.X - SystemInformation.FrameBorderSize.Width;
                yOffset = -e.Y - SystemInformation.CaptionHeight - SystemInformation.FrameBorderSize.Height;
                mouseOffset = new Point(xOffset, yOffset);
                isMouseDown = true;
            }
        }
        private void Main_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e) { if (e.Button == MouseButtons.Left) { isMouseDown = false; } }
        private void Main_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (isMouseDown)
            {
                Point mousePos = Control.MousePosition;
                mousePos.Offset(mouseOffset.X + 4, mouseOffset.Y + 23);
                Location = mousePos;
            }
        }
        private void close_Click(object sender, EventArgs e) { this.Close(); }
        // End mouse movement and close section.

        private void formReset()
        {
            defaultname();
            refreshnames();
            reset();
            calcpoints(this.charName.Text);
        }
        private void clearproftext()
        {
            this.selectProf01.Text = "";
            this.selectProf02.Text = "";
            this.selectProf03.Text = "";
            this.selectProf04.Text = "";
            this.selectProf05.Text = "";
            this.selectProf06.Text = "";
            this.selectProf07.Text = "";
            this.selectProf08.Text = "";
            this.selectProf09.Text = "";
            this.selectProf10.Text = "";
            this.selectProf11.Text = "";
            this.selectProf12.Text = "";
            this.selectProf13.Text = "";
            this.selectProf14.Text = "";
            this.selectProf15.Text = "";
            this.selectProf16.Text = "";
            this.selectProf17.Text = "";
            this.selectProf18.Text = "";
            this.selectProf19.Text = "";
            this.selectProf20.Text = "";
            this.selectProf21.Text = "";
            this.selectProf22.Text = "";
            this.selectProf23.Text = "";
            this.selectProf24.Text = "";
            this.selectProf25.Text = "";
            this.selectProf26.Text = "";
        }
        private void clearprofselect()
        {
            if (viewtab != "Force")
            {
                this.selectProf01.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.selectProf07.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            }
            this.selectProf01.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(244)))), ((int)(((byte)(252)))));
            this.selectProf07.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(244)))), ((int)(((byte)(252)))));
            this.selectProf01.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.selectProf02.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.selectProf07.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.selectProf01.Image = global::SkillCalc.Properties.Resources.professions_listunselect;
            this.selectProf02.Image = global::SkillCalc.Properties.Resources.professions_listunselect;
            this.selectProf03.Image = global::SkillCalc.Properties.Resources.professions_listunselect;
            this.selectProf04.Image = global::SkillCalc.Properties.Resources.professions_listunselect;
            this.selectProf05.Image = global::SkillCalc.Properties.Resources.professions_listunselect;
            this.selectProf06.Image = global::SkillCalc.Properties.Resources.professions_listunselect;
            this.selectProf07.Image = global::SkillCalc.Properties.Resources.professions_listunselect;
            this.selectProf08.Image = global::SkillCalc.Properties.Resources.professions_listunselect;
            this.selectProf09.Image = global::SkillCalc.Properties.Resources.professions_listunselect;
            this.selectProf10.Image = global::SkillCalc.Properties.Resources.professions_listunselect;
            this.selectProf11.Image = global::SkillCalc.Properties.Resources.professions_listunselect;
            this.selectProf12.Image = global::SkillCalc.Properties.Resources.professions_listunselect;
            this.selectProf13.Image = global::SkillCalc.Properties.Resources.professions_listunselect;
            this.selectProf14.Image = global::SkillCalc.Properties.Resources.professions_listunselect;
            this.selectProf15.Image = global::SkillCalc.Properties.Resources.professions_listunselect;
            this.selectProf16.Image = global::SkillCalc.Properties.Resources.professions_listunselect;
            this.selectProf17.Image = global::SkillCalc.Properties.Resources.professions_listunselect;
            this.selectProf18.Image = global::SkillCalc.Properties.Resources.professions_listunselect;
            this.selectProf19.Image = global::SkillCalc.Properties.Resources.professions_listunselect;
            this.selectProf20.Image = global::SkillCalc.Properties.Resources.professions_listunselect;
            this.selectProf21.Image = global::SkillCalc.Properties.Resources.professions_listunselect;
            this.selectProf22.Image = global::SkillCalc.Properties.Resources.professions_listunselect;
            this.selectProf23.Image = global::SkillCalc.Properties.Resources.professions_listunselect;
            this.selectProf24.Image = global::SkillCalc.Properties.Resources.professions_listunselect;
            this.selectProf25.Image = global::SkillCalc.Properties.Resources.professions_listunselect;
            this.selectProf26.Image = global::SkillCalc.Properties.Resources.professions_listunselect;
        }
        private void clearcursor()
        {
            this.selectProf01.Cursor = System.Windows.Forms.Cursors.Default;
            this.selectProf02.Cursor = System.Windows.Forms.Cursors.Default;
            this.selectProf03.Cursor = System.Windows.Forms.Cursors.Default;
            this.selectProf04.Cursor = System.Windows.Forms.Cursors.Default;
            this.selectProf05.Cursor = System.Windows.Forms.Cursors.Default;
            this.selectProf06.Cursor = System.Windows.Forms.Cursors.Default;
            this.selectProf07.Cursor = System.Windows.Forms.Cursors.Default;
            this.selectProf08.Cursor = System.Windows.Forms.Cursors.Default;
            this.selectProf09.Cursor = System.Windows.Forms.Cursors.Default;
            this.selectProf10.Cursor = System.Windows.Forms.Cursors.Default;
            this.selectProf11.Cursor = System.Windows.Forms.Cursors.Default;
            this.selectProf12.Cursor = System.Windows.Forms.Cursors.Default;
            this.selectProf13.Cursor = System.Windows.Forms.Cursors.Default;
            this.selectProf14.Cursor = System.Windows.Forms.Cursors.Default;
            this.selectProf15.Cursor = System.Windows.Forms.Cursors.Default;
            this.selectProf16.Cursor = System.Windows.Forms.Cursors.Default;
            this.selectProf17.Cursor = System.Windows.Forms.Cursors.Default;
            this.selectProf18.Cursor = System.Windows.Forms.Cursors.Default;
            this.selectProf19.Cursor = System.Windows.Forms.Cursors.Default;
            this.selectProf20.Cursor = System.Windows.Forms.Cursors.Default;
            this.selectProf21.Cursor = System.Windows.Forms.Cursors.Default;
            this.selectProf22.Cursor = System.Windows.Forms.Cursors.Default;
            this.selectProf23.Cursor = System.Windows.Forms.Cursors.Default;
            this.selectProf24.Cursor = System.Windows.Forms.Cursors.Default;
            this.selectProf25.Cursor = System.Windows.Forms.Cursors.Default;
            this.selectProf26.Cursor = System.Windows.Forms.Cursors.Default;
        }
        private void clearskills()
        {
            this.master1LeadsTo.Text = "";
            this.master2LeadsTo.Text = "";
            this.master3LeadsTo.Text = "";
            this.MasterCost.Text = "";
            this.labelMaster.Text = "";
            this.firstLeadsTo.Text = "";
            this.secondLeadsTo.Text = "";
            this.thirdLeadsTo.Text = "";
            this.fourthLeadsTo.Text = "";
            this.firstIVCost.Text = "";
            this.firstIIICost.Text = "";
            this.firstIICost.Text = "";
            this.firstICost.Text = "";
            this.labelfirstIV.Text = "";
            this.labelfirstIII.Text = "";
            this.labelfirstII.Text = "";
            this.labelfirstI.Text = "";
            this.secondIVCost.Text = "";
            this.secondIIICost.Text = "";
            this.secondIICost.Text = "";
            this.secondICost.Text = "";
            this.labelsecondIV.Text = "";
            this.labelsecondIII.Text = "";
            this.labelsecondII.Text = "";
            this.labelsecondI.Text = "";
            this.thirdIVCost.Text = "";
            this.thirdIIICost.Text = "";
            this.thirdIICost.Text = "";
            this.thirdICost.Text = "";
            this.labelthirdIV.Text = "";
            this.labelthirdIII.Text = "";
            this.labelthirdII.Text = "";
            this.labelthirdI.Text = "";
            this.fourthIVCost.Text = "";
            this.fourthIIICost.Text = "";
            this.fourthIICost.Text = "";
            this.fourthICost.Text = "";
            this.labelfourthIV.Text = "";
            this.labelfourthIII.Text = "";
            this.labelfourthII.Text = "";
            this.labelfourthI.Text = "";
            this.NoviceCost.Text = "";
            this.labelNovice.Text = "";
            this.novice1ComesFrom.Text = "";
            this.novice2ComesFrom.Text = "";
            this.novice3ComesFrom.Text = "";
        }
        private void cleartabs()
        {
            viewtab = "";
            selectedprof = "";
            this.charName.Image = global::SkillCalc.Properties.Resources.tabs_unselect;
            this.charSpecies.Image = global::SkillCalc.Properties.Resources.tabs_unselect;
            this.pageBasic.Image = global::SkillCalc.Properties.Resources.tabs_unselect;
            this.pageAdvanced.Image = global::SkillCalc.Properties.Resources.tabs_unselect;
            this.pageForce.Image = global::SkillCalc.Properties.Resources.tabs_unselect;
            this.pageJedi.Image = global::SkillCalc.Properties.Resources.tabs_unselect;
            this.charName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(244)))), ((int)(((byte)(255)))));
            this.charSpecies.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(244)))), ((int)(((byte)(255)))));
            this.pageBasic.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(244)))), ((int)(((byte)(255)))));
            this.pageAdvanced.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(244)))), ((int)(((byte)(255)))));
            this.pageForce.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(244)))), ((int)(((byte)(255)))));
            this.pageJedi.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(244)))), ((int)(((byte)(255)))));
            this.headerSpecies.Visible = false;
            this.headerCharacter.Visible = false;
            this.nameEntry.Visible = false;
            this.charSave.Visible = false;
            this.charDelete.Visible = false;
            updateDisplay();
        }
        private void clearclicked()
        {
            labelColors("noviceDefault");

            labelColors("labelfirstIDefault");
            labelColors("labelfirstIIDefault");
            labelColors("labelfirstIIIDefault");
            labelColors("labelfirstIVDefault");

            labelColors("labelsecondIDefault");
            labelColors("labelsecondIIDefault");
            labelColors("labelsecondIIIDefault");
            labelColors("labelsecondIVDefault");

            labelColors("labelthirdIDefault");
            labelColors("labelthirdIIDefault");
            labelColors("labelthirdIIIDefault");
            labelColors("labelthirdIVDefault");

            labelColors("labelfourthIDefault");
            labelColors("labelfourthIIDefault");
            labelColors("labelfourthIIIDefault");
            labelColors("labelfourthIVDefault");

            labelColors("labelMasterDefault");
        }
        private void clearpointsicon()
        {
            this.profIcon1.Visible = false;
            this.profIcon2.Visible = false;
            this.profIcon3.Visible = false;
            this.profIcon4.Visible = false;
            this.profIcon5.Visible = false;
            this.profIcon6.Visible = false;
            this.profIcon7.Visible = false;
            this.profIcon8.Visible = false;
            this.profIcon9.Visible = false;
            this.profIcon10.Visible = false;
            this.profIcon11.Visible = false;
            this.profIcon12.Visible = false;
            this.profIcon13.Visible = false;
            this.profIcon14.Visible = false;
            this.profIcon15.Visible = false;
            this.profIcon16.Visible = false;
            this.profIcon17.Visible = false;
            this.profIcon18.Visible = false;
            this.profIcon19.Visible = false;
            this.profIcon20.Visible = false;
            this.profIcon21.Visible = false;
            this.profIcon22.Visible = false;
            this.profIcon23.Visible = false;
            this.profIcon24.Visible = false;
            this.profIcon25.Visible = false;
            this.profIcon26.Visible = false;
        }
        private void clearselectednamescroll()
        {
            if (namescroll1.Text != "")
            {
                this.namescroll1.Image = global::SkillCalc.Properties.Resources.header_tabs_unselect;
                this.namescroll1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(244)))), ((int)(((byte)(255)))));
            }
            if (namescroll2.Text != "")
            {
                this.namescroll2.Image = global::SkillCalc.Properties.Resources.header_tabs_unselect;
                this.namescroll2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(244)))), ((int)(((byte)(255)))));
            }
            if (namescroll3.Text != "")
            {
                this.namescroll3.Image = global::SkillCalc.Properties.Resources.header_tabs_unselect;
                this.namescroll3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(244)))), ((int)(((byte)(255)))));
            }
            if (namescroll4.Text != "")
            {
                this.namescroll4.Image = global::SkillCalc.Properties.Resources.header_tabs_unselect;
                this.namescroll4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(244)))), ((int)(((byte)(255)))));
            }
            if (namescroll5.Text != "")
            {
                this.namescroll5.Image = global::SkillCalc.Properties.Resources.header_tabs_unselect;
                this.namescroll5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(244)))), ((int)(((byte)(255)))));
            }
            if (namescroll6.Text != "")
            {
                this.namescroll6.Image = global::SkillCalc.Properties.Resources.header_tabs_unselect;
                this.namescroll6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(244)))), ((int)(((byte)(255)))));
            }
            if (namescroll7.Text != "")
            {
                this.namescroll7.Image = global::SkillCalc.Properties.Resources.header_tabs_unselect;
                this.namescroll7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(244)))), ((int)(((byte)(255)))));
            }
            if (namescroll8.Text != "")
            {
                this.namescroll8.Image = global::SkillCalc.Properties.Resources.header_tabs_unselect;
                this.namescroll8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(244)))), ((int)(((byte)(255)))));
            }
        }
        private void clearnamescroll()
        {
            this.leftArrow.Image = global::SkillCalc.Properties.Resources.left_shaded;
            if (namelist.Count >= 9) { this.rightArrow.Image = global::SkillCalc.Properties.Resources.right; }
            else { this.rightArrow.Image = global::SkillCalc.Properties.Resources.right_shaded; }
            this.namescroll1.Text = "";
            this.namescroll2.Text = "";
            this.namescroll3.Text = "";
            this.namescroll4.Text = "";
            this.namescroll5.Text = "";
            this.namescroll6.Text = "";
            this.namescroll7.Text = "";
            this.namescroll8.Text = "";
            this.namescroll1.Image = global::SkillCalc.Properties.Resources.header_tabs_blank;
            this.namescroll2.Image = global::SkillCalc.Properties.Resources.header_tabs_blank;
            this.namescroll3.Image = global::SkillCalc.Properties.Resources.header_tabs_blank;
            this.namescroll4.Image = global::SkillCalc.Properties.Resources.header_tabs_blank;
            this.namescroll5.Image = global::SkillCalc.Properties.Resources.header_tabs_blank;
            this.namescroll6.Image = global::SkillCalc.Properties.Resources.header_tabs_blank;
            this.namescroll7.Image = global::SkillCalc.Properties.Resources.header_tabs_blank;
            this.namescroll8.Image = global::SkillCalc.Properties.Resources.header_tabs_blank;
            this.namescroll1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(244)))), ((int)(((byte)(255)))));
            this.namescroll2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(244)))), ((int)(((byte)(255)))));
            this.namescroll3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(244)))), ((int)(((byte)(255)))));
            this.namescroll4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(244)))), ((int)(((byte)(255)))));
            this.namescroll5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(244)))), ((int)(((byte)(255)))));
            this.namescroll6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(244)))), ((int)(((byte)(255)))));
            this.namescroll7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(244)))), ((int)(((byte)(255)))));
            this.namescroll8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(244)))), ((int)(((byte)(255)))));
        }

        // Profession main category button handlers.
        private void displayMenu(string catagory)
        {
            clearskills();
            clearprofselect();
            clearproftext();
            clearcursor();

            int profNumBegin;
            int profNumEnd;

            switch (catagory)
            {
                case "Basic":
                    {
                        profNumEnd = 6;
                        var profnames = new List<string>();
                        for (profNumBegin = 0; profNumBegin <= profNumEnd; profNumBegin++) { profnames.Add(professions[profNumBegin]); }
                        foreach (string profname in profnames) { displayIcons(profname); }

                        this.selectProf01.Text = "".PadLeft(4) + profnames[0];
                        this.selectProf02.Text = "".PadLeft(4) + profnames[1];
                        this.selectProf03.Text = "".PadLeft(4) + profnames[2];
                        this.selectProf04.Text = "".PadLeft(4) + profnames[3];
                        this.selectProf05.Text = "".PadLeft(4) + profnames[4];
                        this.selectProf06.Text = "".PadLeft(4) + profnames[5];
                        this.selectProf07.Text = "".PadLeft(4) + profnames[6];
                        this.selectProf01.Cursor = System.Windows.Forms.Cursors.Hand;
                        this.selectProf02.Cursor = System.Windows.Forms.Cursors.Hand;
                        this.selectProf03.Cursor = System.Windows.Forms.Cursors.Hand;
                        this.selectProf04.Cursor = System.Windows.Forms.Cursors.Hand;
                        this.selectProf05.Cursor = System.Windows.Forms.Cursors.Hand;
                        this.selectProf06.Cursor = System.Windows.Forms.Cursors.Hand;
                        this.selectProf07.Cursor = System.Windows.Forms.Cursors.Hand;
                    }
                    break;
                case "Advanced":
                    {
                        profNumEnd = 32;
                        var profnames = new List<string>();
                        for (profNumBegin = 7; profNumBegin <= profNumEnd; profNumBegin++) { profnames.Add(professions[profNumBegin]); }
                        foreach (string profname in profnames) { displayIcons(profname); }

                        this.selectProf01.Text = "".PadLeft(4) + profnames[0];
                        this.selectProf02.Text = "".PadLeft(4) + profnames[1];
                        this.selectProf03.Text = "".PadLeft(4) + profnames[2];
                        this.selectProf04.Text = "".PadLeft(4) + profnames[3];
                        this.selectProf05.Text = "".PadLeft(4) + profnames[4];
                        this.selectProf06.Text = "".PadLeft(4) + profnames[5];
                        this.selectProf07.Text = "".PadLeft(4) + profnames[6];
                        this.selectProf08.Text = "".PadLeft(4) + profnames[7];
                        this.selectProf09.Text = "".PadLeft(4) + profnames[8];
                        this.selectProf10.Text = "".PadLeft(4) + profnames[9];
                        this.selectProf11.Text = "".PadLeft(4) + profnames[10];
                        this.selectProf12.Text = "".PadLeft(4) + profnames[11];
                        this.selectProf13.Text = "".PadLeft(4) + profnames[12];
                        this.selectProf14.Text = "".PadLeft(4) + profnames[13];
                        this.selectProf15.Text = "".PadLeft(4) + profnames[14];
                        this.selectProf16.Text = "".PadLeft(4) + profnames[15];
                        this.selectProf17.Text = "".PadLeft(4) + profnames[16];
                        this.selectProf18.Text = "".PadLeft(4) + profnames[17];
                        this.selectProf19.Text = "".PadLeft(4) + profnames[18];
                        this.selectProf20.Text = "".PadLeft(4) + profnames[19];
                        this.selectProf21.Text = "".PadLeft(4) + profnames[20];
                        this.selectProf22.Text = "".PadLeft(4) + profnames[21];
                        this.selectProf23.Text = "".PadLeft(4) + profnames[22];
                        this.selectProf24.Text = "".PadLeft(4) + profnames[23];
                        this.selectProf25.Text = "".PadLeft(4) + profnames[24];
                        this.selectProf26.Text = "".PadLeft(4) + profnames[25];
                        this.selectProf01.Cursor = System.Windows.Forms.Cursors.Hand;
                        this.selectProf02.Cursor = System.Windows.Forms.Cursors.Hand;
                        this.selectProf03.Cursor = System.Windows.Forms.Cursors.Hand;
                        this.selectProf04.Cursor = System.Windows.Forms.Cursors.Hand;
                        this.selectProf05.Cursor = System.Windows.Forms.Cursors.Hand;
                        this.selectProf06.Cursor = System.Windows.Forms.Cursors.Hand;
                        this.selectProf07.Cursor = System.Windows.Forms.Cursors.Hand;
                        this.selectProf08.Cursor = System.Windows.Forms.Cursors.Hand;
                        this.selectProf09.Cursor = System.Windows.Forms.Cursors.Hand;
                        this.selectProf10.Cursor = System.Windows.Forms.Cursors.Hand;
                        this.selectProf11.Cursor = System.Windows.Forms.Cursors.Hand;
                        this.selectProf12.Cursor = System.Windows.Forms.Cursors.Hand;
                        this.selectProf13.Cursor = System.Windows.Forms.Cursors.Hand;
                        this.selectProf14.Cursor = System.Windows.Forms.Cursors.Hand;
                        this.selectProf15.Cursor = System.Windows.Forms.Cursors.Hand;
                        this.selectProf16.Cursor = System.Windows.Forms.Cursors.Hand;
                        this.selectProf17.Cursor = System.Windows.Forms.Cursors.Hand;
                        this.selectProf18.Cursor = System.Windows.Forms.Cursors.Hand;
                        this.selectProf19.Cursor = System.Windows.Forms.Cursors.Hand;
                        this.selectProf20.Cursor = System.Windows.Forms.Cursors.Hand;
                        this.selectProf21.Cursor = System.Windows.Forms.Cursors.Hand;
                        this.selectProf22.Cursor = System.Windows.Forms.Cursors.Hand;
                        this.selectProf23.Cursor = System.Windows.Forms.Cursors.Hand;
                        this.selectProf24.Cursor = System.Windows.Forms.Cursors.Hand;
                        this.selectProf25.Cursor = System.Windows.Forms.Cursors.Hand;
                        this.selectProf26.Cursor = System.Windows.Forms.Cursors.Hand;
                    }
                    break;
                case "Force":
                    {
                        profNumEnd = 41;
                        var profnames = new List<string>();
                        for (profNumBegin = 33; profNumBegin <= profNumEnd; profNumBegin++) { profnames.Add(professions[profNumBegin]); }
                        foreach (string profname in profnames) { displayIcons(profname); }

                        this.selectProf01.Text = "".PadLeft(4) + profnames[0];
                        this.selectProf02.Text = "".PadLeft(4) + profnames[1];
                        this.selectProf03.Text = "".PadLeft(4) + profnames[2];
                        this.selectProf04.Text = "".PadLeft(4) + profnames[3];
                        this.selectProf05.Text = "".PadLeft(4) + profnames[4];
                        this.selectProf06.Text = "".PadLeft(4) + profnames[5];
                        this.selectProf07.Text = "".PadLeft(4) + profnames[6];

                        this.selectProf01.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                        this.selectProf07.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                        this.selectProf01.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
                        this.selectProf07.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
                        this.selectProf01.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                        this.selectProf07.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                        this.selectProf01.Text = "Force Sensitive".PadLeft(4).PadRight(4);
                        this.selectProf02.Text = "".PadLeft(4) + profnames[0];
                        this.selectProf03.Text = "".PadLeft(4) + profnames[1];
                        this.selectProf04.Text = "".PadLeft(4) + profnames[2];
                        this.selectProf05.Text = "".PadLeft(4) + profnames[3];
                        this.selectProf06.Text = "";
                        this.selectProf07.Text = "Force Discipline".PadLeft(4).PadRight(4);
                        this.selectProf08.Text = "".PadLeft(4) + profnames[4];
                        this.selectProf09.Text = "".PadLeft(4) + profnames[5];
                        this.selectProf10.Text = "".PadLeft(4) + profnames[6];
                        this.selectProf11.Text = "".PadLeft(4) + profnames[7];
                        this.selectProf12.Text = "".PadLeft(4) + profnames[8];
                        this.selectProf01.Cursor = System.Windows.Forms.Cursors.Default;
                        this.selectProf02.Cursor = System.Windows.Forms.Cursors.Hand;
                        this.selectProf03.Cursor = System.Windows.Forms.Cursors.Hand;
                        this.selectProf04.Cursor = System.Windows.Forms.Cursors.Hand;
                        this.selectProf05.Cursor = System.Windows.Forms.Cursors.Hand;
                        this.selectProf06.Cursor = System.Windows.Forms.Cursors.Default;
                        this.selectProf07.Cursor = System.Windows.Forms.Cursors.Default;
                        this.selectProf08.Cursor = System.Windows.Forms.Cursors.Hand;
                        this.selectProf09.Cursor = System.Windows.Forms.Cursors.Hand;
                        this.selectProf10.Cursor = System.Windows.Forms.Cursors.Hand;
                        this.selectProf11.Cursor = System.Windows.Forms.Cursors.Hand;
                        this.selectProf12.Cursor = System.Windows.Forms.Cursors.Hand;
                    }
                    break;
                case "Jedi":
                    {
                        profNumEnd = 46;
                        var profnames = new List<string>();
                        for (profNumBegin = 42; profNumBegin <= profNumEnd; profNumBegin++) { profnames.Add(professions[profNumBegin]); }
                        refreshIcons("Jedi");

                        this.selectProf01.Text = "".PadLeft(4) + profnames[1];
                        this.selectProf02.Text = "".PadLeft(4) + profnames[2];
                        this.selectProf03.Text = "".PadLeft(4) + profnames[3];
                        this.selectProf04.Text = "".PadLeft(4) + profnames[4];
                        this.selectProf05.Text = "".PadLeft(4) + profnames[0];
                        this.selectProf01.Cursor = System.Windows.Forms.Cursors.Hand;
                        this.selectProf02.Cursor = System.Windows.Forms.Cursors.Hand;
                        this.selectProf03.Cursor = System.Windows.Forms.Cursors.Hand;
                        this.selectProf04.Cursor = System.Windows.Forms.Cursors.Hand;
                        this.selectProf05.Cursor = System.Windows.Forms.Cursors.Hand;
                    }
                    break;
            }

        }
        private void displaycharacter()
        {
            this.selectProf01.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.selectProf02.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.selectProf01.Text = "Enter character name";
            this.selectProf02.Text = "below to save.";
            this.charSave.Visible = true;
            this.charDelete.Visible = true;
            clearcursor();
            loadnames();
            displaynamesmenu();
            calcpoints(this.charName.Text);
            this.nameEntry.Visible = true;
        }
        private void displaynamesmenu()
        {
            if (namelist.Count >= 1)
            {
                this.selectProf07.Text = namelist[0];
                this.selectProf07.Cursor = System.Windows.Forms.Cursors.Hand;
            }
            if (namelist.Count >= 2)
            {
                this.selectProf08.Text = namelist[1];
                this.selectProf08.Cursor = System.Windows.Forms.Cursors.Hand;
            }
            if (namelist.Count >= 3)
            {
                this.selectProf09.Text = namelist[2];
                this.selectProf09.Cursor = System.Windows.Forms.Cursors.Hand;
            }
            if (namelist.Count >= 4)
            {
                this.selectProf10.Text = namelist[3];
                this.selectProf10.Cursor = System.Windows.Forms.Cursors.Hand;
            }
            if (namelist.Count >= 5)
            {
                this.selectProf11.Text = namelist[4];
                this.selectProf11.Cursor = System.Windows.Forms.Cursors.Hand;
            }
            if (namelist.Count >= 6)
            {
                this.selectProf12.Text = namelist[5];
                this.selectProf12.Cursor = System.Windows.Forms.Cursors.Hand;
            }
            if (namelist.Count >= 7)
            {
                this.selectProf13.Text = namelist[6];
                this.selectProf13.Cursor = System.Windows.Forms.Cursors.Hand;
            }
            if (namelist.Count >= 8)
            {
                this.selectProf14.Text = namelist[7];
                this.selectProf14.Cursor = System.Windows.Forms.Cursors.Hand;
            }
            if (namelist.Count >= 9)
            {
                this.selectProf15.Text = namelist[8];
                this.selectProf15.Cursor = System.Windows.Forms.Cursors.Hand;
            }
            if (namelist.Count >= 10)
            {
                this.selectProf16.Text = namelist[9];
                this.selectProf16.Cursor = System.Windows.Forms.Cursors.Hand;
            }
            if (namelist.Count >= 11)
            {
                this.selectProf17.Text = namelist[10];
                this.selectProf17.Cursor = System.Windows.Forms.Cursors.Hand;
            }
            if (namelist.Count >= 12)
            {
                this.selectProf18.Text = namelist[11];
                this.selectProf18.Cursor = System.Windows.Forms.Cursors.Hand;
            }
            if (namelist.Count >= 13)
            {
                this.selectProf19.Text = namelist[12];
                this.selectProf19.Cursor = System.Windows.Forms.Cursors.Hand;
            }
            if (namelist.Count >= 14)
            {
                this.selectProf20.Text = namelist[13];
                this.selectProf20.Cursor = System.Windows.Forms.Cursors.Hand;
            }
            if (namelist.Count >= 15)
            {
                this.selectProf21.Text = namelist[14];
                this.selectProf21.Cursor = System.Windows.Forms.Cursors.Hand;
            }
            if (namelist.Count >= 16)
            {
                this.selectProf22.Text = namelist[15];
                this.selectProf22.Cursor = System.Windows.Forms.Cursors.Hand;
            }
            if (namelist.Count >= 17)
            {
                this.selectProf23.Text = namelist[16];
                this.selectProf23.Cursor = System.Windows.Forms.Cursors.Hand;
            }
            if (namelist.Count >= 18)
            {
                this.selectProf24.Text = namelist[17];
                this.selectProf24.Cursor = System.Windows.Forms.Cursors.Hand;
            }
            if (namelist.Count >= 19)
            {
                this.selectProf25.Text = namelist[18];
                this.selectProf25.Cursor = System.Windows.Forms.Cursors.Hand;
            }
            if (namelist.Count >= 20)
            {
                this.selectProf26.Text = namelist[19];
                this.selectProf26.Cursor = System.Windows.Forms.Cursors.Hand;
            }
        }
        private void advanced()
        {
            cleartabs();
            viewtab = "Advanced";
            this.pageAdvanced.Image = global::SkillCalc.Properties.Resources.tabs_selected;
            this.pageAdvanced.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(63)))), ((int)(((byte)(75)))));
            clearclicked();
            clearpointsicon();
            displayMenu(viewtab);
        }
        private void namescroll(int position)
        {
            loadnames();
            switch (position)
            {
                case 0:
                    {
                        scroll = 0;
                        this.leftArrow.Image = global::SkillCalc.Properties.Resources.left_shaded;
                        if (namelist.Count < 1)
                        {
                            this.namescroll1.Text = "";
                            this.namescroll2.Text = "";
                            this.namescroll3.Text = "";
                            this.namescroll4.Text = "";
                            this.namescroll5.Text = "";
                            this.namescroll6.Text = "";
                            this.namescroll7.Text = "";
                            this.namescroll8.Text = "";
                            this.namescroll1.Image = global::SkillCalc.Properties.Resources.header_tabs_blank;
                            this.namescroll2.Image = global::SkillCalc.Properties.Resources.header_tabs_blank;
                            this.namescroll3.Image = global::SkillCalc.Properties.Resources.header_tabs_blank;
                            this.namescroll4.Image = global::SkillCalc.Properties.Resources.header_tabs_blank;
                            this.namescroll5.Image = global::SkillCalc.Properties.Resources.header_tabs_blank;
                            this.namescroll6.Image = global::SkillCalc.Properties.Resources.header_tabs_blank;
                            this.namescroll7.Image = global::SkillCalc.Properties.Resources.header_tabs_blank;
                            this.namescroll8.Image = global::SkillCalc.Properties.Resources.header_tabs_blank;
                        }
                        if (namelist.Count < 2)
                        {
                            this.namescroll2.Text = "";
                            this.namescroll3.Text = "";
                            this.namescroll4.Text = "";
                            this.namescroll5.Text = "";
                            this.namescroll6.Text = "";
                            this.namescroll7.Text = "";
                            this.namescroll8.Text = "";
                            this.namescroll2.Image = global::SkillCalc.Properties.Resources.header_tabs_blank;
                            this.namescroll3.Image = global::SkillCalc.Properties.Resources.header_tabs_blank;
                            this.namescroll4.Image = global::SkillCalc.Properties.Resources.header_tabs_blank;
                            this.namescroll5.Image = global::SkillCalc.Properties.Resources.header_tabs_blank;
                            this.namescroll6.Image = global::SkillCalc.Properties.Resources.header_tabs_blank;
                            this.namescroll7.Image = global::SkillCalc.Properties.Resources.header_tabs_blank;
                            this.namescroll8.Image = global::SkillCalc.Properties.Resources.header_tabs_blank;
                        }
                        if (namelist.Count < 3)
                        {
                            this.namescroll3.Text = "";
                            this.namescroll4.Text = "";
                            this.namescroll5.Text = "";
                            this.namescroll6.Text = "";
                            this.namescroll7.Text = "";
                            this.namescroll8.Text = "";
                            this.namescroll3.Image = global::SkillCalc.Properties.Resources.header_tabs_blank;
                            this.namescroll4.Image = global::SkillCalc.Properties.Resources.header_tabs_blank;
                            this.namescroll5.Image = global::SkillCalc.Properties.Resources.header_tabs_blank;
                            this.namescroll6.Image = global::SkillCalc.Properties.Resources.header_tabs_blank;
                            this.namescroll7.Image = global::SkillCalc.Properties.Resources.header_tabs_blank;
                            this.namescroll8.Image = global::SkillCalc.Properties.Resources.header_tabs_blank;
                        }
                        if (namelist.Count < 4)
                        {
                            this.namescroll4.Text = "";
                            this.namescroll5.Text = "";
                            this.namescroll6.Text = "";
                            this.namescroll7.Text = "";
                            this.namescroll8.Text = "";
                            this.namescroll4.Image = global::SkillCalc.Properties.Resources.header_tabs_blank;
                            this.namescroll5.Image = global::SkillCalc.Properties.Resources.header_tabs_blank;
                            this.namescroll6.Image = global::SkillCalc.Properties.Resources.header_tabs_blank;
                            this.namescroll7.Image = global::SkillCalc.Properties.Resources.header_tabs_blank;
                            this.namescroll8.Image = global::SkillCalc.Properties.Resources.header_tabs_blank;
                        }
                        if (namelist.Count < 5)
                        {
                            this.namescroll5.Text = "";
                            this.namescroll6.Text = "";
                            this.namescroll7.Text = "";
                            this.namescroll8.Text = "";
                            this.namescroll5.Image = global::SkillCalc.Properties.Resources.header_tabs_blank;
                            this.namescroll6.Image = global::SkillCalc.Properties.Resources.header_tabs_blank;
                            this.namescroll7.Image = global::SkillCalc.Properties.Resources.header_tabs_blank;
                            this.namescroll8.Image = global::SkillCalc.Properties.Resources.header_tabs_blank;
                        }
                        if (namelist.Count < 6)
                        {
                            this.namescroll6.Text = "";
                            this.namescroll7.Text = "";
                            this.namescroll8.Text = "";
                            this.namescroll6.Image = global::SkillCalc.Properties.Resources.header_tabs_blank;
                            this.namescroll7.Image = global::SkillCalc.Properties.Resources.header_tabs_blank;
                            this.namescroll8.Image = global::SkillCalc.Properties.Resources.header_tabs_blank;
                        }
                        if (namelist.Count < 7)
                        {
                            this.namescroll7.Text = "";
                            this.namescroll8.Text = "";
                            this.namescroll7.Image = global::SkillCalc.Properties.Resources.header_tabs_blank;
                            this.namescroll8.Image = global::SkillCalc.Properties.Resources.header_tabs_blank;
                        }
                        if (namelist.Count < 7)
                        {
                            this.namescroll8.Text = "";
                            this.namescroll8.Image = global::SkillCalc.Properties.Resources.header_tabs_blank;
                        }
                        if (namelist.Count >= 1)
                        {
                            this.namescroll1.Text = namelist[0];
                            this.namescroll1.Image = global::SkillCalc.Properties.Resources.header_tabs_unselect;
                            this.namescroll1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(244)))), ((int)(((byte)(255)))));
                        }
                        if (namelist.Count >= 2)
                        {
                            this.namescroll2.Text = namelist[1];
                            this.namescroll2.Image = global::SkillCalc.Properties.Resources.header_tabs_unselect;
                            this.namescroll2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(244)))), ((int)(((byte)(255)))));
                        }
                        if (namelist.Count >= 3)
                        {
                            this.namescroll3.Text = namelist[2];
                            this.namescroll3.Image = global::SkillCalc.Properties.Resources.header_tabs_unselect;
                            this.namescroll3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(244)))), ((int)(((byte)(255)))));
                        }
                        if (namelist.Count >= 4)
                        {
                            this.namescroll4.Text = namelist[3];
                            this.namescroll4.Image = global::SkillCalc.Properties.Resources.header_tabs_unselect;
                            this.namescroll4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(244)))), ((int)(((byte)(255)))));
                        }
                        if (namelist.Count >= 5)
                        {
                            this.namescroll5.Text = namelist[4];
                            this.namescroll5.Image = global::SkillCalc.Properties.Resources.header_tabs_unselect;
                            this.namescroll5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(244)))), ((int)(((byte)(255)))));
                        }
                        if (namelist.Count >= 6)
                        {
                            this.namescroll6.Text = namelist[5];
                            this.namescroll6.Image = global::SkillCalc.Properties.Resources.header_tabs_unselect;
                            this.namescroll6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(244)))), ((int)(((byte)(255)))));
                        }
                        if (namelist.Count >= 7)
                        {
                            this.namescroll7.Text = namelist[6];
                            this.namescroll7.Image = global::SkillCalc.Properties.Resources.header_tabs_unselect;
                            this.namescroll7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(244)))), ((int)(((byte)(255)))));
                        }
                        if (namelist.Count >= 8)
                        {
                            this.namescroll8.Text = namelist[7];
                            this.namescroll8.Image = global::SkillCalc.Properties.Resources.header_tabs_unselect;
                            this.namescroll8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(244)))), ((int)(((byte)(255)))));
                        }
                        if (namelist.Count >= 9)
                        {
                            this.rightArrow.Image = global::SkillCalc.Properties.Resources.right;
                        }
                        if (namelist.Count < 9)
                        {
                            this.rightArrow.Image = global::SkillCalc.Properties.Resources.right_shaded;
                        }
                    }
                    break;
                case 1:
                    {
                        if (namelist.Count <= 8) { scroll = 0; goto case 0; }
                        else if (namelist.Count >= 9)
                        {
                            scroll = 1;
                            this.leftArrow.Image = global::SkillCalc.Properties.Resources.left;
                            if (namelist.Count >= 2)
                            {
                                this.namescroll1.Text = namelist[1];
                                this.namescroll1.Image = global::SkillCalc.Properties.Resources.header_tabs_unselect;
                            }
                            if (namelist.Count >= 3)
                            {
                                this.namescroll2.Text = namelist[2];
                                this.namescroll2.Image = global::SkillCalc.Properties.Resources.header_tabs_unselect;
                            }
                            if (namelist.Count >= 4)
                            {
                                this.namescroll3.Text = namelist[3];
                                this.namescroll3.Image = global::SkillCalc.Properties.Resources.header_tabs_unselect;
                            }
                            if (namelist.Count >= 5)
                            {
                                this.namescroll4.Text = namelist[4];
                                this.namescroll4.Image = global::SkillCalc.Properties.Resources.header_tabs_unselect;
                            }
                            if (namelist.Count >= 6)
                            {
                                this.namescroll5.Text = namelist[5];
                                this.namescroll5.Image = global::SkillCalc.Properties.Resources.header_tabs_unselect;
                            }
                            if (namelist.Count >= 7)
                            {
                                this.namescroll6.Text = namelist[6];
                                this.namescroll6.Image = global::SkillCalc.Properties.Resources.header_tabs_unselect;
                            }
                            if (namelist.Count >= 8)
                            {
                                this.namescroll7.Text = namelist[7];
                                this.namescroll7.Image = global::SkillCalc.Properties.Resources.header_tabs_unselect;
                            }
                            if (namelist.Count >= 9)
                            {
                                this.namescroll8.Text = namelist[8];
                                this.namescroll8.Image = global::SkillCalc.Properties.Resources.header_tabs_unselect;
                            }
                            if (namelist.Count >= 10)
                            {
                                this.rightArrow.Image = global::SkillCalc.Properties.Resources.right;
                            }
                            if (namelist.Count < 10)
                            {
                                this.rightArrow.Image = global::SkillCalc.Properties.Resources.right_shaded;
                            }
                        }
                        else { scroll = 0; goto case 0; }
                    }
                    break;
                case 2:
                    {
                        if (namelist.Count <= 9) { scroll--; goto case 1; }
                        else if (namelist.Count >= 10)
                        {
                            scroll = 2;
                            this.leftArrow.Image = global::SkillCalc.Properties.Resources.left;
                            if (namelist.Count >= 3)
                            {
                                this.namescroll1.Text = namelist[2];
                                this.namescroll1.Image = global::SkillCalc.Properties.Resources.header_tabs_unselect;
                            }
                            if (namelist.Count >= 4)
                            {
                                this.namescroll2.Text = namelist[3];
                                this.namescroll2.Image = global::SkillCalc.Properties.Resources.header_tabs_unselect;
                            }
                            if (namelist.Count >= 5)
                            {
                                this.namescroll3.Text = namelist[4];
                                this.namescroll3.Image = global::SkillCalc.Properties.Resources.header_tabs_unselect;
                            }
                            if (namelist.Count >= 6)
                            {
                                this.namescroll4.Text = namelist[5];
                                this.namescroll4.Image = global::SkillCalc.Properties.Resources.header_tabs_unselect;
                            }
                            if (namelist.Count >= 7)
                            {
                                this.namescroll5.Text = namelist[6];
                                this.namescroll5.Image = global::SkillCalc.Properties.Resources.header_tabs_unselect;
                            }
                            if (namelist.Count >= 8)
                            {
                                this.namescroll6.Text = namelist[7];
                                this.namescroll6.Image = global::SkillCalc.Properties.Resources.header_tabs_unselect;
                            }
                            if (namelist.Count >= 9)
                            {
                                this.namescroll7.Text = namelist[8];
                                this.namescroll7.Image = global::SkillCalc.Properties.Resources.header_tabs_unselect;
                            }
                            if (namelist.Count >= 10)
                            {
                                this.namescroll8.Text = namelist[9];
                                this.namescroll8.Image = global::SkillCalc.Properties.Resources.header_tabs_unselect;
                            }
                            if (namelist.Count >= 11)
                            {
                                this.rightArrow.Image = global::SkillCalc.Properties.Resources.right;
                            }
                            if (namelist.Count < 11)
                            {
                                this.rightArrow.Image = global::SkillCalc.Properties.Resources.right_shaded;
                            }
                        }
                        else { scroll = 0; goto case 0; }
                    }
                    break;
                case 3:
                    {
                        if (namelist.Count <= 10) { scroll--; goto case 2; }
                        else if (namelist.Count >= 11)
                        {
                            scroll = 3;
                            this.leftArrow.Image = global::SkillCalc.Properties.Resources.left;
                            if (namelist.Count >= 4)
                            {
                                this.namescroll1.Text = namelist[3];
                                this.namescroll1.Image = global::SkillCalc.Properties.Resources.header_tabs_unselect;
                            }
                            if (namelist.Count >= 5)
                            {
                                this.namescroll2.Text = namelist[4];
                                this.namescroll2.Image = global::SkillCalc.Properties.Resources.header_tabs_unselect;
                            }
                            if (namelist.Count >= 6)
                            {
                                this.namescroll3.Text = namelist[5];
                                this.namescroll3.Image = global::SkillCalc.Properties.Resources.header_tabs_unselect;
                            }
                            if (namelist.Count >= 7)
                            {
                                this.namescroll4.Text = namelist[6];
                                this.namescroll4.Image = global::SkillCalc.Properties.Resources.header_tabs_unselect;
                            }
                            if (namelist.Count >= 8)
                            {
                                this.namescroll5.Text = namelist[7];
                                this.namescroll5.Image = global::SkillCalc.Properties.Resources.header_tabs_unselect;
                            }
                            if (namelist.Count >= 9)
                            {
                                this.namescroll6.Text = namelist[8];
                                this.namescroll6.Image = global::SkillCalc.Properties.Resources.header_tabs_unselect;
                            }
                            if (namelist.Count >= 10)
                            {
                                this.namescroll7.Text = namelist[9];
                                this.namescroll7.Image = global::SkillCalc.Properties.Resources.header_tabs_unselect;
                            }
                            if (namelist.Count >= 11)
                            {
                                this.namescroll8.Text = namelist[10];
                                this.namescroll8.Image = global::SkillCalc.Properties.Resources.header_tabs_unselect;
                            }
                            if (namelist.Count >= 12)
                            {
                                this.rightArrow.Image = global::SkillCalc.Properties.Resources.right;
                            }
                            if (namelist.Count < 12)
                            {
                                this.rightArrow.Image = global::SkillCalc.Properties.Resources.right_shaded;
                            }
                        }
                        else { scroll = 0; goto case 0; }
                    }
                    break;
                case 4:
                    {
                        if (namelist.Count <= 11) { scroll--; goto case 3; }
                        else if (namelist.Count >= 12)
                        {
                            scroll = 4;
                            this.leftArrow.Image = global::SkillCalc.Properties.Resources.left;
                            if (namelist.Count >= 5)
                            {
                                this.namescroll1.Text = namelist[4];
                                this.namescroll1.Image = global::SkillCalc.Properties.Resources.header_tabs_unselect;
                            }
                            if (namelist.Count >= 6)
                            {
                                this.namescroll2.Text = namelist[5];
                                this.namescroll2.Image = global::SkillCalc.Properties.Resources.header_tabs_unselect;
                            }
                            if (namelist.Count >= 7)
                            {
                                this.namescroll3.Text = namelist[6];
                                this.namescroll3.Image = global::SkillCalc.Properties.Resources.header_tabs_unselect;
                            }
                            if (namelist.Count >= 8)
                            {
                                this.namescroll4.Text = namelist[7];
                                this.namescroll4.Image = global::SkillCalc.Properties.Resources.header_tabs_unselect;
                            }
                            if (namelist.Count >= 9)
                            {
                                this.namescroll5.Text = namelist[8];
                                this.namescroll5.Image = global::SkillCalc.Properties.Resources.header_tabs_unselect;
                            }
                            if (namelist.Count >= 10)
                            {
                                this.namescroll6.Text = namelist[9];
                                this.namescroll6.Image = global::SkillCalc.Properties.Resources.header_tabs_unselect;
                            }
                            if (namelist.Count >= 11)
                            {
                                this.namescroll7.Text = namelist[10];
                                this.namescroll7.Image = global::SkillCalc.Properties.Resources.header_tabs_unselect;
                            }
                            if (namelist.Count >= 12)
                            {
                                this.namescroll8.Text = namelist[11];
                                this.namescroll8.Image = global::SkillCalc.Properties.Resources.header_tabs_unselect;
                            }
                            if (namelist.Count >= 13)
                            {
                                this.rightArrow.Image = global::SkillCalc.Properties.Resources.right;
                            }
                            if (namelist.Count < 13)
                            {
                                this.rightArrow.Image = global::SkillCalc.Properties.Resources.right_shaded;
                            }
                        }
                        else { scroll = 0; goto case 0; }
                    }
                    break;
                case 5:
                    {
                        if (namelist.Count <= 12) { scroll--; goto case 4; }
                        else if (namelist.Count >= 13)
                        {
                            scroll = 5;
                            this.leftArrow.Image = global::SkillCalc.Properties.Resources.left;
                            if (namelist.Count >= 6)
                            {
                                this.namescroll1.Text = namelist[5];
                                this.namescroll1.Image = global::SkillCalc.Properties.Resources.header_tabs_unselect;
                            }
                            if (namelist.Count >= 7)
                            {
                                this.namescroll2.Text = namelist[6];
                                this.namescroll2.Image = global::SkillCalc.Properties.Resources.header_tabs_unselect;
                            }
                            if (namelist.Count >= 8)
                            {
                                this.namescroll3.Text = namelist[7];
                                this.namescroll3.Image = global::SkillCalc.Properties.Resources.header_tabs_unselect;
                            }
                            if (namelist.Count >= 9)
                            {
                                this.namescroll4.Text = namelist[8];
                                this.namescroll4.Image = global::SkillCalc.Properties.Resources.header_tabs_unselect;
                            }
                            if (namelist.Count >= 10)
                            {
                                this.namescroll5.Text = namelist[9];
                                this.namescroll5.Image = global::SkillCalc.Properties.Resources.header_tabs_unselect;
                            }
                            if (namelist.Count >= 11)
                            {
                                this.namescroll6.Text = namelist[10];
                                this.namescroll6.Image = global::SkillCalc.Properties.Resources.header_tabs_unselect;
                            }
                            if (namelist.Count >= 12)
                            {
                                this.namescroll7.Text = namelist[11];
                                this.namescroll7.Image = global::SkillCalc.Properties.Resources.header_tabs_unselect;
                            }
                            if (namelist.Count >= 13)
                            {
                                this.namescroll8.Text = namelist[12];
                                this.namescroll8.Image = global::SkillCalc.Properties.Resources.header_tabs_unselect;
                            }
                            if (namelist.Count >= 14)
                            {
                                this.rightArrow.Image = global::SkillCalc.Properties.Resources.right;
                            }
                            if (namelist.Count < 14)
                            {
                                this.rightArrow.Image = global::SkillCalc.Properties.Resources.right_shaded;
                            }
                        }
                        else { scroll = 0; goto case 0; }
                    }
                    break;
                case 6:
                    {
                        if (namelist.Count <= 13) { scroll--; goto case 5; }
                        else if (namelist.Count >= 14)
                        {
                            scroll = 6;
                            this.leftArrow.Image = global::SkillCalc.Properties.Resources.left;
                            if (namelist.Count >= 7)
                            {
                                this.namescroll1.Text = namelist[6];
                                this.namescroll1.Image = global::SkillCalc.Properties.Resources.header_tabs_unselect;
                            }
                            if (namelist.Count >= 8)
                            {
                                this.namescroll2.Text = namelist[7];
                                this.namescroll2.Image = global::SkillCalc.Properties.Resources.header_tabs_unselect;
                            }
                            if (namelist.Count >= 9)
                            {
                                this.namescroll3.Text = namelist[8];
                                this.namescroll3.Image = global::SkillCalc.Properties.Resources.header_tabs_unselect;
                            }
                            if (namelist.Count >= 10)
                            {
                                this.namescroll4.Text = namelist[9];
                                this.namescroll4.Image = global::SkillCalc.Properties.Resources.header_tabs_unselect;
                            }
                            if (namelist.Count >= 11)
                            {
                                this.namescroll5.Text = namelist[10];
                                this.namescroll5.Image = global::SkillCalc.Properties.Resources.header_tabs_unselect;
                            }
                            if (namelist.Count >= 12)
                            {
                                this.namescroll6.Text = namelist[11];
                                this.namescroll6.Image = global::SkillCalc.Properties.Resources.header_tabs_unselect;
                            }
                            if (namelist.Count >= 13)
                            {
                                this.namescroll7.Text = namelist[12];
                                this.namescroll7.Image = global::SkillCalc.Properties.Resources.header_tabs_unselect;
                            }
                            if (namelist.Count >= 14)
                            {
                                this.namescroll8.Text = namelist[13];
                                this.namescroll8.Image = global::SkillCalc.Properties.Resources.header_tabs_unselect;
                            }
                            if (namelist.Count >= 15)
                            {
                                this.rightArrow.Image = global::SkillCalc.Properties.Resources.right;
                            }
                            if (namelist.Count < 15)
                            {
                                this.rightArrow.Image = global::SkillCalc.Properties.Resources.right_shaded;
                            }
                        }
                        else { scroll = 0; goto case 0; }
                    }
                    break;
                case 7:
                    {
                        if (namelist.Count <= 14) { scroll--; goto case 6; }
                        else if (namelist.Count >= 15)
                        {
                            scroll = 7;
                            this.leftArrow.Image = global::SkillCalc.Properties.Resources.left;
                            if (namelist.Count >= 8)
                            {
                                this.namescroll1.Text = namelist[7];
                                this.namescroll1.Image = global::SkillCalc.Properties.Resources.header_tabs_unselect;
                            }
                            if (namelist.Count >= 9)
                            {
                                this.namescroll2.Text = namelist[8];
                                this.namescroll2.Image = global::SkillCalc.Properties.Resources.header_tabs_unselect;
                            }
                            if (namelist.Count >= 10)
                            {
                                this.namescroll3.Text = namelist[9];
                                this.namescroll3.Image = global::SkillCalc.Properties.Resources.header_tabs_unselect;
                            }
                            if (namelist.Count >= 11)
                            {
                                this.namescroll4.Text = namelist[10];
                                this.namescroll4.Image = global::SkillCalc.Properties.Resources.header_tabs_unselect;
                            }
                            if (namelist.Count >= 12)
                            {
                                this.namescroll5.Text = namelist[11];
                                this.namescroll5.Image = global::SkillCalc.Properties.Resources.header_tabs_unselect;
                            }
                            if (namelist.Count >= 13)
                            {
                                this.namescroll6.Text = namelist[12];
                                this.namescroll6.Image = global::SkillCalc.Properties.Resources.header_tabs_unselect;
                            }
                            if (namelist.Count >= 14)
                            {
                                this.namescroll7.Text = namelist[13];
                                this.namescroll7.Image = global::SkillCalc.Properties.Resources.header_tabs_unselect;
                            }
                            if (namelist.Count >= 15)
                            {
                                this.namescroll8.Text = namelist[14];
                                this.namescroll8.Image = global::SkillCalc.Properties.Resources.header_tabs_unselect;
                            }
                            if (namelist.Count >= 16)
                            {
                                this.rightArrow.Image = global::SkillCalc.Properties.Resources.right;
                            }
                            if (namelist.Count < 16)
                            {
                                this.rightArrow.Image = global::SkillCalc.Properties.Resources.right_shaded;
                            }
                        }
                        else { scroll = 0; goto case 0; }
                    }
                    break;
                case 8:
                    {
                        if (namelist.Count <= 15) { scroll--; goto case 7; }
                        else if (namelist.Count >= 16)
                        {
                            scroll = 8;
                            this.leftArrow.Image = global::SkillCalc.Properties.Resources.left;
                            if (namelist.Count >= 9)
                            {
                                this.namescroll1.Text = namelist[8];
                                this.namescroll1.Image = global::SkillCalc.Properties.Resources.header_tabs_unselect;
                            }
                            if (namelist.Count >= 10)
                            {
                                this.namescroll2.Text = namelist[9];
                                this.namescroll2.Image = global::SkillCalc.Properties.Resources.header_tabs_unselect;
                            }
                            if (namelist.Count >= 11)
                            {
                                this.namescroll3.Text = namelist[10];
                                this.namescroll3.Image = global::SkillCalc.Properties.Resources.header_tabs_unselect;
                            }
                            if (namelist.Count >= 12)
                            {
                                this.namescroll4.Text = namelist[11];
                                this.namescroll4.Image = global::SkillCalc.Properties.Resources.header_tabs_unselect;
                            }
                            if (namelist.Count >= 13)
                            {
                                this.namescroll5.Text = namelist[12];
                                this.namescroll5.Image = global::SkillCalc.Properties.Resources.header_tabs_unselect;
                            }
                            if (namelist.Count >= 14)
                            {
                                this.namescroll6.Text = namelist[13];
                                this.namescroll6.Image = global::SkillCalc.Properties.Resources.header_tabs_unselect;
                            }
                            if (namelist.Count >= 15)
                            {
                                this.namescroll7.Text = namelist[14];
                                this.namescroll7.Image = global::SkillCalc.Properties.Resources.header_tabs_unselect;
                            }
                            if (namelist.Count >= 16)
                            {
                                this.namescroll8.Text = namelist[15];
                                this.namescroll8.Image = global::SkillCalc.Properties.Resources.header_tabs_unselect;
                            }
                            if (namelist.Count >= 17)
                            {
                                this.rightArrow.Image = global::SkillCalc.Properties.Resources.right;
                            }
                            if (namelist.Count < 17)
                            {
                                this.rightArrow.Image = global::SkillCalc.Properties.Resources.right_shaded;
                            }
                        }
                        else { scroll = 0; goto case 0; }
                    }
                    break;
                case 9:
                    {
                        if (namelist.Count <= 16) { scroll--; goto case 8; }
                        else if (namelist.Count >= 17)
                        {
                            scroll = 9;
                            this.leftArrow.Image = global::SkillCalc.Properties.Resources.left;
                            if (namelist.Count >= 10)
                            {
                                this.namescroll1.Text = namelist[9];
                                this.namescroll1.Image = global::SkillCalc.Properties.Resources.header_tabs_unselect;
                            }
                            if (namelist.Count >= 11)
                            {
                                this.namescroll2.Text = namelist[10];
                                this.namescroll2.Image = global::SkillCalc.Properties.Resources.header_tabs_unselect;
                            }
                            if (namelist.Count >= 12)
                            {
                                this.namescroll3.Text = namelist[11];
                                this.namescroll3.Image = global::SkillCalc.Properties.Resources.header_tabs_unselect;
                            }
                            if (namelist.Count >= 13)
                            {
                                this.namescroll4.Text = namelist[12];
                                this.namescroll4.Image = global::SkillCalc.Properties.Resources.header_tabs_unselect;
                            }
                            if (namelist.Count >= 14)
                            {
                                this.namescroll5.Text = namelist[13];
                                this.namescroll5.Image = global::SkillCalc.Properties.Resources.header_tabs_unselect;
                            }
                            if (namelist.Count >= 15)
                            {
                                this.namescroll6.Text = namelist[14];
                                this.namescroll6.Image = global::SkillCalc.Properties.Resources.header_tabs_unselect;
                            }
                            if (namelist.Count >= 16)
                            {
                                this.namescroll7.Text = namelist[15];
                                this.namescroll7.Image = global::SkillCalc.Properties.Resources.header_tabs_unselect;
                            }
                            if (namelist.Count >= 17)
                            {
                                this.namescroll8.Text = namelist[16];
                                this.namescroll8.Image = global::SkillCalc.Properties.Resources.header_tabs_unselect;
                            }
                            if (namelist.Count >= 18)
                            {
                                this.rightArrow.Image = global::SkillCalc.Properties.Resources.right;
                            }
                            if (namelist.Count < 18)
                            {
                                this.rightArrow.Image = global::SkillCalc.Properties.Resources.right_shaded;
                            }
                        }
                        else { scroll = 0; goto case 0; }
                    }
                    break;
                case 10:
                    {
                        if (namelist.Count <= 17) { scroll--; goto case 9; }
                        else if (namelist.Count >= 18)
                        {
                            scroll = 10;
                            this.leftArrow.Image = global::SkillCalc.Properties.Resources.left;
                            if (namelist.Count >= 11)
                            {
                                this.namescroll1.Text = namelist[10];
                                this.namescroll1.Image = global::SkillCalc.Properties.Resources.header_tabs_unselect;
                            }
                            if (namelist.Count >= 12)
                            {
                                this.namescroll2.Text = namelist[11];
                                this.namescroll2.Image = global::SkillCalc.Properties.Resources.header_tabs_unselect;
                            }
                            if (namelist.Count >= 13)
                            {
                                this.namescroll3.Text = namelist[12];
                                this.namescroll3.Image = global::SkillCalc.Properties.Resources.header_tabs_unselect;
                            }
                            if (namelist.Count >= 14)
                            {
                                this.namescroll4.Text = namelist[13];
                                this.namescroll4.Image = global::SkillCalc.Properties.Resources.header_tabs_unselect;
                            }
                            if (namelist.Count >= 15)
                            {
                                this.namescroll5.Text = namelist[14];
                                this.namescroll5.Image = global::SkillCalc.Properties.Resources.header_tabs_unselect;
                            }
                            if (namelist.Count >= 16)
                            {
                                this.namescroll6.Text = namelist[15];
                                this.namescroll6.Image = global::SkillCalc.Properties.Resources.header_tabs_unselect;
                            }
                            if (namelist.Count >= 17)
                            {
                                this.namescroll7.Text = namelist[16];
                                this.namescroll7.Image = global::SkillCalc.Properties.Resources.header_tabs_unselect;
                            }
                            if (namelist.Count >= 18)
                            {
                                this.namescroll8.Text = namelist[17];
                                this.namescroll8.Image = global::SkillCalc.Properties.Resources.header_tabs_unselect;
                            }
                            if (namelist.Count >= 19)
                            {
                                this.rightArrow.Image = global::SkillCalc.Properties.Resources.right;
                            }
                            if (namelist.Count < 19)
                            {
                                this.rightArrow.Image = global::SkillCalc.Properties.Resources.right_shaded;
                            }
                        }
                        else { scroll = 0; goto case 0; }
                    }
                    break;
                case 11:
                    {
                        if (namelist.Count <= 18) { scroll--; goto case 10; }
                        else if (namelist.Count >= 19)
                        {
                            scroll = 11;
                            this.leftArrow.Image = global::SkillCalc.Properties.Resources.left;
                            if (namelist.Count >= 12)
                            {
                                this.namescroll1.Text = namelist[11];
                                this.namescroll1.Image = global::SkillCalc.Properties.Resources.header_tabs_unselect;
                            }
                            if (namelist.Count >= 13)
                            {
                                this.namescroll2.Text = namelist[12];
                                this.namescroll2.Image = global::SkillCalc.Properties.Resources.header_tabs_unselect;
                            }
                            if (namelist.Count >= 14)
                            {
                                this.namescroll3.Text = namelist[13];
                                this.namescroll3.Image = global::SkillCalc.Properties.Resources.header_tabs_unselect;
                            }
                            if (namelist.Count >= 15)
                            {
                                this.namescroll4.Text = namelist[14];
                                this.namescroll4.Image = global::SkillCalc.Properties.Resources.header_tabs_unselect;
                            }
                            if (namelist.Count >= 16)
                            {
                                this.namescroll5.Text = namelist[15];
                                this.namescroll5.Image = global::SkillCalc.Properties.Resources.header_tabs_unselect;
                            }
                            if (namelist.Count >= 17)
                            {
                                this.namescroll6.Text = namelist[16];
                                this.namescroll6.Image = global::SkillCalc.Properties.Resources.header_tabs_unselect;
                            }
                            if (namelist.Count >= 18)
                            {
                                this.namescroll7.Text = namelist[17];
                                this.namescroll7.Image = global::SkillCalc.Properties.Resources.header_tabs_unselect;
                            }
                            if (namelist.Count >= 19)
                            {
                                this.namescroll8.Text = namelist[18];
                                this.namescroll8.Image = global::SkillCalc.Properties.Resources.header_tabs_unselect;
                            }
                            if (namelist.Count >= 20)
                            {
                                this.rightArrow.Image = global::SkillCalc.Properties.Resources.right;
                            }
                            if (namelist.Count < 20)
                            {
                                this.rightArrow.Image = global::SkillCalc.Properties.Resources.right_shaded;
                            }
                        }
                        else { scroll = 0; goto case 0; }
                    }
                    break;
                case 12:
                    {
                        if (namelist.Count <= 19) { goto case 11; }
                        else if (namelist.Count == 20)
                        {
                            scroll = 12;
                            this.leftArrow.Image = global::SkillCalc.Properties.Resources.left;
                            this.rightArrow.Image = global::SkillCalc.Properties.Resources.right_shaded;
                            if (namelist.Count >= 13)
                            {
                                this.namescroll1.Text = namelist[12];
                                this.namescroll1.Image = global::SkillCalc.Properties.Resources.header_tabs_unselect;
                            }
                            if (namelist.Count >= 14)
                            {
                                this.namescroll2.Text = namelist[13];
                                this.namescroll2.Image = global::SkillCalc.Properties.Resources.header_tabs_unselect;
                            }
                            if (namelist.Count >= 15)
                            {
                                this.namescroll3.Text = namelist[14];
                                this.namescroll3.Image = global::SkillCalc.Properties.Resources.header_tabs_unselect;
                            }
                            if (namelist.Count >= 16)
                            {
                                this.namescroll4.Text = namelist[15];
                                this.namescroll4.Image = global::SkillCalc.Properties.Resources.header_tabs_unselect;
                            }
                            if (namelist.Count >= 17)
                            {
                                this.namescroll5.Text = namelist[16];
                                this.namescroll5.Image = global::SkillCalc.Properties.Resources.header_tabs_unselect;
                            }
                            if (namelist.Count >= 18)
                            {
                                this.namescroll6.Text = namelist[17];
                                this.namescroll6.Image = global::SkillCalc.Properties.Resources.header_tabs_unselect;
                            }
                            if (namelist.Count >= 19)
                            {
                                this.namescroll7.Text = namelist[18];
                                this.namescroll7.Image = global::SkillCalc.Properties.Resources.header_tabs_unselect;
                            }
                            if (namelist.Count == 20)
                            {
                                this.namescroll8.Text = namelist[19];
                                this.namescroll8.Image = global::SkillCalc.Properties.Resources.header_tabs_unselect;
                            }
                        }
                        else { scroll = 0; goto case 0; }
                    }
                    break;
            }
        }
        private void displayspecies()
        {
            clearcursor();
            this.selectProf01.Text = "".PadLeft(4) + "None";
            this.selectProf02.Text = "".PadLeft(4) + "Bothan";
            this.selectProf03.Text = "".PadLeft(4) + "Human";
            this.selectProf04.Text = "".PadLeft(4) + "Ithorian";
            this.selectProf05.Text = "".PadLeft(4) + "Mon Calamari";
            this.selectProf06.Text = "".PadLeft(4) + "Rodian";
            this.selectProf07.Text = "".PadLeft(4) + "Sullustan";
            this.selectProf08.Text = "".PadLeft(4) + "Trandoshan";
            this.selectProf09.Text = "".PadLeft(4) + "Twi'Lek";
            this.selectProf10.Text = "".PadLeft(4) + "Mon Wookie";
            this.selectProf11.Text = "".PadLeft(4) + "Zabrak";
            this.selectProf01.Cursor = System.Windows.Forms.Cursors.Hand;
            this.selectProf02.Cursor = System.Windows.Forms.Cursors.Hand;
            this.selectProf03.Cursor = System.Windows.Forms.Cursors.Hand;
            this.selectProf04.Cursor = System.Windows.Forms.Cursors.Hand;
            this.selectProf05.Cursor = System.Windows.Forms.Cursors.Hand;
            this.selectProf06.Cursor = System.Windows.Forms.Cursors.Hand;
            this.selectProf07.Cursor = System.Windows.Forms.Cursors.Hand;
            this.selectProf08.Cursor = System.Windows.Forms.Cursors.Hand;
            this.selectProf09.Cursor = System.Windows.Forms.Cursors.Hand;
            this.selectProf10.Cursor = System.Windows.Forms.Cursors.Hand;
            this.selectProf11.Cursor = System.Windows.Forms.Cursors.Hand;
        }
        private void nameEntry_TextChanged(object sender, EventArgs e)
        {
            if (this.charName.Text.Length >= 13) { this.charName.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));  }
            else { this.charName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0))); }
            this.charName.Text = this.nameEntry.Text;
        }
        private void handlenames(string name)
        {
            this.nameEntry.Text = name;
            this.charName.Text = name;
            if (this.charName.Text.Length >= 13) { this.charName.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0))); }
            else { this.charName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0))); }
        }
        private void refreshnames()
        {
            cleartabs();
            clearskills();
            clearprofselect();
            clearproftext();
            clearclicked();
            clearpointsicon();
            viewtab = "name";
            this.charName.Text = "Character";
            this.nameEntry.Text = this.charName.Text;
            this.headerCharacter.Visible = true;
            this.charName.Image = global::SkillCalc.Properties.Resources.tabs_selected;
            this.charName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(63)))), ((int)(((byte)(75)))));
            this.charSave.Image = global::SkillCalc.Properties.Resources.characterwindbttn;
            this.charSave.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(244)))), ((int)(((byte)(255)))));
            displaycharacter();
            namescroll(0);
        }

        // This whole chain of code is being an ass so screw it, user can deal with no confirm dialog for now.
        private void confirmDelete()
        {
            DialogResult dialogResult = CustomMessageBox.frmShowMessage.Show("Delete selected character?", "Information", CustomMessageBox.enumMessageButton.YesNo);
            if (dialogResult == DialogResult.Yes) { dodelete(); }
        }

        // Handles hitting enter in character name field.
        private void nameEntry_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter && this.headerCharacter.Visible == true) { e.Handled = true; charSaveButton.PerformClick(); }
        }
        private void nameEntry_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && this.headerCharacter.Visible == true)
            {
                this.charSave.Image = global::SkillCalc.Properties.Resources.characterwindbttn_selected;
                this.charSave.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(63)))), ((int)(((byte)(75)))));
            }
        }
        private void nameEntry_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && this.headerCharacter.Visible == true)
            {
                this.charSave.Image = global::SkillCalc.Properties.Resources.characterwindbttn;
                this.charSave.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(244)))), ((int)(((byte)(255)))));
            }
        }

        // Checks for left click default green display clicks.
        private bool projectedvaluesearch(string skillvalue, int position)
        {
            if (skillvalue.Substring(position, 1) == "1") { return true; }
            else { return false; }
        }
        private void mouseHoverDisplay(string sender, string position)
        {
            if (professions.Contains(selectedprof))
            {
                string name = this.charName.Text;
                string skillvalue = getskills(name, selectedprof);

                switch (position)
                {
                    case "enter":
                        {
                            switch (sender)
                            {
                                case "labelNovice":
                                    {
                                        if (skillvalue.Substring(0, 1) == "0")
                                        {
                                            this.labelNovice.Image = global::SkillCalc.Properties.Resources.skill_hover_default;
                                            this.labelNovice.ForeColor = System.Drawing.Color.White;
                                            this.NoviceCost.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(160)))), ((int)(((byte)(180)))));
                                        }
                                        if (skillvalue.Substring(0, 1) == "1")
                                        {
                                            this.labelNovice.Image = global::SkillCalc.Properties.Resources.skill_hover_spent;
                                            this.labelNovice.ForeColor = System.Drawing.Color.Yellow;
                                            this.NoviceCost.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(124)))), ((int)(((byte)(49)))));
                                        }
                                    }
                                    break;
                                case "labelfirstI":
                                    {
                                        if (skillvalue.Substring(2, 1) == "0")
                                        {
                                            this.labelfirstI.Image = global::SkillCalc.Properties.Resources.skill_hover_default;
                                            this.labelfirstI.ForeColor = System.Drawing.Color.White;
                                            this.firstICost.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(160)))), ((int)(((byte)(180)))));
                                        }
                                        if (skillvalue.Substring(2, 1) == "1")
                                        {
                                            this.labelfirstI.Image = global::SkillCalc.Properties.Resources.skill_hover_spent;
                                            this.labelfirstI.ForeColor = System.Drawing.Color.Yellow;
                                            this.firstICost.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(124)))), ((int)(((byte)(49)))));
                                        }
                                    }
                                    break;
                                case "labelfirstII":
                                    {
                                        if (skillvalue.Substring(3, 1) == "0")
                                        {
                                            this.labelfirstII.Image = global::SkillCalc.Properties.Resources.skill_hover_default;
                                            this.labelfirstII.ForeColor = System.Drawing.Color.White;
                                            this.firstIICost.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(160)))), ((int)(((byte)(180)))));
                                        }
                                        if (skillvalue.Substring(3, 1) == "1")
                                        {
                                            this.labelfirstII.Image = global::SkillCalc.Properties.Resources.skill_hover_spent;
                                            this.labelfirstII.ForeColor = System.Drawing.Color.Yellow;
                                            this.firstIICost.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(124)))), ((int)(((byte)(49)))));
                                        }
                                    }
                                    break;
                                case "labelfirstIII":
                                    {
                                        if (skillvalue.Substring(4, 1) == "0")
                                        {
                                            this.labelfirstIII.Image = global::SkillCalc.Properties.Resources.skill_hover_default;
                                            this.labelfirstIII.ForeColor = System.Drawing.Color.White;
                                            this.firstIIICost.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(160)))), ((int)(((byte)(180)))));
                                        }
                                        if (skillvalue.Substring(4, 1) == "1")
                                        {
                                            this.labelfirstIII.Image = global::SkillCalc.Properties.Resources.skill_hover_spent;
                                            this.labelfirstIII.ForeColor = System.Drawing.Color.Yellow;
                                            this.firstIIICost.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(124)))), ((int)(((byte)(49)))));
                                        }
                                    }
                                    break;
                                case "labelfirstIV":
                                    {
                                        if (skillvalue.Substring(5, 1) == "0")
                                        {
                                            this.labelfirstIV.Image = global::SkillCalc.Properties.Resources.skill_hover_default;
                                            this.labelfirstIV.ForeColor = System.Drawing.Color.White;
                                            this.firstIVCost.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(160)))), ((int)(((byte)(180)))));
                                        }
                                        if (skillvalue.Substring(5, 1) == "1")
                                        {
                                            this.labelfirstIV.Image = global::SkillCalc.Properties.Resources.skill_hover_spent;
                                            this.labelfirstIV.ForeColor = System.Drawing.Color.Yellow;
                                            this.firstIVCost.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(124)))), ((int)(((byte)(49)))));
                                        }
                                    }
                                    break;
                                case "labelsecondI":
                                    {
                                        if (skillvalue.Substring(7, 1) == "0")
                                        {
                                            this.labelsecondI.Image = global::SkillCalc.Properties.Resources.skill_hover_default;
                                            this.labelsecondI.ForeColor = System.Drawing.Color.White;
                                            this.secondICost.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(160)))), ((int)(((byte)(180)))));
                                        }
                                        if (skillvalue.Substring(7, 1) == "1")
                                        {
                                            this.labelsecondI.Image = global::SkillCalc.Properties.Resources.skill_hover_spent;
                                            this.labelsecondI.ForeColor = System.Drawing.Color.Yellow;
                                            this.secondICost.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(124)))), ((int)(((byte)(49)))));
                                        }
                                    }
                                    break;
                                case "labelsecondII":
                                    {
                                        if (skillvalue.Substring(8, 1) == "0")
                                        {
                                            this.labelsecondII.Image = global::SkillCalc.Properties.Resources.skill_hover_default;
                                            this.labelsecondII.ForeColor = System.Drawing.Color.White;
                                            this.secondIICost.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(160)))), ((int)(((byte)(180)))));
                                        }
                                        if (skillvalue.Substring(8, 1) == "1")
                                        {
                                            this.labelsecondII.Image = global::SkillCalc.Properties.Resources.skill_hover_spent;
                                            this.labelsecondII.ForeColor = System.Drawing.Color.Yellow;
                                            this.secondIICost.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(124)))), ((int)(((byte)(49)))));
                                        }
                                    }
                                    break;
                                case "labelsecondIII":
                                    {
                                        if (skillvalue.Substring(9, 1) == "0")
                                        {
                                            this.labelsecondIII.Image = global::SkillCalc.Properties.Resources.skill_hover_default;
                                            this.labelsecondIII.ForeColor = System.Drawing.Color.White;
                                            this.secondIIICost.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(160)))), ((int)(((byte)(180)))));
                                        }
                                        if (skillvalue.Substring(9, 1) == "1")
                                        {
                                            this.labelsecondIII.Image = global::SkillCalc.Properties.Resources.skill_hover_spent;
                                            this.labelsecondIII.ForeColor = System.Drawing.Color.Yellow;
                                            this.secondIIICost.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(124)))), ((int)(((byte)(49)))));
                                        }
                                    }
                                    break;
                                case "labelsecondIV":
                                    {
                                        if (skillvalue.Substring(10, 1) == "0")
                                        {
                                            this.labelsecondIV.Image = global::SkillCalc.Properties.Resources.skill_hover_default;
                                            this.labelsecondIV.ForeColor = System.Drawing.Color.White;
                                            this.secondIVCost.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(160)))), ((int)(((byte)(180)))));
                                        }
                                        if (skillvalue.Substring(10, 1) == "1")
                                        {
                                            this.labelsecondIV.Image = global::SkillCalc.Properties.Resources.skill_hover_spent;
                                            this.labelsecondIV.ForeColor = System.Drawing.Color.Yellow;
                                            this.secondIVCost.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(124)))), ((int)(((byte)(49)))));
                                        }
                                    }
                                    break;
                                case "labelthirdI":
                                    {
                                        if (skillvalue.Substring(12, 1) == "0")
                                        {
                                            this.labelthirdI.Image = global::SkillCalc.Properties.Resources.skill_hover_default;
                                            this.labelthirdI.ForeColor = System.Drawing.Color.White;
                                            this.thirdICost.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(160)))), ((int)(((byte)(180)))));
                                        }
                                        if (skillvalue.Substring(12, 1) == "1")
                                        {
                                            this.labelthirdI.Image = global::SkillCalc.Properties.Resources.skill_hover_spent;
                                            this.labelthirdI.ForeColor = System.Drawing.Color.Yellow;
                                            this.thirdICost.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(124)))), ((int)(((byte)(49)))));
                                        }
                                    }
                                    break;
                                case "labelthirdII":
                                    {
                                        if (skillvalue.Substring(13, 1) == "0")
                                        {
                                            this.labelthirdII.Image = global::SkillCalc.Properties.Resources.skill_hover_default;
                                            this.labelthirdII.ForeColor = System.Drawing.Color.White;
                                            this.thirdIICost.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(160)))), ((int)(((byte)(180)))));
                                        }
                                        if (skillvalue.Substring(13, 1) == "1")
                                        {
                                            this.labelthirdII.Image = global::SkillCalc.Properties.Resources.skill_hover_spent;
                                            this.labelthirdII.ForeColor = System.Drawing.Color.Yellow;
                                            this.thirdIICost.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(124)))), ((int)(((byte)(49)))));
                                        }
                                    }
                                    break;
                                case "labelthirdIII":
                                    {
                                        if (skillvalue.Substring(14, 1) == "0")
                                        {
                                            this.labelthirdIII.Image = global::SkillCalc.Properties.Resources.skill_hover_default;
                                            this.labelthirdIII.ForeColor = System.Drawing.Color.White;
                                            this.thirdIIICost.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(160)))), ((int)(((byte)(180)))));
                                        }
                                        if (skillvalue.Substring(14, 1) == "1")
                                        {
                                            this.labelthirdIII.Image = global::SkillCalc.Properties.Resources.skill_hover_spent;
                                            this.labelthirdIII.ForeColor = System.Drawing.Color.Yellow;
                                            this.thirdIIICost.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(124)))), ((int)(((byte)(49)))));
                                        }
                                    }
                                    break;
                                case "labelthirdIV":
                                    {
                                        if (skillvalue.Substring(15, 1) == "0")
                                        {
                                            this.labelthirdIV.Image = global::SkillCalc.Properties.Resources.skill_hover_default;
                                            this.labelthirdIV.ForeColor = System.Drawing.Color.White;
                                            this.thirdIVCost.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(160)))), ((int)(((byte)(180)))));
                                        }
                                        if (skillvalue.Substring(15, 1) == "1")
                                        {
                                            this.labelthirdIV.Image = global::SkillCalc.Properties.Resources.skill_hover_spent;
                                            this.labelthirdIV.ForeColor = System.Drawing.Color.Yellow;
                                            this.thirdIVCost.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(124)))), ((int)(((byte)(49)))));
                                        }
                                    }
                                    break;
                                case "labelfourthI":
                                    {
                                        if (skillvalue.Substring(17, 1) == "0")
                                        {
                                            this.labelfourthI.Image = global::SkillCalc.Properties.Resources.skill_hover_default;
                                            this.labelfourthI.ForeColor = System.Drawing.Color.White;
                                            this.fourthICost.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(160)))), ((int)(((byte)(180)))));
                                        }
                                        if (skillvalue.Substring(17, 1) == "1")
                                        {
                                            this.labelfourthI.Image = global::SkillCalc.Properties.Resources.skill_hover_spent;
                                            this.labelfourthI.ForeColor = System.Drawing.Color.Yellow;
                                            this.fourthICost.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(124)))), ((int)(((byte)(49)))));
                                        }
                                    }
                                    break;
                                case "labelfourthII":
                                    {
                                        if (skillvalue.Substring(18, 1) == "0")
                                        {
                                            this.labelfourthII.Image = global::SkillCalc.Properties.Resources.skill_hover_default;
                                            this.labelfourthII.ForeColor = System.Drawing.Color.White;
                                            this.fourthIICost.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(160)))), ((int)(((byte)(180)))));
                                        }
                                        if (skillvalue.Substring(18, 1) == "1")
                                        {
                                            this.labelfourthII.Image = global::SkillCalc.Properties.Resources.skill_hover_spent;
                                            this.labelfourthII.ForeColor = System.Drawing.Color.Yellow;
                                            this.fourthIICost.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(124)))), ((int)(((byte)(49)))));
                                        }
                                    }
                                    break;
                                case "labelfourthIII":
                                    {
                                        if (skillvalue.Substring(19, 1) == "0")
                                        {
                                            this.labelfourthIII.Image = global::SkillCalc.Properties.Resources.skill_hover_default;
                                            this.labelfourthIII.ForeColor = System.Drawing.Color.White;
                                            this.fourthIIICost.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(160)))), ((int)(((byte)(180)))));
                                        }
                                        if (skillvalue.Substring(19, 1) == "1")
                                        {
                                            this.labelfourthIII.Image = global::SkillCalc.Properties.Resources.skill_hover_spent;
                                            this.labelfourthIII.ForeColor = System.Drawing.Color.Yellow;
                                            this.fourthIIICost.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(124)))), ((int)(((byte)(49)))));
                                        }
                                    }
                                    break;
                                case "labelfourthIV":
                                    {
                                        if (skillvalue.Substring(20, 1) == "0")
                                        {
                                            this.labelfourthIV.Image = global::SkillCalc.Properties.Resources.skill_hover_default;
                                            this.labelfourthIV.ForeColor = System.Drawing.Color.White;
                                            this.fourthIVCost.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(160)))), ((int)(((byte)(180)))));
                                        }
                                        if (skillvalue.Substring(20, 1) == "1")
                                        {
                                            this.labelfourthIV.Image = global::SkillCalc.Properties.Resources.skill_hover_spent;
                                            this.labelfourthIV.ForeColor = System.Drawing.Color.Yellow;
                                            this.fourthIVCost.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(124)))), ((int)(((byte)(49)))));
                                        }
                                    }
                                    break;
                                case "labelMaster":
                                    {
                                        if (skillvalue.Substring(22, 1) == "0")
                                        {
                                            this.labelMaster.Image = global::SkillCalc.Properties.Resources.skill_hover_default;
                                            this.labelMaster.ForeColor = System.Drawing.Color.White;
                                            this.MasterCost.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(160)))), ((int)(((byte)(180)))));
                                        }
                                        if (skillvalue.Substring(22, 1) == "1")
                                        {
                                            this.labelMaster.Image = global::SkillCalc.Properties.Resources.skill_hover_spent;
                                            this.labelMaster.ForeColor = System.Drawing.Color.Yellow;
                                            this.MasterCost.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(124)))), ((int)(((byte)(49)))));
                                        }
                                    }
                                    break;
                            }
                        }
                        break;
                    case "leave":
                        {
                            switch (sender)
                            {
                                case "labelNovice":
                                    {
                                        if (skillvalue.Substring(0, 1) == "0")
                                        {
                                            this.labelNovice.Image = global::SkillCalc.Properties.Resources.skill_default;
                                            this.labelNovice.ForeColor = System.Drawing.Color.White;
                                            this.NoviceCost.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(96)))), ((int)(((byte)(117)))));
                                        }
                                        if (skillvalue.Substring(0, 1) == "1")
                                        {
                                            this.labelNovice.Image = global::SkillCalc.Properties.Resources.skill_green;
                                            this.labelNovice.ForeColor = System.Drawing.Color.Black;
                                            this.NoviceCost.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(171)))), ((int)(((byte)(48)))));
                                        }
                                    }
                                    break;
                                case "labelfirstI":
                                    {
                                        if (skillvalue.Substring(2, 1) == "0")
                                        {
                                            this.labelfirstI.Image = global::SkillCalc.Properties.Resources.skill_default;
                                            this.labelfirstI.ForeColor = System.Drawing.Color.White;
                                            this.firstICost.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(96)))), ((int)(((byte)(117)))));
                                        }
                                        if (skillvalue.Substring(2, 1) == "1")
                                        {
                                            this.labelfirstI.Image = global::SkillCalc.Properties.Resources.skill_green;
                                            this.labelfirstI.ForeColor = System.Drawing.Color.Black;
                                            this.firstICost.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(171)))), ((int)(((byte)(48)))));
                                        }
                                    }
                                    break;
                                case "labelfirstII":
                                    {
                                        if (skillvalue.Substring(3, 1) == "0")
                                        {
                                            this.labelfirstII.Image = global::SkillCalc.Properties.Resources.skill_default;
                                            this.labelfirstII.ForeColor = System.Drawing.Color.White;
                                            this.firstIICost.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(96)))), ((int)(((byte)(117)))));
                                        }
                                        if (skillvalue.Substring(3, 1) == "1")
                                        {
                                            this.labelfirstII.Image = global::SkillCalc.Properties.Resources.skill_green;
                                            this.labelfirstII.ForeColor = System.Drawing.Color.Black;
                                            this.firstIICost.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(171)))), ((int)(((byte)(48)))));
                                        }
                                    }
                                    break;
                                case "labelfirstIII":
                                    {
                                        if (skillvalue.Substring(4, 1) == "0")
                                        {
                                            this.labelfirstIII.Image = global::SkillCalc.Properties.Resources.skill_default;
                                            this.labelfirstIII.ForeColor = System.Drawing.Color.White;
                                            this.firstIIICost.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(96)))), ((int)(((byte)(117)))));
                                        }
                                        if (skillvalue.Substring(4, 1) == "1")
                                        {
                                            this.labelfirstIII.Image = global::SkillCalc.Properties.Resources.skill_green;
                                            this.labelfirstIII.ForeColor = System.Drawing.Color.Black;
                                            this.firstIIICost.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(171)))), ((int)(((byte)(48)))));
                                        }
                                    }
                                    break;
                                case "labelfirstIV":
                                    {
                                        if (skillvalue.Substring(5, 1) == "0")
                                        {
                                            this.labelfirstIV.Image = global::SkillCalc.Properties.Resources.skill_default;
                                            this.labelfirstIV.ForeColor = System.Drawing.Color.White;
                                            this.firstIVCost.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(96)))), ((int)(((byte)(117)))));
                                        }
                                        if (skillvalue.Substring(5, 1) == "1")
                                        {
                                            this.labelfirstIV.Image = global::SkillCalc.Properties.Resources.skill_green;
                                            this.labelfirstIV.ForeColor = System.Drawing.Color.Black;
                                            this.firstIVCost.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(171)))), ((int)(((byte)(48)))));
                                        }
                                    }
                                    break;
                                case "labelsecondI":
                                    {
                                        if (skillvalue.Substring(7, 1) == "0")
                                        {
                                            this.labelsecondI.Image = global::SkillCalc.Properties.Resources.skill_default;
                                            this.labelsecondI.ForeColor = System.Drawing.Color.White;
                                            this.secondICost.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(96)))), ((int)(((byte)(117)))));
                                        }
                                        if (skillvalue.Substring(7, 1) == "1")
                                        {
                                            this.labelsecondI.Image = global::SkillCalc.Properties.Resources.skill_green;
                                            this.labelsecondI.ForeColor = System.Drawing.Color.Black;
                                            this.secondICost.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(171)))), ((int)(((byte)(48)))));
                                        }
                                    }
                                    break;
                                case "labelsecondII":
                                    {
                                        if (skillvalue.Substring(8, 1) == "0")
                                        {
                                            this.labelsecondII.Image = global::SkillCalc.Properties.Resources.skill_default;
                                            this.labelsecondII.ForeColor = System.Drawing.Color.White;
                                            this.secondIICost.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(96)))), ((int)(((byte)(117)))));
                                        }
                                        if (skillvalue.Substring(8, 1) == "1")
                                        {
                                            this.labelsecondII.Image = global::SkillCalc.Properties.Resources.skill_green;
                                            this.labelsecondII.ForeColor = System.Drawing.Color.Black;
                                            this.secondIICost.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(171)))), ((int)(((byte)(48)))));
                                        }
                                    }
                                    break;
                                case "labelsecondIII":
                                    {
                                        if (skillvalue.Substring(9, 1) == "0")
                                        {
                                            this.labelsecondIII.Image = global::SkillCalc.Properties.Resources.skill_default;
                                            this.labelsecondIII.ForeColor = System.Drawing.Color.White;
                                            this.secondIIICost.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(96)))), ((int)(((byte)(117)))));
                                        }
                                        if (skillvalue.Substring(9, 1) == "1")
                                        {
                                            this.labelsecondIII.Image = global::SkillCalc.Properties.Resources.skill_green;
                                            this.labelsecondIII.ForeColor = System.Drawing.Color.Black;
                                            this.secondIIICost.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(171)))), ((int)(((byte)(48)))));
                                        }
                                    }
                                    break;
                                case "labelsecondIV":
                                    {
                                        if (skillvalue.Substring(10, 1) == "0")
                                        {
                                            this.labelsecondIV.Image = global::SkillCalc.Properties.Resources.skill_default;
                                            this.labelsecondIV.ForeColor = System.Drawing.Color.White;
                                            this.secondIVCost.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(96)))), ((int)(((byte)(117)))));
                                        }
                                        if (skillvalue.Substring(10, 1) == "1")
                                        {
                                            this.labelsecondIV.Image = global::SkillCalc.Properties.Resources.skill_green;
                                            this.labelsecondIV.ForeColor = System.Drawing.Color.Black;
                                            this.secondIVCost.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(171)))), ((int)(((byte)(48)))));
                                        }
                                    }
                                    break;
                                case "labelthirdI":
                                    {
                                        if (skillvalue.Substring(12, 1) == "0")
                                        {
                                            this.labelthirdI.Image = global::SkillCalc.Properties.Resources.skill_default;
                                            this.labelthirdI.ForeColor = System.Drawing.Color.White;
                                            this.thirdICost.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(96)))), ((int)(((byte)(117)))));
                                        }
                                        if (skillvalue.Substring(12, 1) == "1")
                                        {
                                            this.labelthirdI.Image = global::SkillCalc.Properties.Resources.skill_green;
                                            this.labelthirdI.ForeColor = System.Drawing.Color.Black;
                                            this.thirdICost.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(171)))), ((int)(((byte)(48)))));
                                        }
                                    }
                                    break;
                                case "labelthirdII":
                                    {
                                        if (skillvalue.Substring(13, 1) == "0")
                                        {
                                            this.labelthirdII.Image = global::SkillCalc.Properties.Resources.skill_default;
                                            this.labelthirdII.ForeColor = System.Drawing.Color.White;
                                            this.thirdIICost.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(96)))), ((int)(((byte)(117)))));
                                        }
                                        if (skillvalue.Substring(13, 1) == "1")
                                        {
                                            this.labelthirdII.Image = global::SkillCalc.Properties.Resources.skill_green;
                                            this.labelthirdII.ForeColor = System.Drawing.Color.Black;
                                            this.thirdIICost.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(171)))), ((int)(((byte)(48)))));
                                        }
                                    }
                                    break;
                                case "labelthirdIII":
                                    {
                                        if (skillvalue.Substring(14, 1) == "0")
                                        {
                                            this.labelthirdIII.Image = global::SkillCalc.Properties.Resources.skill_default;
                                            this.labelthirdIII.ForeColor = System.Drawing.Color.White;
                                            this.thirdIIICost.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(96)))), ((int)(((byte)(117)))));
                                        }
                                        if (skillvalue.Substring(14, 1) == "1")
                                        {
                                            this.labelthirdIII.Image = global::SkillCalc.Properties.Resources.skill_green;
                                            this.labelthirdIII.ForeColor = System.Drawing.Color.Black;
                                            this.thirdIIICost.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(171)))), ((int)(((byte)(48)))));
                                        }
                                    }
                                    break;
                                case "labelthirdIV":
                                    {
                                        if (skillvalue.Substring(15, 1) == "0")
                                        {
                                            this.labelthirdIV.Image = global::SkillCalc.Properties.Resources.skill_default;
                                            this.labelthirdIV.ForeColor = System.Drawing.Color.White;
                                            this.thirdIVCost.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(96)))), ((int)(((byte)(117)))));
                                        }
                                        if (skillvalue.Substring(15, 1) == "1")
                                        {
                                            this.labelthirdIV.Image = global::SkillCalc.Properties.Resources.skill_green;
                                            this.labelthirdIV.ForeColor = System.Drawing.Color.Black;
                                            this.thirdIVCost.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(171)))), ((int)(((byte)(48)))));
                                        }
                                    }
                                    break;
                                case "labelfourthI":
                                    {
                                        if (skillvalue.Substring(17, 1) == "0")
                                        {
                                            this.labelfourthI.Image = global::SkillCalc.Properties.Resources.skill_default;
                                            this.labelfourthI.ForeColor = System.Drawing.Color.White;
                                            this.fourthICost.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(96)))), ((int)(((byte)(117)))));
                                        }
                                        if (skillvalue.Substring(17, 1) == "1")
                                        {
                                            this.labelfourthI.Image = global::SkillCalc.Properties.Resources.skill_green;
                                            this.labelfourthI.ForeColor = System.Drawing.Color.Black;
                                            this.fourthICost.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(171)))), ((int)(((byte)(48)))));
                                        }
                                    }
                                    break;
                                case "labelfourthII":
                                    {
                                        if (skillvalue.Substring(18, 1) == "0")
                                        {
                                            this.labelfourthII.Image = global::SkillCalc.Properties.Resources.skill_default;
                                            this.labelfourthII.ForeColor = System.Drawing.Color.White;
                                            this.fourthIICost.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(96)))), ((int)(((byte)(117)))));
                                        }
                                        if (skillvalue.Substring(18, 1) == "1")
                                        {
                                            this.labelfourthII.Image = global::SkillCalc.Properties.Resources.skill_green;
                                            this.labelfourthII.ForeColor = System.Drawing.Color.Black;
                                            this.fourthIICost.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(171)))), ((int)(((byte)(48)))));
                                        }
                                    }
                                    break;
                                case "labelfourthIII":
                                    {
                                        if (skillvalue.Substring(19, 1) == "0")
                                        {
                                            this.labelfourthIII.Image = global::SkillCalc.Properties.Resources.skill_default;
                                            this.labelfourthIII.ForeColor = System.Drawing.Color.White;
                                            this.fourthIIICost.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(96)))), ((int)(((byte)(117)))));
                                        }
                                        if (skillvalue.Substring(19, 1) == "1")
                                        {
                                            this.labelfourthIII.Image = global::SkillCalc.Properties.Resources.skill_green;
                                            this.labelfourthIII.ForeColor = System.Drawing.Color.Black;
                                            this.fourthIIICost.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(171)))), ((int)(((byte)(48)))));
                                        }
                                    }
                                    break;
                                case "labelfourthIV":
                                    {
                                        if (skillvalue.Substring(20, 1) == "0")
                                        {
                                            this.labelfourthIV.Image = global::SkillCalc.Properties.Resources.skill_default;
                                            this.labelfourthIV.ForeColor = System.Drawing.Color.White;
                                            this.fourthIVCost.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(96)))), ((int)(((byte)(117)))));
                                        }
                                        if (skillvalue.Substring(20, 1) == "1")
                                        {
                                            this.labelfourthIV.Image = global::SkillCalc.Properties.Resources.skill_green;
                                            this.labelfourthIV.ForeColor = System.Drawing.Color.Black;
                                            this.fourthIVCost.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(171)))), ((int)(((byte)(48)))));
                                        }
                                    }
                                    break;
                                case "labelMaster":
                                    {
                                        if (skillvalue.Substring(22, 1) == "0")
                                        {
                                            this.labelMaster.Image = global::SkillCalc.Properties.Resources.skill_default;
                                            this.labelMaster.ForeColor = System.Drawing.Color.White;
                                            this.MasterCost.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(96)))), ((int)(((byte)(117)))));
                                        }
                                        if (skillvalue.Substring(22, 1) == "1")
                                        {
                                            this.labelMaster.Image = global::SkillCalc.Properties.Resources.skill_green;
                                            this.labelMaster.ForeColor = System.Drawing.Color.Black;
                                            this.MasterCost.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(171)))), ((int)(((byte)(48)))));
                                        }
                                    }
                                    break;
                            }
                        }
                        break;
                }
            }
        }
        private void updateDisplay()
        {
            if (professions.Contains(selectedprof))
            {
                string name = this.charName.Text;
                string skillvalue = getskills(name, selectedprof);

                if (skillvalue.Substring(0, 1) == "0") { labelColors("noviceDefault"); }
                if (skillvalue.Substring(0, 1) == "1") { labelColors("noviceGreen"); }
                if (skillvalue.Substring(0, 1) == "2") { labelColors("noviceYellow"); }

                if (skillvalue.Substring(2, 1) == "0") { labelColors("labelfirstIDefault"); }
                if (skillvalue.Substring(2, 1) == "1") { labelColors("labelfirstIGreen"); }
                if (skillvalue.Substring(2, 1) == "2") { labelColors("labelfirstIYellow"); }
                if (skillvalue.Substring(3, 1) == "0") { labelColors("labelfirstIIDefault"); }
                if (skillvalue.Substring(3, 1) == "1") { labelColors("labelfirstIIGreen"); }
                if (skillvalue.Substring(3, 1) == "2") { labelColors("labelfirstIIYellow"); }
                if (skillvalue.Substring(4, 1) == "0") { labelColors("labelfirstIIIDefault"); }
                if (skillvalue.Substring(4, 1) == "1") { labelColors("labelfirstIIIGreen"); }
                if (skillvalue.Substring(4, 1) == "2") { labelColors("labelfirstIIIYellow"); }
                if (skillvalue.Substring(5, 1) == "0") { labelColors("labelfirstIVDefault"); }
                if (skillvalue.Substring(5, 1) == "1") { labelColors("labelfirstIVGreen"); }
                if (skillvalue.Substring(5, 1) == "2") { labelColors("labelfirstIVYellow"); }

                if (skillvalue.Substring(7, 1) == "0") { labelColors("labelsecondIDefault"); }
                if (skillvalue.Substring(7, 1) == "1") { labelColors("labelsecondIGreen"); }
                if (skillvalue.Substring(7, 1) == "2") { labelColors("labelsecondIYellow"); }
                if (skillvalue.Substring(8, 1) == "0") { labelColors("labelsecondIIDefault"); }
                if (skillvalue.Substring(8, 1) == "1") { labelColors("labelsecondIIGreen"); }
                if (skillvalue.Substring(8, 1) == "2") { labelColors("labelsecondIIYellow"); }
                if (skillvalue.Substring(9, 1) == "0") { labelColors("labelsecondIIIDefault"); }
                if (skillvalue.Substring(9, 1) == "1") { labelColors("labelsecondIIIGreen"); }
                if (skillvalue.Substring(9, 1) == "2") { labelColors("labelsecondIIIYellow"); }
                if (skillvalue.Substring(10, 1) == "0") { labelColors("labelsecondIVDefault"); }
                if (skillvalue.Substring(10, 1) == "1") { labelColors("labelsecondIVGreen"); }
                if (skillvalue.Substring(10, 1) == "2") { labelColors("labelsecondIVYellow"); }

                if (skillvalue.Substring(12, 1) == "0") { labelColors("labelthirdIDefault"); }
                if (skillvalue.Substring(12, 1) == "1") { labelColors("labelthirdIGreen"); }
                if (skillvalue.Substring(12, 1) == "2") { labelColors("labelthirdIYellow"); }
                if (skillvalue.Substring(13, 1) == "0") { labelColors("labelthirdIIDefault"); }
                if (skillvalue.Substring(13, 1) == "1") { labelColors("labelthirdIIGreen"); }
                if (skillvalue.Substring(13, 1) == "2") { labelColors("labelthirdIIYellow"); }
                if (skillvalue.Substring(14, 1) == "0") { labelColors("labelthirdIIIDefault"); }
                if (skillvalue.Substring(14, 1) == "1") { labelColors("labelthirdIIIGreen"); }
                if (skillvalue.Substring(14, 1) == "2") { labelColors("labelthirdIIIYellow"); }
                if (skillvalue.Substring(15, 1) == "0") { labelColors("labelthirdIVDefault"); }
                if (skillvalue.Substring(15, 1) == "1") { labelColors("labelthirdIVGreen"); }
                if (skillvalue.Substring(15, 1) == "2") { labelColors("labelthirdIVYellow"); }

                if (skillvalue.Substring(17, 1) == "0") { labelColors("labelfourthIDefault"); }
                if (skillvalue.Substring(17, 1) == "1") { labelColors("labelfourthIGreen"); }
                if (skillvalue.Substring(17, 1) == "2") { labelColors("labelfourthIYellow"); }
                if (skillvalue.Substring(18, 1) == "0") { labelColors("labelfourthIIDefault"); }
                if (skillvalue.Substring(18, 1) == "1") { labelColors("labelfourthIIGreen"); }
                if (skillvalue.Substring(18, 1) == "2") { labelColors("labelfourthIIYellow"); }
                if (skillvalue.Substring(19, 1) == "0") { labelColors("labelfourthIIIDefault"); }
                if (skillvalue.Substring(19, 1) == "1") { labelColors("labelfourthIIIGreen"); }
                if (skillvalue.Substring(19, 1) == "2") { labelColors("labelfourthIIIYellow"); }
                if (skillvalue.Substring(20, 1) == "0") { labelColors("labelfourthIVDefault"); }
                if (skillvalue.Substring(20, 1) == "1") { labelColors("labelfourthIVGreen"); }
                if (skillvalue.Substring(20, 1) == "2") { labelColors("labelfourthIVYellow"); }

                if (skillvalue.Substring(22, 1) == "0") { labelColors("labelMasterDefault"); }
                if (skillvalue.Substring(22, 1) == "1") { labelColors("labelMasterGreen"); }
                if (skillvalue.Substring(22, 1) == "2") { labelColors("labelMasterYellow"); }
            }
        }
        private void labelColors(string label)
        {
            switch (label)
            {
                case "noviceDefault":
                    {
                        this.labelNovice.ForeColor = System.Drawing.Color.White;
                        this.NoviceCost.ForeColor = System.Drawing.Color.Yellow;
                        this.labelNovice.Image = global::SkillCalc.Properties.Resources.skill_default;
                        this.NoviceCost.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(96)))), ((int)(((byte)(117)))));
                    }
                    break;
                case "noviceGreen":
                    {
                        this.labelNovice.ForeColor = System.Drawing.Color.Black;
                        this.NoviceCost.ForeColor = System.Drawing.Color.Black;
                        this.labelNovice.Image = global::SkillCalc.Properties.Resources.skill_green;
                        this.NoviceCost.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(171)))), ((int)(((byte)(48)))));
                    }
                    break;
                case "noviceYellow":
                    {
                        this.labelNovice.ForeColor = System.Drawing.Color.Black;
                        this.NoviceCost.ForeColor = System.Drawing.Color.Black;
                        this.labelNovice.Image = global::SkillCalc.Properties.Resources.skill_yellow;
                        this.NoviceCost.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(206)))), ((int)(((byte)(129)))));
                    }
                    break;

                case "labelfirstIDefault":
                    {
                        this.labelfirstI.ForeColor = System.Drawing.Color.White;
                        this.firstICost.ForeColor = System.Drawing.Color.Yellow;
                        this.labelfirstI.Image = global::SkillCalc.Properties.Resources.skill_default;
                        this.firstICost.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(96)))), ((int)(((byte)(117)))));
                    }
                    break;
                case "labelfirstIGreen":
                    {
                        this.labelfirstI.ForeColor = System.Drawing.Color.Black;
                        this.firstICost.ForeColor = System.Drawing.Color.Black;
                        this.labelfirstI.Image = global::SkillCalc.Properties.Resources.skill_green;
                        this.firstICost.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(171)))), ((int)(((byte)(48)))));
                    }
                    break;
                case "labelfirstIYellow":
                    {
                        this.labelfirstI.ForeColor = System.Drawing.Color.Black;
                        this.firstICost.ForeColor = System.Drawing.Color.Black;
                        this.labelfirstI.Image = global::SkillCalc.Properties.Resources.skill_yellow;
                        this.firstICost.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(206)))), ((int)(((byte)(129)))));
                    }
                    break;
                case "labelfirstIIDefault":
                    {
                        this.labelfirstII.ForeColor = System.Drawing.Color.White;
                        this.firstIICost.ForeColor = System.Drawing.Color.Yellow;
                        this.labelfirstII.Image = global::SkillCalc.Properties.Resources.skill_default;
                        this.firstIICost.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(96)))), ((int)(((byte)(117)))));
                    }
                    break;
                case "labelfirstIIGreen":
                    {
                        this.labelfirstII.ForeColor = System.Drawing.Color.Black;
                        this.firstIICost.ForeColor = System.Drawing.Color.Black;
                        this.labelfirstII.Image = global::SkillCalc.Properties.Resources.skill_green;
                        this.firstIICost.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(171)))), ((int)(((byte)(48)))));
                    }
                    break;
                case "labelfirstIIYellow":
                    {
                        this.labelfirstII.ForeColor = System.Drawing.Color.Black;
                        this.firstIICost.ForeColor = System.Drawing.Color.Black;
                        this.labelfirstII.Image = global::SkillCalc.Properties.Resources.skill_yellow;
                        this.firstIICost.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(206)))), ((int)(((byte)(129)))));
                    }
                    break;
                case "labelfirstIIIDefault":
                    {
                        this.labelfirstIII.ForeColor = System.Drawing.Color.White;
                        this.firstIIICost.ForeColor = System.Drawing.Color.Yellow;
                        this.labelfirstIII.Image = global::SkillCalc.Properties.Resources.skill_default;
                        this.firstIIICost.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(96)))), ((int)(((byte)(117)))));
                    }
                    break;
                case "labelfirstIIIGreen":
                    {
                        this.labelfirstIII.ForeColor = System.Drawing.Color.Black;
                        this.firstIIICost.ForeColor = System.Drawing.Color.Black;
                        this.labelfirstIII.Image = global::SkillCalc.Properties.Resources.skill_green;
                        this.firstIIICost.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(171)))), ((int)(((byte)(48)))));
                    }
                    break;
                case "labelfirstIIIYellow":
                    {
                        this.labelfirstIII.ForeColor = System.Drawing.Color.Black;
                        this.firstIIICost.ForeColor = System.Drawing.Color.Black;
                        this.labelfirstIII.Image = global::SkillCalc.Properties.Resources.skill_yellow;
                        this.firstIIICost.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(206)))), ((int)(((byte)(129)))));
                    }
                    break;
                case "labelfirstIVDefault":
                    {
                        this.labelfirstIV.ForeColor = System.Drawing.Color.White;
                        this.firstIVCost.ForeColor = System.Drawing.Color.Yellow;
                        this.labelfirstIV.Image = global::SkillCalc.Properties.Resources.skill_default;
                        this.firstIVCost.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(96)))), ((int)(((byte)(117)))));
                    }
                    break;
                case "labelfirstIVGreen":
                    {
                        this.labelfirstIV.ForeColor = System.Drawing.Color.Black;
                        this.firstIVCost.ForeColor = System.Drawing.Color.Black;
                        this.labelfirstIV.Image = global::SkillCalc.Properties.Resources.skill_green;
                        this.firstIVCost.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(171)))), ((int)(((byte)(48)))));
                    }
                    break;
                case "labelfirstIVYellow":
                    {
                        this.labelfirstIV.ForeColor = System.Drawing.Color.Black;
                        this.firstIVCost.ForeColor = System.Drawing.Color.Black;
                        this.labelfirstIV.Image = global::SkillCalc.Properties.Resources.skill_yellow;
                        this.firstIVCost.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(206)))), ((int)(((byte)(129)))));
                    }
                    break;

                case "labelsecondIDefault":
                    {
                        this.labelsecondI.ForeColor = System.Drawing.Color.White;
                        this.secondICost.ForeColor = System.Drawing.Color.Yellow;
                        this.labelsecondI.Image = global::SkillCalc.Properties.Resources.skill_default;
                        this.secondICost.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(96)))), ((int)(((byte)(117)))));
                    }
                    break;
                case "labelsecondIGreen":
                    {
                        this.labelsecondI.ForeColor = System.Drawing.Color.Black;
                        this.secondICost.ForeColor = System.Drawing.Color.Black;
                        this.labelsecondI.Image = global::SkillCalc.Properties.Resources.skill_green;
                        this.secondICost.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(171)))), ((int)(((byte)(48)))));
                    }
                    break;
                case "labelsecondIYellow":
                    {
                        this.labelsecondI.ForeColor = System.Drawing.Color.Black;
                        this.secondICost.ForeColor = System.Drawing.Color.Black;
                        this.labelsecondI.Image = global::SkillCalc.Properties.Resources.skill_yellow;
                        this.secondICost.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(206)))), ((int)(((byte)(129)))));
                    }
                    break;
                case "labelsecondIIDefault":
                    {
                        this.labelsecondII.ForeColor = System.Drawing.Color.White;
                        this.secondIICost.ForeColor = System.Drawing.Color.Yellow;
                        this.labelsecondII.Image = global::SkillCalc.Properties.Resources.skill_default;
                        this.secondIICost.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(96)))), ((int)(((byte)(117)))));
                    }
                    break;
                case "labelsecondIIGreen":
                    {
                        this.labelsecondII.ForeColor = System.Drawing.Color.Black;
                        this.secondIICost.ForeColor = System.Drawing.Color.Black;
                        this.labelsecondII.Image = global::SkillCalc.Properties.Resources.skill_green;
                        this.secondIICost.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(171)))), ((int)(((byte)(48)))));
                    }
                    break;
                case "labelsecondIIYellow":
                    {
                        this.labelsecondII.ForeColor = System.Drawing.Color.Black;
                        this.secondIICost.ForeColor = System.Drawing.Color.Black;
                        this.labelsecondII.Image = global::SkillCalc.Properties.Resources.skill_yellow;
                        this.secondIICost.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(206)))), ((int)(((byte)(129)))));
                    }
                    break;
                case "labelsecondIIIDefault":
                    {
                        this.labelsecondIII.ForeColor = System.Drawing.Color.White;
                        this.secondIIICost.ForeColor = System.Drawing.Color.Yellow;
                        this.labelsecondIII.Image = global::SkillCalc.Properties.Resources.skill_default;
                        this.secondIIICost.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(96)))), ((int)(((byte)(117)))));
                    }
                    break;
                case "labelsecondIIIGreen":
                    {
                        this.labelsecondIII.ForeColor = System.Drawing.Color.Black;
                        this.secondIIICost.ForeColor = System.Drawing.Color.Black;
                        this.labelsecondIII.Image = global::SkillCalc.Properties.Resources.skill_green;
                        this.secondIIICost.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(171)))), ((int)(((byte)(48)))));
                    }
                    break;
                case "labelsecondIIIYellow":
                    {
                        this.labelsecondIII.ForeColor = System.Drawing.Color.Black;
                        this.secondIIICost.ForeColor = System.Drawing.Color.Black;
                        this.labelsecondIII.Image = global::SkillCalc.Properties.Resources.skill_yellow;
                        this.secondIIICost.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(206)))), ((int)(((byte)(129)))));
                    }
                    break;
                case "labelsecondIVDefault":
                    {
                        this.labelsecondIV.ForeColor = System.Drawing.Color.White;
                        this.secondIVCost.ForeColor = System.Drawing.Color.Yellow;
                        this.labelsecondIV.Image = global::SkillCalc.Properties.Resources.skill_default;
                        this.secondIVCost.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(96)))), ((int)(((byte)(117)))));
                    }
                    break;
                case "labelsecondIVGreen":
                    {
                        this.labelsecondIV.ForeColor = System.Drawing.Color.Black;
                        this.secondIVCost.ForeColor = System.Drawing.Color.Black;
                        this.labelsecondIV.Image = global::SkillCalc.Properties.Resources.skill_green;
                        this.secondIVCost.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(171)))), ((int)(((byte)(48)))));
                    }
                    break;
                case "labelsecondIVYellow":
                    {
                        this.labelsecondIV.ForeColor = System.Drawing.Color.Black;
                        this.secondIVCost.ForeColor = System.Drawing.Color.Black;
                        this.labelsecondIV.Image = global::SkillCalc.Properties.Resources.skill_yellow;
                        this.secondIVCost.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(206)))), ((int)(((byte)(129)))));
                    }
                    break;

                case "labelthirdIDefault":
                    {
                        this.labelthirdI.ForeColor = System.Drawing.Color.White;
                        this.thirdICost.ForeColor = System.Drawing.Color.Yellow;
                        this.labelthirdI.Image = global::SkillCalc.Properties.Resources.skill_default;
                        this.thirdICost.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(96)))), ((int)(((byte)(117)))));
                    }
                    break;
                case "labelthirdIGreen":
                    {
                        this.labelthirdI.ForeColor = System.Drawing.Color.Black;
                        this.thirdICost.ForeColor = System.Drawing.Color.Black;
                        this.labelthirdI.Image = global::SkillCalc.Properties.Resources.skill_green;
                        this.thirdICost.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(171)))), ((int)(((byte)(48)))));
                    }
                    break;
                case "labelthirdIYellow":
                    {
                        this.labelthirdI.ForeColor = System.Drawing.Color.Black;
                        this.thirdICost.ForeColor = System.Drawing.Color.Black;
                        this.labelthirdI.Image = global::SkillCalc.Properties.Resources.skill_yellow;
                        this.thirdICost.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(206)))), ((int)(((byte)(129)))));
                    }
                    break;
                case "labelthirdIIDefault":
                    {
                        this.labelthirdII.ForeColor = System.Drawing.Color.White;
                        this.thirdIICost.ForeColor = System.Drawing.Color.Yellow;
                        this.labelthirdII.Image = global::SkillCalc.Properties.Resources.skill_default;
                        this.thirdIICost.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(96)))), ((int)(((byte)(117)))));
                    }
                    break;
                case "labelthirdIIGreen":
                    {
                        this.labelthirdII.ForeColor = System.Drawing.Color.Black;
                        this.thirdIICost.ForeColor = System.Drawing.Color.Black;
                        this.labelthirdII.Image = global::SkillCalc.Properties.Resources.skill_green;
                        this.thirdIICost.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(171)))), ((int)(((byte)(48)))));
                    }
                    break;
                case "labelthirdIIYellow":
                    {
                        this.labelthirdII.ForeColor = System.Drawing.Color.Black;
                        this.thirdIICost.ForeColor = System.Drawing.Color.Black;
                        this.labelthirdII.Image = global::SkillCalc.Properties.Resources.skill_yellow;
                        this.thirdIICost.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(206)))), ((int)(((byte)(129)))));
                    }
                    break;
                case "labelthirdIIIDefault":
                    {
                        this.labelthirdIII.ForeColor = System.Drawing.Color.White;
                        this.thirdIIICost.ForeColor = System.Drawing.Color.Yellow;
                        this.labelthirdIII.Image = global::SkillCalc.Properties.Resources.skill_default;
                        this.thirdIIICost.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(96)))), ((int)(((byte)(117)))));
                    }
                    break;
                case "labelthirdIIIGreen":
                    {
                        this.labelthirdIII.ForeColor = System.Drawing.Color.Black;
                        this.thirdIIICost.ForeColor = System.Drawing.Color.Black;
                        this.labelthirdIII.Image = global::SkillCalc.Properties.Resources.skill_green;
                        this.thirdIIICost.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(171)))), ((int)(((byte)(48)))));
                    }
                    break;
                case "labelthirdIIIYellow":
                    {
                        this.labelthirdIII.ForeColor = System.Drawing.Color.Black;
                        this.thirdIIICost.ForeColor = System.Drawing.Color.Black;
                        this.labelthirdIII.Image = global::SkillCalc.Properties.Resources.skill_yellow;
                        this.thirdIIICost.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(206)))), ((int)(((byte)(129)))));
                    }
                    break;
                case "labelthirdIVDefault":
                    {
                        this.labelthirdIV.ForeColor = System.Drawing.Color.White;
                        this.thirdIVCost.ForeColor = System.Drawing.Color.Yellow;
                        this.labelthirdIV.Image = global::SkillCalc.Properties.Resources.skill_default;
                        this.thirdIVCost.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(96)))), ((int)(((byte)(117)))));
                    }
                    break;
                case "labelthirdIVGreen":
                    {
                        this.labelthirdIV.ForeColor = System.Drawing.Color.Black;
                        this.thirdIVCost.ForeColor = System.Drawing.Color.Black;
                        this.labelthirdIV.Image = global::SkillCalc.Properties.Resources.skill_green;
                        this.thirdIVCost.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(171)))), ((int)(((byte)(48)))));
                    }
                    break;
                case "labelthirdIVYellow":
                    {
                        this.labelthirdIV.ForeColor = System.Drawing.Color.Black;
                        this.thirdIVCost.ForeColor = System.Drawing.Color.Black;
                        this.labelthirdIV.Image = global::SkillCalc.Properties.Resources.skill_yellow;
                        this.thirdIVCost.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(206)))), ((int)(((byte)(129)))));
                    }
                    break;

                case "labelfourthIDefault":
                    {
                        this.labelfourthI.ForeColor = System.Drawing.Color.White;
                        this.fourthICost.ForeColor = System.Drawing.Color.Yellow;
                        this.labelfourthI.Image = global::SkillCalc.Properties.Resources.skill_default;
                        this.fourthICost.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(96)))), ((int)(((byte)(117)))));
                    }
                    break;
                case "labelfourthIGreen":
                    {
                        this.labelfourthI.ForeColor = System.Drawing.Color.Black;
                        this.fourthICost.ForeColor = System.Drawing.Color.Black;
                        this.labelfourthI.Image = global::SkillCalc.Properties.Resources.skill_green;
                        this.fourthICost.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(171)))), ((int)(((byte)(48)))));
                    }
                    break;
                case "labelfourthIYellow":
                    {
                        this.labelfourthI.ForeColor = System.Drawing.Color.Black;
                        this.fourthICost.ForeColor = System.Drawing.Color.Black;
                        this.labelfourthI.Image = global::SkillCalc.Properties.Resources.skill_yellow;
                        this.fourthICost.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(206)))), ((int)(((byte)(129)))));
                    }
                    break;
                case "labelfourthIIDefault":
                    {
                        this.labelfourthII.ForeColor = System.Drawing.Color.White;
                        this.fourthIICost.ForeColor = System.Drawing.Color.Yellow;
                        this.labelfourthII.Image = global::SkillCalc.Properties.Resources.skill_default;
                        this.fourthIICost.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(96)))), ((int)(((byte)(117)))));
                    }
                    break;
                case "labelfourthIIGreen":
                    {
                        this.labelfourthII.ForeColor = System.Drawing.Color.Black;
                        this.fourthIICost.ForeColor = System.Drawing.Color.Black;
                        this.labelfourthII.Image = global::SkillCalc.Properties.Resources.skill_green;
                        this.fourthIICost.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(171)))), ((int)(((byte)(48)))));
                    }
                    break;
                case "labelfourthIIYellow":
                    {
                        this.labelfourthII.ForeColor = System.Drawing.Color.Black;
                        this.fourthIICost.ForeColor = System.Drawing.Color.Black;
                        this.labelfourthII.Image = global::SkillCalc.Properties.Resources.skill_yellow;
                        this.fourthIICost.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(206)))), ((int)(((byte)(129)))));
                    }
                    break;
                case "labelfourthIIIDefault":
                    {
                        this.labelfourthIII.ForeColor = System.Drawing.Color.White;
                        this.fourthIIICost.ForeColor = System.Drawing.Color.Yellow;
                        this.labelfourthIII.Image = global::SkillCalc.Properties.Resources.skill_default;
                        this.fourthIIICost.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(96)))), ((int)(((byte)(117)))));
                    }
                    break;
                case "labelfourthIIIGreen":
                    {
                        this.labelfourthIII.ForeColor = System.Drawing.Color.Black;
                        this.fourthIIICost.ForeColor = System.Drawing.Color.Black;
                        this.labelfourthIII.Image = global::SkillCalc.Properties.Resources.skill_green;
                        this.fourthIIICost.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(171)))), ((int)(((byte)(48)))));
                    }
                    break;
                case "labelfourthIIIYellow":
                    {
                        this.labelfourthIII.ForeColor = System.Drawing.Color.Black;
                        this.fourthIIICost.ForeColor = System.Drawing.Color.Black;
                        this.labelfourthIII.Image = global::SkillCalc.Properties.Resources.skill_yellow;
                        this.fourthIIICost.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(206)))), ((int)(((byte)(129)))));
                    }
                    break;
                case "labelfourthIVDefault":
                    {
                        this.labelfourthIV.ForeColor = System.Drawing.Color.White;
                        this.fourthIVCost.ForeColor = System.Drawing.Color.Yellow;
                        this.labelfourthIV.Image = global::SkillCalc.Properties.Resources.skill_default;
                        this.fourthIVCost.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(96)))), ((int)(((byte)(117)))));
                    }
                    break;
                case "labelfourthIVGreen":
                    {
                        this.labelfourthIV.ForeColor = System.Drawing.Color.Black;
                        this.fourthIVCost.ForeColor = System.Drawing.Color.Black;
                        this.labelfourthIV.Image = global::SkillCalc.Properties.Resources.skill_green;
                        this.fourthIVCost.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(171)))), ((int)(((byte)(48)))));
                    }
                    break;
                case "labelfourthIVYellow":
                    {
                        this.labelfourthIV.ForeColor = System.Drawing.Color.Black;
                        this.fourthIVCost.ForeColor = System.Drawing.Color.Black;
                        this.labelfourthIV.Image = global::SkillCalc.Properties.Resources.skill_yellow;
                        this.fourthIVCost.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(206)))), ((int)(((byte)(129)))));
                    }
                    break;

                case "labelMasterDefault":
                    {
                        this.labelMaster.ForeColor = System.Drawing.Color.White;
                        this.MasterCost.ForeColor = System.Drawing.Color.Yellow;
                        this.labelMaster.Image = global::SkillCalc.Properties.Resources.skill_default;
                        this.MasterCost.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(96)))), ((int)(((byte)(117)))));
                    }
                    break;
                case "labelMasterGreen":
                    {
                        this.labelMaster.ForeColor = System.Drawing.Color.Black;
                        this.MasterCost.ForeColor = System.Drawing.Color.Black;
                        this.labelMaster.Image = global::SkillCalc.Properties.Resources.skill_green;
                        this.MasterCost.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(171)))), ((int)(((byte)(48)))));
                    }
                    break;
                case "labelMasterYellow":
                    {
                        this.labelMaster.ForeColor = System.Drawing.Color.Black;
                        this.MasterCost.ForeColor = System.Drawing.Color.Black;
                        this.labelMaster.Image = global::SkillCalc.Properties.Resources.skill_yellow;
                        this.MasterCost.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(206)))), ((int)(((byte)(129)))));
                    }
                    break;
            }
        }
    }
}
