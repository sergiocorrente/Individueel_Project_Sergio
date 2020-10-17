using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Individueel_Project_Sergio
{
    /// <summary>
    /// Interaction logic for Registratie.xaml
    /// </summary>
    public partial class Registratie : Window
    {
        public Registratie()
        {
            InitializeComponent();
            cmbGebruikerType.Items.Add("Beheerder");
            cmbGebruikerType.Items.Add("Verkoper");
            cmbGebruikerType.Items.Add("Magazinier");
        }

        private void btnToevoegen_Click(object sender, RoutedEventArgs e)
        {
            int roleID = 0;
            string hash = "Etnerr0c";
            string gebruiker = cmbGebruikerType.Text.ToString();
            switch (gebruiker)
            {
                case "Beheerder": roleID = 1; break;
                case "Verkoper": roleID = 2; break;
                case "Magazinier": roleID = 3; break;

                default:
                    break;
            }
            if (txtPasswoord.Password == txtConfPasswoord.Password && roleID != 0)
            {
                byte[] data = UTF8Encoding.UTF8.GetBytes(txtPasswoord.Password);
                using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
                {
                    byte[] keys = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(hash));
                    using (TripleDESCryptoServiceProvider tripDes = new TripleDESCryptoServiceProvider() { Key = keys, Mode = CipherMode.ECB, Padding = PaddingMode.PKCS7 }) 
                    {
                        ICryptoTransform transform = tripDes.CreateEncryptor();
                        Byte[] results = transform.TransformFinalBlock(data, 0, data.Length);
                        txtPasswoord.Password = Convert.ToBase64String(results, 0, results.Length);
                    }
                }
                using (MagazijnEntities ctx = new MagazijnEntities())
                {
                    ctx.PersoneelsIDs.Add(new PersoneelsID()
                    {
                        Voornaam = txtVoorNaam.Text,
                        Achternaam = txtAchterNaam.Text,
                        Username = txtGebruikeNaam.Text,
                        RoleID = roleID,
                        Wachtwoord = txtPasswoord.Password

                    });
                    ctx.SaveChanges();
                }
            }
            else
            {
                MessageBox.Show("Er is iets miss probeer opnieuw");
            }
        }
    }
}
