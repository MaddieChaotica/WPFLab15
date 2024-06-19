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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPFLab15
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void generator_Click(object sender, RoutedEventArgs e)
        {

            //RandomNumberGenerator DOES NOT WORK WITH INT ANYMORE
            Randies.Clear();
            Random rnd = new Random();
            for (int i = 0; i < 10; i++)
            {
                Randies.Text = Randies.Text + " " + rnd.Next(0,10);
            }
           

        }

        private void generator2_Click(object sender, RoutedEventArgs e)
        {
            List<string> ABCs = new List<string> {"a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p" ,"q", "r", "s", "t", "u", "v", "w", "x", "y", "z"};

            Random rnd = new Random();
            letties.Clear();
            for (int i = 0; i < 10; i++)
            {
                letties.Text = letties.Text + " " + ABCs[rnd.Next(0, 26)];
            }

        }

        private void Encrypt_Click(object sender, RoutedEventArgs e)
        {
            string ssecretMessage = uEnc.Text;
            char[] secretMessage = ssecretMessage.ToLower().ToCharArray();
 
            char[] encryptedMessage = new char[secretMessage.Length];
            string kkey = Key.Text;
            char[] key = kkey.ToLower().ToCharArray();
            for (int i = 0, j = 0; i < secretMessage.Length; i++, j++)
            {
                if (secretMessage[i] == ' ')
                {
                    i++;
                }

                encryptedMessage[i] = Alphabet.alphabet[((Array.IndexOf(Alphabet.alphabet, key[j]) + Array.IndexOf(Alphabet.alphabet, secretMessage[i])) % 26)];
            }

            Enc.Text = new string(encryptedMessage);
        }
        static class Alphabet
        {
            public static char[] alphabet = new char[] { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
        }
    }
}
