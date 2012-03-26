using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DziennikLekcyjny
{
    public partial class mainWindow : Form
    {
        private byte tabsCount = 6;
        private string[] tabsNames = { "Frekwencja", "Oceny", "Tematy zajęć", "Uwagi", "Ogłoszenia", "Plan zajęć" };
        private int rowCount = 10, columnCount = 20;
        private List<dataGridSettings> settings = new List<dataGridSettings>(); //lista ustawien wyswietlania dataGridView
        /*ZAKŁADKI :
         * frekwencja
         * oceny
         * tematy zajęć
         * uwagi
         * ogłoszenia
         * plan zajęć
         * kalendarz
         */

        public mainWindow()
        {
            InitializeComponent();

            for (int i = 0; i < tabsCount; ++i)
            {
                tabs.TabPages[i].Text = tabsNames[i];
            }
            statusBar.Items.Add("");                //data i czas

            //lista ustawien;

            settings.Add(new dataGridSettings());   //frekwencja            
            settings[0].columnCount = 50;           // 5 dni po max 10 lekcji
            settings[0].rowCount = 15;              // narazie nie wiadomo ilu bedzie uczniow
            settings[0].rowHeaderSize = 150;
            settings[0].columnWidth = 15;
            settings[0].offset = new Point(0, 0);

            settings.Add(new dataGridSettings());   //oceny
            settings[1].columnCount = 30;           
            settings[1].rowCount = 15;              // narazie nie wiadomo ilu bedzie uczniow
            settings[1].rowHeaderSize = 150;
            settings[1].columnWidth = 20;
            settings[1].offset = new Point(0, 0);

            dataGrid1.Location = addPoints( dataGrid1.Location, settings[0].offset );
            dataGrid1.ColumnCount = settings[0].columnCount;
            dataGrid1.RowCount = settings[0].rowCount;
            dataGrid1.RowHeadersWidth = settings[0].rowHeaderSize;
            dataGrid1.ColumnHeadersVisible = false;

            dataGrid2.Location = addPoints(dataGrid2.Location, settings[1].offset);
            dataGrid2.ColumnCount = settings[1].columnCount;
            dataGrid2.RowCount = settings[1].rowCount;
            dataGrid2.RowHeadersWidth = settings[1].rowHeaderSize;
            dataGrid2.ColumnHeadersVisible = true;

            for (int i = 0; i < dataGrid1.ColumnCount; ++i)
                dataGrid1.Columns[i].Width = settings[0].columnWidth;

            for (int i = 0; i < dataGrid2.ColumnCount; ++i)
                dataGrid2.Columns[i].Width = settings[1].columnWidth;

            

            for (int i = 0; i < dataGrid1.RowCount; ++i)
                dataGrid1.Rows[i].HeaderCell.Value = "Imie i nazwisko";

            for (int i = 0; i < dataGrid2.RowCount; ++i)
                dataGrid2.Rows[i].HeaderCell.Value = "Imie i nazwisko";
            

            dataGrid1.AllowUserToResizeColumns = dataGrid2.AllowUserToResizeColumns = false;
            dataGrid1.AllowUserToResizeRows = dataGrid2.AllowUserToResizeRows = false;
        }

        private void zakończToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void mainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void dateTime_Tick(object sender, EventArgs e)
        {
            statusBar.Items[0].Text = DateTime.Now.ToString();
        }

        private Point addPoints(Point a, Point b)
        {
            return new Point(a.X + b.X, a.Y + b.Y);
        }

    }
}
