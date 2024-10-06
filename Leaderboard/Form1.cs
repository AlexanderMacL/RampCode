using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using System.Windows.Forms.VisualStyles;

namespace Leaderboard
{
   public partial class Form1 : Form
   {
      const int RESULT_TIMOUT_SECONDS = 60;
      public enum Material {
         Plastic = 0,
         Wood = 1,
         Felt = 2,
         Rubber = 3,
         Combo = 4
      }

      public enum Width {
         Narrow = 0,
         Wide = 1,
         Combo = 2
      }

      public static Color[] Colours = {
         Color.Red,
         Color.Orange,
         Color.ForestGreen,
         Color.RoyalBlue,
         Color.LightGray
      };

      public class RaceResult
      {
         public int track;
         public int time;
         public Material material;
         public Width width;
         public bool combo;
         public DateTime timestamp;
         public bool valid;
         public string messagestring;
         public bool selected = false;
         public RaceResult(string s) {
            messagestring = s;
            string[] ss = s.Split(',');
            bool success = true;
            foreach (var p in ss) {
               if (p.Length > 0) {
                  switch (p[0]) {
                     case 'D':
                        success &= DateTime.TryParse(p.Substring(1), out timestamp);
                        break;
                     case 'T':
                        success &= Int32.TryParse(p.Substring(1), out track);
                        break;
                     case 'M':
                        success &= Int32.TryParse(p.Substring(1), out var mi);
                        material = (Material)mi;
                        break;
                     case 'W':
                        success &= Int32.TryParse(p.Substring(1), out var wi);
                        width = (Width)wi;
                        break;
                     case 'C':
                        success &= Int32.TryParse(p.Substring(1), out var ci);
                        combo = ci == 1;
                        break;
                     default:
                        success &= Int32.TryParse(p, out time);
                        break;
                  }
               }
            }
            success &= (track != 0);
            valid = success;
            if (combo) {
               material = Material.Combo;
               width = Width.Combo;
            }
         }

         public ListViewItem ToListViewItem() {
            var li = new ListViewItem(new string[] {messagestring}); // goes into hidden first column
            foreach (var i in new string[] { track.ToString(), $"{time / 1000.0:0.000}", material.ToString(), width.ToString(), timestamp.ToString() }) {
               li.SubItems.Add(i);
            }
            li.SubItems[3].ForeColor = Colours[(int)material];
            li.SubItems[4].ForeColor = Colours.Where(cc => cc!=Colours[3]).ToList()[(int)width + 1];
            li.UseItemStyleForSubItems = false;
            li.Selected = selected;
            return li;
         }
      }
      public List<RaceResult> resultList = new List<RaceResult>();
      private SerialPort serialPort;
      private StreamWriter sw;
      private readonly string PORTFILENAME;
      private readonly string LOGFILENAME;
      public Form1() // constructor
      {
         bool isRunningInVS = !string.IsNullOrEmpty(Environment.GetEnvironmentVariable("VisualStudioEdition"));
         string pth = isRunningInVS ? Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.FullName : Application.StartupPath;
         PORTFILENAME = pth + "\\Port.txt";
         LOGFILENAME = pth + "\\LeaderboardLog.txt";
         InitializeComponent();
         string port = "";
         try {
            port = File.ReadAllText(PORTFILENAME);
         } catch (Exception) {
            MessageBox.Show($"Could not open port file, please check file exists in the location {PORTFILENAME}", "Port file not found", MessageBoxButtons.OK);
         }
         if (!File.Exists(LOGFILENAME))
            MessageBox.Show($"Could not open log file, please check file exists in the location {LOGFILENAME}", "Log file not found", MessageBoxButtons.OK);
         try {
            serialPort = new SerialPort(port, 115200);
            serialPort.Open();
         } catch (Exception) {
            MessageBox.Show($"Could not open Port {port}, please check portname in port file at {PORTFILENAME} is correct", "Port could not be opened", MessageBoxButtons.OK);
         }

         PopulateResults();

         // application loop
         Timer updateTimer = new Timer();
         updateTimer.Interval = 400;
         updateTimer.Tick += UpdateTimer_Tick;
         updateTimer.Enabled = true;
      }

      private void PopulateResults() {
         resultList.Clear();
         // populate list of RaceResults from file
         foreach (var line in File.ReadAllLines(LOGFILENAME)) {
            RaceResult rr = new RaceResult(line);
            if (rr.valid) {
               resultList.Add(rr);
               RefreshListViewItems();
            }
         }
      }

      private void RefreshListViewItems() {
         listView1.Items.Clear();
         // get list of track 1 and track 2 results
         List<RaceResult> track1items = new List<RaceResult>(resultList.Where(item => item.track == 1));
         List<RaceResult> track2items = new List<RaceResult>(resultList.Where(item => item.track == 2));
         var ordered1 = track1items.OrderByDescending(item => item.timestamp.Ticks).ToList();
         foreach (var i in ordered1) i.selected = false;
         if (ordered1.Count > 0) ordered1.First().selected = true;
         var ordered2 = track2items.OrderByDescending(item => item.timestamp.Ticks).ToList();
         foreach (var i in ordered2) i.selected = false;
         if (ordered2.Count > 0) ordered2.First().selected = true;
         // find most recent timestamp
         // set Item.Selected property of that result by using result property of resultList item
         foreach (var i in Enumerable.Concat(ordered1,ordered2).OrderByDescending(item => item.time).Reverse()) {
            listView1.Items.Add(i.ToListViewItem());
         }
      }

      private void UpdateTimer_Tick(object sender, EventArgs e) {
         var updateTime = DateTime.Now;
         if (serialPort != null && serialPort.IsOpen) {
            sw = File.AppendText(LOGFILENAME);
            while (serialPort.BytesToRead > 0)
            {
               string line = serialPort.ReadLine();
               line = "D" + updateTime.ToString() + "," + line;
               sw.Write(line);
               RaceResult rr = new RaceResult(line);
               resultList.Add(rr);
               RefreshListViewItems();
               label1.Text = line;
            }
            sw.Flush();
            sw.Close();
            this.Invalidate();
         }
         if (resultList.Count > 0) {
            List<RaceResult> track1items = new List<RaceResult>(resultList.Where(item => item.track == 1));
            if (track1items.Count > 0) {
               RaceResult track1mostrecent = track1items.OrderByDescending(item => item.timestamp.Ticks).First();
               if (DateTime.Now - track1mostrecent.timestamp > TimeSpan.FromSeconds(RESULT_TIMOUT_SECONDS))
               {
                  track1Time.Text = $"{0.0:0.000} s";
                  track1Material.Text = "";
                  track1Width.Text = "";
                  track1staticmaterial.Visible = false;
                  track1staticwidth.Visible = false;
               }
               else
               {
                  track1Time.Text = $"{track1mostrecent.time / 1000.0:0.000} s";
                  if (track1mostrecent.material != Material.Combo) {
                     track1staticmaterial.Visible = true;
                     track1Material.ForeColor = Colours[(int)track1mostrecent.material];
                     track1Material.Text = track1mostrecent.material.ToString();
                  }
                  if (track1mostrecent.width != Width.Combo) {
                     track1staticwidth.Visible = true;
                     track1Width.ForeColor = Colours[(int)track1mostrecent.width+1];
                     track1Width.Text = track1mostrecent.width.ToString();
                  }
               }
            }
            List<RaceResult> track2items = new List<RaceResult>(resultList.Where(item => item.track == 2));
            if (track2items.Count > 0) {
               RaceResult track2mostrecent = track2items.OrderByDescending(item => item.timestamp.Ticks).First();

               if (DateTime.Now - track2mostrecent.timestamp > TimeSpan.FromSeconds(RESULT_TIMOUT_SECONDS)) {
                  track2Time.Text = $"{0.0:0.000} s";
                  track2Material.Text = "";
                  track2Width.Text = "";
                  track2staticmaterial.Visible = false;
                  track2staticwidth.Visible = false;
               } else {
                  track2Time.Text = $"{track2mostrecent.time / 1000.0:0.000} s";
                  if (track2mostrecent.material != Material.Combo) {
                     track2staticmaterial.Visible = true;
                     track2Material.ForeColor = Colours[(int)track2mostrecent.material];
                     track2Material.Text = track2mostrecent.material.ToString();
                  }
                  if (track2mostrecent.width != Width.Combo) {
                     track2staticwidth.Visible = true;
                     track2Width.ForeColor = Colours[(int)track2mostrecent.width+1];
                     track2Width.Text = track2mostrecent.width.ToString();
                  }
               }
            }
         }
      }

      private void button1_Click(object sender, EventArgs e) {
         if (resultList.Count == 0) {
            MessageBox.Show("There are no results to save", "Result list empty", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            return;
         }
         int i = 1;
         string destfile;
         do {
            destfile = LOGFILENAME.Remove(LOGFILENAME.Length - 4) + i.ToString() + ".txt";
            i++;
         } while (File.Exists(destfile));
         try {
            File.Copy(LOGFILENAME, destfile);
            var fs = File.Create(LOGFILENAME); // overwrites log
            fs.Close();

            PopulateResults();
            RefreshListViewItems();
         } catch (Exception ex) {
            MessageBox.Show("An error occurred while saving data\n\n" + ex.Message, "Error saving leaderboard", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
         }
         MessageBox.Show("Data saved to " + destfile, "Data saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
      }
   }
}
