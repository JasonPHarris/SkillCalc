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
using System.Linq;
using System.Windows.Forms;

namespace SkillCalc
{
    public partial class Main : Form
    {
        private void clearDebug_Click(object sender, EventArgs e) { this.debugbox.Text = "DEBUG:::"; }
        private void help_Click(object sender, EventArgs e)
        {
            if (showhelp == false) { showhelp = true; this.help.Image = global::SkillCalc.Properties.Resources.show_help; }
            else { showhelp = false; this.help.Image = null; }
        }

        // Reset to default view handlers.
        // This is also used to clear between clicks
        // so that the new selection is forced to display correctly.
        private void pageReset_Click(object sender, EventArgs e) { formReset(); }
        private void charName_Click(object sender, EventArgs e) { refreshnames(); }
        private void charSpecies_Click(object sender, EventArgs e)
        {
            cleartabs();
            clearskills();
            clearprofselect();
            clearproftext();
            this.headerSpecies.Visible = true;
            this.charSpecies.Image = global::SkillCalc.Properties.Resources.tabs_selected;
            this.charSpecies.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(63)))), ((int)(((byte)(75)))));
            displayspecies();
            clearclicked();
            clearpointsicon();
        }
        private void charExport_Click(object sender, EventArgs e) { }
        private void charSave_Click(object sender, EventArgs e) { if (charSave.Visible) { savename(); } }
        private void charDelete_Click(object sender, EventArgs e) { dodelete(); }
        private void charSaveButton_Click(object sender, EventArgs e) { if (charSave.Visible) { savename(); } }

        private void pageBasic_Click(object sender, EventArgs e)
        {
            //cleartabs();
            //viewtab = "Basic";
            //this.pageBasic.Image = global::SkillCalc.Properties.Resources.tabs_selected;
            //this.pageBasic.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(63)))), ((int)(((byte)(75)))));
            //clearclicked();
            //clearpointsicon();
            //displayMenu(viewtab);
            viewBasic();
        }
        private void pageAdvanced_Click(object sender, EventArgs e) { advanced(); }
        private void pageForce_Click(object sender, EventArgs e)
        {
            cleartabs();
            viewtab = "Force";
            this.pageForce.Image = global::SkillCalc.Properties.Resources.tabs_selected;
            this.pageForce.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(63)))), ((int)(((byte)(75)))));
            clearclicked();
            clearpointsicon();
            displayMenu(viewtab);
        }
        private void pageJedi_Click(object sender, EventArgs e)
        {
            cleartabs();
            viewtab = "Jedi";
            this.pageJedi.Image = global::SkillCalc.Properties.Resources.tabs_selected;
            this.pageJedi.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(63)))), ((int)(((byte)(75)))));
            clearclicked();
            clearpointsicon();
            displayMenu(viewtab);
        }

        private void preset1_Click(object sender, EventArgs e)
        {
            formReset();
            string name = "Character";

            setTK(name);
            setDoc(name);
            advanced();
            calcpoints(name);
        }
        private void preset2_Click(object sender, EventArgs e)
        {
            formReset();
            string name = "Character";

            setTK(name);
            setPistol(name);
            setSmug(name);
            advanced();
            calcpoints(name);
        }
        private void preset3_Click(object sender, EventArgs e)
        {
            formReset();
            string name = "Character";

            setTK(name);
            setComm(name);
            advanced();
            calcpoints(name);
        }
        private void preset4_Click(object sender, EventArgs e)
        {
            formReset();
            string name = "Character";

            setTK(name);
            setCH(name);
            advanced();
            calcpoints(name);
        }
        private void preset5_Click(object sender, EventArgs e)
        {
            formReset();
            string name = "Character";

            setBE(name);
            setCH(name);
            advanced();
            calcpoints(name);
        }
        private void preset6_Click(object sender, EventArgs e)
        {
            formReset();
            string name = "Character";

            setCM(name);
            setDoc(name);
            advanced();
            calcpoints(name);
        }
        private void preset7_Click(object sender, EventArgs e)
        {
            formReset();
            string name = "Character";

            setASmith(name);
            setWSmith(name);
            setTailor(name);
            advanced();
            calcpoints(name);
        }
        private void preset8_Click(object sender, EventArgs e)
        {
            formReset();
            string name = "Character";

            setDance(name);
            setID(name);
            setMus(name);
            string tempskillvalue = getskills(name, professions[2]);
            string tempskillvalue1 = ReplaceAt(tempskillvalue, 22, '1');
            updateskills(name, professions[2], tempskillvalue1);
            advanced();
            calcpoints(name);
        }

        // Highlight pressed buttons that don't stay selected.
        private void charExport_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.charExport.Image = global::SkillCalc.Properties.Resources.tabs_selected;
                this.charExport.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(63)))), ((int)(((byte)(75)))));
            }
        }
        private void charExport_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.charExport.Image = global::SkillCalc.Properties.Resources.tabs_unselect;
                this.charExport.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(244)))), ((int)(((byte)(255)))));
            }
        }
        private void charSave_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.charSave.Image = global::SkillCalc.Properties.Resources.characterwindbttn_selected;
                this.charSave.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(63)))), ((int)(((byte)(75)))));
            }
        }
        private void charSave_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.charSave.Image = global::SkillCalc.Properties.Resources.characterwindbttn;
                this.charSave.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(244)))), ((int)(((byte)(255)))));
            }
        }
        private void charDelete_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.charDelete.Image = global::SkillCalc.Properties.Resources.characterwindbttn_selected;
                this.charDelete.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(63)))), ((int)(((byte)(75)))));
            }
        }
        private void charDelete_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.charDelete.Image = global::SkillCalc.Properties.Resources.characterwindbttn;
                this.charDelete.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(244)))), ((int)(((byte)(255)))));
            }
        }
        private void pageReset_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.pageReset.Image = global::SkillCalc.Properties.Resources.tabs_selected;
                this.pageReset.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(63)))), ((int)(((byte)(75)))));
            }
        }
        private void pageReset_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.pageReset.Image = global::SkillCalc.Properties.Resources.tabs_unselect;
                this.pageReset.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(244)))), ((int)(((byte)(255)))));
            }
        }

        // Slides names around based on number of saved names and arrows clicked.
        private void leftArrow_Click(object sender, EventArgs e) { if (scroll != 0) { namescroll(scroll - 1); } }
        private void rightArrow_Click(object sender, EventArgs e) 
        {
            if (scroll <= 11 && namelist.Count > 8) { namescroll(scroll + 1); }
            else if (scroll >= 12) { namescroll(12); }
        }
        private void namescroll1_Click(object sender, EventArgs e)
        {
            if (namescroll1.Text != "")
            {
                clearpointsicon();
                clearselectednamescroll();
                this.namescroll1.Image = global::SkillCalc.Properties.Resources.header_tabs_selected;
                this.namescroll1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(63)))), ((int)(((byte)(75)))));
                handlenames(namescroll1.Text);
                updateDisplay();
                calcpoints(namescroll1.Text);
                refreshIcons(viewtab);
            }
        }
        private void namescroll2_Click(object sender, EventArgs e)
        {
            if (namescroll2.Text != "")
            {
                clearpointsicon();
                clearselectednamescroll();
                this.namescroll2.Image = global::SkillCalc.Properties.Resources.header_tabs_selected;
                this.namescroll2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(63)))), ((int)(((byte)(75)))));
                handlenames(namescroll2.Text);
                updateDisplay();
                calcpoints(namescroll2.Text);
                refreshIcons(viewtab);
            }
        }
        private void namescroll3_Click(object sender, EventArgs e)
        {
            if (namescroll3.Text != "")
            {
                clearpointsicon();
                clearselectednamescroll();
                this.namescroll3.Image = global::SkillCalc.Properties.Resources.header_tabs_selected;
                this.namescroll3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(63)))), ((int)(((byte)(75)))));
                handlenames(namescroll3.Text);
                updateDisplay();
                calcpoints(namescroll3.Text);
                refreshIcons(viewtab);
            }
        }
        private void namescroll4_Click(object sender, EventArgs e)
        {
            if (namescroll4.Text != "")
            {
                clearpointsicon();
                clearselectednamescroll();
                this.namescroll4.Image = global::SkillCalc.Properties.Resources.header_tabs_selected;
                this.namescroll4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(63)))), ((int)(((byte)(75)))));
                handlenames(namescroll4.Text);
                updateDisplay();
                calcpoints(namescroll4.Text);
                refreshIcons(viewtab);
            }
        }
        private void namescroll5_Click(object sender, EventArgs e)
        {
            if (namescroll5.Text != "")
            {
                clearpointsicon();
                clearselectednamescroll();
                this.namescroll5.Image = global::SkillCalc.Properties.Resources.header_tabs_selected;
                this.namescroll5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(63)))), ((int)(((byte)(75)))));
                handlenames(namescroll5.Text);
                updateDisplay();
                calcpoints(namescroll5.Text);
                refreshIcons(viewtab);
            }
        }
        private void namescroll6_Click(object sender, EventArgs e)
        {
            if (namescroll6.Text != "")
            {
                clearpointsicon();
                clearselectednamescroll();
                this.namescroll6.Image = global::SkillCalc.Properties.Resources.header_tabs_selected;
                this.namescroll6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(63)))), ((int)(((byte)(75)))));
                handlenames(namescroll6.Text);
                updateDisplay();
                calcpoints(namescroll6.Text);
                refreshIcons(viewtab);
            }
        }
        private void namescroll7_Click(object sender, EventArgs e)
        {
            if (namescroll7.Text != "")
            {
                clearpointsicon();
                clearselectednamescroll();
                this.namescroll7.Image = global::SkillCalc.Properties.Resources.header_tabs_selected;
                this.namescroll7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(63)))), ((int)(((byte)(75)))));
                handlenames(namescroll7.Text);
                updateDisplay();
                calcpoints(namescroll7.Text);
                refreshIcons(viewtab);
            }
        }
        private void namescroll8_Click(object sender, EventArgs e)
        {
            if (namescroll8.Text != "")
            {
                clearpointsicon();
                clearselectednamescroll();
                this.namescroll8.Image = global::SkillCalc.Properties.Resources.header_tabs_selected;
                this.namescroll8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(63)))), ((int)(((byte)(75)))));
                handlenames(namescroll8.Text);
                updateDisplay();
                calcpoints(namescroll8.Text);
                refreshIcons(viewtab);
            }
        }

        // Display Professions in left box to click/select.
        private void selectProf01_Click(object sender, EventArgs e)
        {
            if (viewtab != "Force" && (viewtab == "Basic" || viewtab == "Advanced" || viewtab == "Jedi"))
            {
                clearskills();
                clearprofselect();
                this.selectProf01.Image = global::SkillCalc.Properties.Resources.professions_listselect;
                if (viewtab == "Basic") { artisan(); selectedprof = "Artisan"; }
                if (viewtab == "Advanced") { architect(); selectedprof = "Architect"; }
                if (viewtab == "Jedi") { lightmaster(); selectedprof = "Light Master"; }
                updateDisplay();
            }
        }
        private void selectProf02_Click(object sender, EventArgs e)
        {
            if (viewtab == "Basic" || viewtab == "Advanced" || viewtab == "Force" || viewtab == "Jedi")
            {
                clearskills();
                clearprofselect();
                this.selectProf02.Image = global::SkillCalc.Properties.Resources.professions_listselect;
                if (viewtab == "Basic") { brawler(); selectedprof = "Brawler"; }
                if (viewtab == "Advanced") { armorsmith(); selectedprof = "Armorsmith"; }
                if (viewtab == "Force") { combatprowess(); selectedprof = "Combat Prowess"; }
                if (viewtab == "Jedi") { lightjourneyman(); selectedprof = "Light Journeyman"; }
                updateDisplay();
            }
        }
        private void selectProf03_Click(object sender, EventArgs e)
        {
            if (viewtab == "Basic" || viewtab == "Advanced" || viewtab == "Force" || viewtab == "Jedi")
            {
                clearskills();
                clearprofselect();
                this.selectProf03.Image = global::SkillCalc.Properties.Resources.professions_listselect;
                if (viewtab == "Basic") { entertainer(); selectedprof = "Entertainer"; }
                if (viewtab == "Advanced") { bioengineer(); selectedprof = "Bio-Engineer"; }
                if (viewtab == "Force") { craftingmastery(); selectedprof = "Crafting Mastery"; }
                if (viewtab == "Jedi") { darkmaster(); selectedprof = "Dark Master"; }
                updateDisplay();
            }
        }
        private void selectProf04_Click(object sender, EventArgs e)
        {
            if (viewtab == "Basic" || viewtab == "Advanced" || viewtab == "Force" || viewtab == "Jedi")
            {
                clearskills();
                clearprofselect();
                this.selectProf04.Image = global::SkillCalc.Properties.Resources.professions_listselect;
                if (viewtab == "Basic") { marksman(); selectedprof = "Marksman"; }
                if (viewtab == "Advanced") { bountyhunter(); selectedprof = "Bounty Hunter"; }
                if (viewtab == "Force") { enhancedreflexes(); selectedprof = "Enhanced Reflexes"; }
                if (viewtab == "Jedi") { darkjourneyman(); selectedprof = "Dark Journeyman"; }
                updateDisplay();
            }
        }
        private void selectProf05_Click(object sender, EventArgs e)
        {
            if (viewtab == "Basic" || viewtab == "Advanced" || viewtab == "Force" || viewtab == "Jedi")
            {
                clearskills();
                clearprofselect();
                this.selectProf05.Image = global::SkillCalc.Properties.Resources.professions_listselect;
                if (viewtab == "Basic") { medic(); selectedprof = "Medic"; }
                if (viewtab == "Advanced") { carbineer(); selectedprof = "Carbineer"; }
                if (viewtab == "Force") { heightenedsenses(); selectedprof = "Heightened Senses"; }
                if (viewtab == "Jedi") { padawan(); selectedprof = "Padawan"; }
                updateDisplay();
            }
        }
        private void selectProf06_Click(object sender, EventArgs e)
        {
            if (viewtab == "Basic" || viewtab == "Advanced")
            {
                clearskills();
                clearprofselect();
                this.selectProf06.Image = global::SkillCalc.Properties.Resources.professions_listselect;
                if (viewtab == "Basic") { politician(); selectedprof = "Politician"; }
                if (viewtab == "Advanced") { chef(); selectedprof = "Chef"; }
                updateDisplay();
            }
        }
        // names start here.
        private void selectProf07_Click(object sender, EventArgs e)
        {
            if ((viewtab == "Basic" || viewtab == "Advanced" || viewtab == "name") && selectProf07.Text != "")
            {
                clearskills();
                clearprofselect();
                this.selectProf07.Image = global::SkillCalc.Properties.Resources.professions_listselect;
                if (viewtab == "Basic") { scout(); selectedprof = "Scout"; }
                if (viewtab == "Advanced") { combatmedic(); selectedprof = "Combat Medic"; }
                if (viewtab == "name") { handlenames(selectProf07.Text); calcpoints(selectProf07.Text); viewBasic(); }
                updateDisplay();
            }
        }
        private void selectProf08_Click(object sender, EventArgs e)
        {
            if ((viewtab == "Advanced" || viewtab == "Force" || viewtab == "name") && selectProf08.Text != "")
            {
                clearskills();
                clearprofselect();
                this.selectProf08.Image = global::SkillCalc.Properties.Resources.professions_listselect;
                if (viewtab == "Advanced") { commando(); selectedprof = "Commando"; }
                if (viewtab == "Force") { forcedefense(); selectedprof = "Force Defense"; }
                if (viewtab == "name") { handlenames(selectProf08.Text); calcpoints(selectProf08.Text); viewBasic(); }
                updateDisplay();
            }
        }
        private void selectProf09_Click(object sender, EventArgs e)
        {
            if ((viewtab == "Advanced" || viewtab == "Force" || viewtab == "name") && selectProf09.Text != "")
            {
                clearskills();
                clearprofselect();
                this.selectProf09.Image = global::SkillCalc.Properties.Resources.professions_listselect;
                if (viewtab == "Advanced") { creaturehandler(); selectedprof = "Creature Handler"; }
                if (viewtab == "Force") { forceenhancement(); selectedprof = "Force Enhancement"; }
                if (viewtab == "name") { handlenames(selectProf09.Text); calcpoints(selectProf09.Text); viewBasic(); }
                updateDisplay();
            }
        }
        private void selectProf10_Click(object sender, EventArgs e)
        {
            if ((viewtab == "Advanced" || viewtab == "Force" || viewtab == "name") && selectProf10.Text != "")
            {
                clearskills();
                clearprofselect();
                this.selectProf10.Image = global::SkillCalc.Properties.Resources.professions_listselect;
                if (viewtab == "Advanced") { dancer(); selectedprof = "Dancer"; }
                if (viewtab == "Force") { forcehealing(); selectedprof = "Force Healing"; }
                if (viewtab == "name") { handlenames(selectProf10.Text); calcpoints(selectProf10.Text); viewBasic(); }
                updateDisplay();
            }
        }
        private void selectProf11_Click(object sender, EventArgs e)
        {
            if ((viewtab == "Advanced" || viewtab == "Force" || viewtab == "name") && selectProf11.Text != "")
            {
                clearskills();
                clearprofselect();
                this.selectProf11.Image = global::SkillCalc.Properties.Resources.professions_listselect;
                if (viewtab == "Advanced") { doctor(); selectedprof = "Doctor"; }
                if (viewtab == "Force") { lightsaber(); selectedprof = "Lightsaber"; }
                if (viewtab == "name") { handlenames(selectProf11.Text); calcpoints(selectProf11.Text); viewBasic(); }
                updateDisplay();
            }
        }
        private void selectProf12_Click(object sender, EventArgs e)
        {
            if ((viewtab == "Advanced" || viewtab == "Force" || viewtab == "name") && selectProf12.Text != "")
            {
                clearskills();
                clearprofselect();
                this.selectProf12.Image = global::SkillCalc.Properties.Resources.professions_listselect;
                if (viewtab == "Advanced") { droidengineer(); selectedprof = "Droid Engineer"; }
                if (viewtab == "Force") { forcepowers(); selectedprof = "Force Powers"; }
                if (viewtab == "name") { handlenames(selectProf12.Text); calcpoints(selectProf12.Text); viewBasic(); }
                updateDisplay();
            }
        }
        private void selectProf13_Click(object sender, EventArgs e)
        {
            if ((viewtab == "Advanced" || viewtab == "name") && selectProf13.Text != "")
            {
                clearskills();
                clearprofselect();
                this.selectProf13.Image = global::SkillCalc.Properties.Resources.professions_listselect;
                if (viewtab == "Advanced") { fencer(); selectedprof = "Fencer"; }
                if (viewtab == "name") { handlenames(selectProf13.Text); calcpoints(selectProf13.Text); viewBasic(); }
                updateDisplay();
            }
        }
        private void selectProf14_Click(object sender, EventArgs e)
        {
            if ((viewtab == "Advanced" || viewtab == "name") && selectProf14.Text != "")
            {
                clearskills();
                clearprofselect();
                this.selectProf14.Image = global::SkillCalc.Properties.Resources.professions_listselect;
                if (viewtab == "Advanced") { imagedesigner(); selectedprof = "Image Designer"; }
                if (viewtab == "name") { handlenames(selectProf14.Text); calcpoints(selectProf14.Text); viewBasic(); }
                updateDisplay();
            }
        }
        private void selectProf15_Click(object sender, EventArgs e)
        {
            if ((viewtab == "Advanced" || viewtab == "name") && selectProf15.Text != "")
            {
                clearskills();
                clearprofselect();
                this.selectProf15.Image = global::SkillCalc.Properties.Resources.professions_listselect;
                if (viewtab == "Advanced") { merchant(); selectedprof = "Merchant"; }
                if (viewtab == "name") { handlenames(selectProf15.Text); calcpoints(selectProf15.Text); viewBasic(); }
                updateDisplay();
            }
        }
        private void selectProf16_Click(object sender, EventArgs e)
        {
            if ((viewtab == "Advanced" || viewtab == "name") && selectProf16.Text != "")
            {
                clearskills();
                clearprofselect();
                this.selectProf16.Image = global::SkillCalc.Properties.Resources.professions_listselect;
                if (viewtab == "Advanced") { musician(); selectedprof = "Musician"; }
                if (viewtab == "name") { handlenames(selectProf16.Text); calcpoints(selectProf16.Text); viewBasic(); }
                updateDisplay();
            }
        }
        private void selectProf17_Click(object sender, EventArgs e)
        {
            if ((viewtab == "Advanced" || viewtab == "name") && selectProf17.Text != "")
            {
                clearskills();
                clearprofselect();
                this.selectProf17.Image = global::SkillCalc.Properties.Resources.professions_listselect;
                if (viewtab == "Advanced") { pikeman(); selectedprof = "Pikeman"; }
                if (viewtab == "name") { handlenames(selectProf17.Text); calcpoints(selectProf17.Text); viewBasic(); }
                updateDisplay();
            }
        }
        private void selectProf18_Click(object sender, EventArgs e)
        {
            if ((viewtab == "Advanced" || viewtab == "name") && selectProf18.Text != "")
            {
                clearskills();
                clearprofselect();
                this.selectProf18.Image = global::SkillCalc.Properties.Resources.professions_listselect;
                if (viewtab == "Advanced") { pistoleer(); selectedprof = "Pistoleer"; }
                if (viewtab == "name") { handlenames(selectProf18.Text); calcpoints(selectProf18.Text); viewBasic(); }
                updateDisplay();
            }
        }
        private void selectProf19_Click(object sender, EventArgs e)
        {
            if ((viewtab == "Advanced" || viewtab == "name") && selectProf19.Text != "")
            {
                clearskills();
                clearprofselect();
                this.selectProf19.Image = global::SkillCalc.Properties.Resources.professions_listselect;
                if (viewtab == "Advanced") { ranger(); selectedprof = "Ranger"; }
                if (viewtab == "name") { handlenames(selectProf19.Text); calcpoints(selectProf19.Text); viewBasic(); }
                updateDisplay();
            }
        }
        private void selectProf20_Click(object sender, EventArgs e)
        {
            if ((viewtab == "Advanced" || viewtab == "name") && selectProf20.Text != "")
            {
                clearskills();
                clearprofselect();
                this.selectProf20.Image = global::SkillCalc.Properties.Resources.professions_listselect;
                if (viewtab == "Advanced") { rifleman(); selectedprof = "Rifleman"; }
                if (viewtab == "name") { handlenames(selectProf20.Text); calcpoints(selectProf20.Text); viewBasic(); }
                updateDisplay();
            }
        }
        private void selectProf21_Click(object sender, EventArgs e)
        {
            if ((viewtab == "Advanced" || viewtab == "name") && selectProf21.Text != "")
            {
                clearskills();
                clearprofselect();
                this.selectProf21.Image = global::SkillCalc.Properties.Resources.professions_listselect;
                if (viewtab == "Advanced") { smuggler(); selectedprof = "Smuggler"; }
                if (viewtab == "name") { handlenames(selectProf21.Text); calcpoints(selectProf21.Text); viewBasic(); }
                updateDisplay();
            }
        }
        private void selectProf22_Click(object sender, EventArgs e)
        {
            if ((viewtab == "Advanced" || viewtab == "name") && selectProf22.Text != "")
            {
                clearskills();
                clearprofselect();
                this.selectProf22.Image = global::SkillCalc.Properties.Resources.professions_listselect;
                if (viewtab == "Advanced") { squadleader(); selectedprof = "Squad Leader"; }
                if (viewtab == "name") { handlenames(selectProf22.Text); calcpoints(selectProf22.Text); viewBasic(); }
                updateDisplay();
            }
        }
        private void selectProf23_Click(object sender, EventArgs e)
        {
            if ((viewtab == "Advanced" || viewtab == "name") && selectProf23.Text != "")
            {
                clearskills();
                clearprofselect();
                this.selectProf23.Image = global::SkillCalc.Properties.Resources.professions_listselect;
                if (viewtab == "Advanced") { swordsman(); selectedprof = "Swordsman"; }
                if (viewtab == "name") { handlenames(selectProf23.Text); calcpoints(selectProf23.Text); viewBasic(); }
                updateDisplay();
            }
        }
        private void selectProf24_Click(object sender, EventArgs e)
        {
            if ((viewtab == "Advanced" || viewtab == "name") && selectProf24.Text != "")
            {
                clearskills();
                clearprofselect();
                this.selectProf24.Image = global::SkillCalc.Properties.Resources.professions_listselect;
                if (viewtab == "Advanced") { tailor(); selectedprof = "Tailor"; }
                if (viewtab == "name") { handlenames(selectProf24.Text); calcpoints(selectProf24.Text); viewBasic(); }
                updateDisplay();
            }
        }
        private void selectProf25_Click(object sender, EventArgs e)
        {
            if ((viewtab == "Advanced" || viewtab == "name") && selectProf25.Text != "")
            {
                clearskills();
                clearprofselect();
                this.selectProf25.Image = global::SkillCalc.Properties.Resources.professions_listselect;
                if (viewtab == "Advanced") { teraskasiartist(); selectedprof = "Teras Kasi Artist"; }
                if (viewtab == "name") { handlenames(selectProf25.Text); calcpoints(selectProf25.Text); viewBasic(); }
                updateDisplay();
            }
        }
        private void selectProf26_Click(object sender, EventArgs e)
        {
            if ((viewtab == "Advanced" || viewtab == "name") && selectProf26.Text != "")
            {
                clearskills();
                clearprofselect();
                this.selectProf26.Image = global::SkillCalc.Properties.Resources.professions_listselect;
                if (viewtab == "Advanced") { weaponsmith(); selectedprof = "Weaponsmith"; }
                if (viewtab == "name") { handlenames(selectProf26.Text); calcpoints(selectProf26.Text); viewBasic(); }
                updateDisplay();
            }
        }

        private void labelNovice_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) { if (professions.Contains(selectedprof)) { clickedProf("labelNovice_MouseDown", "left"); } }
            if (e.Button == MouseButtons.Right) { if (professions.Contains(selectedprof)) { clickedProf("labelNovice_MouseDown", "right"); } }
        }
        private void labelNovice_MouseEnter(object sender, EventArgs e) { mouseHoverDisplay("labelNovice", "enter"); tooltipbox("show", "novice"); }
        private void labelNovice_MouseLeave(object sender, EventArgs e) { mouseHoverDisplay("labelNovice", "leave"); tooltipbox("hide", "novice"); }
        private void labelfirstI_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) { if (professions.Contains(selectedprof)) { clickedProf("labelfirstI_MouseDown", "left"); } }
            if (e.Button == MouseButtons.Right) { if (professions.Contains(selectedprof)) { clickedProf("labelfirstI_MouseDown", "right"); } }
        }
        private void labelfirstI_MouseEnter(object sender, EventArgs e) { mouseHoverDisplay("labelfirstI", "enter"); tooltipbox("show", "labelfirstI"); }
        private void labelfirstI_MouseLeave(object sender, EventArgs e) { mouseHoverDisplay("labelfirstI", "leave"); tooltipbox("hide", "labelfirstI"); }
        private void labelfirstII_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) { if (professions.Contains(selectedprof)) { clickedProf("labelfirstII_MouseDown", "left"); } }
            if (e.Button == MouseButtons.Right) { if (professions.Contains(selectedprof)) { clickedProf("labelfirstII_MouseDown", "right"); } }
        }
        private void labelfirstII_MouseEnter(object sender, EventArgs e) { mouseHoverDisplay("labelfirstII", "enter"); tooltipbox("show", "labelfirstII"); }
        private void labelfirstII_MouseLeave(object sender, EventArgs e) { mouseHoverDisplay("labelfirstII", "leave"); tooltipbox("hide", "labelfirstII"); }
        private void labelfirstIII_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) { if (professions.Contains(selectedprof)) { clickedProf("labelfirstIII_MouseDown", "left"); } }
            if (e.Button == MouseButtons.Right) { if (professions.Contains(selectedprof)) { clickedProf("labelfirstIII_MouseDown", "right"); } }
        }
        private void labelfirstIII_MouseEnter(object sender, EventArgs e) { mouseHoverDisplay("labelfirstIII", "enter"); tooltipbox("show", "labelfirstIII"); }
        private void labelfirstIII_MouseLeave(object sender, EventArgs e) { mouseHoverDisplay("labelfirstIII", "leave"); tooltipbox("hide", "labelfirstIII"); }
        private void labelfirstIV_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) { if (professions.Contains(selectedprof)) { clickedProf("labelfirstIV_MouseDown", "left"); } }
            if (e.Button == MouseButtons.Right) { if (professions.Contains(selectedprof)) { clickedProf("labelfirstIV_MouseDown", "right"); } }
        }
        private void labelfirstIV_MouseEnter(object sender, EventArgs e) { mouseHoverDisplay("labelfirstIV", "enter"); tooltipbox("show", "labelfirstIV"); }
        private void labelfirstIV_MouseLeave(object sender, EventArgs e) { mouseHoverDisplay("labelfirstIV", "leave"); tooltipbox("hide", "labelfirstIV"); }
        private void labelsecondI_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) { if (professions.Contains(selectedprof)) { clickedProf("labelsecondI_MouseDown", "left"); } }
            if (e.Button == MouseButtons.Right) { if (professions.Contains(selectedprof)) { clickedProf("labelsecondI_MouseDown", "right"); } }
        }
        private void labelsecondI_MouseEnter(object sender, EventArgs e) { mouseHoverDisplay("labelsecondI", "enter"); tooltipbox("show", "labelsecondI"); }
        private void labelsecondI_MouseLeave(object sender, EventArgs e) { mouseHoverDisplay("labelsecondI", "leave"); tooltipbox("hide", "labelsecondI"); }
        private void labelsecondII_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) { if (professions.Contains(selectedprof)) { clickedProf("labelsecondII_MouseDown", "left"); } }
            if (e.Button == MouseButtons.Right) { if (professions.Contains(selectedprof)) { clickedProf("labelsecondII_MouseDown", "right"); } }
        }
        private void labelsecondII_MouseEnter(object sender, EventArgs e) { mouseHoverDisplay("labelsecondII", "enter"); tooltipbox("show", "labelsecondII"); }
        private void labelsecondII_MouseLeave(object sender, EventArgs e) { mouseHoverDisplay("labelsecondII", "leave"); tooltipbox("hide", "labelsecondII"); }
        private void labelsecondIII_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) { if (professions.Contains(selectedprof)) { clickedProf("labelsecondIII_MouseDown", "left"); } }
            if (e.Button == MouseButtons.Right) { if (professions.Contains(selectedprof)) { clickedProf("labelsecondIII_MouseDown", "right"); } }
        }
        private void labelsecondIII_MouseEnter(object sender, EventArgs e) { mouseHoverDisplay("labelsecondIII", "enter"); tooltipbox("show", "labelsecondIII"); }
        private void labelsecondIII_MouseLeave(object sender, EventArgs e) { mouseHoverDisplay("labelsecondIII", "leave"); tooltipbox("hide", "labelsecondIII"); }
        private void labelsecondIV_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) { if (professions.Contains(selectedprof)) { clickedProf("labelsecondIV_MouseDown", "left"); } }
            if (e.Button == MouseButtons.Right) { if (professions.Contains(selectedprof)) { clickedProf("labelsecondIV_MouseDown", "right"); } }
        }
        private void labelsecondIV_MouseEnter(object sender, EventArgs e) { mouseHoverDisplay("labelsecondIV", "enter"); tooltipbox("show", "labelsecondIV"); }
        private void labelsecondIV_MouseLeave(object sender, EventArgs e) { mouseHoverDisplay("labelsecondIV", "leave"); tooltipbox("hide", "labelsecondIV"); }
        private void labelthirdI_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) { if (professions.Contains(selectedprof)) { clickedProf("labelthirdI_MouseDown", "left"); } }
            if (e.Button == MouseButtons.Right) { if (professions.Contains(selectedprof)) { clickedProf("labelthirdI_MouseDown", "right"); } }
        }
        private void labelthirdI_MouseEnter(object sender, EventArgs e) { mouseHoverDisplay("labelthirdI", "enter"); tooltipbox("show", "labelthirdI"); }
        private void labelthirdI_MouseLeave(object sender, EventArgs e) { mouseHoverDisplay("labelthirdI", "leave"); tooltipbox("hide", "labelthirdI"); }
        private void labelthirdII_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) { if (professions.Contains(selectedprof)) { clickedProf("labelthirdII_MouseDown", "left"); } }
            if (e.Button == MouseButtons.Right) { if (professions.Contains(selectedprof)) { clickedProf("labelthirdII_MouseDown", "right"); } }
        }
        private void labelthirdII_MouseEnter(object sender, EventArgs e) { mouseHoverDisplay("labelthirdII", "enter"); tooltipbox("show", "labelthirdII"); }
        private void labelthirdII_MouseLeave(object sender, EventArgs e) { mouseHoverDisplay("labelthirdII", "leave"); tooltipbox("hide", "labelthirdII"); }
        private void labelthirdIII_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) { if (professions.Contains(selectedprof)) { clickedProf("labelthirdIII_MouseDown", "left"); } }
            if (e.Button == MouseButtons.Right) { if (professions.Contains(selectedprof)) { clickedProf("labelthirdIII_MouseDown", "right"); } }
        }
        private void labelthirdIII_MouseEnter(object sender, EventArgs e) { mouseHoverDisplay("labelthirdIII", "enter"); tooltipbox("show", "labelthirdIII"); }
        private void labelthirdIII_MouseLeave(object sender, EventArgs e) { mouseHoverDisplay("labelthirdIII", "leave"); tooltipbox("hide", "labelthirdIII"); }
        private void labelthirdIV_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) { if (professions.Contains(selectedprof)) { clickedProf("labelthirdIV_MouseDown", "left"); } }
            if (e.Button == MouseButtons.Right) { if (professions.Contains(selectedprof)) { clickedProf("labelthirdIV_MouseDown", "right"); } }
        }
        private void labelthirdIV_MouseEnter(object sender, EventArgs e) { mouseHoverDisplay("labelthirdIV", "enter"); tooltipbox("show", "labelthirdIV"); }
        private void labelthirdIV_MouseLeave(object sender, EventArgs e) { mouseHoverDisplay("labelthirdIV", "leave"); tooltipbox("hide", "labelthirdIV"); }
        private void labelfourthI_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) { if (professions.Contains(selectedprof)) { clickedProf("labelfourthI_MouseDown", "left"); } }
            if (e.Button == MouseButtons.Right) { if (professions.Contains(selectedprof)) { clickedProf("labelfourthI_MouseDown", "right"); } }
        }
        private void labelfourthI_MouseEnter(object sender, EventArgs e) { mouseHoverDisplay("labelfourthI", "enter"); tooltipbox("show", "labelfourthI"); }
        private void labelfourthI_MouseLeave(object sender, EventArgs e) { mouseHoverDisplay("labelfourthI", "leave"); tooltipbox("hide", "labelfourthI"); }
        private void labelfourthII_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) { if (professions.Contains(selectedprof)) { clickedProf("labelfourthII_MouseDown", "left"); } }
            if (e.Button == MouseButtons.Right) { if (professions.Contains(selectedprof)) { clickedProf("labelfourthII_MouseDown", "right"); } }
        }
        private void labelfourthII_MouseEnter(object sender, EventArgs e) { mouseHoverDisplay("labelfourthII", "enter"); tooltipbox("show", "labelfourthII"); }
        private void labelfourthII_MouseLeave(object sender, EventArgs e) { mouseHoverDisplay("labelfourthII", "leave"); tooltipbox("hide", "labelfourthII"); }
        private void labelfourthIII_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) { if (professions.Contains(selectedprof)) { clickedProf("labelfourthIII_MouseDown", "left"); } }
            if (e.Button == MouseButtons.Right) { if (professions.Contains(selectedprof)) { clickedProf("labelfourthIII_MouseDown", "right"); } }
        }
        private void labelfourthIII_MouseEnter(object sender, EventArgs e) { mouseHoverDisplay("labelfourthIII", "enter"); tooltipbox("show", "labelfourthIII"); }
        private void labelfourthIII_MouseLeave(object sender, EventArgs e) { mouseHoverDisplay("labelfourthIII", "leave"); tooltipbox("hide", "labelfourthIII"); }
        private void labelfourthIV_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) { if (professions.Contains(selectedprof)) { clickedProf("labelfourthIV_MouseDown", "left"); } }
            if (e.Button == MouseButtons.Right) { if (professions.Contains(selectedprof)) { clickedProf("labelfourthIV_MouseDown", "right"); } }
        }
        private void labelfourthIV_MouseEnter(object sender, EventArgs e) { mouseHoverDisplay("labelfourthIV", "enter"); tooltipbox("show", "labelfourthIV"); }
        private void labelfourthIV_MouseLeave(object sender, EventArgs e) { mouseHoverDisplay("labelfourthIV", "leave"); tooltipbox("hide", "labelfourthIV"); }
        private void labelMaster_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) { if (professions.Contains(selectedprof)) { clickedProf("labelMaster_MouseDown", "left"); } }
            if (e.Button == MouseButtons.Right) { if (professions.Contains(selectedprof)) { clickedProf("labelMaster_MouseDown", "right"); } }
        }
        private void labelMaster_MouseEnter(object sender, EventArgs e) { mouseHoverDisplay("labelMaster", "enter"); tooltipbox("show", "master"); }
        private void labelMaster_MouseLeave(object sender, EventArgs e) { mouseHoverDisplay("labelMaster", "leave"); tooltipbox("hide", "master"); }
    }
}