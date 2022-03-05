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
    public partial class UserControlConsultaTurno : UserControl
    {
        AppDbContext dbSqlServer = new AppDbContext();
        string buscaturno = string.Empty;
        public UserControlConsultaTurno()
        {
            InitializeComponent();
        }

        private void bt_ConsultaTurno_Click(object sender, RoutedEventArgs e) => consultarTurno();

        public void consultarTurno()
        {
            buscaturno = txtUsuario.Text;
            dtgr_ConsultaTurno.ItemsSource = dbSqlServer.Turnos.Where(i => i.Nome.Contains(buscaturno)).ToList();
        }

        private void btEditarTurno_Click(object sender, RoutedEventArgs e)
        {
            Turno turno = new Turno();
            turno = dbSqlServer.Turnos.FirstOrDefault(i => i.Id.Equals(PegarCodigo()));
        }

        public int PegarCodigo()
        {
            var selectedItem = dtgr_ConsultaTurno.SelectedItem.ToString();
            Type t = dtgr_ConsultaTurno.SelectedItem.GetType();
            System.Reflection.PropertyInfo[] props = t.GetProperties();
            string propertyValue = props[0].GetValue(dtgr_ConsultaTurno.SelectedItem, null).ToString();
            return int.Parse(propertyValue);
        }

        private void btExcluirTurno_Click(object sender, RoutedEventArgs e)
        {
            Turno turno = (Turno)dtgr_ConsultaTurno.SelectedItem;
            dbSqlServer.Turnos.Attach(turno);
            dbSqlServer.Turnos.Remove(turno);
            dbSqlServer.SaveChanges();

            consultarTurno();
        }
    }
}
