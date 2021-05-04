using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PrismSample.ViewModels
{
    using System.Collections.ObjectModel;
    public class ViewDViewModel : BindableBase
    {
        private ObservableCollection<string> _areas = new ObservableCollection<string>();
        public ObservableCollection<string> Areas
        {
            get { return _areas; }
            set { SetProperty(ref _areas, value); }
        }

        public ViewDViewModel(MainWindowViewModel mainWindowViewModel)
        {
            _areas.Add("神戸");
            _areas.Add("神奈川");
            _areas.Add("金沢");

            _products.Add(new Product() { Value = 10, DisplayValue = "パン" });
            _products.Add(new Product() { Value = 20, DisplayValue = "コーヒー牛乳" });
            _products.Add(new Product() { Value = 30, DisplayValue = "傘" });

            CloseButton = new DelegateCommand(CloseButtonExecute);
            ProductsSelectionChanged = new DelegateCommand<object[]>(ProductsSelectionChangedExecute);


            _mainWindowViewModel = mainWindowViewModel;
        }

        private ObservableCollection<Product> _products = new ObservableCollection<Product>();
        public ObservableCollection<Product> Products
        {
            get { return _products; }
            set { SetProperty(ref _products, value); }
        }

        public class Product
        {
            public int Value { get; set; }
            public string DisplayValue { get; set; }
        }

        private Product _selectedProduct = null;
        public Product SelectedProduct
        {
            get { return _selectedProduct; }
            set { SetProperty(ref _selectedProduct, value); }
        }

        public DelegateCommand CloseButton { get; }
        private void CloseButtonExecute()
        {
            var ret = SelectedProduct;
        }

        public DelegateCommand<object[]> ProductsSelectionChanged { get; }
        private void ProductsSelectionChangedExecute(object[] selectedItems)
        {
            var product = selectedItems.First() as Product;
            SelectedText = string.Format(@"{0}:{1}", product.Value, product.DisplayValue);

            _mainWindowViewModel.Title = SelectedText;

        }

        private string _selectedText = "";
        public string SelectedText
        {
            get { return _selectedText; }
            set { SetProperty(ref _selectedText, value); }
        }

        MainWindowViewModel _mainWindowViewModel;

    }
}
