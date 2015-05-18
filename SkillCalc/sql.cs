/*
SkillCalc Copyright (c) sstheno@gmail.com

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
using System.Data;
using System.IO;
using System.Windows.Forms;
using System.Data.SQLite;

namespace SkillCalc
{
    public partial class Main : Form
    {
        // Use this to debug SQL : foreach (SQLiteParameter param in cmd.Parameters) { debug(param.ParameterName + ": " + param.Value.ToString()); }
        private string sqlpath()
        {
            var dir = Environment.CurrentDirectory;
            const string filename = @"\SkillCalc.sqlite";
            string path = dir + filename;
            return path;
        }
        private void checkFile()
        {
            string path = sqlpath();
            if (!File.Exists(path))
            {
                var conn = new SQLiteConnection("Data Source=" + sqlpath() + ";Version=3;");

                SQLiteCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;

                try
                {
                    conn.Open();
                    string CommandText = @"CREATE TABLE 'Characters' ('Name' TEXT PRIMARY KEY  NOT NULL, 'Species' VARCHAR(15) DEFAULT ('None'),";
                    foreach (string value in professions)
                    {
                        CommandText += "'" + value + "' VARCHAR(25) DEFAULT ('0-0000-0000-0000-0000-0'),";
                    }
                    cmd.CommandText += CommandText.Remove(CommandText.Length - 1);
                    cmd.CommandText += ");";
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                catch (Exception ex) { throw new Exception(ex.Message); }
            }
        }
        private void defaultname()
        {
            var conn = new SQLiteConnection("Data Source=" + sqlpath() + ";Version=3;");

            SQLiteCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "REPLACE INTO Characters (Name) VALUES (@name);";
            cmd.Parameters.Add(new SQLiteParameter("@name", "Character"));

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        private bool maxsaves()
        {
            var conn = new SQLiteConnection("Data Source=" + sqlpath() + ";Version=3;");

            SQLiteCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM Characters WHERE Name != \"Character\" LIMIT 20;";

            try
            {
                conn.Open();
                SQLiteDataReader reader = cmd.ExecuteReader();
                int num = 0;
                string namebox = "selectProf";
                List<string> names = new List<string>();
                while (reader.Read())
                {
                    namebox += num;
                    names.Add(reader.GetValue(0).ToString());
                    num++;
                }
                conn.Close();
                if (names.Count >= 20) { return true; }
                else { return false; }
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        private bool charexists(string name)
        {
            int count;
            var conn = new SQLiteConnection("Data Source=" + sqlpath() + ";Version=3;");

            SQLiteCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT count(*) FROM Characters WHERE Name LIKE (@name)";
            cmd.Parameters.AddWithValue("@name", name);
            conn.Open();
            count = Convert.ToInt32(cmd.ExecuteScalar());
            conn.Close();
            if (count != 0) { return true; }
            return false;
        }
        private void savename()
        {
            string name = this.charName.Text;
            
            if (name != "" && name != "Character")
            {
                if (maxsaves() == false && charexists(name) == false)
                {
                    var conn = new SQLiteConnection("Data Source=" + sqlpath() + ";Version=3;");

                    List<string> skillvalues = new List<string>();
                    SQLiteCommand cmd = conn.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    try
                    {
                        cmd.CommandText = "SELECT * FROM Characters WHERE (Name) = (@name);";
                        cmd.Parameters.Add(new SQLiteParameter("@name", "Character"));

                        conn.Open();
                        SQLiteDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            skillvalues.Add(reader.GetString(0));
                            skillvalues.Add(reader.GetString(1));
                            for (int i = 2; i < reader.FieldCount; i++)
                            {
                                skillvalues.Add(reader.GetString(i));
                            }
                        }
                        conn.Close();
                    }
                    catch (Exception ex) { throw new Exception(ex.Message); }

                    var conn2 = new SQLiteConnection("Data Source=" + sqlpath() + ";Version=3;");
                    SQLiteCommand cmd2 = conn2.CreateCommand();
                    cmd2.CommandType = CommandType.Text;                    
                    try
                    {
                        cmd2.CommandText = "INSERT INTO Characters (Name) VALUES (@name);";
                        cmd2.Parameters.Add(new SQLiteParameter("@name", name));
                        conn2.Open();
                        cmd2.ExecuteNonQuery();
                        conn2.Close();
                    }
                    catch (Exception ex) { throw new Exception(ex.Message); }

                    var conn3 = new SQLiteConnection("Data Source=" + sqlpath() + ";Version=3;");
                    SQLiteCommand cmd3 = conn3.CreateCommand();
                    cmd3.CommandType = CommandType.Text;
                    try
                    {
                        conn3.Open();
                        for (int i = 0; i < skillvalues.Count - 2; i++)
                        {
                            string column = professions[i];
                            cmd3.CommandText = "UPDATE Characters SET `" + column + "` = (@skill) WHERE (Name) LIKE (@name);";
                            cmd3.Parameters.Add(new SQLiteParameter("@name", name));
                            cmd3.Parameters.Add(new SQLiteParameter("@skill", skillvalues[i + 2]));
                            cmd3.ExecuteNonQuery();
                        }
                        conn3.Close();
                    }
                    catch (Exception ex) { throw new Exception(ex.Message); }
                    defaultname();
                    refreshnames();
                }
                else if (maxsaves() == true) { CustomMessageBox.frmShowMessage.Show("You already have max saves.", "Error", CustomMessageBox.enumMessageButton.OK); }
            }
            else { CustomMessageBox.frmShowMessage.Show("You must enter a name to save.", "Error", CustomMessageBox.enumMessageButton.OK); }
        }
        private void loadnames()
        {
            var conn = new SQLiteConnection("Data Source=" + sqlpath() + ";Version=3;");
            
            SQLiteCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM Characters WHERE Name != \"Character\" LIMIT 20;";
            
            try
            {
                namelist.Clear();
                conn.Open();
                SQLiteDataReader reader = cmd.ExecuteReader();
                List<string> names = new List<string>();
                while (reader.Read()) { names.Add(reader.GetValue(0).ToString()); }
                if (names.Count >= 1) { namelist.Add(names[0]); }
                if (names.Count >= 2) { namelist.Add(names[1]); }
                if (names.Count >= 3) { namelist.Add(names[2]); }
                if (names.Count >= 4) { namelist.Add(names[3]); }
                if (names.Count >= 5) { namelist.Add(names[4]); }
                if (names.Count >= 6) { namelist.Add(names[5]); }
                if (names.Count >= 7) { namelist.Add(names[6]); }
                if (names.Count >= 8) { namelist.Add(names[7]); }
                if (names.Count >= 9) { namelist.Add(names[8]); }
                if (names.Count >= 10) { namelist.Add(names[9]); }
                if (names.Count >= 11) { namelist.Add(names[10]); }
                if (names.Count >= 12) { namelist.Add(names[11]); }
                if (names.Count >= 13) { namelist.Add(names[12]); }
                if (names.Count >= 14) { namelist.Add(names[13]); }
                if (names.Count >= 15) { namelist.Add(names[14]); }
                if (names.Count >= 16) { namelist.Add(names[15]); }
                if (names.Count >= 17) { namelist.Add(names[16]); }
                if (names.Count >= 18) { namelist.Add(names[17]); }
                if (names.Count >= 19) { namelist.Add(names[18]); }
                if (names.Count >= 20) { namelist.Add(names[19]); }
                conn.Close();
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        private void dodelete()
        {
            string name = this.charName.Text;
            if (name == "Character" || name == "")
            {
                CustomMessageBox.frmShowMessage.Show("Select a character to delete.", "Information", CustomMessageBox.enumMessageButton.OK);
            }
            else
            {
                var conn = new SQLiteConnection("Data Source=" + sqlpath() + ";Version=3;");

                SQLiteCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "DELETE FROM Characters WHERE (Name) = (@name);";
                cmd.Parameters.Add(new SQLiteParameter("@name", name));

                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                catch (Exception ex) { throw new Exception(ex.Message); }
                CustomMessageBox.frmShowMessage.Show(name + " is deleted.", "Information", CustomMessageBox.enumMessageButton.OK);
                refreshnames();
            }
        }
        private void updateskills(string name, string skill, string skillvalue)
        {
            var conn = new SQLiteConnection("Data Source=" + sqlpath() + ";Version=3;");

            SQLiteCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "UPDATE Characters SET `" + skill + "` = (@skillvalue) WHERE (Name) LIKE (@name);";
            cmd.Parameters.Add(new SQLiteParameter("@skillvalue", skillvalue));
            cmd.Parameters.Add(new SQLiteParameter("@name", name));

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        private string getskills(string name, string skill)
        {
            var conn = new SQLiteConnection("Data Source=" + sqlpath() + ";Version=3;");

            SQLiteCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT `" + skill + "` FROM Characters WHERE (Name) = (@name);";
            cmd.Parameters.Add(new SQLiteParameter("@name", name));

            try
            {
                conn.Open();
                List<string> skillvalue = new List<string>();
                SQLiteDataReader reader = cmd.ExecuteReader();
                while (reader.Read()) { skillvalue.Add(reader.GetString(0)); }
                conn.Close();
                return skillvalue[0];
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        private void reset()
        {
            string name = "Character";
            var conn = new SQLiteConnection("Data Source=" + sqlpath() + ";Version=3;");

            SQLiteCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;

            try
            {
                conn.Open();
                cmd.CommandText = "DELETE FROM Characters WHERE (Name) = (@name);";
                cmd.Parameters.Add(new SQLiteParameter("@name", name));
                cmd.ExecuteNonQuery();
                cmd.CommandText = "REPLACE INTO Characters (Name) VALUES (@name);";
                cmd.Parameters.Add(new SQLiteParameter("@name", name));
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
    }
}