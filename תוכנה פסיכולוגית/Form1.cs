using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AForge.Video;
using AForge.Video.DirectShow;

namespace תוכנה_פסיכולוגית
{
    public partial class Form1 : Form
    {
        private FilterInfoCollection videoDevicesList;
        private IVideoSource videoSource;
        public Form1()
        {
            InitializeComponent();
            videoDevicesList = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach (FilterInfo videoDevice in videoDevicesList)
            {
                cmbVideoSource.Items.Add(videoDevice.Name);
            }
            if (cmbVideoSource.Items.Count > 0)
            {
                cmbVideoSource.SelectedIndex = 0;
            }
            else
            {
                MessageBox.Show("No video sources found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)

        {
            panel2.Visible = true;
            panel2.Location = new System.Drawing.Point(0, 0);
            panel2.Size = new System.Drawing.Size(Width , Height );
            if (comboBox1.Text == "פנים עגולות")
            {
                richTextBox1.Text = "אתה אדם חייכן, מלא חיות וחיוניות, חברותי ואופטימי. חוש הומור הינו מרכיב חשוב באישיות שלך ולכן בכל מפגש אתה עשוי להיות במרכז העניינים ולהיות המצחיקן והבדחן שבחבורה. אתה זקוק לחיזוקים, לתשומת לב ולפינוק ולכן אתה עלול להימצא בעצבות ובתחושת התכנסות פנימית ";
                
                label8.Text = "פנים עגולות ";
            }
            if (comboBox1.Text == "פנים מרובעות")
            {
                richTextBox1.Text = " אתה אדם בעלי מזג עצבני משהו. חסרי סבלונות ונוטע להיפגע בקלות. ניחנו בספונטניות ובחוסר סבלנות. רגזנים ונמהרים";
                label8.Text = " פנים מרובעות";
            }
            if (comboBox1.Text == "פנים משולשות")
            {
                richTextBox1.Text = "אתה אדם בעלי מזג נוח , חם, מופנם במידה אך שאפתן ומשיג את רצונך באסרטיביות  ";

                label8.Text = "פנים משולשות  ";
            }
            if (comboBox1.Text == "פנים מאורכות")
            {
                richTextBox1.Text = " אתה אדם בעלי קסם אישי רב , איש שיחה מרתק, עצמאי מאוד , סולדים משגרה חונקת , יצירתי ובעל מעוף. סקרן וחקרן";
                label8.Text = "פנים מאורכות ";
            }
            if (comboBox2.Text == "עיניים קרובות")
            {
                richTextBox1.Text += " בנוסף  אתה עצמאי מאוד ופחות חברותי. רגיש ופגיעה עם נטייה לפסימיות. חסר סבלנות אך אתה מסתיר את זה בחן רב. משדר נינוחות ושלווה אך עלול להתפרץ באגרסיביות רבה";
                label8.Text += " ועיניים קרובות ";
            }
            if (comboBox2.Text == "עיניים בולטות")
            {
                richTextBox1.Text += "בנוסף את איש חמם ורגיש מאוד. חברותי ומלא כריזמה. אתה איש שיחה נפלא עם יכולת שכנוע גבוהה. רעשן ומלא חיים ולכן בכל מקום שבו תמצא טביעה חותם ותדאג להצהיר על נוכחותך. נוטע למצבי רוח משתנים אך אתה נרגע מהר ואינך נוטר טינה ";
                label8.Text += "ועיניים בולטות ";

            }
            if (comboBox2.Text == "עיניים רחוקות")
            {
                richTextBox1.Text += "בנוסף אתה איש קליל הפועל מתוך תחושות בטן. אתה חיי באוירה אופטימית חסרת עכבות . בעל נטייה אומנותית עם כשרון רב ליצירה. סולד ממסגרות ומשתוקקים לחופש ולמרחבים. בעל חוסן נפשי רב ויכולת נתינה רגשית גבוהה מאוד. נאמן ומסור אך זהירות שלא לפגוע בך בשל רגישותך הרבה ";
                label8.Text += " ועיניים רחקות";

            }
            if (comboBox2.Text == "עיניים שקועות")
            {
                richTextBox1.Text += "בנוסף אתה מביעות חולשה נפשית, חוסר בטחון ומופנמות אתה איש רגיש מאוד עם נטייה לפחדים ולחרדות. אתה מתאפיין בחולשה ולא אסרטיבי הנאלץ לקבל בהכנעה את רצון הסביבה. אתה נלחץ בקלות ועלול להימצא במצוקה רגשית . אתה איש טוב וללבי ";
                label8.Text += "ועיניים שקועות";

            }
                 

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            videoSource = new VideoCaptureDevice(videoDevicesList[cmbVideoSource.SelectedIndex].MonikerString);
            videoSource.NewFrame += new NewFrameEventHandler(video_NewFrame);
            videoSource.Start();
        }

        private void video_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            Bitmap bitmap = (Bitmap)eventArgs.Frame.Clone();
            bitmap.RotateFlip(RotateFlipType.RotateNoneFlipX);
            pictureBox1.Image = bitmap;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            videoSource = new VideoCaptureDevice(videoDevicesList[cmbVideoSource.SelectedIndex].MonikerString);
            videoSource.NewFrame += new NewFrameEventHandler(video_NewFrame);
            videoSource.Start();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            videoSource.Stop(); 
            Application.Exit();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            videoSource.Stop();
        }

        private void button1_ClientSizeChanged(object sender, EventArgs e)
        {
          
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            panel2.Size = new System.Drawing.Size(Width, Height);
            label9.Location = new System.Drawing.Point((Width / 2 ) - 122, 10);
            label10.Location = new System.Drawing.Point((Width / 2 ) - 98, 30);
        }
    }
}
