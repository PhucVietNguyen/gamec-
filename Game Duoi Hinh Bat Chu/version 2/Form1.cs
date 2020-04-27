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

namespace version_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int Giay = 60;
        int diem = 0;
        int index;
        int soluongogoiy;
        string[] filedap_an = File.ReadAllLines(@"Dap_An.txt");
        string[] filegoi_y = File.ReadAllLines(@"Goi_Y.txt");
        char[] kytu_button;
        TextBox[] txt;
        Button[] btn;
        int chisoindex;
        int[] LuuTruIndex;

        int chisoindex_kytu;
        int[] LuuTruIndex_kytu;
        char[] kytubutton_saurandom;
        private void Form1_Load(object sender, EventArgs e)
        {
            tm.Start();
            lblDiem.Text = "Điểm Số: " + diem.ToString();
            #region tạo textbox to form
            LuuTruIndex = new int[filedap_an.Length];
            Random rd = new Random();
            index = rd.Next(1, filedap_an.Length + 1);

            ptrHinhAnh.Image = Image.FromFile("game_doan_chu\\" + index + ".jpg");
            ptrHinhAnh.SizeMode = PictureBoxSizeMode.StretchImage;
            chisoindex = 0;
            LuuTruIndex[chisoindex] = index;
            //label1.Text = filedap_an[index - 1];
            Textbox_to_Form();
            #endregion
            soluongogoiy = filedap_an[index - 1].Length * 2;
            Button_to_Form();
            #region in ký tự từ đáp án lên các button, theo một cách không có quy luật(random)
            Dapan_to_Button(rd);
            #endregion
        }

        private void Dapan_to_Button(Random rd)
        {
            kytu_button = new char[filedap_an[index - 1].Length * 2];

            for (int i = 0; i < filedap_an[index - 1].Length; i++)
            {
                kytu_button[i] = filedap_an[index - 1][i];
            }
            for (int i = filedap_an[index - 1].Length; i < filedap_an[index - 1].Length * 2; i++)
            {
                kytu_button[i] = (char)rd.Next(97, 123);
            }
            kytubutton_saurandom = new char[filedap_an[index - 1].Length * 2];
            LuuTruIndex_kytu = new int[filedap_an[index - 1].Length * 2];
            chisoindex_kytu = 0;
            LuuTruIndex_kytu[0] = 0;
            kytubutton_saurandom[0] = kytu_button[0];
            int index_sum;
            bool check;
            do
            {
                check = true;
                index_sum = rd.Next(0, kytu_button.Length);
                for (int i = 0; i <= chisoindex_kytu; i++)
                {
                    if (LuuTruIndex_kytu[i] == index_sum)
                    {
                        check = false;
                        break;
                    }
                }
                if (check == true)
                {
                    chisoindex_kytu++;
                    LuuTruIndex_kytu[chisoindex_kytu] = index_sum;
                    kytubutton_saurandom[chisoindex_kytu] = kytu_button[index_sum];
                }
                if (chisoindex_kytu < kytu_button.Length - 1)//Cực kỳ quan trọng, nếu là size thì sẽ thành vòng lặp vô hạn, phải là size - 1.
                {
                    check = false;
                }
            } while (check == false);

            for (int i = 0; i < kytubutton_saurandom.Length; i++)
            {
                btn[i].Text = kytubutton_saurandom[i].ToString();
            }
        }

        private void Button_to_Form()
        {

            btn = new Button[filedap_an[index - 1].Length * 2];
            btn[0] = new Button();
            btn[1] = new Button();

            int[] x = new int[filedap_an[index - 1].Length * 2];
            int[] y = new int[filedap_an[index - 1].Length * 2];

            x[0] = ptrHinhAnh.Location.X + ptrHinhAnh.Size.Width + 20;
            y[0] = ptrHinhAnh.Location.Y;
            btn[0].Location = new Point(x[0], y[0]);
            btn[0].Size = new System.Drawing.Size(23, 23);
            btn[0].Click += Form1_Click;
            this.Controls.Add(btn[0]);

            x[1] = x[0] + btn[0].Size.Width + 15;
            y[1] = y[0];

            btn[1].Location = new Point(x[1], y[1]);
            btn[1].Size = new System.Drawing.Size(23, 23);
            btn[1].Click+=Form1_Click;
            this.Controls.Add(btn[1]);

            for (int i = 2; i < filedap_an[index - 1].Length * 2; i++)
            {
                btn[i] = new Button();
                x[i] = x[i - 2];
                y[i] = y[i - 2] + btn[0].Size.Height + 15;
                x[i] = x[i - 2];
                y[i] = y[i - 2] + btn[0].Size.Height + 15;
                btn[i].Location = new Point(x[i], y[i]);
                btn[i].Size = new System.Drawing.Size(23, 23);
                btn[i].Click+=Form1_Click;
                this.Controls.Add(btn[i]);
            }
        }

        void Form1_Click(object sender, EventArgs e)
        {
            if (sender is Button)
            {
                foreach (TextBox tex in txt)
                {
                    if (tex.Text == "")
                    {
                        tex.Text = ((Button)sender).Text;
                        ((Button)sender).Visible = false;
                        break;
                    }
                }

                bool check = false;
                foreach (TextBox tex in txt)
                {
                    if (tex.Text == "")
                    {
                        check = true;
                        break;
                    }
                }

                if (check == false)
                {
                    string str = "";
                    foreach (TextBox tex in txt)
                    {
                        str += tex.Text;
                    }

                    if (str == filedap_an[index - 1])
                    {
                        MessageBox.Show("Chinh xac cmnr!");
                        ChuyenSangCauHoiKhac();
                        diem += 3;
                        lblDiem.Text = "Điểm Số: " + diem.ToString();
                        tm.Start();
                        Giay = 60;
                    }
                    else
                    {
                        MessageBox.Show("Sai cmnr!");
                    }
                }
            }
            else if (sender is TextBox)
            {
                foreach (Button button in btn)
                {
                    if (((TextBox)sender).Text == button.Text && button.Visible == false)
                    {
                        button.Visible = true;
                        break;
                    }
                }
                ((TextBox)sender).ResetText();
            }
        }
        private void Textbox_to_Form()
        {
            txt = new TextBox[filedap_an[index - 1].Length];
            txt[0] = new TextBox();
            int[] x = new int[filedap_an[index - 1].Length];
            int[] y = new int[filedap_an[index - 1].Length];
            x[0] = ptrHinhAnh.Location.X;
            y[0] = ptrHinhAnh.Location.Y + ptrHinhAnh.Size.Height + 15;
            txt[0].Location = new Point(x[0], y[0]);
            txt[0].Size = new System.Drawing.Size(20, 20);
            txt[0].Click+=Form1_Click;
            txt[0].ReadOnly = true;
            txt[0].TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Controls.Add(txt[0]);
            for (int i = 1; i < filedap_an[index - 1].Length; i++)
            {
                txt[i] = new TextBox();
                x[i] = x[i - 1] + txt[0].Size.Width + 15;
                y[i] = y[0];
                txt[i].Location = new Point(x[i], y[i]);
                txt[i].Size = new System.Drawing.Size(20, 20);
                txt[i].Click+=Form1_Click;
                txt[i].ReadOnly = true;
                txt[i].TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
                this.Controls.Add(txt[i]);
            }
        }

        private void ChuyenSangCauHoiKhac()
        {
            if (chisoindex == filedap_an.Length - 1)
            {
                MessageBox.Show("Good Game!");
                return;
            }
            bool check;
            Random rd;
            do
            {
                rd = new Random();
                index = rd.Next(1, filedap_an.Length + 1);
                check = true;
                for (int i = 0; i <= chisoindex; i++)
                {
                    if (LuuTruIndex[i] == index)
                    {
                        check = false;
                        break;
                    }
                }
                if (check == true)
                {
                    LuuTruIndex[++chisoindex] = index;
                    ptrHinhAnh.Image = Image.FromFile("game_doan_chu\\" + index + ".jpg");
                    ptrHinhAnh.SizeMode = PictureBoxSizeMode.StretchImage;
                }
            } while (check == false);
            //Xóa đi các ô textbox thừa dựa theo số lượng ký tự có trong đáp án.
            foreach (TextBox t in txt)
            {
                this.Controls.Remove(t);
                t.Dispose();
            }
            Textbox_to_Form();//Add textbox lên form
            //end
            //Xóa đi các ô button thừa dựa theo số lượng ký tự có trong đáp án.
            foreach (Button t in btn)
            {
                this.Controls.Remove(t);
                t.Dispose();
            }
            Button_to_Form();//Add nút nhất lên form
            //end

            kytu_button = new char[filedap_an[index - 1].Length * 2];

            for (int i = 0; i < filedap_an[index - 1].Length; i++)
            {
                kytu_button[i] = filedap_an[index - 1][i];
            }
            for (int i = filedap_an[index - 1].Length; i < filedap_an[index - 1].Length * 2; i++)
            {
                kytu_button[i] = (char)rd.Next(97, 123);
            }

            for (int i = 0; i < filedap_an[index - 1].Length * 2; i++)
            {
                int sum = rd.Next(kytu_button.Length);
                btn[i].Text = kytu_button[sum].ToString();
            }
            Dapan_to_Button(rd);
        }

        private void btnTroGiup_Click(object sender, EventArgs e)
        {
            if(diem >= 4)
            {
                MessageBox.Show(filegoi_y[index - 1], "Hãy đọc kỹ gợi ý nhé!!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                diem -= 4;
                lblDiem.Text = "Điểm Số: " + diem.ToString(); 
            }
            else
            {
                MessageBox.Show("Bạn chưa đủ điều kiện nhận gợi ý!", "Cố gắng lên!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void tm_Tick(object sender, EventArgs e)
        {
            Giay--;
            lblThoiGian.Text = "Thời gian còn lại: " + Giay.ToString() + " giây";
            if (Giay == 0)
            {
                tm.Stop();
                MessageBox.Show("Bạn đã hết thời gian suy nghĩ>>>", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }
    
    }
}
