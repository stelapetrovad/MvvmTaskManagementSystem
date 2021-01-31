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

using MvvmTaskManagementSystem.Models;
using MvvmTaskManagementSystem.Commands;
using System.Collections.ObjectModel;
using MvvmTaskManagementSystem.ViewModels;
namespace MvvmTaskManagementSystem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        TaskViewModel ViewModel;
        public MainWindow()
        {
            InitializeComponent();
            ViewModel = new TaskViewModel();
            this.DataContext = ViewModel;
        }
    }
}
