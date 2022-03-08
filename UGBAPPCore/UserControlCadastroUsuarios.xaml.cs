﻿using APPTCCUGB.Context;
using APPTCCUGB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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

namespace APPTCCUGB
{
    /// <summary>
    /// Interação lógica para UserControlProviders.xam
    /// </summary>
    public partial class UserControlCadastroUsuarios : UserControl
    {
        AppDbContext dbSqlServer = new AppDbContext();
        public UserControlCadastroUsuarios()
        {
            InitializeComponent();
            bStatus.Content = string.Empty;
            bStatus.Visibility = Visibility.Collapsed;
            clearUsuario();
        }

        public UserControlCadastroUsuarios(Usuario usuario)
        {
            InitializeComponent();
            fillUsuario(usuario);
        }

        public void clearUsuario()
        {
            txtCodigo.Text = "0";
            txtNome.Text = string.Empty;
        }

        public void fillUsuario(Usuario usuario)
        {
            txtCodigo.Text = usuario.Id.ToString();
            txtNome.Text = usuario.Nome;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Usuario usuario = new Usuario();

            usuario.Id = int.Parse(txtCodigo.Text);
            usuario.Nome = txtNome.Text;

            dbSqlServer.Usuarios.Add(usuario);

            if (usuario.Id == 0)
                dbSqlServer.SaveChanges();
            else
            {
                dbSqlServer.Usuarios.Attach(usuario);
                dbSqlServer.Update(usuario);
                dbSqlServer.SaveChanges();
            }

            txtCodigo.Text = usuario.Id.ToString();

            bStatus.Content = "Cadastrado com sucesso!";
            bStatus.Visibility = Visibility.Visible;
        }
    }
}
