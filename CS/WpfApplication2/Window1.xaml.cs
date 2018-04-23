using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using DevExpress.Xpf.Grid;

namespace WpfApplication2 {

    public partial class Window1 : Window {
        List<TestData> list;

        public Window1() {
            InitializeComponent();

            list = new List<TestData>();
            for (int i = 0; i < 100; i++) {
                list.Add(new TestData() 
                { Text = Guid.NewGuid().ToString(), Number = i });
            }

            grid.DataSource = list;
        }

        private void autoSearch_TextChanged(object sender, 
            TextChangedEventArgs e) {
            for (int i = 0; i < list.Count; i++) {
                if (list[i].Text.StartsWith(autoSearch.Text)) {
                    view.MoveFocusedRow(grid.GetRowHandleByListIndex(i));
                    return;
                }
            }
        }
    }

    public class TestData {
        public string Text { get; set; }
        public int Number { get; set; }
    }

}
