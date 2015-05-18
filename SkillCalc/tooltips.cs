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
using System.Linq;
using System.Windows.Forms;

namespace SkillCalc
{
    public partial class Main : Form
    {
        // Really not pleased with this method. But I have no idea how to read the tre files.
        // One could extract the files from them and read those, but that will not work for later plans for this tool.
        // Need the ability to read from the base tre files much like Sytner's Editer does.
        // Alternatively, have a export to sqlite for all data from tre files, and read data that way.
        // For now this is disabled. Enable by removing the return; in tooltipbox()
        private string tooltiptext(string sender)
        {
            switch (sender)
            {
                case "novice-header":
                    {
                        if (selectedprof == professions[0])
                        {
                            string tiptext = "(Novice Artisan)";
                            return tiptext;
                        }
                        break;
                    }
                case "novice":
                    {
                        if (selectedprof == professions[0])
                        {
                            string tiptext = "\r\n\r\n" +
                                             "A Novice Artisan has the ability to find and extract the fundamental types of raw material used in item\r\n" +
                                             "continue her studies in engineering, domestic arts, business, and resource surveying.  Each of these\r\n" +
                                             "paths leads to different elite crafting professions.\r\n" +
                                             "\r\n" +
                                             "This skill requires 15 skill points to learn.\r\n";
                            return tiptext;
                        }
                        break;
                    }
                case "labelfirstI":
                    {
                        if (selectedprof == professions[0])
                        {
                            string tiptext = "Engineering involves the construction of complex devices such as weapons, armor, and tools.  This\r\n" +
                                             "skill series leads to the Architect, Armorsmith, Weaponsmith, and Droid Engineer professions.\r\n" +
                                             "\r\n" +
                                             "This skill requires 2 skill points to learn.\r\n" +
                                             "This skill requires 500 points of General Crafting Experience.\r\n\r\n";
                            return tiptext;
                        }
                        break;
                    }
                case "labelfirstII":
                    {
                        if (selectedprof == professions[0])
                        {
                            string tiptext = "Engineering involves the construction of complex devices such as weapons, armor, and tools.  This\r\n" +
                                             "skill series leads to the Architect, Armorsmith, Weaponsmith, and Droid Engineer professions.\r\n" +
                                             "\r\n" +
                                             "This skill requires 3 skill points to learn.\r\n" +
                                             "This skill requires 1000 points of General Crafting Experience.\r\n\r\n";
                            return tiptext;
                        }
                        break;
                    }
                case "labelfirstIII":
                    {
                        if (selectedprof == professions[0])
                        {
                            string tiptext = "Engineering involves the construction of complex devices such as weapons, armor, and tools.  This\r\n" +
                                             "skill series leads to the Architect, Armorsmith, Weaponsmith, and Droid Engineer professions.\r\n" +
                                             "\r\n" +
                                             "This skill requires 4 skill points to learn.\r\n" +
                                             "This skill requires 3000 points of General Crafting Experience.\r\n\r\n";
                            return tiptext;
                        }
                        break;
                    }
                case "labelfirstIV-header":
                    {
                        if (selectedprof == professions[0])
                        {
                            string tiptext = "(Engineer)";
                            return tiptext;
                        }
                        break;
                    }
                case "labelfirstIV":
                    {
                        if (selectedprof == professions[0])
                        {
                            string tiptext = "\r\n\r\n" +
                                             "Engineering involves the construction of complex devices such as weapons, armor, and tools.  This\r\n" +
                                             "skill series leads to the Architect, Armorsmith, Weaponsmith, and Droid Engineer professions.\r\n" +
                                             "\r\n" +
                                             "This skill requires 5 skill points to learn.\r\n" +
                                             "This skill requires 6000 points of General Crafting Experience.\r\n\r\n";
                            return tiptext;
                        }
                        break;
                    }
                case "labelsecondI":
                    {
                        if (selectedprof == professions[0])
                        {
                            string tiptext = "Simple Cooking involves the study of basic culinary techniques.  In addition to the study of food, the\r\n" +
                                             "Artisan begins working with clothing.\r\n" +
                                             "\r\n" +
                                             "This skill requires 2 skill points to learn.\r\n" +
                                             "This skill requires 500 points of General Crafting Experience.\r\n\r\n";
                            return tiptext;
                        }
                        break;
                    }
                case "labelsecondII":
                    {
                        if (selectedprof == professions[0])
                        {
                            string tiptext = "Simple Tailoring focuses on improving the Artisan's ability to create clothing.  The Artisan also\r\n" +
                                             "increases their knowledge of food preparation.\r\n" +
                                             "\r\n" +
                                             "This skill requires 3 skill points to learn.\r\n" +
                                             "This skill requires 1000 points of General Crafting Experience.\r\n\r\n";
                            return tiptext;
                        }
                        break;
                    }
                case "labelsecondIII":
                    {
                        if (selectedprof == professions[0])
                        {
                            string tiptext = "Basic Desserts involves the study of various cultural dessert-making methods.  The study of tailoring\r\n" +
                                             "also continues.\r\n" +
                                             "\r\n" +
                                             "This skill requires 4 skill points to learn.\r\n" +
                                             "This skill requires 3000 points of General Crafting Experience.\r\n\r\n";
                            return tiptext;
                        }
                        break;
                    }
                case "labelsecondIV-header":
                    {
                        if (selectedprof == professions[0])
                        {
                            string tiptext = "(Homemaker)";
                            return tiptext;
                        }
                        break;
                    }
                case "labelsecondIV":
                    {
                        if (selectedprof == professions[0])
                        {
                            string tiptext = "\r\n\r\n" +
                                             "At this skill level, the Artisan gains the ability to craft a clothing repair kit.  With this tool the artisan\r\n" +
                                             "can keep any piece of clothing in top shape.  The Artisan also furthers their food-making knowledge.\r\n" +
                                             "At this point, the Artisan gains access to two elite professions: Tailor and Chef.\r\n" +
                                             "\r\n" +
                                             "This skill requires 5 skill points to learn.\r\n" +
                                             "This skill requires 6000 points of General Crafting Experience.\r\n\r\n";
                            return tiptext;
                        }
                        break;
                    }
                case "labelthirdI":
                    {
                        if (selectedprof == professions[0])
                        {
                            string tiptext = "With the \"Access Fees\" skill, an Artisan may place an access fee on any public building they own.\r\n" +
                                             "People who wish to use the building must pay the access fee to be granted access for a selected\r\n" +
                                             "amount of time.\r\n" +
                                             "\r\n" +
                                             "This skill requires 2 skill points to learn.\r\n" +
                                             "This skill requires 500 points of General Crafting Experience.\r\n\r\n";
                            return tiptext;
                        }
                        break;
                    }
                case "labelthirdII":
                    {
                        if (selectedprof == professions[0])
                        {
                            string tiptext = "The \"Advanced Sales\" skill allows you to place premium auctions at a bazaar terminal.  Premium\r\n" +
                                             "auctions cost more than regular auctions, but are highlighted and marked out from the other auctions\r\n" +
                                             "on the browse list.\r\n" +
                                             "\r\n" +
                                             "This skill requires 3 skill points to learn.\r\n" +
                                             "This skill requires 1000 points of General Crafting Experience.\r\n\r\n";
                            return tiptext;
                        }
                        break;
                    }
                case "labelthirdIII":
                    {
                        if (selectedprof == professions[0])
                        {
                            string tiptext = "At the \"Business Ownership\" skill level, an Artisan can place a vendor in any public structure they\r\n" +
                                             "own.  Initially the Artisan may only select a bulky machine style vendor, but as the Hiring skill mod\r\n" +
                                             "increases, more vendor types become available.  To place a vendor, select \"Create Vendor\" from your\r\n" +
                                             "structure's management terminal.\r\n" +
                                             "\r\n" +
                                             "This skill requires 4 skill points to learn.\r\n" +
                                             "This skill requires 3000 points of General Crafting Experience.\r\n\r\n";
                            return tiptext;
                        }
                        break;
                    }
                case "labelthirdIV-header":
                    {
                        if (selectedprof == professions[0])
                        {
                            string tiptext = "(Businessman)";
                            return tiptext;
                        }
                        break;
                    }
                case "labelthirdIV":
                    {
                        if (selectedprof == professions[0])
                        {
                            string tiptext = "\r\n\r\n" +
                                             "At this skill level the Artisan earns more vendor types to choose from.\r\n" +
                                             "\r\n" +
                                             "This skill requires 5 skill points to learn.\r\n" +
                                             "This skill requires 6000 points of General Crafting Experience.\r\n\r\n";
                            return tiptext;
                        }
                        break;
                    }
                case "labelfourthI":
                    {
                        if (selectedprof == professions[0])
                        {
                            string tiptext = "Each level of surveying increases the yield per sample, the chance to succeed at sampling, and the\r\n" +
                                             "range the Artisan can survey.\r\n" +
                                             "\r\n" +
                                             "This skill requires 2 skill points to learn.\r\n" +
                                             "This skill requires 500 points of General Crafting Experience.\r\n\r\n";
                            return tiptext;
                        }
                        break;
                    }
                case "labelfourthII":
                    {
                        if (selectedprof == professions[0])
                        {
                            string tiptext = "Each level of surveying increases the yield per sample, the chance to succeed at sampling, and the\r\n" +
                                             "range the Artisan can survey.\r\n" +
                                             "\r\n" +
                                             "This skill requires 3 skill points to learn.\r\n" +
                                             "This skill requires 2500 points of General Crafting Experience.\r\n\r\n";
                            return tiptext;
                        }
                        break;
                    }
                case "labelfourthIII":
                    {
                        if (selectedprof == professions[0])
                        {
                            string tiptext = "Each level of surveying increases the yield per sample, the chance to succeed at sampling, and the\r\n" +
                                             "range the Artisan can survey.\r\n" +
                                             "\r\n" +
                                             "This skill requires 4 skill points to learn.\r\n" +
                                             "This skill requires 5000 points of General Crafting Experience.\r\n\r\n";
                            return tiptext;
                        }
                        break;
                    }
                case "labelfourthIV-header":
                    {
                        if (selectedprof == professions[0])
                        {
                            string tiptext = "(Surveyor)";
                            return tiptext;
                        }
                        break;
                    }
                case "labelfourthIV":
                    {
                        if (selectedprof == professions[0])
                        {
                            string tiptext = "\r\n\r\n" +
                                             "Each level of surveying increases the yield per sample, the chance to succeed at sampling, and the\r\n" +
                                             "range the Artisan can survey.\r\n" +
                                             "\r\n" +
                                             "This skill requires 5 skill points to learn.\r\n" +
                                             "This skill requires 10000 points of General Crafting Experience.\r\n\r\n";
                            return tiptext;
                        }
                        break;
                    }
                case "master-header":
                    {
                        if (selectedprof == professions[0])
                        {
                            string tiptext = "(Master Artisan)";
                            return tiptext;
                        }
                        break;
                    }
                case "master":
                    {
                        if (selectedprof == professions[0])
                        {
                            string tiptext = "\r\n\r\n" +
                                             "A Master Artisan has well-rounded knowledge in engineering, domestic arts, business, and surveying.\r\n" +
                                             "They are able to design complex microcircuitry and gather the rare materials necessary to build\r\n" +
                                             "them.  Their work forms the basis of components used in crafting elite items like droids, weapons, and\r\n" +
                                             "armor.\r\n" +
                                             "\r\n" +
                                             "This skill requires 6 skill points to learn.\r\n\r\n";
                            return tiptext;
                        }
                        break;
                    }
            }
            return "ToolTip Incomplete.";
        }
        private void tooltipbox(string showstate, string sender)
        {
            return;
            if (professions.Contains(selectedprof))
            {
                switch (showstate)
                {
                    case "show":
                        {
                            switch (sender)
                            {
                                case "novice":
                                    {
                                        this.toolTipContentBox.Visible = true;
                                        this.toolTipHeaderBox.Visible = true;
                                        this.toolTipContentBox.Text = tooltiptext("novice");
                                        this.toolTipHeaderBox.Text = tooltiptext("novice-header");
                                        this.toolTipHeaderBox.Location = new System.Drawing.Point(this.labelNovice.Location.X - 49, this.labelNovice.Location.Y + 51);
                                        this.toolTipContentBox.Location = new System.Drawing.Point(this.labelNovice.Location.X - 50, this.labelNovice.Location.Y + 50);
                                        this.toolTipHeaderBox.BringToFront();
                                    }
                                    break;
                                case "labelfirstI":
                                    {
                                        this.toolTipContentBox.Visible = true;
                                        this.toolTipContentBox.Text = tooltiptext("labelfirstI");
                                        this.toolTipContentBox.Location = new System.Drawing.Point(this.labelfirstI.Location.X + 25, this.labelfirstI.Location.Y + 50);
                                    }
                                    break;
                                case "labelfirstII":
                                    {
                                        this.toolTipContentBox.Visible = true;
                                        this.toolTipContentBox.Text = tooltiptext("labelfirstII");
                                        this.toolTipContentBox.Location = new System.Drawing.Point(this.labelfirstII.Location.X + 25, this.labelfirstII.Location.Y + 50);
                                    }
                                    break;
                                case "labelfirstIII":
                                    {
                                        this.toolTipContentBox.Visible = true;
                                        this.toolTipContentBox.Text = tooltiptext("labelfirstIII");
                                        this.toolTipContentBox.Location = new System.Drawing.Point(this.labelfirstIII.Location.X + 25, this.labelfirstIII.Location.Y + 50);
                                    }
                                    break;
                                case "labelfirstIV":
                                    {
                                        this.toolTipContentBox.Visible = true;
                                        this.toolTipHeaderBox.Visible = true;
                                        this.toolTipContentBox.Text = tooltiptext("labelfirstIV");
                                        this.toolTipHeaderBox.Text = tooltiptext("labelfirstIV-header");
                                        this.toolTipHeaderBox.Location = new System.Drawing.Point(this.labelfirstIV.Location.X + 24, this.labelfirstIV.Location.Y + 51);
                                        this.toolTipContentBox.Location = new System.Drawing.Point(this.labelfirstIV.Location.X + 25, this.labelfirstIV.Location.Y + 50);
                                        this.toolTipHeaderBox.BringToFront();
                                    }
                                    break;
                                case "labelsecondI":
                                    {
                                        this.toolTipContentBox.Visible = true;
                                        this.toolTipContentBox.Text = tooltiptext("labelsecondI");
                                        this.toolTipContentBox.Location = new System.Drawing.Point(this.labelsecondI.Location.X + 25, this.labelsecondI.Location.Y + 50);
                                    }
                                    break;
                                case "labelsecondII":
                                    {
                                        this.toolTipContentBox.Visible = true;
                                        this.toolTipContentBox.Text = tooltiptext("labelsecondII");
                                        this.toolTipContentBox.Location = new System.Drawing.Point(this.labelsecondII.Location.X + 25, this.labelsecondII.Location.Y + 50);
                                    }
                                    break;
                                case "labelsecondIII":
                                    {
                                        this.toolTipContentBox.Visible = true;
                                        this.toolTipContentBox.Text = tooltiptext("labelsecondIII");
                                        this.toolTipContentBox.Location = new System.Drawing.Point(this.labelsecondIII.Location.X + 25, this.labelsecondIII.Location.Y + 50);
                                    }
                                    break;
                                case "labelsecondIV":
                                    {
                                        this.toolTipContentBox.Visible = true;
                                        this.toolTipHeaderBox.Visible = true;
                                        this.toolTipContentBox.Text = tooltiptext("labelsecondIV");
                                        this.toolTipHeaderBox.Text = tooltiptext("labelsecondIV-header");
                                        this.toolTipHeaderBox.Location = new System.Drawing.Point(this.labelsecondIV.Location.X + 24, this.labelsecondIV.Location.Y + 51);
                                        this.toolTipContentBox.Location = new System.Drawing.Point(this.labelsecondIV.Location.X + 25, this.labelsecondIV.Location.Y + 50);
                                        this.toolTipHeaderBox.BringToFront();
                                    }
                                    break;
                                case "labelthirdI":
                                    {
                                        this.toolTipContentBox.Visible = true;
                                        this.toolTipContentBox.Text = tooltiptext("labelthirdI");
                                        this.toolTipContentBox.Location = new System.Drawing.Point(this.labelthirdI.Location.X - 127, this.labelthirdI.Location.Y + 50);
                                    }
                                    break;
                                case "labelthirdII":
                                    {
                                        this.toolTipContentBox.Visible = true;
                                        this.toolTipContentBox.Text = tooltiptext("labelthirdII");
                                        this.toolTipContentBox.Location = new System.Drawing.Point(this.labelthirdII.Location.X - 127, this.labelthirdII.Location.Y + 50);
                                    }
                                    break;
                                case "labelthirdIII":
                                    {
                                        this.toolTipContentBox.Visible = true;
                                        this.toolTipContentBox.Text = tooltiptext("labelthirdIII");
                                        this.toolTipContentBox.Location = new System.Drawing.Point(this.labelthirdIII.Location.X - 127, this.labelthirdIII.Location.Y + 50);
                                    }
                                    break;
                                case "labelthirdIV":
                                    {
                                        this.toolTipContentBox.Visible = true;
                                        this.toolTipHeaderBox.Visible = true;
                                        this.toolTipContentBox.Text = tooltiptext("labelthirdIV");
                                        this.toolTipHeaderBox.Text = tooltiptext("labelthirdIV-header");
                                        this.toolTipHeaderBox.Location = new System.Drawing.Point(this.labelthirdIV.Location.X - 126, this.labelthirdIV.Location.Y + 51);
                                        this.toolTipContentBox.Location = new System.Drawing.Point(this.labelthirdIV.Location.X - 127, this.labelthirdIV.Location.Y + 50);
                                        this.toolTipHeaderBox.BringToFront();
                                    }
                                    break;
                                case "labelfourthI":
                                    {
                                        this.toolTipContentBox.Visible = true;
                                        this.toolTipContentBox.Text = tooltiptext("labelfourthI");
                                        this.toolTipContentBox.Location = new System.Drawing.Point(this.labelfourthI.Location.X - 300, this.labelfourthI.Location.Y + 50);
                                    }
                                    break;
                                case "labelfourthII":
                                    {
                                        this.toolTipContentBox.Visible = true;
                                        this.toolTipContentBox.Text = tooltiptext("labelfourthII");
                                        this.toolTipContentBox.Location = new System.Drawing.Point(this.labelfourthII.Location.X - 300, this.labelfourthII.Location.Y + 50);
                                    }
                                    break;
                                case "labelfourthIII":
                                    {
                                        this.toolTipContentBox.Visible = true;
                                        this.toolTipContentBox.Text = tooltiptext("labelfourthIII");
                                        this.toolTipContentBox.Location = new System.Drawing.Point(this.labelfourthIII.Location.X - 300, this.labelfourthIII.Location.Y + 50);
                                    }
                                    break;
                                case "labelfourthIV":
                                    {
                                        this.toolTipContentBox.Visible = true;
                                        this.toolTipHeaderBox.Visible = true;
                                        this.toolTipContentBox.Text = tooltiptext("labelfourthIV");
                                        this.toolTipHeaderBox.Text = tooltiptext("labelfourthIV-header");
                                        this.toolTipHeaderBox.Location = new System.Drawing.Point(this.labelfourthIV.Location.X - 299, this.labelfourthIV.Location.Y + 51);
                                        this.toolTipContentBox.Location = new System.Drawing.Point(this.labelfourthIV.Location.X - 300, this.labelfourthIV.Location.Y + 50);
                                        this.toolTipHeaderBox.BringToFront();
                                    }
                                    break;
                                case "master":
                                    {
                                        this.toolTipHeaderBox.Visible = true;
                                        this.toolTipContentBox.Visible = true;
                                        this.toolTipContentBox.Text = tooltiptext("master");
                                        this.toolTipHeaderBox.Text = tooltiptext("master-header");
                                        this.toolTipHeaderBox.Location = new System.Drawing.Point(this.labelMaster.Location.X - 49, this.labelMaster.Location.Y + 51);
                                        this.toolTipContentBox.Location = new System.Drawing.Point(this.labelMaster.Location.X -50, this.labelMaster.Location.Y + 50);
                                        this.toolTipHeaderBox.BringToFront();
                                    }
                                    break;
                            }
                        }
                        break;
                    case "hide":
                        {
                            this.toolTipContentBox.Visible = false;
                            this.toolTipContentBox.Text = "";
                            this.toolTipHeaderBox.Visible = false;
                            this.toolTipHeaderBox.Text = "";
                        }
                        break;
                }
            }
        }
    }
}