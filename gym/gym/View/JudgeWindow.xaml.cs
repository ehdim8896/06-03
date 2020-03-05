﻿using gym.Models;
using gym.Models.Enums;
using gym.Util;
using gym.ViewModel;
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
using System.Windows.Shapes;

namespace gym.View
{
    /// <summary>
    /// Interaction logic for JudgeWindow.xaml
    /// </summary>
    public partial class JudgeWindow : Window
    {
        JudgeViewModel _judgeView;
        public JudgeWindow()
        {
            InitializeComponent();
            _judgeView = new JudgeViewModel();
            this.DataContext = _judgeView;
        }
    }
}
