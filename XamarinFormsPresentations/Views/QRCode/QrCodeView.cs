﻿using System;
using Xamarin.Forms;
using ZXing.Net.Mobile.Forms;

namespace XamarinFormsPresentations
{
    class QrCodeView : ModelBoundContentView<QrCodeViewModel>
    {
        private Entry entry;
        private Button qrGeneratorButton;
        private StackLayout stackLayout;
        private ZXingBarcodeImageView barcode = new ZXingBarcodeImageView
        {
            HorizontalOptions = LayoutOptions.FillAndExpand,
            VerticalOptions = LayoutOptions.FillAndExpand,
            AutomationId = "zxingBarcodeImageView",
        };
        public QrCodeView()
        {
            barcode.BarcodeFormat = ZXing.BarcodeFormat.QR_CODE;
            barcode.BarcodeOptions.Width = 300;
            barcode.BarcodeOptions.Height = 300;
            barcode.BarcodeOptions.Margin = 10;
            barcode.BarcodeValue = "ZXing.Net.Mobile";
            #region label
            var label = new Label
            {
                Text = "QR Code Generator",
                HorizontalTextAlignment = TextAlignment.Center,
                FontSize = 25
            };
            #endregion

            #region entry
            entry = new Entry
            {
                Placeholder = "Insert Your code here",
                HorizontalTextAlignment = TextAlignment.Center
            };
            #endregion

            #region qr generator button
            qrGeneratorButton = new Button
            {
                Text = "Generate",
            };
            #endregion
            qrGeneratorButton.Clicked += Button_Clicked;

            stackLayout = new StackLayout
            {

                Children = {
                    label,
                    entry,
                    qrGeneratorButton
                },
                VerticalOptions = LayoutOptions.FillAndExpand
            };

            Content = stackLayout;
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            try
            {
                Xamarin.Forms.Device.BeginInvokeOnMainThread(() =>
                {
                    barcode = new ZXingBarcodeImageView
                    {
                        HorizontalOptions = LayoutOptions.FillAndExpand,
                        VerticalOptions = LayoutOptions.FillAndExpand,
                        AutomationId = "zxingBarcodeImageView",
                        BarcodeFormat = ZXing.BarcodeFormat.QR_CODE,
                        HeightRequest = 300,
                        WidthRequest = 300,
                        Margin = 10,
                        BarcodeValue = entry.Text
                    };
                 
                    stackLayout.Children.Clear();
                    stackLayout.Children.Add(barcode);
                });
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.ToString());
                //System.Diagnostics.Debug.WriteLine("Enter value that want to be carried in the QR Code");
                App.MasterPage.DisplayAlert("Alert", "Enter value that want to be carried in the QR Code", "OK");
            }
        }
    }
}