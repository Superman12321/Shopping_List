using System.ComponentModel;

public class Product : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler PropertyChanged;

    private int _quantityProduct;
    public int QuantityProduct
    {
        get { return _quantityProduct; }
        set
        {
            _quantityProduct = value;
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs("QuantityProduct"));
            }
        }
    }

    public string ProductName { get; set; }
    public string QuantityCategory { get; set; }
    public bool IsOptimal { get; set; }

    private bool _isChecked;
    public bool IsChecked
    {
        get { return _isChecked; }
        set
        {
            _isChecked = value;
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs("IsChecked"));
            }
        }
    }
}
