using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GraveyardManager
{
    /// <summary>
    /// ResizeWindow
    /// This class is used to resize a window
    /// The user must catch the form closing event and retrieve the information from the local ResizeWindow variable
    /// </summary>
    public partial class ResizeWindow : Form
    {
        #region ResizeWindow Variables
        public Size sz_Resized;
        private int i_HeightOrig;       //the original height, used for the percentage calculations
        private int i_WidthOrig;        //the original width, used for the percentage calculations
        #endregion ResizeWindow Variables

        #region public ResizeWindow(Size sz)
        public ResizeWindow(Size sz)
        {
            InitializeComponent();
            sz_Resized = sz;        //set the public Size to the size passed to this class constructor
            i_HeightOrig = sz_Resized.Height;       //get the original height
            i_WidthOrig = sz_Resized.Width;     //get the original width
            txt_HeightPix.Text = sz_Resized.Height.ToString();      //set the text  of hte height input box
            txt_WidthPix.Text = sz_Resized.Width.ToString();        //set the text of the width input box
            txt_HeightPerc.Text = "100%";       //set the percent text box to 100% for the height
            txt_WidthPerc.Text = "100%";        //set the percent text box to 100% for the widht
            txt_HeightPix.TextChanged += Txt_HeightPix_TextChanged;     //assign the text changed event to the height pixel box
            txt_WidthPix.TextChanged += Txt_WidthPix_TextChanged;       //assign the text changed event to the width pixel box
            txt_HeightPerc.TextChanged += Txt_HeightPerc_TextChanged;       //assign the text changed event to the height percent box
            txt_WidthPerc.TextChanged += Txt_WidthPerc_TextChanged;         //assign the text changed event to the width percent box
        }
        #endregion public ResizeWindow(Size sz)

        #region private void txt_HeightPix_TextChanged(object sender, EventArgs e)
        /// <summary>
        /// Txt_HeightPix_TextChanged()
        /// This method will update the percentage and pixel text boxes if they are valid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Txt_HeightPix_TextChanged(object sender, EventArgs e)
        {
            //before processing make sure the text box is not empty
            if (txt_HeightPix.Text.Length <= 0)
                return;
            //please note that Util_UI.ParseOnlyInt will always return an int
            string s_NewText = Util_UI.ParseOnlyInt(txt_HeightPix);
            int i_NewPix = int.Parse(s_NewText);     //parse out the pixel to an int
            if(i_NewPix <= 0)
            {
                //then you cannot adjust the percentage, the user should be stopped and a ding should be played
                using (SoundPlayer sp_Bonk = new SoundPlayer("./audio/Windows Ding.wav"))
                {
                    sp_Bonk.Play();
                }
                return;
            }
            int i_NewPerc = (int)Math.Round((double)i_NewPix / (double)i_HeightOrig * 100);     //calculate the new percentage
            txt_HeightPerc.TextChanged -= Txt_HeightPerc_TextChanged;
            txt_HeightPix.TextChanged -= Txt_HeightPix_TextChanged;
            txt_HeightPix.Text = s_NewText;     //set the height new pixels
            txt_HeightPerc.Text = i_NewPerc.ToString() + "%";     //set the height new percentage
            txt_HeightPerc.TextChanged += Txt_HeightPerc_TextChanged;
            txt_HeightPix.TextChanged += Txt_HeightPix_TextChanged;
        }
        #endregion private void txt_HeightPix_TextChanged(object sender, EventArgs e)
        #region private void txt_WidthPix_TextChanged(object sender, EventArgs e)
        /// <summary>
        /// Txt_WidthPix_TextChanged()
        /// This method gets called whenever the text changes in the width text box
        /// The percentage and pixel text boxes get changed similtaneously
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Txt_WidthPix_TextChanged(object sender, EventArgs e)
        {
            if (txt_WidthPix.Text.Length <= 0)
                return;
            //please note that the Util_UI.ParseOnlyInt will always return an int
            string s_NewText = Util_UI.ParseOnlyInt(txt_WidthPix);
            int i_NewPix = int.Parse(s_NewText);        //parse out the pixel width to an int
            if(i_NewPix <= 0)
            {
                //then you cannot adjust the percent because of a divide by 0, the user should be stopped and ding should be played
                using (SoundPlayer sp_Bonk = new SoundPlayer("./audio/Windows Ding.wav"))
                    sp_Bonk.Play();
                return;
            }
            int i_NewPerc = (int)Math.Round((double)i_NewPix / (double)i_WidthOrig * 100);      //calculate the new percentage
            txt_WidthPix.TextChanged -= Txt_WidthPix_TextChanged;
            txt_WidthPerc.TextChanged -= Txt_WidthPerc_TextChanged;
            txt_WidthPix.Text = s_NewText;     //set the new text of the height pixels text box
            txt_WidthPerc.Text = i_NewPerc.ToString() + "%";      //set the new width of the percentage box
            txt_WidthPix.TextChanged += Txt_WidthPix_TextChanged;
            txt_WidthPerc.TextChanged += Txt_WidthPerc_TextChanged;
        }
        #endregion private void txt_WidthPix_TextChanged(object sender, EventArgs e)

        #region private void txt_HeightPerc_TextChanged(object sender, EventArgs e)
        /// <summary>
        /// txt_HeightPerc_TextChanged()
        /// This will get called whenever the pixel height text box changes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Txt_HeightPerc_TextChanged(object sender, EventArgs e)
        {

            //please note that Util_UI.ParseOnlyInt will always return an int, exclude the percentage from the function call
            string s_NewText = Util_UI.ParseOnlyInt(txt_HeightPerc, txt_HeightPerc.Text.Length - 1);        //get the new text, which will be used for calculating the new pixel value
            int i_Perc = int.Parse(s_NewText);      //parse the text so that the percentage is in an int so we can utilize it
            if(i_Perc <= 0)
            {
                //then the percentage is invalid, play a sound and return
                using (SoundPlayer sp_Bonk = new SoundPlayer("./audio/Windows Ding.wav"))
                    sp_Bonk.Play();
                return;
            }
            int i_NewHeight = (int)Math.Round((double)i_HeightOrig * (double)i_Perc / 100.0);       //calculate the new height
            txt_HeightPerc.TextChanged -= Txt_HeightPerc_TextChanged;       //unregister the text changes so I can make adjustments
            txt_HeightPix.TextChanged -= Txt_HeightPix_TextChanged;
            txt_HeightPerc.Text = s_NewText + "%";        //set the new parsed text, tack a percentage onto the end
            txt_HeightPix.Text = i_NewHeight.ToString();        //calculate the height pixel box
            txt_HeightPerc.TextChanged += Txt_HeightPerc_TextChanged;       //reregister the text change events
            txt_HeightPix.TextChanged += Txt_HeightPix_TextChanged;
        }
        #endregion private void txt_HeighPerc_TextChanged(object sender, EventArgs e)
        #region private void Txt_WidthPerc_TextChanged(object sender, EventArgs e)
        /// <summary>
        /// txt_WidthPerc_TextChanged()
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Txt_WidthPerc_TextChanged(object sender, EventArgs e)
        {
            //please note that Util_UI.ParseOnlyInt will always return an int, exclude the percentage from the function call
            string s_NewText = Util_UI.ParseOnlyInt(txt_HeightPerc, txt_HeightPerc.Text.Length - 1);      //get the new text, which will be used for calculating the new pixel value
            int i_Perc = int.Parse(s_NewText);      //parse the text so that the percentage is an int so we can utilize it
            if(i_Perc <= 0 )
            {
                //then the percentage is invalid, play a sound and return
                using (SoundPlayer sp_Bonk = new SoundPlayer("./audio/Windows Ding.wav"))
                    sp_Bonk.Play();
                return;
            }
            int i_NewWidth = (int)Math.Round((double)i_WidthOrig * (double)i_Perc / 100.0);     //calculate the new width
            txt_WidthPix.TextChanged -= Txt_WidthPix_TextChanged;       //unregister the text changed event so changes can manually be done
            txt_WidthPerc.TextChanged -= Txt_WidthPerc_TextChanged;
            txt_WidthPerc.Text = s_NewText + "%";       //set the new width parsed text, tack ap ercentage onto the end
            txt_WidthPix.Text = i_NewWidth.ToString();      //set the text of the width pixel box
            txt_WidthPix.TextChanged += Txt_WidthPix_TextChanged;       //register the text changed event so changes can manually be done
            txt_WidthPerc.TextChanged += Txt_WidthPerc_TextChanged;
        }
        #endregion private void Txt_WidthPerc_TextChanged(object sender, EventArgs e)

        #region private void btn_Resize_Click(object sender, EventArgs e)
        /// <summary>
        /// btn_Resize_Click()
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Resize_Click(object sender, EventArgs e)
        {
            //create a new size based on the text inside height and width
            sz_Resized = new Size(int.Parse(txt_WidthPix.Text), int.Parse(txt_HeightPix.Text));
            this.Close();       //close the window
        }
        #endregion private void btn_Resize_Click(object sender, EventArgs e)
    }
}
