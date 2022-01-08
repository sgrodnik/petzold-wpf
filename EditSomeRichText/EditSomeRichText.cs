using Microsoft.Win32;
using System;
using System.IO;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;

namespace Petzold.EditSomeRichText {
    internal class EditSomeRichText : Window {
        RichTextBox t;
        string filter = "Document Files(*.xaml)|*.xaml|A11 files(*.*)|*.*";
        [STAThread]
        public static void Main() { new Application().Run(new EditSomeRichText()); }
        public EditSomeRichText() {
            Title = $"({MethodBase.GetCurrentMethod().DeclaringType.Name} Title)";
            t = new RichTextBox();
            t.VerticalScrollBarVisibility = ScrollBarVisibility.Auto;
            Content = t;
            t.Focus();
        }
        protected override void OnPreviewTextInput(TextCompositionEventArgs e) {
            base.OnPreviewTextInput(e);
            if (e.ControlText.Length > 0 && e.ControlText[0] == '\x0F') {
                OpenFileDialog d = new OpenFileDialog();
                d.CheckFileExists = true;
                d.Filter = filter;
                if ((bool)d.ShowDialog(this)) {
                    FlowDocument flow = t.Document;
                    TextRange range = new TextRange(flow.ContentStart, flow.ContentEnd);
                    Stream stream = null;
                    try {
                        stream = new FileStream(d.FileName, FileMode.Open);
                        range.Load(stream, DataFormats.Xaml);
                    } catch (Exception ex) {
                        MessageBox.Show(ex.Message);
                    } finally {
                        if (stream != null) { stream.Close(); }
                    }
                    e.Handled = true;
                }
                if (e.ControlText.Length > 0 && e.ControlText[0] == '\x13') {
                    SaveFileDialog dlg = new SaveFileDialog();
                    dlg.FileName = filter;
                    if ((bool)dlg.ShowDialog(this)) {
                        FlowDocument flow = t.Document;
                        TextRange range = new TextRange(flow.ContentStart, flow.ContentEnd);
                        Stream stream = null;
                        try {
                            stream = new FileStream(dlg.FileName, FileMode.Create);
                            range.Save(stream, DataFormats.Xaml);
                        } catch (Exception ex) {
                            MessageBox.Show(ex.Message);
                        } finally { 
                            if (stream != null) { stream.Close(); }
                        }
                    }
                    e.Handled= true;
                }
            }
        }
    }
}
