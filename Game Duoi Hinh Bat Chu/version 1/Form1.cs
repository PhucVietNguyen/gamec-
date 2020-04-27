using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace version_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int dem = 0;//Biến dùng để đếm số thứ tự hiển thị trên textbox, nhận được khi ấn button tương ứng.
        int diem = 0;//Biến dùng để lưu trữ và tính toán điêm có được của người chơi.
        int[] kiemtradem = new int[14];//id của 14 nút nhấn, để lưu trữ khi ta ấn nút nhấn lựa chọn ký tự tương ứng. Chức năng để hiển thị lại nút nhấn lên form khi ta ấn textbox chứa ký tự tương ứng.
        string[] tex = System.IO.File.ReadAllLines(@"Dap_An.txt");//đọc file chứa thông tin đáp án trong file dữ liệu
        string[] goiy = System.IO.File.ReadAllLines(@"Goi_Y.txt");//đọc file chứa thông tin gợi ý tương ứng với đáp án trong file dữ liệu.
        string[] txt = new string[14];//mảng trung gian chứa thông tin từ nút nhấn sang textbox tương ứng.
        string DapAnCuaBan = "";//lưu trữ đáp án của ban để so sánh với đáp án lưu trữ xem có chính xác không?
        private void btnStart_Click(object sender, EventArgs e)
        {
            CatDatButTonAndTextBox();//Cài đặt các nút nhấn chưa dữ liệu là ký tự trên form sao cho hợp lý về mặt hiển thị, để phù hợp với yêu cầu trò chơi.
            DapAnCuaBan = "";
            //reset lại toàn bộ nút nhất chứa ký tự
            btn_1.Visible = true; btn_2.Visible = true; btn_3.Visible = true; btn_4.Visible = true; btn_5.Visible = true; btn_6.Visible = true; btn_7.Visible = true;
            btn_8.Visible = true; btn_9.Visible = true; btn_10.Visible = true; btn_11.Visible = true; btn_12.Visible = true; btn_13.Visible = true; btn_14.Visible = true;
            //reset lại toàn bộ textbox chưa ký tự
            txtChu_1.Clear(); txtChu_2.Clear(); txtChu_3.Clear();  txtChu_4.Clear(); txtChu_5.Clear(); txtChu_6.Clear();
            txtChu_7.Clear(); txtChu_8.Clear(); txtChu_9.Clear(); txtChu_10.Clear(); txtChu_11.Clear(); txtChu_12.Clear();
            //reset lại biến trung gian
            for (int i = 0; i <= dem; i++)
            {
                txt[i] = "";
            }
            dem = 0;
        }
        int index;//Chỉ số random được, nó được dùng cho cả ảnh, đáp án và gợi ý
        private void CatDatButTonAndTextBox()
        {
            //Cài đặt random ảnh gợi ý và câu hỏi
            Random rd = new Random();

            index = rd.Next(1, tex.Length);

            ptrHinhAnh.Image = Image.FromFile("game_doan_chu\\" + index + ".jpg");
            ptrHinhAnh.SizeMode = PictureBoxSizeMode.StretchImage;
            //Các if xử lý sau chính là cài đặt cho các button và các textbox phù hợp với yêu cầu của trò chơi, ẩn hiện phù hợp với số ký tự của đáp án, button sẽ mất đi sau khi ấn chọn
            if (index == 1)
            {
                txtChu_12.Visible = false;
                txtChu_11.Visible = false;
                txtChu_10.Visible = false;
                txtChu_9.Visible = false;
                txtChu_8.Visible = false;
                txtChu_7.Visible = false;
                txtChu_6.Visible = false;

                btn_1.Text = "b"; btn_2.Text = "n"; btn_3.Text = "a"; btn_4.Text = "l"; btn_5.Text = "m"; btn_6.Text = "q"; btn_7.Text = "h";
                btn_8.Text = "o"; btn_9.Text = "a"; btn_10.Text = "b"; btn_11.Text = "x"; btn_12.Text = "e"; btn_13.Text = "k"; btn_14.Text = "u";
            }
            else if (index == 2)
            {
                txtChu_12.Visible = false;
                txtChu_11.Visible = false;
                txtChu_10.Visible = false;
                txtChu_9.Visible = false;
                txtChu_8.Visible = false;
                txtChu_7.Visible = false;
                txtChu_6.Visible = true;
                btn_1.Text = "i"; btn_2.Text = "n"; btn_3.Text = "a"; btn_4.Text = "l"; btn_5.Text = "d"; btn_6.Text = "q"; btn_7.Text = "h";
                btn_8.Text = "o"; btn_9.Text = "d"; btn_10.Text = "b"; btn_11.Text = "x"; btn_12.Text = "e"; btn_13.Text = "k"; btn_14.Text = "u";
            }
            else if (index == 3)
            {
                txtChu_12.Visible = false;
                txtChu_11.Visible = false;
                txtChu_10.Visible = false;
                txtChu_9.Visible = false;
                txtChu_8.Visible = false;
                txtChu_6.Visible = true;
                txtChu_7.Visible = true;
                btn_1.Text = "h"; btn_2.Text = "n"; btn_3.Text = "u"; btn_4.Text = "l"; btn_5.Text = "d"; btn_6.Text = "q"; btn_7.Text = "h";
                btn_8.Text = "g"; btn_9.Text = "d"; btn_10.Text = "b"; btn_11.Text = "t"; btn_12.Text = "e"; btn_13.Text = "k"; btn_14.Text = "u";
            }
            else if (index == 4)
            {
                txtChu_12.Visible = false;
                txtChu_11.Visible = false;
                txtChu_7.Visible = true;
                txtChu_8.Visible = true;
                txtChu_9.Visible = true;
                txtChu_10.Visible = true;
                btn_1.Text = "a"; btn_2.Text = "n"; btn_3.Text = "u"; btn_4.Text = "t"; btn_5.Text = "r"; btn_6.Text = "o"; btn_7.Text = "h";
                btn_8.Text = "o"; btn_9.Text = "i"; btn_10.Text = "n"; btn_11.Text = "a"; btn_12.Text = "g"; btn_13.Text = "t"; btn_14.Text = "u";
            }
            else if (index == 5)
            {
                txtChu_12.Visible = false;
                txtChu_11.Visible = false;
                txtChu_10.Visible = false;
                txtChu_9.Visible = false;
                txtChu_8.Visible = false;
                txtChu_6.Visible = true;
                txtChu_7.Visible = true;
                btn_1.Text = "q"; btn_2.Text = "g"; btn_3.Text = "u"; btn_4.Text = "l"; btn_5.Text = "d"; btn_6.Text = "s"; btn_7.Text = "a";
                btn_8.Text = "o"; btn_9.Text = "d"; btn_10.Text = "a"; btn_11.Text = "a"; btn_12.Text = "e"; btn_13.Text = "b"; btn_14.Text = "t";
            }
            else if (index == 6)
            {
                txtChu_12.Visible = false;
                txtChu_11.Visible = false;
                txtChu_10.Visible = false;
                txtChu_9.Visible = false;
                txtChu_8.Visible = false;
                txtChu_6.Visible = true;
                txtChu_7.Visible = false;
                btn_1.Text = "c"; btn_2.Text = "m"; btn_3.Text = "y"; btn_4.Text = "u"; btn_5.Text = "v"; btn_6.Text = "q"; btn_7.Text = "a";
                btn_8.Text = "n"; btn_9.Text = "h"; btn_10.Text = "a"; btn_11.Text = "a"; btn_12.Text = "c"; btn_13.Text = "t"; btn_14.Text = "c";
            }
            else if (index == 7)
            {
                txtChu_12.Visible = false;
                txtChu_11.Visible = false;
                txtChu_10.Visible = false;
                txtChu_9.Visible = false;
                txtChu_8.Visible = false;
                txtChu_6.Visible = true;
                txtChu_7.Visible = false;
                btn_1.Text = "r"; btn_2.Text = "t"; btn_3.Text = "u"; btn_4.Text = "l"; btn_5.Text = "p"; btn_6.Text = "c"; btn_7.Text = "t";
                btn_8.Text = "a"; btn_9.Text = "n"; btn_10.Text = "s"; btn_11.Text = "a"; btn_12.Text = "m"; btn_13.Text = "c"; btn_14.Text = "h";
            }
            else if (index == 8)
            {
                txtChu_12.Visible = false;
                txtChu_11.Visible = false;
                txtChu_10.Visible = false;
                txtChu_9.Visible = false;
                //btn_5.Visible = true;
                txtChu_8.Visible = true;
                txtChu_6.Visible = true;
                txtChu_7.Visible = true;
                btn_1.Text = "r"; btn_2.Text = "t"; btn_3.Text = "u"; btn_4.Text = "l"; btn_5.Text = "p"; btn_6.Text = "h"; btn_7.Text = "t";
                btn_8.Text = "a"; btn_9.Text = "n"; btn_10.Text = "s"; btn_11.Text = "a"; btn_12.Text = "m"; btn_13.Text = "t"; btn_14.Text = "h";
            }
            else if (index == 9)
            {
                txtChu_12.Visible = false;
                txtChu_11.Visible = false;
                txtChu_10.Visible = false;
                txtChu_9.Visible = false;
                txtChu_8.Visible = false;
                txtChu_6.Visible = true;
                txtChu_7.Visible = true;
               btn_1.Text = "o"; btn_2.Text = "t"; btn_3.Text = "u"; btn_4.Text = "l"; btn_5.Text = "p"; btn_6.Text = "h"; btn_7.Text = "i";
                btn_8.Text = "a"; btn_9.Text = "n"; btn_10.Text = "s"; btn_11.Text = "a"; btn_12.Text = "m"; btn_13.Text = "t"; btn_14.Text = "h";
            }
            else if (index == 10)
            {
                txtChu_12.Visible = false;
                txtChu_11.Visible = false;
                txtChu_10.Visible = false;
                txtChu_9.Visible = false;
                txtChu_8.Visible = false;
                txtChu_6.Visible = true;
                txtChu_7.Visible = false;
                btn_1.Text = "u"; btn_2.Text = "b"; btn_3.Text = "i"; btn_4.Text = "o"; btn_5.Text = "t"; btn_6.Text = "a"; btn_7.Text = "h";
                btn_8.Text = "m"; btn_9.Text = "d"; btn_10.Text = "u"; btn_11.Text = "a"; btn_12.Text = "g"; btn_13.Text = "e"; btn_14.Text = "t";
            }
            else if (index == 11)
            {
                txtChu_12.Visible = false;
                txtChu_11.Visible = false;
                txtChu_10.Visible = false;
                txtChu_9.Visible = false;
                txtChu_8.Visible = false;
                txtChu_6.Visible = true;
                txtChu_7.Visible = false;
                btn_1.Text = "s"; btn_2.Text = "n"; btn_3.Text = "a"; btn_4.Text = "o"; btn_5.Text = "m"; btn_6.Text = "u"; btn_7.Text = "i";
                btn_8.Text = "u"; btn_9.Text = "n"; btn_10.Text = "d"; btn_11.Text = "a"; btn_12.Text = "g"; btn_13.Text = "t"; btn_14.Text = "g";
            }
            else if (index == 12)
            {
                txtChu_12.Visible = false;
                txtChu_11.Visible = true;
                txtChu_10.Visible = true;
                txtChu_9.Visible = true;
                txtChu_8.Visible = true;
                txtChu_6.Visible = true;
                txtChu_7.Visible = true;
                btn_1.Text = "e"; btn_2.Text = "n"; btn_3.Text = "n"; btn_4.Text = "d"; btn_5.Text = "m"; btn_6.Text = "u"; btn_7.Text = "u";
                btn_8.Text = "a"; btn_9.Text = "a"; btn_10.Text = "t"; btn_11.Text = "g"; btn_12.Text = "y"; btn_13.Text = "a"; btn_14.Text = "d";
            }
            else if (index == 13)
            {
                txtChu_12.Visible = false;
                txtChu_11.Visible = false;
                txtChu_10.Visible = false;
                txtChu_9.Visible = false;
                txtChu_8.Visible = false;
                txtChu_6.Visible = true;
                txtChu_7.Visible = true;
                btn_1.Text = "a"; btn_2.Text = "e"; btn_3.Text = "n"; btn_4.Text = "d"; btn_5.Text = "g"; btn_6.Text = "a"; btn_7.Text = "u";
                btn_8.Text = "g"; btn_9.Text = "n"; btn_10.Text = "t"; btn_11.Text = "m"; btn_12.Text = "y"; btn_13.Text = "d"; btn_14.Text = "u";
            }
            else if (index == 14)
            {
                txtChu_12.Visible = false;
                txtChu_11.Visible = false;
                txtChu_10.Visible = false;
                txtChu_9.Visible = false;
                txtChu_8.Visible = false;
                txtChu_6.Visible = true;
                txtChu_7.Visible = false;
                btn_1.Text = "a"; btn_2.Text = "e"; btn_3.Text = "h"; btn_4.Text = "d"; btn_5.Text = "i"; btn_6.Text = "a"; btn_7.Text = "u";
                btn_8.Text = "b"; btn_9.Text = "p"; btn_10.Text = "t"; btn_11.Text = "n"; btn_12.Text = "e"; btn_13.Text = "d"; btn_14.Text = "o";
            }
        }
        private void btn_1_Click(object sender, EventArgs e)
        {
            txt[dem] = btn_1.Text;//Lưu giá trị của button vào biến trung gian txt.
            btn_1.Visible = false;//ẩn button sau khi ấn chọn
            dem++;/*giá trị này cực ký quan trọng là mấu chốt giải quyết vấn đề làm sao cho khi ấn button, thì giá trị hiển thị lên textbox phải tương ứng
                   ví du: bt_5 được ấn thứ nhất, thì giá trị của nó sẽ hiển thị lên texbox thứ 1 theo chiều đọc của mình, bt_2 được ấn thứ 2 thì hiển thị lên ô thứ 2....*/
            ButtonToTextbox();//Chuyển dữ liệu từ button sang textbox tương ứng.
            //Sau khi ấn ký tự cuối cùng được nhập vào thì toàn bộ button còn lại sẽ biến mất không có phép ta nhập nữa
            if (dem == tex[index - 1].Length)
            {
                btn_1.Visible = false; btn_2.Visible = false; btn_3.Visible = false; btn_4.Visible = false; btn_5.Visible = false; btn_6.Visible = false; btn_7.Visible = false;
                btn_8.Visible = false; btn_9.Visible = false; btn_10.Visible = false; btn_11.Visible = false; btn_12.Visible = false; btn_13.Visible = false; btn_14.Visible = false;
            }
            kiemtradem[0] = dem;//id của nút nhấn thứ 1
        }

        private void ButtonToTextbox()
        {
            txtChu_1.Text = txt[0]; txtChu_2.Text = txt[1]; txtChu_3.Text = txt[2]; txtChu_4.Text = txt[3]; txtChu_5.Text = txt[4]; txtChu_6.Text = txt[5];
            txtChu_7.Text = txt[6]; txtChu_8.Text = txt[7]; txtChu_9.Text = txt[8]; txtChu_10.Text = txt[9]; txtChu_11.Text = txt[10]; txtChu_12.Text = txt[11];
        }

        private void btn_2_Click(object sender, EventArgs e)
        {
            txt[dem] = btn_2.Text;
            btn_2.Visible = false;
            dem++;
            ButtonToTextbox();
            if (dem == tex[index - 1].Length)
            {
                btn_1.Visible = false; btn_2.Visible = false; btn_3.Visible = false; btn_4.Visible = false; btn_5.Visible = false; btn_6.Visible = false; btn_7.Visible = false;
                btn_8.Visible = false; btn_9.Visible = false; btn_10.Visible = false; btn_11.Visible = false; btn_12.Visible = false; btn_13.Visible = false; btn_14.Visible = false;
            }
            kiemtradem[1] = dem;
        }

        private void btn_3_Click(object sender, EventArgs e)
        {
            txt[dem] = btn_3.Text;
            btn_3.Visible = false;
            dem++;
            ButtonToTextbox();
            if (dem == tex[index - 1].Length)
            {
                btn_1.Visible = false; btn_2.Visible = false; btn_3.Visible = false; btn_4.Visible = false; btn_5.Visible = false; btn_6.Visible = false; btn_7.Visible = false;
                btn_8.Visible = false; btn_9.Visible = false; btn_10.Visible = false; btn_11.Visible = false; btn_12.Visible = false; btn_13.Visible = false; btn_14.Visible = false;
            }
            kiemtradem[2] = dem;
        }

        private void btn_4_Click(object sender, EventArgs e)
        {
            txt[dem] = btn_4.Text;
            btn_4.Visible = false;
            dem++;
            ButtonToTextbox();
            if (dem == tex[index - 1].Length)
            {
                btn_1.Visible = false; btn_2.Visible = false; btn_3.Visible = false; btn_4.Visible = false; btn_5.Visible = false; btn_6.Visible = false; btn_7.Visible = false;
                btn_8.Visible = false; btn_9.Visible = false; btn_10.Visible = false; btn_11.Visible = false; btn_12.Visible = false; btn_13.Visible = false; btn_14.Visible = false;
            }
            kiemtradem[3] = dem;
        }

        private void btn_5_Click(object sender, EventArgs e)
        {
            txt[dem] = btn_5.Text;
            btn_5.Visible = false;
            dem++;
            ButtonToTextbox();
            if (dem == tex[index - 1].Length)
            {
                btn_1.Visible = false; btn_2.Visible = false; btn_3.Visible = false; btn_4.Visible = false; btn_5.Visible = false; btn_6.Visible = false; btn_7.Visible = false;
                btn_8.Visible = false; btn_9.Visible = false; btn_10.Visible = false; btn_11.Visible = false; btn_12.Visible = false; btn_13.Visible = false; btn_14.Visible = false;
            }
            kiemtradem[4] = dem;
        }

        private void btn_6_Click(object sender, EventArgs e)
        {
            txt[dem] = btn_6.Text;
            btn_6.Visible = false;
            dem++;
            ButtonToTextbox();
            if (dem == tex[index - 1].Length)
            {
                btn_1.Visible = false; btn_2.Visible = false; btn_3.Visible = false; btn_4.Visible = false; btn_5.Visible = false; btn_6.Visible = false; btn_7.Visible = false;
                btn_8.Visible = false; btn_9.Visible = false; btn_10.Visible = false; btn_11.Visible = false; btn_12.Visible = false; btn_13.Visible = false; btn_14.Visible = false;
            }
            kiemtradem[5] = dem;
        }

        private void btn_7_Click(object sender, EventArgs e)
        {
            txt[dem] = btn_7.Text;
            btn_7.Visible = false;
            dem++;
            ButtonToTextbox();
            if (dem == tex[index - 1].Length)
            {
                btn_1.Visible = false; btn_2.Visible = false; btn_3.Visible = false; btn_4.Visible = false; btn_5.Visible = false; btn_6.Visible = false; btn_7.Visible = false;
                btn_8.Visible = false; btn_9.Visible = false; btn_10.Visible = false; btn_11.Visible = false; btn_12.Visible = false; btn_13.Visible = false; btn_14.Visible = false;
            }
            kiemtradem[6] = dem;
        }

        private void btn_8_Click(object sender, EventArgs e)
        {
            txt[dem] = btn_8.Text;
            btn_8.Visible = false;
            dem++;
            ButtonToTextbox();
            if (dem == tex[index - 1].Length)
            {
                btn_1.Visible = false; btn_2.Visible = false; btn_3.Visible = false; btn_4.Visible = false; btn_5.Visible = false; btn_6.Visible = false; btn_7.Visible = false;
                btn_8.Visible = false; btn_9.Visible = false; btn_10.Visible = false; btn_11.Visible = false; btn_12.Visible = false; btn_13.Visible = false; btn_14.Visible = false;
            }
            kiemtradem[7] = dem;
        }

        private void btn_9_Click(object sender, EventArgs e)
        {
            txt[dem] = btn_9.Text;
            btn_9.Visible = false;
            dem++;
            ButtonToTextbox();
            if (dem == tex[index - 1].Length)
            {
                btn_1.Visible = false; btn_2.Visible = false; btn_3.Visible = false; btn_4.Visible = false; btn_5.Visible = false; btn_6.Visible = false; btn_7.Visible = false;
                btn_8.Visible = false; btn_9.Visible = false; btn_10.Visible = false; btn_11.Visible = false; btn_12.Visible = false; btn_13.Visible = false; btn_14.Visible = false;
            }
            kiemtradem[8] = dem;
        }

        private void btn_10_Click(object sender, EventArgs e)
        {
            txt[dem] = btn_10.Text;
            btn_10.Visible = false;
            dem++;
            ButtonToTextbox();
            if (dem == tex[index - 1].Length)
            {
                btn_1.Visible = false; btn_2.Visible = false; btn_3.Visible = false; btn_4.Visible = false; btn_5.Visible = false; btn_6.Visible = false; btn_7.Visible = false;
                btn_8.Visible = false; btn_9.Visible = false; btn_10.Visible = false; btn_11.Visible = false; btn_12.Visible = false; btn_13.Visible = false; btn_14.Visible = false;
            }
            kiemtradem[9] = dem;
        }

        private void btn_11_Click(object sender, EventArgs e)
        {
            txt[dem] = btn_11.Text;
            btn_11.Visible = false;
            dem++;
            ButtonToTextbox();
            if (dem == tex[index - 1].Length)
            {
                btn_1.Visible = false; btn_2.Visible = false; btn_3.Visible = false; btn_4.Visible = false; btn_5.Visible = false; btn_6.Visible = false; btn_7.Visible = false;
                btn_8.Visible = false; btn_9.Visible = false; btn_10.Visible = false; btn_11.Visible = false; btn_12.Visible = false; btn_13.Visible = false; btn_14.Visible = false;
            }
            kiemtradem[10] = dem;
        }

        private void btn_12_Click(object sender, EventArgs e)
        {
            txt[dem] = btn_12.Text;
            btn_12.Visible = false;
            dem++;
            ButtonToTextbox();
            if (dem == tex[index - 1].Length)
            {
                btn_1.Visible = false; btn_2.Visible = false; btn_3.Visible = false; btn_4.Visible = false; btn_5.Visible = false; btn_6.Visible = false; btn_7.Visible = false;
                btn_8.Visible = false; btn_9.Visible = false; btn_10.Visible = false; btn_11.Visible = false; btn_12.Visible = false; btn_13.Visible = false; btn_14.Visible = false;
            }
            kiemtradem[11] = dem;
        }

        private void btn_13_Click(object sender, EventArgs e)
        {
            txt[dem] = btn_13.Text;
            btn_13.Visible = false;
            dem++;
            ButtonToTextbox();
            if (dem == tex[index - 1].Length)
            {
                btn_1.Visible = false; btn_2.Visible = false; btn_3.Visible = false; btn_4.Visible = false; btn_5.Visible = false; btn_6.Visible = false; btn_7.Visible = false;
                btn_8.Visible = false; btn_9.Visible = false; btn_10.Visible = false; btn_11.Visible = false; btn_12.Visible = false; btn_13.Visible = false; btn_14.Visible = false;
            }
            kiemtradem[12] = dem;
        }

        private void btn_14_Click(object sender, EventArgs e)
        {
            txt[dem] = btn_14.Text; 
            btn_14.Visible = false;
            dem++;
            ButtonToTextbox();
            if (dem == tex[index - 1].Length)
            {
                btn_1.Visible = false; btn_2.Visible = false; btn_3.Visible = false; btn_4.Visible = false; btn_5.Visible = false; btn_6.Visible = false; btn_7.Visible = false;
                btn_8.Visible = false; btn_9.Visible = false; btn_10.Visible = false; btn_11.Visible = false; btn_12.Visible = false; btn_13.Visible = false; btn_14.Visible = false;
            }
            kiemtradem[13] = dem;
        }

        private void btnKiemTra_Click(object sender, EventArgs e)
        {
            DapAnCuaBan = txtChu_1.Text + txtChu_2.Text + txtChu_3.Text + txtChu_4.Text + txtChu_5.Text + txtChu_6.Text 
                + txtChu_7.Text + txtChu_8.Text + txtChu_9.Text + txtChu_10.Text + txtChu_11.Text + txtChu_12.Text;
            int size = tex.Length;
            if (tex[index - 1] == DapAnCuaBan)
            {
                diem += 3;
                MessageBox.Show("Chính xác!", "Tuyệt cmn vời");
                txtChu_1.Clear(); txtChu_2.Clear(); txtChu_3.Clear(); ; txtChu_4.Clear(); txtChu_5.Clear(); txtChu_6.Clear();
                txtChu_7.Clear(); txtChu_8.Clear(); txtChu_9.Clear(); txtChu_10.Clear(); txtChu_11.Clear(); txtChu_12.Clear();
                for (int i = 0; i <= dem; i++)
                {
                    txt[i] = "";
                }
                dem = 0;
                DapAnCuaBan = "";
                lblDiem.Text = "Điểm số: " + diem.ToString();
            }
            else
            {
                MessageBox.Show("Sai rồi, hãy thử lại nào", "huhu!");
                txtChu_1.Clear(); txtChu_2.Clear(); txtChu_3.Clear(); ; txtChu_4.Clear(); txtChu_5.Clear(); txtChu_6.Clear();
                txtChu_7.Clear(); txtChu_8.Clear(); txtChu_9.Clear(); txtChu_10.Clear(); txtChu_11.Clear(); txtChu_12.Clear();
                for (int i = 0; i <= dem; i++)
                {
                    txt[i] = "";
                }
                btn_1.Visible = true; btn_2.Visible = true; btn_3.Visible = true; btn_4.Visible = true; btn_5.Visible = true; btn_6.Visible = true; btn_7.Visible = true;
                btn_8.Visible = true; btn_9.Visible = true; btn_10.Visible = true; btn_11.Visible = true; btn_12.Visible = true; btn_13.Visible = true; btn_14.Visible = true;
                dem = 0;
                DapAnCuaBan = "";
            }

        }

        private void txtChu_1_Click(object sender, EventArgs e)
        {
            if (txtChu_1.Text != "")
            {
                txt[dem] = "";
                bool check = false;
                if (btn_1.Text == txtChu_1.Text && check == false && kiemtradem[0] == dem)
                {
                    btn_1.Visible = true;
                    check = true;
                }
                if (btn_2.Text == txtChu_1.Text && check == false && kiemtradem[1] == dem)
                {
                    btn_2.Visible = true;
                    check = true;
                }
                if (btn_3.Text == txtChu_1.Text && check == false && kiemtradem[2] == dem)
                {
                    btn_3.Visible = true;
                    check = true;
                }
                if (btn_4.Text == txtChu_1.Text && check == false && kiemtradem[3] == dem)
                {
                    btn_4.Visible = true;
                    check = true;
                }
                if (btn_5.Text == txtChu_1.Text && check == false && kiemtradem[4] == dem)
                {
                    btn_5.Visible = true;
                    check = true;
                }
                if (btn_6.Text == txtChu_1.Text && check == false && kiemtradem[5] == dem)
                {
                    btn_6.Visible = true;
                    check = true;
                }
                if (btn_7.Text == txtChu_1.Text && check == false && kiemtradem[6] == dem)
                {
                    btn_7.Visible = true;
                    check = true;
                }
                if (btn_8.Text == txtChu_1.Text && check == false && kiemtradem[7] == dem)
                {
                    btn_8.Visible = true;
                    check = true;
                }
                if (btn_9.Text == txtChu_1.Text && check == false && kiemtradem[8] == dem)
                {
                    btn_9.Visible = true;
                    check = true;
                }
                if (btn_10.Text == txtChu_1.Text && check == false && kiemtradem[9] == dem)
                {
                    btn_10.Visible = true;
                    check = true;
                }
                if (btn_11.Text == txtChu_1.Text && check == false && kiemtradem[10] == dem)
                {
                    btn_11.Visible = true;
                    check = true;
                }
                if (btn_12.Text == txtChu_1.Text && check == false && kiemtradem[11] == dem)
                {
                    btn_12.Visible = true;
                    check = true;
                }
                if (btn_13.Text == txtChu_1.Text && check == false && kiemtradem[12] == dem)
                {
                    btn_13.Visible = true;
                    check = true;
                }
                if (btn_14.Text == txtChu_1.Text && check == false && kiemtradem[13] == dem)
                {
                    btn_14.Visible = true;
                    check = true;
                }
                dem--;
                txtChu_1.Clear();
            }
        }

        private void txtChu_2_Click(object sender, EventArgs e)
        {
            if (txtChu_2.Text != "")
            {
                txt[dem] = "";
                bool check = false;
                if (btn_1.Text == txtChu_2.Text && check == false && kiemtradem[0] == dem)
                {
                    btn_1.Visible = true;
                    check = true;
                }
                if (btn_2.Text == txtChu_2.Text && check == false && kiemtradem[1] == dem)
                {
                    btn_2.Visible = true;
                    check = true;
                }
                if (btn_3.Text == txtChu_2.Text && check == false && kiemtradem[2] == dem)
                {
                    btn_3.Visible = true;
                    check = true;
                }
                if (btn_4.Text == txtChu_2.Text && check == false && kiemtradem[3] == dem)
                {
                    btn_4.Visible = true;
                    check = true;
                }
                if (btn_5.Text == txtChu_2.Text && check == false && kiemtradem[4] == dem)
                {
                    btn_5.Visible = true;
                    check = true;
                }
                if (btn_6.Text == txtChu_2.Text && check == false && kiemtradem[5] == dem)
                {
                    btn_6.Visible = true;
                    check = true;
                }
                if (btn_7.Text == txtChu_2.Text && check == false && kiemtradem[6] == dem)
                {
                    btn_7.Visible = true;
                    check = true;
                }
                if (btn_8.Text == txtChu_2.Text && check == false && kiemtradem[7] == dem)
                {
                    btn_8.Visible = true;
                    check = true;
                }
                if (btn_9.Text == txtChu_2.Text && check == false && kiemtradem[8] == dem)
                {
                    btn_9.Visible = true;
                    check = true;
                }
                if (btn_10.Text == txtChu_2.Text && check == false && kiemtradem[9] == dem)
                {
                    btn_10.Visible = true;
                    check = true;
                }
                if (btn_11.Text == txtChu_2.Text && check == false && kiemtradem[10] == dem)
                {
                    btn_11.Visible = true;
                    check = true;
                }
                if (btn_12.Text == txtChu_2.Text && check == false && kiemtradem[11] == dem)
                {
                    btn_12.Visible = true;
                    check = true;
                }
                if (btn_13.Text == txtChu_2.Text && check == false && kiemtradem[12] == dem)
                {
                    btn_13.Visible = true;
                    check = true;
                }
                if (btn_14.Text == txtChu_2.Text && check == false && kiemtradem[13] == dem)
                {
                    btn_14.Visible = true;
                    check = true;
                }
                dem--;
                txtChu_2.Clear();
            }
        }

        private void txtChu_3_Click(object sender, EventArgs e)
        {
            if (txtChu_3.Text != "")
            {
                txt[dem] = "";
                bool check = false;
                if (btn_1.Text == txtChu_3.Text && check == false && kiemtradem[0] == dem)
                {
                    btn_1.Visible = true;
                    check = true;
                }
                if (btn_2.Text == txtChu_3.Text && check == false && kiemtradem[1] == dem)
                {
                    btn_2.Visible = true;
                    check = true;
                }
                if (btn_3.Text == txtChu_3.Text && check == false && kiemtradem[2] == dem)
                {
                    btn_3.Visible = true;
                    check = true;
                }
                if (btn_4.Text == txtChu_3.Text && check == false && kiemtradem[3] == dem)
                {
                    btn_4.Visible = true;
                    check = true;
                }
                if (btn_5.Text == txtChu_3.Text && check == false && kiemtradem[4] == dem)
                {
                    btn_5.Visible = true;
                    check = true;
                }
                if (btn_6.Text == txtChu_3.Text && check == false && kiemtradem[5] == dem)
                {
                    btn_6.Visible = true;
                    check = true;
                }
                if (btn_7.Text == txtChu_3.Text && check == false && kiemtradem[6] == dem)
                {
                    btn_7.Visible = true;
                    check = true;
                }
                if (btn_8.Text == txtChu_3.Text && check == false && kiemtradem[7] == dem)
                {
                    btn_8.Visible = true;
                    check = true;
                }
                if (btn_9.Text == txtChu_3.Text && check == false && kiemtradem[8] == dem)
                {
                    btn_9.Visible = true;
                    check = true;
                }
                if (btn_10.Text == txtChu_3.Text && check == false && kiemtradem[9] == dem)
                {
                    btn_10.Visible = true;
                    check = true;
                }
                if (btn_11.Text == txtChu_3.Text && check == false && kiemtradem[10] == dem)
                {
                    btn_11.Visible = true;
                    check = true;
                }
                if (btn_12.Text == txtChu_3.Text && check == false && kiemtradem[11] == dem)
                {
                    btn_12.Visible = true;
                    check = true;
                }
                if (btn_13.Text == txtChu_3.Text && check == false && kiemtradem[12] == dem)
                {
                    btn_13.Visible = true;
                    check = true;
                }
                if (btn_14.Text == txtChu_3.Text && check == false && kiemtradem[13] == dem)
                {
                    btn_14.Visible = true;
                    check = true;
                }
                dem--;
                txtChu_3.Clear();
            }
        }

        private void txtChu_4_Click(object sender, EventArgs e)
        {
            if (txtChu_4.Text != "")
            {
                txt[dem] = "";
                
                bool check = false;
                if (btn_1.Text == txtChu_4.Text && check == false && kiemtradem[0] == dem)
                {
                    btn_1.Visible = true;
                    check = true;
                }
                if (btn_2.Text == txtChu_4.Text && check == false && kiemtradem[1] == dem)
                {
                    btn_2.Visible = true;
                    check = true;
                }
                if (btn_3.Text == txtChu_4.Text && check == false && kiemtradem[2] == dem)
                {
                    btn_3.Visible = true;
                    check = true;
                }
                if (btn_4.Text == txtChu_4.Text && check == false && kiemtradem[3] == dem)
                {
                    btn_4.Visible = true;
                    check = true;
                }
                if (btn_5.Text == txtChu_4.Text && check == false && kiemtradem[4] == dem)
                {
                    btn_5.Visible = true;
                    check = true;
                }
                if (btn_6.Text == txtChu_4.Text && check == false && kiemtradem[5] == dem)
                {
                    btn_6.Visible = true;
                    check = true;
                }
                if (btn_7.Text == txtChu_4.Text && check == false && kiemtradem[6] == dem)
                {
                    btn_7.Visible = true;
                    check = true;
                }
                if (btn_8.Text == txtChu_4.Text && check == false && kiemtradem[7] == dem)
                {
                    btn_8.Visible = true;
                    check = true;
                }
                if (btn_9.Text == txtChu_4.Text && check == false && kiemtradem[8] == dem)
                {
                    btn_9.Visible = true;
                    check = true;
                }
                if (btn_10.Text == txtChu_4.Text && check == false && kiemtradem[9] == dem)
                {
                    btn_10.Visible = true;
                    check = true;
                }
                if (btn_11.Text == txtChu_4.Text && check == false && kiemtradem[10] == dem)
                {
                    btn_11.Visible = true;
                    check = true;
                }
                if (btn_12.Text == txtChu_4.Text && check == false && kiemtradem[11] == dem)
                {
                    btn_12.Visible = true;
                    check = true;
                }
                if (btn_13.Text == txtChu_4.Text && check == false && kiemtradem[12] == dem)
                {
                    btn_13.Visible = true;
                    check = true;
                }
                if (btn_14.Text == txtChu_4.Text && check == false && kiemtradem[13] == dem)
                {
                    btn_14.Visible = true;
                    check = true;
                }
                dem--;
                txtChu_4.Clear();
            }
        }

        private void txtChu_5_Click(object sender, EventArgs e)
        {
            if (txtChu_5.Text != "")
            {
                txt[dem] = "";
             
                bool check = false;
                if (btn_1.Text == txtChu_5.Text && check == false && kiemtradem[0] == dem)
                {
                    btn_1.Visible = true;
                    check = true;
                }
                if (btn_2.Text == txtChu_5.Text && check == false && kiemtradem[1] == dem)
                {
                    btn_2.Visible = true;
                    check = true;
                }
                if (btn_3.Text == txtChu_5.Text && check == false && kiemtradem[2] == dem)
                {
                    btn_3.Visible = true;
                    check = true;
                }
                if (btn_4.Text == txtChu_5.Text && check == false && kiemtradem[3] == dem)
                {
                    btn_4.Visible = true;
                    check = true;
                }
                if (btn_5.Text == txtChu_5.Text && check == false && kiemtradem[4] == dem)
                {
                    btn_5.Visible = true;
                    check = true;
                }
                if (btn_6.Text == txtChu_5.Text && check == false && kiemtradem[5] == dem)
                {
                    btn_6.Visible = true;
                    check = true;
                }
                if (btn_7.Text == txtChu_5.Text && check == false && kiemtradem[6] == dem)
                {
                    btn_7.Visible = true;
                    check = true;
                }
                if (btn_8.Text == txtChu_5.Text && check == false && kiemtradem[7] == dem)
                {
                    btn_8.Visible = true;
                    check = true;
                }
                if (btn_9.Text == txtChu_5.Text && check == false && kiemtradem[8] == dem)
                {
                    btn_9.Visible = true;
                    check = true;
                }
                if (btn_10.Text == txtChu_5.Text && check == false && kiemtradem[9] == dem)
                {
                    btn_10.Visible = true;
                    check = true;
                }
                if (btn_11.Text == txtChu_5.Text && check == false && kiemtradem[10] == dem)
                {
                    btn_11.Visible = true;
                    check = true;
                }
                if (btn_12.Text == txtChu_5.Text && check == false && kiemtradem[11] == dem)
                {
                    btn_12.Visible = true;
                    check = true;
                }
                if (btn_13.Text == txtChu_5.Text && check == false && kiemtradem[12] == dem)
                {
                    btn_13.Visible = true;
                    check = true;
                }
                if (btn_14.Text == txtChu_5.Text && check == false && kiemtradem[13] == dem)
                {
                    btn_14.Visible = true;
                    check = true;
                }
                dem--;
                txtChu_5.Clear();
            }
        }

        private void txtChu_6_Click(object sender, EventArgs e)
        {
            if (txtChu_6.Text != "")
            {
                txt[dem] = "";
             
                bool check = false;
                if (btn_1.Text == txtChu_6.Text && check == false && kiemtradem[0] == dem)
                {
                    btn_1.Visible = true;
                    check = true;
                }
                if (btn_2.Text == txtChu_6.Text && check == false && kiemtradem[1] == dem)
                {
                    btn_2.Visible = true;
                    check = true;
                }
                if (btn_3.Text == txtChu_6.Text && check == false && kiemtradem[2] == dem)
                {
                    btn_3.Visible = true;
                    check = true;
                }
                if (btn_4.Text == txtChu_6.Text && check == false && kiemtradem[3] == dem)
                {
                    btn_4.Visible = true;
                    check = true;
                }
                if (btn_5.Text == txtChu_6.Text && check == false && kiemtradem[4] == dem)
                {
                    btn_5.Visible = true;
                    check = true;
                }
                if (btn_6.Text == txtChu_6.Text && check == false && kiemtradem[5] == dem)
                {
                    btn_6.Visible = true;
                    check = true;
                }
                if (btn_7.Text == txtChu_6.Text && check == false && kiemtradem[6] == dem)
                {
                    btn_7.Visible = true;
                    check = true;
                }
                if (btn_8.Text == txtChu_6.Text && check == false && kiemtradem[7] == dem)
                {
                    btn_8.Visible = true;
                    check = true;
                }
                if (btn_9.Text == txtChu_6.Text && check == false && kiemtradem[8] == dem)
                {
                    btn_9.Visible = true;
                    check = true;
                }
                if (btn_10.Text == txtChu_6.Text && check == false && kiemtradem[9] == dem)
                {
                    btn_10.Visible = true;
                    check = true;
                }
                if (btn_11.Text == txtChu_6.Text && check == false && kiemtradem[10] == dem)
                {
                    btn_11.Visible = true;
                    check = true;
                }
                if (btn_12.Text == txtChu_6.Text && check == false && kiemtradem[11] == dem)
                {
                    btn_12.Visible = true;
                    check = true;
                }
                if (btn_13.Text == txtChu_6.Text && check == false && kiemtradem[12] == dem)
                {
                    btn_13.Visible = true;
                    check = true;
                }
                if (btn_14.Text == txtChu_6.Text && check == false && kiemtradem[13] == dem)
                {
                    btn_14.Visible = true;
                    check = true;
                }
                dem--;
                txtChu_6.Clear();
            }
        }

        private void txtChu_7_Click(object sender, EventArgs e)
        {
            if (txtChu_7.Text != "")
            {
                txt[dem] = "";
                
                bool check = false;
                if (btn_1.Text == txtChu_7.Text && check == false && kiemtradem[0] == dem)
                {
                    btn_1.Visible = true;
                    check = true;
                }
                if (btn_2.Text == txtChu_7.Text && check == false && kiemtradem[1] == dem)
                {
                    btn_2.Visible = true;
                    check = true;
                }
                if (btn_3.Text == txtChu_7.Text && check == false && kiemtradem[2] == dem)
                {
                    btn_3.Visible = true;
                    check = true;
                }
                if (btn_4.Text == txtChu_7.Text && check == false && kiemtradem[3] == dem)
                {
                    btn_4.Visible = true;
                    check = true;
                }
                if (btn_5.Text == txtChu_7.Text && check == false && kiemtradem[4] == dem)
                {
                    btn_5.Visible = true;
                    check = true;
                }
                if (btn_6.Text == txtChu_7.Text && check == false && kiemtradem[5] == dem)
                {
                    btn_6.Visible = true;
                    check = true;
                }
                if (btn_7.Text == txtChu_7.Text && check == false && kiemtradem[6] == dem)
                {
                    btn_7.Visible = true;
                    check = true;
                }
                if (btn_8.Text == txtChu_7.Text && check == false && kiemtradem[7] == dem)
                {
                    btn_8.Visible = true;
                    check = true;
                }
                if (btn_9.Text == txtChu_7.Text && check == false && kiemtradem[8] == dem)
                {
                    btn_9.Visible = true;
                    check = true;
                }
                if (btn_10.Text == txtChu_7.Text && check == false && kiemtradem[9] == dem)
                {
                    btn_10.Visible = true;
                    check = true;
                }
                if (btn_11.Text == txtChu_7.Text && check == false && kiemtradem[10] == dem)
                {
                    btn_11.Visible = true;
                    check = true;
                }
                if (btn_12.Text == txtChu_7.Text && check == false && kiemtradem[11] == dem)
                {
                    btn_12.Visible = true;
                    check = true;
                }
                if (btn_13.Text == txtChu_7.Text && check == false && kiemtradem[12] == dem)
                {
                    btn_13.Visible = true;
                    check = true;
                }
                if (btn_14.Text == txtChu_7.Text && check == false && kiemtradem[13] == dem)
                {
                    btn_14.Visible = true;
                    check = true;
                }
                dem--;
                txtChu_7.Clear();
            }
        }

        private void txtChu_8_Click(object sender, EventArgs e)
        {
            if (txtChu_8.Text != "")
            {
                txt[dem] = "";
                
                bool check = false;
                if (btn_1.Text == txtChu_8.Text && check == false && kiemtradem[0] == dem)
                {
                    btn_1.Visible = true;
                    check = true;
                }
                if (btn_2.Text == txtChu_8.Text && check == false && kiemtradem[1] == dem)
                {
                    btn_2.Visible = true;
                    check = true;
                }
                if (btn_3.Text == txtChu_8.Text && check == false && kiemtradem[2] == dem)
                {
                    btn_3.Visible = true;
                    check = true;
                }
                if (btn_4.Text == txtChu_8.Text && check == false && kiemtradem[3] == dem)
                {
                    btn_4.Visible = true;
                    check = true;
                }
                if (btn_5.Text == txtChu_8.Text && check == false && kiemtradem[4] == dem)
                {
                    btn_5.Visible = true;
                    check = true;
                }
                if (btn_6.Text == txtChu_8.Text && check == false && kiemtradem[5] == dem)
                {
                    btn_6.Visible = true;
                    check = true;
                }
                if (btn_7.Text == txtChu_8.Text && check == false && kiemtradem[6] == dem)
                {
                    btn_7.Visible = true;
                    check = true;
                }
                if (btn_8.Text == txtChu_8.Text && check == false && kiemtradem[7] == dem)
                {
                    btn_8.Visible = true;
                    check = true;
                }
                if (btn_9.Text == txtChu_8.Text && check == false && kiemtradem[8] == dem)
                {
                    btn_9.Visible = true;
                    check = true;
                }
                if (btn_10.Text == txtChu_8.Text && check == false && kiemtradem[9] == dem)
                {
                    btn_10.Visible = true;
                    check = true;
                }
                if (btn_11.Text == txtChu_8.Text && check == false && kiemtradem[10] == dem)
                {
                    btn_11.Visible = true;
                    check = true;
                }
                if (btn_12.Text == txtChu_8.Text && check == false && kiemtradem[11] == dem)
                {
                    btn_12.Visible = true;
                    check = true;
                }
                if (btn_13.Text == txtChu_8.Text && check == false && kiemtradem[12] == dem)
                {
                    btn_13.Visible = true;
                    check = true;
                }
                if (btn_14.Text == txtChu_8.Text && check == false && kiemtradem[13] == dem)
                {
                    btn_14.Visible = true;
                    check = true;
                }
                dem--;
                txtChu_8.Clear();
            }
        }

        private void txtChu_9_Click(object sender, EventArgs e)
        {
            if (txtChu_9.Text != "")
            {
                txt[dem] = "";
             
                bool check = false;
                if (btn_1.Text == txtChu_9.Text && check == false && kiemtradem[0] == dem)
                {
                    btn_1.Visible = true;
                    check = true;
                }
                if (btn_2.Text == txtChu_9.Text && check == false && kiemtradem[1] == dem)
                {
                    btn_2.Visible = true;
                    check = true;
                }
                if (btn_3.Text == txtChu_9.Text && check == false && kiemtradem[2] == dem)
                {
                    btn_3.Visible = true;
                    check = true;
                }
                if (btn_4.Text == txtChu_9.Text && check == false && kiemtradem[3] == dem)
                {
                    btn_4.Visible = true;
                    check = true;
                }
                if (btn_5.Text == txtChu_9.Text && check == false && kiemtradem[4] == dem)
                {
                    btn_5.Visible = true;
                    check = true;
                }
                if (btn_6.Text == txtChu_9.Text && check == false && kiemtradem[5] == dem)
                {
                    btn_6.Visible = true;
                    check = true;
                }
                if (btn_7.Text == txtChu_9.Text && check == false && kiemtradem[6] == dem)
                {
                    btn_7.Visible = true;
                    check = true;
                }
                if (btn_8.Text == txtChu_9.Text && check == false && kiemtradem[7] == dem)
                {
                    btn_8.Visible = true;
                    check = true;
                }
                if (btn_9.Text == txtChu_9.Text && check == false && kiemtradem[8] == dem)
                {
                    btn_9.Visible = true;
                    check = true;
                }
                if (btn_10.Text == txtChu_9.Text && check == false && kiemtradem[9] == dem)
                {
                    btn_10.Visible = true;
                    check = true;
                }
                if (btn_11.Text == txtChu_9.Text && check == false && kiemtradem[10] == dem)
                {
                    btn_11.Visible = true;
                    check = true;
                }
                if (btn_12.Text == txtChu_9.Text && check == false && kiemtradem[11] == dem)
                {
                    btn_12.Visible = true;
                    check = true;
                }
                if (btn_13.Text == txtChu_9.Text && check == false && kiemtradem[12] == dem)
                {
                    btn_13.Visible = true;
                    check = true;
                }
                if (btn_14.Text == txtChu_9.Text && check == false && kiemtradem[13] == dem)
                {
                    btn_14.Visible = true;
                    check = true;
                }
                dem--;
                txtChu_9.Clear();
            }
        }

        private void txtChu_10_Click(object sender, EventArgs e)
        {
            if (txtChu_10.Text != "")
            {
                txt[dem] = "";
               
                bool check = false;
                if (btn_1.Text == txtChu_10.Text && check == false && kiemtradem[0] == dem)
                {
                    btn_1.Visible = true;
                    check = true;
                }
                if (btn_2.Text == txtChu_10.Text && check == false && kiemtradem[1] == dem)
                {
                    btn_2.Visible = true;
                    check = true;
                }
                if (btn_3.Text == txtChu_10.Text && check == false && kiemtradem[2] == dem)
                {
                    btn_3.Visible = true;
                    check = true;
                }
                if (btn_4.Text == txtChu_10.Text && check == false && kiemtradem[3] == dem)
                {
                    btn_4.Visible = true;
                    check = true;
                }
                if (btn_5.Text == txtChu_10.Text && check == false && kiemtradem[4] == dem)
                {
                    btn_5.Visible = true;
                    check = true;
                }
                if (btn_6.Text == txtChu_10.Text && check == false && kiemtradem[5] == dem)
                {
                    btn_6.Visible = true;
                    check = true;
                }
                if (btn_7.Text == txtChu_10.Text && check == false && kiemtradem[6] == dem)
                {
                    btn_7.Visible = true;
                    check = true;
                }
                if (btn_8.Text == txtChu_10.Text && check == false && kiemtradem[7] == dem)
                {
                    btn_8.Visible = true;
                    check = true;
                }
                if (btn_9.Text == txtChu_10.Text && check == false && kiemtradem[8] == dem)
                {
                    btn_9.Visible = true;
                    check = true;
                }
                if (btn_10.Text == txtChu_10.Text && check == false && kiemtradem[9] == dem)
                {
                    btn_10.Visible = true;
                    check = true;
                }
                if (btn_11.Text == txtChu_10.Text && check == false && kiemtradem[10] == dem)
                {
                    btn_11.Visible = true;
                    check = true;
                }
                if (btn_12.Text == txtChu_10.Text && check == false && kiemtradem[11] == dem)
                {
                    btn_12.Visible = true;
                    check = true;
                }
                if (btn_13.Text == txtChu_10.Text && check == false && kiemtradem[12] == dem)
                {
                    btn_13.Visible = true;
                    check = true;
                }
                if (btn_14.Text == txtChu_10.Text && check == false && kiemtradem[13] == dem)
                {
                    btn_14.Visible = true;
                    check = true;
                }
                dem--;
                txtChu_10.Clear();
            }
        }

        private void txtChu_11_Click(object sender, EventArgs e)
        {
            if (txtChu_11.Text != "")
            {
                txt[dem] = "";
               
                bool check = false;
                if (btn_1.Text == txtChu_11.Text && check == false && kiemtradem[0] == dem)
                {
                    btn_1.Visible = true;
                    check = true;
                }
                if (btn_2.Text == txtChu_11.Text && check == false && kiemtradem[1] == dem)
                {
                    btn_2.Visible = true;
                    check = true;
                }
                if (btn_3.Text == txtChu_11.Text && check == false && kiemtradem[2] == dem)
                {
                    btn_3.Visible = true;
                    check = true;
                }
                if (btn_4.Text == txtChu_11.Text && check == false && kiemtradem[3] == dem)
                {
                    btn_4.Visible = true;
                    check = true;
                }
                if (btn_5.Text == txtChu_11.Text && check == false && kiemtradem[4] == dem)
                {
                    btn_5.Visible = true;
                    check = true;
                }
                if (btn_6.Text == txtChu_11.Text && check == false && kiemtradem[5] == dem)
                {
                    btn_6.Visible = true;
                    check = true;
                }
                if (btn_7.Text == txtChu_11.Text && check == false && kiemtradem[6] == dem)
                {
                    btn_7.Visible = true;
                    check = true;
                }
                if (btn_8.Text == txtChu_11.Text && check == false && kiemtradem[7] == dem)
                {
                    btn_8.Visible = true;
                    check = true;
                }
                if (btn_9.Text == txtChu_11.Text && check == false && kiemtradem[8] == dem)
                {
                    btn_9.Visible = true;
                    check = true;
                }
                if (btn_10.Text == txtChu_11.Text && check == false && kiemtradem[9] == dem)
                {
                    btn_10.Visible = true;
                    check = true;
                }
                if (btn_11.Text == txtChu_11.Text && check == false && kiemtradem[10] == dem)
                {
                    btn_11.Visible = true;
                    check = true;
                }
                if (btn_12.Text == txtChu_11.Text && check == false && kiemtradem[11] == dem)
                {
                    btn_12.Visible = true;
                    check = true;
                }
                if (btn_13.Text == txtChu_11.Text && check == false && kiemtradem[12] == dem)
                {
                    btn_13.Visible = true;
                    check = true;
                }
                if (btn_14.Text == txtChu_11.Text && check == false && kiemtradem[13] == dem)
                {
                    btn_14.Visible = true;
                    check = true;
                }
                dem--;
                txtChu_11.Clear();
            }
        }

        private void txtChu_12_Click(object sender, EventArgs e)
        {
            if (txtChu_12.Text != "")
            {
                txt[dem] = "";
          
                bool check = false;
                if (btn_1.Text == txtChu_12.Text && check == false && kiemtradem[0] == dem)
                {
                    btn_1.Visible = true;
                    check = true;
                }
                if (btn_2.Text == txtChu_12.Text && check == false && kiemtradem[1] == dem)
                {
                    btn_2.Visible = true;
                    check = true;
                }
                if (btn_3.Text == txtChu_12.Text && check == false && kiemtradem[2] == dem)
                {
                    btn_3.Visible = true;
                    check = true;
                }
                if (btn_4.Text == txtChu_12.Text && check == false && kiemtradem[3] == dem)
                {
                    btn_4.Visible = true;
                    check = true;
                }
                if (btn_5.Text == txtChu_12.Text && check == false && kiemtradem[4] == dem)
                {
                    btn_5.Visible = true;
                    check = true;
                }
                if (btn_6.Text == txtChu_12.Text && check == false && kiemtradem[5] == dem)
                {
                    btn_6.Visible = true;
                    check = true;
                }
                if (btn_7.Text == txtChu_12.Text && check == false && kiemtradem[6] == dem)
                {
                    btn_7.Visible = true;
                    check = true;
                }
                if (btn_8.Text == txtChu_12.Text && check == false && kiemtradem[7] == dem)
                {
                    btn_8.Visible = true;
                    check = true;
                }
                if (btn_9.Text == txtChu_12.Text && check == false && kiemtradem[8] == dem)
                {
                    btn_9.Visible = true;
                    check = true;
                }
                if (btn_10.Text == txtChu_12.Text && check == false && kiemtradem[9] == dem)
                {
                    btn_10.Visible = true;
                    check = true;
                }
                if (btn_11.Text == txtChu_12.Text && check == false && kiemtradem[10] == dem)
                {
                    btn_11.Visible = true;
                    check = true;
                }
                if (btn_12.Text == txtChu_12.Text && check == false && kiemtradem[11] == dem)
                {
                    btn_12.Visible = true;
                    check = true;
                }
                if (btn_13.Text == txtChu_12.Text && check == false && kiemtradem[12] == dem)
                {
                    btn_13.Visible = true;
                    check = true;
                }
                if (btn_14.Text == txtChu_12.Text && check == false && kiemtradem[13] == dem)
                {
                    btn_14.Visible = true;
                    check = true;
                }
                dem--;
                txtChu_12.Clear();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn đã sẵn sàng thử thách chưa?", "hello><", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                btnStart.PerformClick();
                lblDiem.Text = "Điểm số: " + diem.ToString();
            }
            else
            {
                this.Close();
            }
        }
        
        private void btn_GoiY_Click(object sender, EventArgs e)
        {
            if (diem >= 6)
            {
                MessageBox.Show(goiy[index - 1], "hãy đọc kỹ gợi ý nhé, hihi!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                diem -= 5;
                lblDiem.Text = "Điểm số: " + diem.ToString();
            }
            else
            {
                MessageBox.Show("bạn chưa đủ điều kiện nhận gợi ý, hihi!", "?????", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void btnStart_MouseHover(object sender, EventArgs e)
        {
            this.btnStart.Font = new System.Drawing.Font("Brush Script MT", 24F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        }

        private void btnStart_MouseLeave(object sender, EventArgs e)
        {
            this.btnStart.Font = new System.Drawing.Font("Brush Script MT", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        }

        private void btn_GoiY_MouseHover(object sender, EventArgs e)
        {
            this.btn_GoiY.Font = new System.Drawing.Font("Brush Script MT", 24F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        }

        private void btn_GoiY_MouseLeave(object sender, EventArgs e)
        {
            this.btn_GoiY.Font = new System.Drawing.Font("Brush Script MT", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        }

        private void btnKiemTra_MouseHover(object sender, EventArgs e)
        {
            this.btnKiemTra.Font = new System.Drawing.Font("Brush Script MT", 19F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        }

        private void btnKiemTra_MouseLeave(object sender, EventArgs e)
        {
            this.btnKiemTra.Font = new System.Drawing.Font("Brush Script MT", 15F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        }

        private void label1_MouseHover(object sender, EventArgs e)
        {
            this.label1.Font = new System.Drawing.Font("Monotype Corsiva", 33.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        }

        private void label1_MouseLeave(object sender, EventArgs e)
        {
            this.label1.Font = new System.Drawing.Font("Monotype Corsiva", 27.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        }

    }
}
