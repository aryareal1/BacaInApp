using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace BacaIn.Controls;

public partial class ManageBooks : UserControl
{
    public ManageBooks()
    {
        InitializeComponent();
    }
}

public sealed class BookRow
{
    [Key] public int Id { get; set; }
    public string Title { get; set; } = "";
    public string Author { get; set; } = "";
    public string? Isbn { get; set; }
    public string Publisher { get; set; } = "";
    public int? Year { get; set; }
    public int Copies { get; set; }
}