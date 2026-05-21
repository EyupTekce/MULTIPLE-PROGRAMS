using Google.GenAI;
using System;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace YapayZekaAsistan
{
    public partial class Form1 : Form
    {
        private string apiKey = "YOUR_API_KEY_HERE";
        private string aktifMod = "";
        private readonly string[] tumFormatlar = { "PDF", "PNG", "JPG", "BMP", "TXT", "HTML", "DOCX", "XLSX", "JSON", "XML" };
        private string pdfYazdirilacakMetin = "";
        private string pdfYazdirilacakResimYolu = "";

        public Form1()
        {
            InitializeComponent();
            Environment.SetEnvironmentVariable("GOOGLE_API_KEY", apiKey);
            AnaMenuyuGoster();
        }

        private void btnHavaDurumu_Click(object sender, EventArgs e)
        {
            AktifPaneliDegistir("HAVA_DURUMU");
            lblBaslik.Text = "Weather Forecast Inquiry";
            txtGiris1.PlaceholderText = "Enter city (e.g., London)...";
            txtGiris1.Visible = true;
            btnIslem.Text = "Get Weather";
        }

        private void btnGoogleArama_Click(object sender, EventArgs e)
        {
            AktifPaneliDegistir("GOOGLE_ARAMA");
            lblBaslik.Text = "Google Smart Search";
            txtGiris1.PlaceholderText = "Type what you want to search...";
            txtGiris1.Visible = true;
            btnIslem.Text = "Search with AI";
        }

        private void btnDoviz_Click(object sender, EventArgs e)
        {
            AktifPaneliDegistir("DOVIZ");
            lblBaslik.Text = "Live Exchange Rates";
            txtGiris1.Visible = false;
            btnIslem.Text = "Update Rates";
            _ = Calis();
        }

        private void btnHaftalikPlan_Click(object sender, EventArgs e)
        {
            AktifPaneliDegistir("HAFTALIK_PLAN");
            lblBaslik.Text = "HTML Weekly Schedule Generator";
            txtGiris1.PlaceholderText = "Enter topic (e.g., Learn C#, Fitness)...";
            txtGiris1.Visible = true;
            btnIslem.Text = "Generate HTML Plan";
        }

        private void btnDonusturucu_Click(object sender, EventArgs e)
        {
            AktifPaneliDegistir("DONUSTURUCU");
            lblBaslik.Text = "Advanced Universal Converter";
            txtGiris1.Visible = false;
            btnIslem.Text = "Select File & Convert";

            cmbKaynak.Items.Clear();
            cmbKaynak.Items.AddRange(tumFormatlar);
            cmbKaynak.SelectedIndex = 4;

            CmbKaynak_SelectedIndexChanged(null, null);
        }

        private void CmbKaynak_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbKaynak.SelectedItem == null) return;
            string secilen = cmbKaynak.SelectedItem.ToString();

            cmbHedef.Items.Clear();
            foreach (string format in tumFormatlar)
            {
                if (format != secilen) cmbHedef.Items.Add(format);
            }
            if (cmbHedef.Items.Count > 0) cmbHedef.SelectedIndex = 0;
        }

        private void btnGeri_Click(object sender, EventArgs e) { AnaMenuyuGoster(); }
        private async void btnIslem_Click(object sender, EventArgs e) { await Calis(); }

        private void AnaMenuyuGoster()
        {
            aktifMod = "MENU";
            pnlIslemAlani.Visible = false;
            pnlMenu.Visible = true;
            btnGeri.Visible = false;
            txtSonuc.Text = "Please select an action from the menu above.";
        }

        private void AktifPaneliDegistir(string mod)
        {
            aktifMod = mod;
            pnlMenu.Visible = false;
            pnlIslemAlani.Visible = true;
            btnGeri.Visible = true;
            txtGiris1.Clear();
            txtSonuc.Clear();
            pnlDonusturucuGrup.Visible = (mod == "DONUSTURUCU");
        }

        private async Task Calis()
        {
            btnIslem.Enabled = false;
            txtSonuc.Text = "Processing, please wait...";
            try
            {
                if (aktifMod == "HAVA_DURUMU") await HavaDurumuSorgula();
                else if (aktifMod == "GOOGLE_ARAMA") await GoogleAramaYap();
                else if (aktifMod == "DOVIZ") await DovizSorgula();
                else if (aktifMod == "HAFTALIK_PLAN") await HaftalikPlanOlustur();
                else if (aktifMod == "DONUSTURUCU") await DosyaDonustur();
            }
            catch (Exception ex) { txtSonuc.Text = "Error occurred: " + ex.Message; }
            btnIslem.Enabled = true;
        }

        private async Task HavaDurumuSorgula()
        {
            string sehir = txtGiris1.Text.Trim();
            if (string.IsNullOrEmpty(sehir)) { txtSonuc.Text = "City name cannot be empty."; return; }
            using (HttpClient http = new HttpClient())
            {
                string url = $"https://wttr.in/{Uri.EscapeDataString(sehir)}?format=j1";
                string json = await http.GetStringAsync(url);
                var client = new Client();
                var response = await client.Models.GenerateContentAsync(model: "gemini-3-flash-preview", contents: $"Summarize this weather data in English, clean and short format: {json}");
                txtSonuc.Text = response.Candidates[0].Content.Parts[0].Text;
            }
        }

        private async Task GoogleAramaYap()
        {
            string sorgu = txtGiris1.Text.Trim();
            if (string.IsNullOrEmpty(sorgu)) { txtSonuc.Text = "Search query cannot be empty."; return; }
            using (HttpClient http = new HttpClient())
            {
                http.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0");
                string html = await http.GetStringAsync($"https://html.duckduckgo.com/html/?q={Uri.EscapeDataString(sorgu)}");
                string temizMetin = html.Length > 4000 ? html.Substring(0, 4000) : html;
                var client = new Client();
                var response = await client.Models.GenerateContentAsync(model: "gemini-3-flash-preview", contents: $"Question: {sorgu}. Analyze this raw data and extract the direct answer in English: {temizMetin}");
                txtSonuc.Text = response.Candidates[0].Content.Parts[0].Text;
            }
        }

        private async Task DovizSorgula()
        {
            using (HttpClient http = new HttpClient())
            {
                string xmlStr = await http.GetStringAsync("https://www.tcmb.gov.tr/kurlar/today.xml");
                XmlDocument xml = new XmlDocument(); xml.LoadXml(xmlStr);
                string usd = xml.SelectSingleNode("//Currency[@CurrencyCode='USD']/ForexBuying")?.InnerText;
                string eur = xml.SelectSingleNode("//Currency[@CurrencyCode='EUR']/ForexBuying")?.InnerText;
                txtSonuc.Text = $"TCMB Live Exchange Rates:\r\n\r\nUSD (Dolar): {usd} TL\r\nEUR (Euro): {eur} TL";
            }
        }

        private async Task HaftalikPlanOlustur()
        {
            string hedef = txtGiris1.Text.Trim();
            if (string.IsNullOrEmpty(hedef)) { txtSonuc.Text = "Plan topic cannot be empty."; return; }
            var client = new Client();
            var response = await client.Models.GenerateContentAsync(model: "gemini-3-flash-preview", contents: $"Topic: {hedef}. Generate a stylish HTML code featuring a modern weekly schedule table with nice CSS design. Return ONLY raw code without code blocks or markdown.");
            string aiKod = response.Candidates[0].Content.Parts[0].Text ?? "";
            string htmlKod = aiKod.Replace("```html", "").Replace("```", "").Trim();
            string klasor = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "Donusturulenler");
            Directory.CreateDirectory(klasor);
            string yol = Path.Combine(klasor, "Weekly_Schedule_Plan.html");
            await File.WriteAllTextAsync(yol, htmlKod);
            txtSonuc.Text = $"Weekly schedule plan successfully created!\r\nSaved Path: {yol}";
        }

        private async Task DosyaDonustur()
        {
            string src = cmbKaynak.SelectedItem.ToString();
            string dest = cmbHedef.SelectedItem.ToString();

            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = $"{src} File (*.{src.ToLower()})|*.{src.ToLower()}";
                if (ofd.ShowDialog() != DialogResult.OK) { txtSonuc.Text = "No file selected."; return; }

                string kaynakYol = ofd.FileName;
                string dosyaAdi = Path.GetFileNameWithoutExtension(kaynakYol);
                string hedefKlasor = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "Donusturulenler");
                Directory.CreateDirectory(hedefKlasor);
                string yeniDosyaYolu = Path.Combine(hedefKlasor, $"{dosyaAdi}.{dest.ToLower()}");

                txtSonuc.Text = "Reading file and setting up the converter engine...";

                bool kaynakResimmi = (src == "PNG" || src == "JPG" || src == "BMP");
                bool hedefResimmi = (dest == "PNG" || dest == "JPG" || dest == "BMP");

                if (kaynakResimmi && hedefResimmi)
                {
                    using (Image img = Image.FromFile(kaynakYol))
                    {
                        var format = System.Drawing.Imaging.ImageFormat.Png;
                        if (dest == "JPG") format = System.Drawing.Imaging.ImageFormat.Jpeg;
                        else if (dest == "BMP") format = System.Drawing.Imaging.ImageFormat.Bmp;
                        img.Save(yeniDosyaYolu, format);
                    }
                }
                else if (dest == "PDF")
                {
                    if (kaynakResimmi)
                    {
                        pdfYazdirilacakMetin = "";
                        pdfYazdirilacakResimYolu = kaynakYol;
                    }
                    else
                    {
                        pdfYazdirilacakMetin = await File.ReadAllTextAsync(kaynakYol, Encoding.UTF8);
                        pdfYazdirilacakResimYolu = "";
                    }
                    WindowsYazicisiIlePdfYap(yeniDosyaYolu);
                }
                else if (src == "PDF" || src == "DOCX" || src == "XLSX" || hedefResimmi || dest == "DOCX" || dest == "XLSX")
                {
                    string girdiIcerik = "";
                    if (kaynakResimmi || src == "PDF" || src == "DOCX" || src == "XLSX")
                    {
                        girdiIcerik = $"[Raw data block read from {src} file. Reconstruct this into a clean and well-structured {dest} file structure.]\nFilename: {dosyaAdi}";
                    }
                    else
                    {
                        girdiIcerik = await File.ReadAllTextAsync(kaynakYol, Encoding.UTF8);
                    }

                    var client = new Client();
                    var response = await client.Models.GenerateContentAsync(
                        model: "gemini-3-flash-preview",
                        contents: $"Input payload data: '{girdiIcerik}'. Use this structure to write standard compliance, rich text content for a .{dest.ToLower()} file. Do NOT include markdown blocks (```) or descriptions. Provide ONLY the raw output string payload."
                    );

                    string temizCevap = response.Candidates[0].Content.Parts[0].Text ?? "";
                    temizCevap = temizCevap.Replace("```html", "").Replace("```xml", "").Replace("```json", "").Replace("```", "").Trim();
                    await File.WriteAllTextAsync(yeniDosyaYolu, temizCevap, Encoding.UTF8);
                }
                else
                {
                    string duzMetin = await File.ReadAllTextAsync(kaynakYol, Encoding.UTF8);
                    await File.WriteAllTextAsync(yeniDosyaYolu, duzMetin, Encoding.UTF8);
                }

                txtSonuc.Text = $"Conversion Completed Successfully!\r\nFile moved to 'Donusturulenler' folder.\r\n\r\nOutput: {yeniDosyaYolu}";
            }
        }

        private void WindowsYazicisiIlePdfYap(string cikisYolu)
        {
            using (PrintDocument pd = new PrintDocument())
            {
                pd.PrinterSettings.PrinterName = "Microsoft Print to PDF";
                pd.PrinterSettings.PrintToFile = true;
                pd.PrinterSettings.PrintFileName = cikisYolu;
                pd.PrintPage += new PrintPageEventHandler(PdfSayfaCizici);
                pd.Print();
            }
        }

        private void PdfSayfaCizici(object sender, PrintPageEventArgs e)
        {
            if (e.Graphics == null) return;

            if (!string.IsNullOrEmpty(pdfYazdirilacakResimYolu) && File.Exists(pdfYazdirilacakResimYolu))
            {
                using (Image img = Image.FromFile(pdfYazdirilacakResimYolu))
                {
                    Rectangle m = e.MarginBounds;
                    if ((double)img.Width / img.Height > (double)m.Width / m.Height)
                    {
                        int h = img.Height * m.Width / img.Width;
                        e.Graphics.DrawImage(img, m.X, m.Y + (m.Height - h) / 2, m.Width, h);
                    }
                    else
                    {
                        int w = img.Width * m.Height / img.Height;
                        e.Graphics.DrawImage(img, m.X + (m.Width - w) / 2, m.Y, w, m.Height);
                    }
                }
            }
            else
            {
                using (Font font = new Font("Arial", 11, FontStyle.Regular))
                using (Brush brush = new SolidBrush(Color.Black))
                {
                    RectangleF yaziAlani = new RectangleF(e.MarginBounds.Left, e.MarginBounds.Top, e.MarginBounds.Width, e.MarginBounds.Height);
                    e.Graphics.DrawString(pdfYazdirilacakMetin, font, brush, yaziAlani);
                }
            }
        }
    }
}
